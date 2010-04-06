using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace MDIExample
{
    public partial class RichTextEditor : ChildForm
    {
        private RichTextDocument document;

        private RichTextSource sourceViewer;
        public RichTextSource SourceViewer
        {
            get { return sourceViewer; }
            set { sourceViewer = value; }
        }

        public RichTextEditor()
        {
            InitializeComponent();

            document = new RichTextDocument();
            document.TextChanged += new EventHandler(document_TextChanged);
        }

        void document_TextChanged(object sender, EventArgs e)
        {
            if (rtb.Rtf != document.Text)
            {
                rtb.Rtf = document.Text;
                sourceViewer.tbx.Text = document.Text;
            }
        }

        private void rtb_TextChanged(object sender, EventArgs e)
        {
            if (rtb.Rtf != document.Text)
            {
                document.Text = rtb.Rtf;
                sourceViewer.tbx.Text = rtb.Rtf;
            }
        }

        override public DialogResult OpenFile() { return RichTextDocumentLoader.OpenFile(document); }

        override public void SaveFile() { RichTextDocumentSaver.SaveFile(document); }
        override public void SaveFileAs() { RichTextDocumentSaver.SaveFileAs(document); }


        #region Menu Edit
        private void tsmiUndo_Click(object sender, EventArgs e)
        {
            this.rtb.Undo();
        }

        private void tsmiRedo_Click(object sender, EventArgs e)
        {
            this.rtb.Redo();
        }

        private void tsmiCut_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(this.rtb.SelectedText);
            this.rtb.SelectedText = String.Empty;
        }

        private void tsmiCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(rtb.SelectedText);
        }

        private void tsmiPaste_Click(object sender, EventArgs e)
        {
            IDataObject data = Clipboard.GetDataObject();

            if (data.GetDataPresent(DataFormats.Text))
                rtb.SelectedText = data.GetData(DataFormats.Text).ToString();
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            rtb.SelectedText = String.Empty;
        }

        private void tsmiSelectAll_Click(object sender, EventArgs e)
        {
            rtb.SelectAll();
        }

        private void tsmiDate_Click(object sender, EventArgs e)
        {
            rtb.SelectedText = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
        }
        #endregion

        #region Menu Format

        private void tsmiWordWrap_Click(object sender, EventArgs e)
        {
            this.rtb.WordWrap = ((ToolStripMenuItem)sender).Checked;
        }

        private void tsmiFont_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowDialog();
            rtb.SelectionFont = fontDialog.Font;
        }

        private void tsmiColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();
            rtb.SelectionColor = colorDialog.Color;
        }

        #endregion

        #region Menu Print
        private void tsmiPrint__Click(object sender, EventArgs e)
        {
            PrintDocument();
        }

        private void PrintDocument()
        {
            PrintDialog printDialog = new PrintDialog();
            DialogResult dr = printDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                PrintDocument doc = new PrintDocument();
                doc.PrinterSettings.PrinterName = printDialog.PrinterSettings.PrinterName;
                doc.PrintPage += new PrintPageEventHandler(CreatePage);
                doc.Print();


            }      
        }

        private void PrintPreview()
        {
            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += new PrintPageEventHandler(CreatePage);
            previewDialog.Document = doc;
            previewDialog.Show();
        }

        private void CreatePage(object sender, PrintPageEventArgs ppeArgs)
        {
            SolidBrush br = new SolidBrush(System.Drawing.SystemColors.ControlText);
            ppeArgs.Graphics.DrawString(rtb.Text, rtb.SelectionFont, br, 20, 10);
        }

        private void tsmiPrintPreview_Click(object sender, EventArgs e)
        {
            PrintPreview();
        }

        #endregion



        private void RichTextEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!document.IsSaved)
            {
                DialogResult dr = MessageBox.Show("Сохранить файл?", "Файл не сохранен!", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                switch (dr)
                {
                    case DialogResult.Yes: RichTextDocumentSaver.SaveFile(document); break;
                    case DialogResult.No: break;
                    case DialogResult.Cancel: e.Cancel = true; break;
                }
            }
        }

        private void tbx_TextChanged(object sender, EventArgs e)
        {
            sourceViewer.tbx.Text = this.rtb.Rtf;
        }

        private void tspPrint_Click(object sender, EventArgs e)
        {
            PrintDocument();
        }

        private void tsbOpen_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void tsbPreview_Click(object sender, EventArgs e)
        {
            PrintPreview();
        }

        private void tsbCut_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(this.rtb.SelectedText);
            this.rtb.SelectedText = String.Empty;
        }

        private void tsbCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(rtb.SelectedText);
        }

        private void tsbPaste_Click(object sender, EventArgs e)
        {
            IDataObject data = Clipboard.GetDataObject();

            if (data.GetDataPresent(DataFormats.Text))
                rtb.SelectedText = data.GetData(DataFormats.Text).ToString();
        }

        private void tsbUndo_Click(object sender, EventArgs e)
        {
            this.rtb.Undo();
        }

        private void tsbRedo_Click(object sender, EventArgs e)
        {
            this.rtb.Redo();
        }
    }
}
