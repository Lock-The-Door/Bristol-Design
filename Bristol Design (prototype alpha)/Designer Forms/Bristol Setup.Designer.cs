namespace Bristol_Design.Designer_Forms
{
    partial class Bristol_Setup
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
            this.b_save = new System.Windows.Forms.Button();
            this.b_cancel = new System.Windows.Forms.Button();
            this.l_title = new System.Windows.Forms.Label();
            this.l_size = new System.Windows.Forms.Label();
            this.l_x = new System.Windows.Forms.Label();
            this.nud_length = new System.Windows.Forms.NumericUpDown();
            this.nud_width = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nud_length)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_width)).BeginInit();
            this.SuspendLayout();
            // 
            // b_save
            // 
            this.b_save.Location = new System.Drawing.Point(713, 415);
            this.b_save.Name = "b_save";
            this.b_save.Size = new System.Drawing.Size(75, 23);
            this.b_save.TabIndex = 0;
            this.b_save.Text = "Save";
            this.b_save.UseVisualStyleBackColor = true;
            // 
            // b_cancel
            // 
            this.b_cancel.Location = new System.Drawing.Point(632, 415);
            this.b_cancel.Name = "b_cancel";
            this.b_cancel.Size = new System.Drawing.Size(75, 23);
            this.b_cancel.TabIndex = 1;
            this.b_cancel.Text = "Cancel";
            this.b_cancel.UseVisualStyleBackColor = true;
            // 
            // l_title
            // 
            this.l_title.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_title.Location = new System.Drawing.Point(13, 13);
            this.l_title.Name = "l_title";
            this.l_title.Size = new System.Drawing.Size(240, 45);
            this.l_title.TabIndex = 2;
            this.l_title.Text = "Board Settings";
            // 
            // l_size
            // 
            this.l_size.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.l_size.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_size.Location = new System.Drawing.Point(21, 79);
            this.l_size.Name = "l_size";
            this.l_size.Size = new System.Drawing.Size(63, 28);
            this.l_size.TabIndex = 3;
            this.l_size.Text = "Size:";
            this.l_size.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // l_x
            // 
            this.l_x.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.l_x.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_x.Location = new System.Drawing.Point(141, 82);
            this.l_x.Name = "l_x";
            this.l_x.Size = new System.Drawing.Size(27, 23);
            this.l_x.TabIndex = 4;
            this.l_x.Text = "x";
            this.l_x.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // nud_length
            // 
            this.nud_length.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.nud_length.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_length.Location = new System.Drawing.Point(90, 80);
            this.nud_length.Name = "nud_length";
            this.nud_length.Size = new System.Drawing.Size(45, 31);
            this.nud_length.TabIndex = 5;
            this.nud_length.Value = new decimal(new int[] {
            22,
            0,
            0,
            0});
            // 
            // nud_width
            // 
            this.nud_width.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.nud_width.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_width.Location = new System.Drawing.Point(174, 80);
            this.nud_width.Name = "nud_width";
            this.nud_width.Size = new System.Drawing.Size(45, 31);
            this.nud_width.TabIndex = 6;
            this.nud_width.Value = new decimal(new int[] {
            24,
            0,
            0,
            0});
            // 
            // Bristol_Setup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.nud_width);
            this.Controls.Add(this.nud_length);
            this.Controls.Add(this.l_x);
            this.Controls.Add(this.l_size);
            this.Controls.Add(this.l_title);
            this.Controls.Add(this.b_cancel);
            this.Controls.Add(this.b_save);
            this.Name = "Bristol_Setup";
            this.Text = "Bristol Board Settings";
            ((System.ComponentModel.ISupportInitialize)(this.nud_length)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_width)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b_save;
        private System.Windows.Forms.Button b_cancel;
        private System.Windows.Forms.Label l_title;
        private System.Windows.Forms.Label l_size;
        private System.Windows.Forms.Label l_x;
        private System.Windows.Forms.NumericUpDown nud_length;
        private System.Windows.Forms.NumericUpDown nud_width;
    }
}