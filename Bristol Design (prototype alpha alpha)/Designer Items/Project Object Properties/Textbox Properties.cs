﻿using System;
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
            textBox.Text = "Click to add text";
            textBox.MouseDown += TextBox_MouseDown;
            textBox.MouseUp += TextBox_MouseUp;
            textBox.MouseMove += TextBox_MouseMove;
            mouseDown = true;
            textBox.Enabled = true;
            textBox.Focus();
            textBox.Name = "bl_textBox" + projectItemID;
            textBox.TextChanged += TextBox_TextChanged;
            projectItemID = textBoxId;

            textBox.KeyPress += TextBox_KeyPress;

            textBox.BringToFront();
            Console.WriteLine(selectedPanel);
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)8)
            {
                projectTextbox.Parent.Controls.Remove(projectTextbox);
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.Name = textBox.Text + projectItemID;
        }

        private bool mouseDown = false;
        private Point MouseDownLocation;
        private bool move = false;

        private void TextBox_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void TextBox_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            MouseDownLocation = e.Location;

            TextBox textBox = sender as TextBox;

            move = MouseDownLocation.X < 2 || MouseDownLocation.Y < 2 || MouseDownLocation.X > textBox.Size.Width - 2 || MouseDownLocation.Y > textBox.Height - 2;
            Console.WriteLine(textBox.Width + " " + MouseDownLocation.X);

            textBox.BringToFront();
            textBox.Focus();
        }

        private void TextBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mouseDown || e.Button != MouseButtons.Left || !move)
                return;
            TextBox textBox = sender as TextBox;
            textBox.Left = e.X + textBox.Left - MouseDownLocation.X;
            textBox.Top = e.Y + textBox.Top - MouseDownLocation.Y;
        }

        private void TextBox_LostFocus(object sender, EventArgs e)
        {
            projectTextbox.BorderStyle = BorderStyle.None;
        }

        private void TextBox_GotFocus(object sender, EventArgs e)
        {
            projectTextbox.BorderStyle = BorderStyle.FixedSingle;
        }
    }
}
