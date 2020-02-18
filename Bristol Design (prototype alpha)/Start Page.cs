using Bristol_Design__prototype_alpha_alpha_;
using System;
using System.Windows.Forms;

namespace Bristol_Design__prototype_alpha_
{
    public partial class Start_Page : Form
    {

        public Start_Page()
        {
            InitializeComponent();
        }

        private void b_placeholderLaunch_Click(object sender, EventArgs e)
        {
            // Create and name the form
            tsb_ designerForm = new tsb_();
            designerForm.fileName = "Untitled Bristol Board";

            // Open the new form
            designerForm.Show();

            // Close this form
            designerForm.StartPageRef = this;
            designerForm.Focus();
            Visible = false;

            // Close when the user exits to form
            designerForm.FormClosed += DesignerForm_FormClosed;
        }

        private void DesignerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!Visible)
                Close();
        }
    }
}
