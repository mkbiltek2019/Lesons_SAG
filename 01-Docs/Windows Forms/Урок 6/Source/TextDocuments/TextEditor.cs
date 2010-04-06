using System;
using System.Text;
using System.Windows.Forms;

namespace MDIExample
{
    public partial class TextEditor : ChildForm
    {
        private TextDocument document;

        public TextEditor() 
        {
            InitializeComponent();

            document = new TextDocument();
            document.TextChanged += new EventHandler(document_TextChanged);
        }

        void document_TextChanged(object sender, EventArgs e)
        {
            if (tbxText.Text != document.Text) tbxText.Text = document.Text;
        }

        private void tbxText_TextChanged(object sender, EventArgs e)
        {
            if (tbxText.Text != document.Text) document.Text = tbxText.Text;
        }

        private void ContentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!document.IsSaved)
            {
                DialogResult dr = MessageBox.Show("Сохранить файл?", "Файл не сохранен!", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                switch (dr)
                {
                    case DialogResult.Yes: TextDocumentSaver.SaveFile(document); break;
                    case DialogResult.No: break;
                    case DialogResult.Cancel: e.Cancel = true; break;
                }
            }
        }

        override public DialogResult OpenFile() { return TextDocumentLoader.OpenFile(document); }

        override public void SaveFile() { TextDocumentSaver.SaveFile(document); }
        override public void SaveFileAs() { TextDocumentSaver.SaveFileAs(document); }


        #region Menu Edit

        private void tsmiUndo_Click(object sender, EventArgs e)
        {
            this.tbxText.Undo();
        }

        private void tsmiCut_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(this.tbxText.SelectedText);
            this.tbxText.SelectedText = String.Empty;
        }

        private void tsmiCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(this.tbxText.SelectedText);
        }

        private void tsmiPaste_Click(object sender, EventArgs e)
        {
            IDataObject data = Clipboard.GetDataObject();

            if (data.GetDataPresent(DataFormats.Text))
            {
                this.tbxText.SelectedText = data.GetData(DataFormats.Text).ToString();
            }
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            this.tbxText.SelectedText = String.Empty;
        }

        private void tsmiSelectAll_Click(object sender, EventArgs e)
        {
            this.tbxText.SelectAll();
        }

        private void tsmiTime_Click(object sender, EventArgs e)
        {
            this.tbxText.SelectedText = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
        }

        #endregion


        #region OpenFileInEncoding

        private void tsmiOpenAsWindow1251_Click(object sender, EventArgs e)
        {
            TextDocumentLoader.ReloadFile(this.document, Encoding.GetEncoding(1251));
        }

        private void tsmiOpenAsDOS866_Click(object sender, EventArgs e)
        {
            TextDocumentLoader.ReloadFile(this.document, Encoding.GetEncoding(866));
        }

        private void tsmiOpenAsКОИ8Р_Click(object sender, EventArgs e)
        {
            TextDocumentLoader.ReloadFile(this.document, Encoding.GetEncoding("KOI8-R"));
        }

        private void tsmiOpenAsКОИ8U_Click(object sender, EventArgs e)
        {
            TextDocumentLoader.ReloadFile(this.document, Encoding.GetEncoding("KOI8-U"));
        }

        private void tsmiOpenAsLittleEndian_Click(object sender, EventArgs e)
        {
            TextDocumentLoader.ReloadFile(this.document, Encoding.Unicode);
        }

        private void tsmiOpenAsBigEndian_Click(object sender, EventArgs e)
        {
            TextDocumentLoader.ReloadFile(this.document, Encoding.BigEndianUnicode);
        }

        private void tsmiOpenAsUTF8_Click(object sender, EventArgs e)
        {
            TextDocumentLoader.ReloadFile(this.document, Encoding.UTF8);
        }

        #endregion


        #region SaveFileInEncoding

        private void tsmiSaveAsWindows1251_Click(object sender, EventArgs e)
        {
            TextDocumentSaver.SaveFileInEncoding(document, Encoding.GetEncoding(1251));
        }

        private void tsmiSaveAsDOS866_Click(object sender, EventArgs e)
        {
            TextDocumentSaver.SaveFileInEncoding(document, Encoding.GetEncoding(866));
        }

        private void tsmiSaveAsКОИ8Р_Click(object sender, EventArgs e)
        {
            TextDocumentSaver.SaveFileInEncoding(document, Encoding.GetEncoding("KOI8-R"));
        }

        private void tsmiSaveAsКОИ8U_Click(object sender, EventArgs e)
        {
            TextDocumentSaver.SaveFileInEncoding(document, Encoding.GetEncoding("KOI8-U"));
        }

        private void tsmiSaveAsLittleEndian_Click(object sender, EventArgs e)
        {
            TextDocumentSaver.SaveFileInEncoding(document, Encoding.Unicode);
        }

        private void tsmiSaveAsBigEndian_Click(object sender, EventArgs e)
        {
            TextDocumentSaver.SaveFileInEncoding(document, Encoding.BigEndianUnicode);
        }

        private void tsmiSaveAsUTF8_Click(object sender, EventArgs e)
        {
            TextDocumentSaver.SaveFileInEncoding(document, Encoding.UTF8);
        }

        #endregion


    }
}
