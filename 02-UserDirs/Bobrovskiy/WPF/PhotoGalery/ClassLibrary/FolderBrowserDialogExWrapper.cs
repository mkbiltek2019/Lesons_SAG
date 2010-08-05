namespace ClassLibrary
{
    using System.Windows.Forms;

    public class FolderBrowserDialogExWrapper
    {
        private string _folderName = @"c:\";

        public string GetFolderPath()
        {
            _folderName = (System.IO.Directory.Exists(_folderName)) ? _folderName : "";

            Ionic.Utils.FolderBrowserDialogEx folderBrowserDialogEx =
                                     new Ionic.Utils.FolderBrowserDialogEx
            {
                Description = "Select a folder:",
                ShowNewFolderButton = true,
                ShowEditBox = true,
                //NewStyle = false,
                SelectedPath = _folderName,
                ShowFullPathInEditBox = false
            };

            folderBrowserDialogEx.RootFolder = System.Environment.SpecialFolder.MyComputer;

            DialogResult result = folderBrowserDialogEx.ShowDialog();

            if (result == DialogResult.OK)
            {
                return folderBrowserDialogEx.SelectedPath;
            }

            return string.Empty;
        }
    }
}
