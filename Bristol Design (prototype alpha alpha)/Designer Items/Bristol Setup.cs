using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bristol_Design.Designer_Forms
{
    public partial class Bristol_Setup : Form
    {
        // Bristol board type
        string bbType;
        // Size variables
        decimal width;
        decimal height;
        string units;

        public Bristol_Setup(string _bbType, decimal _width, decimal _height, string _units)
        {
            InitializeComponent();

            // Load in the values
            bbType = _bbType;
            width = _width;
            height = _height;
            units = _units;

            // Display the values
            List<ComboBox> lstDDL = new List<ComboBox>();
            GetControlsRecursiveWin<ComboBox>(Controls, lstDDL);
            switch (cmbb_boardType.Text) // Set the board type text
            {
                case "trif":
                    lstDDL[0].SelectedIndex = 1;
                    break;
                case "fltb":
                    lstDDL[0].SelectedIndex = 0;
                    break;
            }
            nud_height.Value = height;
            nud_width.Value = width;
            switch (cmbb_units.Text) // Set board size units
            {
                case "cm":
                    lstDDL[1].SelectedIndex = 1;
                    break;
                case "in":
                    lstDDL[1].SelectedIndex = 0;
                    break;
            }
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            switch (cmbb_boardType.Text) // Set the board type text
            {
                case "Tri-fold":
                    bbType = "trif";
                    break;
                case "Normal Flat Bristol Board":
                    bbType = "fltb";
                    break;
            }

            switch (cmbb_units.Text) // Set board size units
            {
                case "Cm.":
                    units = "cm";
                    break;
                case "In.":
                    units = "in";
                    break;
            }

            height = nud_height.Value; // Set board length

            width = nud_width.Value; // Set board width
        }

        public static void GetControlsRecursiveWin<T>(Control.ControlCollection controlCollection, List<T> resultCollection) where T : System.Windows.Forms.Control
        {
            foreach (Control control in controlCollection)
            {
                if (control is T)
                    resultCollection.Add((T)control);

                if (control.HasChildren)
                    GetControlsRecursiveWin(control.Controls, resultCollection);
            }
        }
    }
}
