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
        public Textbox_Properties(TextBox textBox, int textBoxId)
        {
            projectTextbox = textBox;
            textBox.MouseDown += TextBox_MouseDown;
            textBox.MouseUp += TextBox_MouseUp;
            textBox.MouseMove += TextBox_MouseMove;
            textBox.MouseClick += TextBox_MouseClick;
            textBox.Enabled = true;
            textBox.Focus();
            textBox.Name = "bo_textBox-" + projectItemID;
            textBox.TextChanged += TextBox_TextChanged;
            projectItemID = textBoxId;

            textBox.KeyPress += TextBox_KeyPress;

            textBox.BringToFront();
        }

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

        bool move;
        private bool mouseDown = false;
        private bool resizeX = false;
        private bool resizeY = false;
        private bool reverseResize = false;
        //private bool resize = false; // This is a corner resize with no fixed axis
        private Point MouseDownLocation;
        private Size startSize;

        private void TextBox_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;

            // Prevent extremely small resizing
            TextBox textBox = sender as TextBox;
            int newX = textBox.Size.Width;
            int newY = textBox.Size.Height;
            Console.WriteLine(newX + ", " + newY);
            if (newX < 10 && newX >= 0)
                newX = 10;
            if (newY < 10 && newY >= 0)
                newY = 10;

            // Set the new size
            textBox.Size = new Size(newX, newY);
        }

        private void TextBox_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            MouseDownLocation = e.Location;

            TextBox textBox = sender as TextBox;

            resizeY = e.Location.X > textBox.Size.Width / 2 - 2 && e.Location.X < textBox.Size.Width / 2 + 2 && move;
            resizeX = e.Location.Y > textBox.Size.Height / 2 - 2 && e.Location.Y < textBox.Size.Height / 2 + 2 && move;
            reverseResize = (resizeX && e.Location.X < 4) || (resizeY && e.Location.Y < 4);

            startSize = textBox.Size;

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

            if (cursorResizeX && !mouseDown)
                textBox.Cursor = Cursors.SizeWE;
            else if (cursorResizeY && !mouseDown)
                textBox.Cursor = Cursors.SizeNS;
            else if (cursorMove && !mouseDown)
                textBox.Cursor = Cursors.SizeAll;
            else if (!mouseDown)
                textBox.Cursor = Cursors.IBeam;

            bool click = mouseDown && e.Button == MouseButtons.Left;

            if (click && resizeY)
            {
                if (reverseResize)
                {
                    textBox.Height = MouseDownLocation.Y - (e.Y + startSize.Height) + startSize.Height;
                }
                else
                    textBox.Height = e.Y - MouseDownLocation.Y + startSize.Height;
                textBox.DeselectAll();
            }
            else if (click && resizeX)
                textBox.Width = e.X - MouseDownLocation.X + startSize.Width;
            else if (click && move)
            {
                textBox.Left = e.X + textBox.Left - MouseDownLocation.X;
                textBox.Top = e.Y + textBox.Top - MouseDownLocation.Y;
                textBox.DeselectAll();
            }
        }

        private void TextBox_MouseClick(object sender, MouseEventArgs e)
        {
            projectTextbox.BorderStyle = BorderStyle.FixedSingle;
        }
    }
}