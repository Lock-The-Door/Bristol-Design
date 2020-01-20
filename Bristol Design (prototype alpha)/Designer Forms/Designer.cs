using Bristol_Design.Designer_Forms;
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
    public partial class tsb_ : Form
    {
        string path; // The path to the open file

        public tsb_()
        {
            InitializeComponent();

            // Center the controls
            Center();
            Console.WriteLine($"first: {pb_text.Location} second: {pb_image.Location}, size: {Toolbox.Size}, form: {Size}");

            // Load a better Title Bar
            menuStrip.Dock = DockStyle.None;
            new Label
            {
                Text = Text,
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(100, 24),
                BackColor = Color.FromArgb(240, 40, 40),
                ForeColor = Color.White,
                Dock = DockStyle.Top,
                AutoSize = false
            };
            menuStrip.Dock = DockStyle.Top;

            // Recenter on resize
            Resize += Designer_Resize;
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
            save("");
        }

        private void save(string path)
        {
            // Create list that contains each line of the .bbp and init it with the project details
            List<string> bbp = new List<string>();

            string randomizedStringStarter = "bristolboardprojectfile_"; // The randomised string starts like this to ensure the file is not unsupported or corrupted

            char[] characters = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&-=(){}[]|/`<>+-.~".ToCharArray();

            Random random = new Random();

            for (int i = 0; i < 256; i++)
            {
                randomizedStringStarter += characters[random.Next(0, characters.Length)];
            }

            Console.WriteLine(randomizedStringStarter);

            string boardSettings = "bristolboardprojectfile bb 22,28 in #FFFFFF"; // default value with the random value The entire file will have to start with this, otherwise it is either unsupported or corrupted.

            // Get all the controls on the board
            foreach (Control boardObject in p_board.Controls)
            {
                string bbpLine; // This will be saved to store the line in the
                if (boardObject.Name.StartsWith("bl_")) // Board labels will have their own identifier of "bl_"
                {
                    Label boardLabel = boardObject as Label;

                    bbpLine = "tb "; // Start line off with the textbox type.

                    // Get position of the text.
                    bbpLine += boardLabel.Location.X + "," + boardLabel.Location.Y + " ";
                    // Get size of the textbox
                    bbpLine += boardLabel.Size.Height + "," + boardLabel.Size.Width;

                    // Get text
                    bbpLine += randomizedStringStarter + boardLabel.Text + randomizedStringStarter;

                    //Get b,i,u,s
                    if (boardLabel.Font.Bold)
                        bbpLine += "bold ";
                    if (boardLabel.Font.Italic)
                        bbpLine += "italic";
                    if (boardLabel.Font.Underline)
                        bbpLine += "underline";
                    if (boardLabel.Font.Strikeout)
                        bbpLine += "strikeout";

                    // Add line to the final file
                    bbp.Add(bbpLine);
                }
                else if (boardObject.Name.StartsWith("bp_")) // Board pictures will have their own identifier of "bp_"
                {
                    PictureBox boardPicture = boardObject as PictureBox;

                    bbpLine = "img";
                }
                else
                {
                    DialogResult saveFailAction = MessageBox.Show("An object on your board was not readable so your file failed to save. Would you like to abort saving, retry saving, or simply ignore this and save the file anyway?", "Saving Error!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                    
                    switch(saveFailAction)
                    {
                        case DialogResult.Abort:
                            return;
                        case DialogResult.Retry:
                            save(path);
                            return;
                    }
                }
            }

            Console.WriteLine(bbp);
        }

        private void boardSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bristol_Setup setup = new Bristol_Setup();
        }

        private void tsts_Zoom_Click(object sender, EventArgs e)
        {

        }
    }
}
