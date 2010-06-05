using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MediaLibrary.Business;
using MediaLibrary.ValidationRules;
using System.Resources;
using System.Reflection;

namespace MediaLibraryClient
{
    public partial class TrackListInsertForm : Form
    {
        TrackList CurrentTrackList
        {
            get;
            set;
        }
        ResourceManager resourceManager;

        public TrackListInsertForm()
        {
            InitializeComponent();
            CurrentTrackList = new TrackList();
            resourceManager =
                new ResourceManager("MediaLibraryClient.Properties.Resources", Assembly.GetExecutingAssembly()); 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TrackList trackList = new TrackList()
            {
                Name = trackListNameTextBox.Text
            };

            trackList.Save();
        }

        private void trackListNameTextBox_Validating(object sender, CancelEventArgs e)
        {
            IValidator vadidatorForTrackList = new TrackListValidator();
            string validationErrorKey = vadidatorForTrackList.ValidateMember(CurrentTrackList, "Name");

            if(!string.IsNullOrEmpty(validationErrorKey))
                errorProvider.SetError(trackListNameTextBox, resourceManager.GetString(validationErrorKey));
        }

        private void InitializeCurrentTrackList()
        {
            CurrentTrackList.Name = trackListNameTextBox.Text;
        }
    }
}