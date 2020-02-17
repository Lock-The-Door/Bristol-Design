using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bristol_Design.Designer_Items
{
    public class PictureBox_Properties
    {
        int projectItemID;
        public PictureBox projectPictureBox;
        public PictureBox_Properties(PictureBox pictureBox, int pictureBoxId)
        {
            projectPictureBox = pictureBox;
            pictureBox.Image = Bristol_Design_prototype_alpha_alpha.Properties.Resources.Placeholder;
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox.MouseDown += ImageBox_MouseDown;
            pictureBox.MouseUp += ImageBox_MouseUp;
            pictureBox.MouseMove += ImageBox_MouseMove;
            pictureBox.Location = new Point(100, 100);
            pictureBox.Enabled = true;
            pictureBox.BringToFront();
            pictureBox.Focus();
            pictureBox.Name = "bo_pictureBox-" + pictureBoxId;
            projectItemID = pictureBoxId;
        }

        private bool mouseDown = false;
        private Point MouseDownLocation;

        private void ImageBox_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void ImageBox_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            mouseDown = true;
            MouseDownLocation = e.Location;
            pictureBox.BringToFront();
            pictureBox.Focus();
        }

        private void ImageBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mouseDown || e.Button != MouseButtons.Left)
                return;
            PictureBox imageBox = sender as PictureBox;
            imageBox.Left = e.X + imageBox.Left - MouseDownLocation.X;
            imageBox.Top = e.Y + imageBox.Top - MouseDownLocation.Y;
        }


    }
}
