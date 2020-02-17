using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bristol_Design.Designer_Items
{
    public class Textbox_Properties
    {
        int projectItemID;
        public TextBox projectTextbox;
        private Panel selectedPanel;
        public Textbox_Properties(TextBox textBox, int textBoxId)
        {
            projectTextbox = textBox;
            textBox.MouseDown += TextBox_MouseDown;
            textBox.MouseUp += TextBox_MouseUp;
            textBox.MouseMove += TextBox_MouseMove;
            textBox.MouseClick += TextBox_MouseClick;
            mouseDown = true;
            textBox.Enabled = true;
            textBox.Focus();
            textBox.Name = "bo_textBox-" + projectItemID;
            textBox.TextChanged += TextBox_TextChanged;
            projectItemID = textBoxId;

            textBox.KeyPress += TextBox_KeyPress;

            textBox.BringToFront();
            Console.WriteLine(selectedPanel);
        }

        bool move;

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)8 && move)
            {
                projectTextbox.Parent.Controls.Remove(projectTextbox);
            }
            /*else if (e.KeyChar == (char)13)
            {
                projectTextbox.BorderStyle = BorderStyle.None;
                projectTextbox.Enabled = false;
                projectTextbox.Enabled = true;
            }*/
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.Name = "bo_textBox-" + textBox.Text + projectItemID;
        }

        private bool mouseDown = false;
        private Point MouseDownLocation;

        private void TextBox_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void TextBox_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            MouseDownLocation = e.Location;

            TextBox textBox = sender as TextBox;

            textBox.BringToFront();
            textBox.Focus();
        }

        private void TextBox_MouseMove(object sender, MouseEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            bool cursorMove = e.Location.X < 4 || e.Location.Y < 4 || e.Location.X > textBox.Size.Width - 4 || e.Location.Y > textBox.Height - 4;
            bool cursorResizeY = e.Location.X > textBox.Size.Width/2 - 2 && e.Location.X < textBox.Size.Width/2 + 2 && cursorMove;
            bool cursorResizeX = e.Location.Y > textBox.Size.Height/2 - 2 && e.Location.Y < textBox.Size.Height/2 + 2 && cursorMove;
            move = MouseDownLocation.X < 4 || MouseDownLocation.Y < 4 || MouseDownLocation.X > textBox.Size.Width - 4 || MouseDownLocation.Y > textBox.Height - 4;

            if (cursorResizeX)
                textBox.Cursor = Cursors.SizeWE;
            else if (cursorResizeY)
                textBox.Cursor = Cursors.SizeNS;
            else if (cursorMove)
                textBox.Cursor = Cursors.SizeAll;
            else
                textBox.Cursor = Cursors.IBeam;

            if (mouseDown && e.Button == MouseButtons.Left && move)
            {
                textBox.Left = e.X + textBox.Left - MouseDownLocation.X;
                textBox.Top = e.Y + textBox.Top - MouseDownLocation.Y;
            }
        }

        private void TextBox_MouseClick(object sender, MouseEventArgs e)
        {
            projectTextbox.BorderStyle = BorderStyle.FixedSingle;
        }
    }
}