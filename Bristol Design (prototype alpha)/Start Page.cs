using Bristol_Design;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bristol_Design__prototype_alpha_
{
    public partial class Start_Page : Form
    {
        bool formShown = true;

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

            formShown = false;

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
