namespace Exercise05Task01
{
    partial class BestClubForm
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
            this.clubListBox = new System.Windows.Forms.ListBox();
            this.okBtn = new System.Windows.Forms.Button();
            this.clubsLabel = new System.Windows.Forms.Label();
            this.goalsCountTextBox = new System.Windows.Forms.TextBox();
            this.goalsCountLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // clubListBox
            // 
            this.clubListBox.FormattingEnabled = true;
            this.clubListBox.Location = new System.Drawing.Point(7, 64);
            this.clubListBox.Name = "clubListBox";
            this.clubListBox.Size = new System.Drawing.Size(203, 95);
            this.clubListBox.TabIndex = 0;
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(135, 165);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 1;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // clubsLabel
            // 
            this.clubsLabel.AutoSize = true;
            this.clubsLabel.Location = new System.Drawing.Point(4, 48);
            this.clubsLabel.Name = "clubsLabel";
            this.clubsLabel.Size = new System.Drawing.Size(33, 13);
            this.clubsLabel.TabIndex = 2;
            this.clubsLabel.Text = "Clubs";
            // 
            // goalsCountTextBox
            // 
            this.goalsCountTextBox.Location = new System.Drawing.Point(7, 25);
            this.goalsCountTextBox.Name = "goalsCountTextBox";
            this.goalsCountTextBox.Size = new System.Drawing.Size(104, 20);
            this.goalsCountTextBox.TabIndex = 3;
            // 
            // goalsCountLabel
            // 
            this.goalsCountLabel.AutoSize = true;
            this.goalsCountLabel.Location = new System.Drawing.Point(4, 9);
            this.goalsCountLabel.Name = "goalsCountLabel";
            this.goalsCountLabel.Size = new System.Drawing.Size(59, 13);
            this.goalsCountLabel.TabIndex = 4;
            this.goalsCountLabel.Text = "Goal count";
            // 
            // BestClubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 194);
            this.Controls.Add(this.goalsCountLabel);
            this.Controls.Add(this.goalsCountTextBox);
            this.Controls.Add(this.clubsLabel);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.clubListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BestClubForm";
            this.Text = "BestClubForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox clubListBox;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Label clubsLabel;
        private System.Windows.Forms.TextBox goalsCountTextBox;
        private System.Windows.Forms.Label goalsCountLabel;
    }
}