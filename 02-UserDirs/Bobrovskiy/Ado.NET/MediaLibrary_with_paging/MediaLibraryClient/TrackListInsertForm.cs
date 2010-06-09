using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using MediaLibrary.Business;
using MediaLibrary.ValidationRules;
using System.Resources;
using System.Reflection;

namespace MediaLibraryClient
{
    public partial class TrackListInsertForm : Form
    {
        private TrackList CurrentTrackList
        {
            get;
            set;
        }
        private ResourceManager resourceManager;
        private List<string> selectedDataGridViewItem = null;
        
        public TrackListInsertForm()
        {
            InitializeComponent();
            CurrentTrackList = new TrackList();
            resourceManager =
                new ResourceManager("MediaLibraryClient.Properties.Resources",
                                     Assembly.GetExecutingAssembly()); 
        }

        public TrackListInsertForm(List<string> cellList)
        {
            InitializeComponent();
            CurrentTrackList = new TrackList();
            resourceManager =
                new ResourceManager("MediaLibraryClient.Properties.Resources", 
                                     Assembly.GetExecutingAssembly());
            selectedDataGridViewItem = cellList;
            trackListNameTextBox.Text = selectedDataGridViewItem[1];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedDataGridViewItem != null)
                {
                    if (selectedDataGridViewItem.Count > 0)
                    {
                        TrackList trackList = new TrackList()
                        {
                            ID = int.Parse(selectedDataGridViewItem[0]),
                            Name = trackListNameTextBox.Text
                        };
                        trackList.Save();
                    }
                }
                else
                {
                    TrackList trackList = new TrackList()
                    {
                        Name = trackListNameTextBox.Text
                    };
                    trackList.Save();
                }
            
        }

        private void trackListNameTextBox_Validating(object sender, CancelEventArgs e)
        {
            IValidator vadidatorForTrackList = new TrackListValidator();
            string validationErrorKey = vadidatorForTrackList.ValidateMember(CurrentTrackList, "Name");

            if (string.IsNullOrEmpty(validationErrorKey))
            {   
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false; 
            }

            errorProvider.SetError(sender as Control,
                                    resourceManager.GetString(validationErrorKey));
            
        }

        private void InitializeCurrentTrackList()
        {
            CurrentTrackList.Name = trackListNameTextBox.Text;
        }

        private void trackListNameTextBox_Validated(object sender, EventArgs e)
        {
            //errorProvider.SetError(sender as Control, string.Empty);
        }

    }
}