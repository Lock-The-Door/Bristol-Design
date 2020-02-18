namespace Bristol_Design__prototype_alpha_
{
    partial class Start_Page
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.b_placeholderLaunch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // b_placeholderLaunch
            // 
            this.b_placeholderLaunch.Location = new System.Drawing.Point(86, 54);
            this.b_placeholderLaunch.Name = "b_placeholderLaunch";
            this.b_placeholderLaunch.Size = new System.Drawing.Size(501, 221);
            this.b_placeholderLaunch.TabIndex = 1;
            this.b_placeholderLaunch.Text = "Placeholder button that launches the program";
            this.b_placeholderLaunch.UseVisualStyleBackColor = true;
            this.b_placeholderLaunch.Click += new System.EventHandler(this.b_placeholderLaunch_Click);
            // 
            // Start_Page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 332);
            this.Controls.Add(this.b_placeholderLaunch);
            this.Name = "Start_Page";
            this.Text = "Start_Page";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b_placeholderLaunch;
    }
}