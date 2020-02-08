﻿using Bristol_Design.Designer_Forms;
using Bristol_Design.Designer_Items;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bristol_Design__prototype_alpha_
{
    public partial class tsb_ : Form
    {
        string path; // The path to the open file

        public string fileName;

        public tsb_()
        {
            InitializeComponent();

            // Center the controls
            Center();

            // Recenter on re-size
            Resize += Designer_Resize;
        }

        private void tsb__Load(object sender, EventArgs e)
        {
            // Update and load the form first
            Update();

            updateName();
        }

        private void updateName()
        {
            // Set form name
            Text = fileName + " - Bristol Design";

            // Set title bar name
            l_Title.Text = fileName + " - Bristol Design";
        }

        private void Designer_Resize(object sender, EventArgs e)
        {
            Center();
        }

        private void Center()
        {
            Update(); // Load all the controls first

            int center = Size.Width / 2;

            // Center board
            int adjustedCenter = center - p_board.Size.Width / 2;
            p_board.Location = new Point(adjustedCenter, p_board.Location.Y);

            // Center toolbox items
            List<PictureBox> tools = Toolbox.Controls.OfType<PictureBox>().ToList();

            double dividedButtonSpace = Toolbox.Width / tools.Count; // All button sizes are equal, divide the space of the panel by the number of buttons (this will allow us to not need to change any code for each new button we add)
            // Points cannot be doubles, round them for best accuracy then convert them into an int
            int roundedDividedButtonSpace = Convert.ToInt32(Math.Round(dividedButtonSpace));

            // Place the buttons accordingly
            int position = 0;
            foreach (PictureBox tool in tools)
            {
                // Place the button
                position += roundedDividedButtonSpace;
                tool.Location = new Point(position - (roundedDividedButtonSpace / 2), tool.Location.Y);

                Update();
            }
        }


        private void tsb_Save_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem_Click(sender, e);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (path == null)
            {
                saveAsToolStripMenuItem_Click(sender, e); // If the file does not exist yet, run save as command
                return;
            }

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult saveAsLocation = saveFileDialog.ShowDialog();
            if (saveAsLocation == DialogResult.Cancel)
                return;
            save(Path.GetFullPath(saveFileDialog.FileName));
        }

        private void save(string savePath)
        {
            // Create list that contains each line of the .bbp and initialize it with the project details
            List<string> bbp = new List<string>();

            string randomizedStringStarter = "bristolboardprojectfile_"; // The randomized string starts like this to ensure the file is not unsupported or corrupted

            char[] characters = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&-=(){}[]|/`<>+-.~".ToCharArray();

            Random random = new Random();

            for (int i = 0; i < 256; i++)
            {
                randomizedStringStarter += characters[random.Next(0, characters.Length)];
            }

            Console.WriteLine(randomizedStringStarter);

            string boardSettings = "bristolboardprojectfile bb 22,28 in #FFFFFF"; // default value with the random value The entire file will have to start with this, otherwise it is either unsupported or corrupted.

            // Add starting lines for the file
            bbp.Add(boardSettings);
            bbp.Add(randomizedStringStarter);

            // Get all the controls on the board
            string bbpLine; // This will be saved to store the line
            foreach (Textbox_Properties tb_properties in projectTextboxes)
            {
                TextBox boardTextBox = tb_properties.projectTextbox as TextBox;

                bbpLine = "tb "; // Start line off with the textbox type.

                // Get position of the text.
                bbpLine += boardTextBox.Location.X + "," + boardTextBox.Location.Y + " ";
                // Get size of the textbox
                bbpLine += boardTextBox.Size.Height + "," + boardTextBox.Size.Width;

                // Get text
                bbpLine += randomizedStringStarter + boardTextBox.Text + randomizedStringStarter + " ";

                // Get font name
                bbpLine += boardTextBox.Font.FontFamily;

                // Get Font size
                bbpLine += boardTextBox.Size + " ";

                //Get b,i,u,s
                if (boardTextBox.Font.Bold)
                    bbpLine += "bold ";
                if (boardTextBox.Font.Italic)
                    bbpLine += "italic ";
                if (boardTextBox.Font.Underline)
                    bbpLine += "underline ";
                if (boardTextBox.Font.Strikeout)
                    bbpLine += "strikeout ";

                // Add line to the final file
                bbp.Add(bbpLine);
            }

            foreach (PictureBox_Properties pb_properties in projectPictureboxes)
            {
                bbpLine = "img";
            }

            Console.WriteLine(bbp);

            // Compile the lines
            string compiledBbp = "";
            foreach (string line in bbp)
                compiledBbp += line;

            // Finally write to the file
            if (path == null)
            {
                var directory = Directory.CreateDirectory(Path.GetFullPath(Path.GetDirectoryName(savePath)));
                savePath = Path.Combine(directory.FullName, Path.GetFileName(savePath));
            }
            FileStream stream = File.Create(savePath);

            foreach (byte bbpByte in Encoding.UTF8.GetBytes(compiledBbp))
            {
                stream.WriteByte(bbpByte);
            }

            stream.Dispose();

            // Once saved, rename the project and specify a save path
            path = savePath;
            fileName = Path.GetFileNameWithoutExtension(path);
            updateName();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // For each item created with the creation tool, delete it.
            foreach (Textbox_Properties textboxProperty in projectTextboxes)
                Controls.Remove(textboxProperty.projectTextbox);
            foreach (PictureBox_Properties pictureboxProperty in projectPictureboxes)
                Controls.Remove(pictureboxProperty.projectPictureBox);
        }

        private void boardSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bristol_Setup setup = new Bristol_Setup();
            setup.ShowDialog();
        }

        List<Textbox_Properties> projectTextboxes = new List<Textbox_Properties>();
        List<PictureBox_Properties> projectPictureboxes = new List<PictureBox_Properties>();

        int projectItemCount;

        private void pb_text_MouseDown(object sender, EventArgs e)
        {
            TextBox textBox = new TextBox
            {
                Parent = this,
                Name = "textBox" + projectItemCount
            };

            Textbox_Properties textbox_Properties = new Textbox_Properties(textBox, projectItemCount);

            projectTextboxes.Add(textbox_Properties);

            Console.WriteLine(textBox);

            projectItemCount++;
        }

        private void pb_image_MouseDown(object sender, EventArgs e)
        {
            PictureBox pictureBox = new PictureBox
            {
                Parent = this,
                Name = "pictureBox" + projectItemCount
            };

            PictureBox_Properties pictureBox_Properties = new PictureBox_Properties(pictureBox, projectItemCount);

            projectPictureboxes.Add(pictureBox_Properties);

            Console.WriteLine(pictureBox);

            projectItemCount++;
        }

        public Form StartPageRef { get; set; }
        private void startPageStripMenuItem_Click(object sender, EventArgs e)
        {
            StartPageRef.Show();
            StartPageRef.Update();
            StartPageRef.Focus();
            Update();
            Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pdfCreation();
        }

        private void exportStripMenuItem_Click(object sender, EventArgs e)
        {
            pdfCreation();
        }

        private void pdfCreation()
        {
            throw new NotImplementedException();
        }
    }
}
