using Bristol_Design.Designer_Forms;
using Bristol_Design.Designer_Items;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bristol_Design_prototype_alpha_alpha
{
    public partial class tsb_ : Form
    {
        string path; // The path to the open file

        public string fileName;

        // Bristol board type
        string bbType = "fltb";
        // Size variables
        decimal length = 28.5m;
        decimal height = 22.5m;
        string units = "in";

        public tsb_()
        {
            InitializeComponent();

            // Center the controls
            Center();

            // Recenter on re-size
            Resize += Designer_Resize;

            // On click request deselect for all other objects
            MouseDown += Control_MouseDown;
            foreach (Control control in Controls)
            {
                control.MouseDown += Control_MouseDown;
            }
        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (Control control in Controls)
            {
                if (control.Name.StartsWith("bo_textBox-") && control != sender)
                {
                    TextBox textObject = control as TextBox;
                    textObject.BorderStyle = BorderStyle.None;
                    textObject.Enabled = false;
                    textObject.Enabled = true;
                }
                else if (control.Name.StartsWith("bo_pictureBox-"))
                    (control as PictureBox).BorderStyle = BorderStyle.None;
            }
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
            DialogResult saveAsDialog = saveFileDialog.ShowDialog();
            if (saveAsDialog == DialogResult.Cancel)
                return;
            save(Path.GetFullPath(saveFileDialog.FileName));
        }

        List<Textbox_Properties> projectTextboxes = new List<Textbox_Properties>();
        
        List<PictureBox_Properties> projectPictureboxes = new List<PictureBox_Properties>();

        private void save(string savePath)
        {
            // Create list that contains each line of the .bbp and initialize it with the project details
            List<string> bbp = new List<string>();

            string randomizedStringEnd = "bristolboardprojectfile_"; // The randomized string starts like this to ensure the file is not unsupported or corrupted
            string randomizedFontNameEnd = "bristolboardprojectfont_";

            char[] characters = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&-=(){}[]|/`<>+-.~".ToCharArray();

            Random random = new Random();

            for (int i = 0; i < 256; i++)
            {
                randomizedStringEnd += characters[random.Next(0, characters.Length)];
                randomizedFontNameEnd += characters[random.Next(0, characters.Length)];
            }

            Console.WriteLine(randomizedStringEnd);

            string boardSettings = "bristolboardprojectfile bb 22,28 in #FFFFFF"; // default value with the random value The entire file will have to start with this, otherwise it is either unsupported or corrupted.

            // Add starting lines for the file
            bbp.Add(boardSettings);
            bbp.Add(randomizedStringEnd);
            bbp.Add(randomizedFontNameEnd);

            // Get all the controls on the board
            string bbpLine; // This will be saved to store the line
            foreach (Textbox_Properties tb_properties in projectTextboxes)
            {
                TextBox boardTextBox = tb_properties.projectTextbox as TextBox;

                bbpLine = "tb "; // Start line off with the textbox type.

                // Get position of the text.
                bbpLine += boardTextBox.Location.X + "," + boardTextBox.Location.Y + " ";
                // Get size of the textbox
                bbpLine += boardTextBox.Size.Height + "," + boardTextBox.Size.Width + " ";

                // Get text
                bbpLine += boardTextBox.Text + randomizedStringEnd;

                // Get font name
                bbpLine += boardTextBox.Font.FontFamily.Name + randomizedFontNameEnd;

                // Get Font size
                bbpLine += boardTextBox.Font.Size + " ";

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
                bbpLine = "pb ";
            }

            Console.WriteLine(bbp);

            // Compile the lines
            string compiledBbp = "";
            foreach (string line in bbp)
                compiledBbp += line + "\n";

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

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get file location
            DialogResult openResult = openFileDialog.ShowDialog();
            if (openResult == DialogResult.Cancel)
                return;
            string openPath = Path.GetFullPath(openFileDialog.FileName);

            // Open and read file
            List<string> bbpProjectLines = new List<string>();
            foreach (string bbpProjectLine in File.ReadLines(openPath))
            {
                bbpProjectLines.Add(bbpProjectLine);
                Console.WriteLine(bbpProjectLine);
            }

            // Get board setting files first
            string settings = bbpProjectLines[0];
            string textEnd = bbpProjectLines[1];
            string fontEnd = bbpProjectLines[2];
            //Remove those lines
            bbpProjectLines.RemoveRange(0, 3);

            // Define a textbox id
            int projectItemCount = 0;

            // Get the project items next
            foreach (string projectObject in bbpProjectLines)
            {
                Console.WriteLine(projectObject);
                // Get object type to load the correct properties then delete them
                string projectObjectType = projectObject.Substring(0, 2); 
                string projectProperties = projectObject.Remove(0, 3);

                Console.WriteLine(projectObjectType);
                Console.WriteLine(projectProperties);

                switch (projectObjectType)
                {
                    case "tb": // Textbox
                        int endPos;

                        // Get position
                        int xPos = Convert.ToInt32(projectProperties.Remove(projectProperties.IndexOf(',')));
                        projectProperties = projectProperties.Remove(0, projectProperties.IndexOf(',') + 1);
                        endPos = projectProperties.IndexOf(' '); // Get the property end character (a space)
                        int yPos = Convert.ToInt32(projectProperties.Remove(endPos));
                        projectProperties = projectProperties.Remove(0, endPos + 1);
                        Point position = new Point(xPos, yPos);

                        // Get size
                        int height = Convert.ToInt32(projectProperties.Remove(projectProperties.IndexOf(',')));
                        projectProperties = projectProperties.Remove(0, projectProperties.IndexOf(',') + 1);
                        endPos = projectProperties.IndexOf(' '); // Get the property end character (a space)
                        int width = Convert.ToInt32(projectProperties.Remove(endPos));
                        projectProperties = projectProperties.Remove(0, endPos + 1);

                        Console.WriteLine(width + " " + height);

                        // Get the original string
                        string textboxText = projectProperties;
                        // Remove the last character until the ending is the string end
                        while (!textboxText.EndsWith(textEnd))
                            textboxText = textboxText.Remove(textboxText.Length - 1);
                        // Get the amount of characters that are left (to know how much to remove from the properties string)
                        int removeCount = textboxText.Length + 1;
                        // Remove the string end
                        textboxText = textboxText.Remove(textboxText.Length - 280); // The end is hard coded to 280 characters
                        // Remove the used properties
                        projectProperties = projectProperties.Remove(0, removeCount);

                        // Get font name
                        string fontFamilyName = projectProperties;
                        // Remove the last character until the ending is the string end
                        while (!fontFamilyName.EndsWith(fontEnd))
                            fontFamilyName = fontFamilyName.Remove(fontFamilyName.Length - 1);
                        // Get the amount of characters that are left (to know how much to remove from the properties string)
                        removeCount = fontFamilyName.Length;
                        // Remove the string end
                        fontFamilyName =  fontFamilyName.Remove(fontFamilyName.Length - 280); // The end is hard coded to 280 characters
                        // Remove the used properties
                        projectProperties = projectProperties.Remove(0, removeCount);

                        // Get size
                        endPos = projectProperties.IndexOf(' ');
                        float fontSize = float.Parse(projectProperties.Remove(endPos));
                        // Remove the property
                        projectProperties = projectProperties.Remove(0, endPos + 1);

                        //Get b,i,u,s
                        FontStyle fontStyle = FontStyle.Regular;
                        endPos = projectProperties.IndexOf(' ');
                        bool finished = false;
                        if (projectProperties.Length == 0) // Make sure there are more properties first
                            finished = true;
                        if (!finished && projectProperties.Remove(endPos) == "bold")
                        {
                            fontStyle = FontStyle.Bold;
                            projectProperties = projectProperties.Remove(0, endPos + 1);

                            if (projectProperties.Length == 0) // Make sure there are more properties first
                                finished = true;
                        }
                        if (!finished && projectProperties.Remove(endPos) == "italic")
                        {
                            fontStyle = fontStyle | FontStyle.Italic;
                            projectProperties = projectProperties.Remove(0, endPos + 1);

                            if (projectProperties.Length == 0) // Make sure there are more properties first
                                finished = true;
                        }
                        if (!finished && projectProperties.Remove(endPos) == "underline")
                        {
                            fontStyle = fontStyle | FontStyle.Underline;
                            projectProperties = projectProperties.Remove(0, endPos + 1);

                            if (projectProperties.Length == 0) // Make sure there are more properties first
                                finished = true;
                        }
                        if (!finished && projectProperties.Remove(endPos) == "strikeout")
                        {
                            fontStyle = fontStyle | FontStyle.Strikeout;
                            projectProperties = projectProperties.Remove(0, endPos + 1);

                            if (projectProperties.Length == 0) // Make sure there are more properties first
                                finished = true;
                        }

                        // Create the textbox and add the properties
                        Textbox_Properties textbox_Properties = new Textbox_Properties(new TextBox(), projectItemCount);
                        TextBox textbox = textbox_Properties.projectTextbox;
                        textbox.Parent = this;
                        textbox.Location = position;
                        textbox.Font = new Font(fontFamilyName, fontSize, fontStyle);
                        Console.WriteLine(fontSize + " " + textbox.Font);
                        textbox.Size = new Size(new Point(width, height));
                        Console.WriteLine(textbox.Size);
                        textbox.Text = textboxText;
                        projectTextboxes.Add(textbox_Properties);
                        textbox.BringToFront();
                        Update();

                        break;
                }

                // Increase projectItemCount
                projectItemCount++;
            }

            // Update the name
            fileName = Path.GetFileNameWithoutExtension(openPath);
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
            Bristol_Setup setup = new Bristol_Setup(bbType, length, height, units);
            setup.ShowDialog();
        }

        int projectItemCount;

        private void pb_text_MouseDown(object sender, EventArgs e)
        {
            TextBox textBox = new TextBox
            {
                Parent = this,
                Name = "textBox" + projectItemCount,
                Location = new Point(500, 500),
                BorderStyle = BorderStyle.FixedSingle,
                Multiline = true
            };

            textBox.MouseDown += Control_MouseDown;

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

            pictureBox.MouseDown += Control_MouseDown;

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
