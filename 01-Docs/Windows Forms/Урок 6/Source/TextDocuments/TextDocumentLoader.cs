using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MDIExample
{
    public static class TextDocumentLoader
    {
        public static DialogResult OpenFile(TextDocument doc)
        {
            OpenFileDialog ofg = new OpenFileDialog()
            {
                CheckFileExists = true,
                CheckPathExists = true,
                ValidateNames = true,
                Title = "Open File - MDI Sample",
                Filter = "Text files (*.txt)|*.txt"
            };

            if (ofg.ShowDialog() == DialogResult.OK)
            {
                doc.Location = ofg.FileName;

                try
                {
                    TextReader textReader = new StreamReader(doc.Location, doc.TextEncoding, true);
                    doc.Text = textReader.ReadToEnd();
                    textReader.Close();

                    return DialogResult.OK;
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Ошибка открытия файла!/n" + exception.Message, "MDI Sample", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return DialogResult.Cancel;
        }

        private static void ReloadFile(TextDocument doc)
        {
            try
            {
                TextReader textReader = new StreamReader(doc.Location, doc.TextEncoding, true);
                doc.Text = textReader.ReadToEnd();
                textReader.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Ошибка открытия файла!/n" + exception.Message, "MDI Sample", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void ReloadFile(TextDocument doc, Encoding encoding)
        {
            doc.TextEncoding = encoding;

            if (doc.Location != String.Empty) ReloadFile(doc);
            else OpenFile(doc);
        }

    }
}
