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
            this.components = new System.ComponentModel.Container();
            this.b_save = new System.Windows.Forms.Button();
            this.b_cancel = new System.Windows.Forms.Button();
            this.l_title = new System.Windows.Forms.Label();
            this.l_size = new System.Windows.Forms.Label();
            this.l_x = new System.Windows.Forms.Label();
            this.nud_height = new System.Windows.Forms.NumericUpDown();
            this.nud_width = new System.Windows.Forms.NumericUpDown();
            this.cmbb_boardType = new System.Windows.Forms.ComboBox();
            this.cmbb_units = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bristolSetupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nud_height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bristolSetupBindingSource)).BeginInit();
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
            this.b_save.Click += new System.EventHandler(this.b_save_Click);
            // 
            // b_cancel
            // 
            this.b_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
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
            this.l_title.Location = new System.Drawing.Point(12, 9);
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
            this.l_size.Location = new System.Drawing.Point(14, 111);
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
            this.l_x.Location = new System.Drawing.Point(148, 112);
            this.l_x.Name = "l_x";
            this.l_x.Size = new System.Drawing.Size(27, 23);
            this.l_x.TabIndex = 4;
            this.l_x.Text = "x";
            this.l_x.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // nud_height
            // 
            this.nud_height.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.nud_height.DecimalPlaces = 1;
            this.nud_height.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_height.Location = new System.Drawing.Point(83, 111);
            this.nud_height.Name = "nud_height";
            this.nud_height.Size = new System.Drawing.Size(60, 31);
            this.nud_height.TabIndex = 5;
            this.nud_height.Value = new decimal(new int[] {
            225,
            0,
            0,
            65536});
            // 
            // nud_width
            // 
            this.nud_width.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.nud_width.DecimalPlaces = 1;
            this.nud_width.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_width.Location = new System.Drawing.Point(178, 111);
            this.nud_width.Name = "nud_width";
            this.nud_width.Size = new System.Drawing.Size(60, 31);
            this.nud_width.TabIndex = 6;
            this.nud_width.Value = new decimal(new int[] {
            285,
            0,
            0,
            65536});
            // 
            // cmbb_boardType
            // 
            this.cmbb_boardType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbb_boardType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbb_boardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbb_boardType.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbb_boardType.FormattingEnabled = true;
            this.cmbb_boardType.ItemHeight = 23;
            this.cmbb_boardType.Items.AddRange(new object[] {
            "Normal Flat Bristol Board",
            "Tri-fold"});
            this.cmbb_boardType.Location = new System.Drawing.Point(252, 68);
            this.cmbb_boardType.MaxDropDownItems = 5;
            this.cmbb_boardType.Name = "cmbb_boardType";
            this.cmbb_boardType.Size = new System.Drawing.Size(252, 31);
            this.cmbb_boardType.TabIndex = 7;
            // 
            // cmbb_units
            // 
            this.cmbb_units.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbb_units.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbb_units.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbb_units.FormattingEnabled = true;
            this.cmbb_units.Items.AddRange(new object[] {
            "In.",
            "Cm."});
            this.cmbb_units.Location = new System.Drawing.Point(263, 111);
            this.cmbb_units.Name = "cmbb_units";
            this.cmbb_units.Size = new System.Drawing.Size(59, 31);
            this.cmbb_units.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 28);
            this.label1.TabIndex = 9;
            this.label1.Text = "Bristol Board Type:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Bristol_Setup
            // 
            this.AcceptButton = this.b_save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.b_cancel;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbb_units);
            this.Controls.Add(this.cmbb_boardType);
            this.Controls.Add(this.nud_width);
            this.Controls.Add(this.nud_height);
            this.Controls.Add(this.l_x);
            this.Controls.Add(this.l_size);
            this.Controls.Add(this.l_title);
            this.Controls.Add(this.b_cancel);
            this.Controls.Add(this.b_save);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Bristol_Setup";
            this.ShowInTaskbar = false;
            this.Text = "Bristol Board Settings";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.nud_height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bristolSetupBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b_save;
        private System.Windows.Forms.Button b_cancel;
        private System.Windows.Forms.Label l_title;
        private System.Windows.Forms.Label l_size;
        private System.Windows.Forms.Label l_x;
        private System.Windows.Forms.NumericUpDown nud_height;
        private System.Windows.Forms.NumericUpDown nud_width;
        private System.Windows.Forms.ComboBox cmbb_boardType;
        private System.Windows.Forms.ComboBox cmbb_units;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bristolSetupBindingSource;
    }
}