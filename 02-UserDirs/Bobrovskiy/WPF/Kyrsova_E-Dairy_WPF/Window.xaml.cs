using System;
using System.Windows;
using System.Windows.Media.Animation;
using Fluent;
using Mvvm.ViewModels;
using Windows_With_CUBE;

namespace EDairy
{
    /// <summary>
    /// Represents the main window of the application
    /// </summary>
    public partial class Window : RibbonWindow
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Window()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        #region   cube

        private void OnLoaded(object sender, EventArgs e)
        {
            // setup trackball for moving the model around
            _trackball = new Trackball();
            _trackball.Attach(this);
            _trackball.Slaves.Add(myViewport3D);
            _trackball.Enabled = true;

        }

        #region Globals

        Trackball _trackball;

        #endregion

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            Storyboard s;

            s = (Storyboard)this.FindResource("RotateStoryboard");
            this.BeginStoryboard(s);
        }
        #endregion
    }
}