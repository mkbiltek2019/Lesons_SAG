namespace ClassLibrary
{  
    using System.Windows.Forms;

    public class BrowserWrapper
    {
        public string GetFolderPath()
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                //dlg.Description = Description;
                //dlg.SelectedPath = MediaTypeNames.Text;
                dlg.ShowNewFolderButton = true;
                DialogResult result = dlg.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    return dlg.SelectedPath;
                    //BindingExpression be = GetBindingExpression(TextProperty);
                    //if (be != null)
                    //    be.UpdateSource();
                }
            }

            return string.Empty;
        }
    }
}
