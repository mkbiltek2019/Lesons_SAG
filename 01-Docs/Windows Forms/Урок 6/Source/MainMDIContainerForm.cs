using System;
using System.Windows.Forms;

namespace MDIExample
{
    public partial class MainMDIContainerForm : Form
    {
        public MainMDIContainerForm() { InitializeComponent(); }

        # region Menu File  // Обработчики нажатий кнопок меню

        private void tsmiNewTextFile_Click(object sender, EventArgs e)
        {
            TextEditor textEditor = new TextEditor() { MdiParent = this };
            textEditor.Show();
        }

        private void tsmiNewRichTextFile_Click(object sender, EventArgs e)
        {
            RichTextSource sourceEditor = new RichTextSource() { MdiParent = this };
            RichTextEditor rtfEditor = new RichTextEditor() { MdiParent = this, SourceViewer = sourceEditor };
            sourceEditor.Show();
            rtfEditor.Show();
        }

        private void tsmiOpenTextFile_Click(object sender, EventArgs e)
        {
            TextEditor cf = new TextEditor() { MdiParent = this };
            if (cf.OpenFile() == DialogResult.OK) cf.Show();
        }

        private void tsmiOpenRichTextFile_Click(object sender, EventArgs e)
        {
            RichTextSource sourceEditor = new RichTextSource() { MdiParent = this };
            RichTextEditor rtfEditor = new RichTextEditor() { MdiParent = this, SourceViewer = sourceEditor };

            if (rtfEditor.OpenFile() == DialogResult.OK)
            {
                sourceEditor.Show();
                rtfEditor.Show();
            }
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            Form cf = this.ActiveMdiChild;
            if (cf != null) ((ChildForm)cf).SaveFile();
        }

        private void tsmiSaveAs_Click(object sender, EventArgs e)
        {
            Form cf = this.ActiveMdiChild;
            if (cf != null) ((ChildForm)cf).SaveFileAs();
        }

        private void tsmiSaveAll_Click(object sender, EventArgs e)
        {
            Form[] forms = this.MdiChildren;
            foreach (ChildForm cf in forms) cf.SaveFile();
        }

        private void tsmiClose_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null) this.ActiveMdiChild.Close();
        }

        private void tsmiCloseAll_Click(object sender, EventArgs e)
        {
            foreach (Form fm in this.MdiChildren) fm.Close();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion


        #region Menu Layout

        // Расположить окна каскадом
        private void tsmiCascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }

        // Упорядочить
        private void tsmiArrangeIcons_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.ArrangeIcons);
        }

        // Окна черепицей сверху вниз
        private void tsmiTileHorizontal_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
        }

        // Окна черепицей слева направо
        private void tsmiTileVertical_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
        }

        // Минимизировать все окна
        private void tsmiMinimazeAll_Click(object sender, EventArgs e)
        {
            // получаем все дочерние формы 
            Form[] forms = this.MdiChildren;

            // каждое дочернее окно минимизируем
            foreach (Form cf in forms) cf.WindowState = FormWindowState.Minimized;
        }

        // Максимизируем все окна
        private void tsmiMaximizeAll_Click(object sender, EventArgs e)
        {
            Form[] forms = this.MdiChildren;
            foreach (Form cf in forms) cf.WindowState = FormWindowState.Maximized;
        }

        #endregion

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm() { MdiParent = this };
            aboutForm.Show();
        }
    }
}
