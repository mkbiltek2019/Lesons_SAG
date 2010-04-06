using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MDIExample
{
    public static class TextDocumentSaver
    {
        private static void Save(TextDocument doc)
        {
            try
            {
                TextWriter textWriter = new StreamWriter(doc.Location, false, doc.TextEncoding);
                textWriter.Write(doc.Text);
                textWriter.Close();

                doc.isSaved = true;
            }
            catch
            {
                MessageBox.Show("Ошибка сохранения файла!", "MDI Sample", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void SaveFileAs(TextDocument doc)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                CheckPathExists = true,
                ValidateNames = true,
                AddExtension = true,
                Title = "Save File - MDI Sample",
                Filter = "Text files (*.txt)|*.txt"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                doc.Location = sfd.FileName;
                TextDocumentSaver.Save(doc);
            }
        }

        public static void SaveFile(TextDocument doc)
        {
            if (doc.Location != String.Empty) Save(doc);
            else SaveFileAs(doc);
        }

        public static void SaveFileInEncoding(TextDocument doc, Encoding encoding)
        {
            doc.TextEncoding = encoding;
            SaveFile(doc);
        }
    }
}
