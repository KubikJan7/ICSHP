namespace Exercise05Task01
{
    partial class PlayerForm
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
            this.goalCountUpDown = new System.Windows.Forms.NumericUpDown();
            this.clubComboBox = new System.Windows.Forms.ComboBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.clubLabel = new System.Windows.Forms.Label();
            this.goalsLabel = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            this.stornoBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.goalCountUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // goalCountUpDown
            // 
            this.goalCountUpDown.Location = new System.Drawing.Point(71, 59);
            this.goalCountUpDown.Name = "goalCountUpDown";
            this.goalCountUpDown.Size = new System.Drawing.Size(121, 20);
            this.goalCountUpDown.TabIndex = 0;
            // 
            // clubComboBox
            // 
            this.clubComboBox.FormattingEnabled = true;
            this.clubComboBox.Location = new System.Drawing.Point(71, 32);
            this.clubComboBox.Name = "clubComboBox";
            this.clubComboBox.Size = new System.Drawing.Size(121, 21);
            this.clubComboBox.TabIndex = 1;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(71, 6);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(121, 20);
            this.nameTextBox.TabIndex = 2;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(12, 9);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 3;
            this.nameLabel.Text = "Name";
            // 
            // clubLabel
            // 
            this.clubLabel.AutoSize = true;
            this.clubLabel.Location = new System.Drawing.Point(12, 35);
            this.clubLabel.Name = "clubLabel";
            this.clubLabel.Size = new System.Drawing.Size(28, 13);
            this.clubLabel.TabIndex = 4;
            this.clubLabel.Text = "Club";
            // 
            // goalsLabel
            // 
            this.goalsLabel.AutoSize = true;
            this.goalsLabel.Location = new System.Drawing.Point(12, 61);
            this.goalsLabel.Name = "goalsLabel";
            this.goalsLabel.Size = new System.Drawing.Size(34, 13);
            this.goalsLabel.TabIndex = 5;
            this.goalsLabel.Text = "Goals";
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(13, 90);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 6;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // stornoBtn
            // 
            this.stornoBtn.Location = new System.Drawing.Point(128, 90);
            this.stornoBtn.Name = "stornoBtn";
            this.stornoBtn.Size = new System.Drawing.Size(75, 23);
            this.stornoBtn.TabIndex = 7;
            this.stornoBtn.Text = "Storno";
            this.stornoBtn.UseVisualStyleBackColor = true;
            this.stornoBtn.Click += new System.EventHandler(this.StornoBtn_Click);
            // 
            // PlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(206, 127);
            this.Controls.Add(this.stornoBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.goalsLabel);
            this.Controls.Add(this.clubLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.goalCountUpDown);
            this.Controls.Add(this.clubComboBox);
            this.Controls.Add(this.nameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlayerForm";
            this.Text = "PlayerForm";
            ((System.ComponentModel.ISupportInitialize)(this.goalCountUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown goalCountUpDown;
        private System.Windows.Forms.ComboBox clubComboBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label clubLabel;
        private System.Windows.Forms.Label goalsLabel;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button stornoBtn;
    }
}