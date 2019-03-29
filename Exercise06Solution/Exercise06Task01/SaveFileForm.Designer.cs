namespace Exercise06Task01
{
    partial class SaveFileForm
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
            this.saveBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.teamsToSaveListBox = new System.Windows.Forms.ListBox();
            this.teamsToSaveLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(12, 126);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 0;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(103, 126);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 23);
            this.closeBtn.TabIndex = 1;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // teamsToSaveListBox
            // 
            this.teamsToSaveListBox.FormattingEnabled = true;
            this.teamsToSaveListBox.Location = new System.Drawing.Point(12, 25);
            this.teamsToSaveListBox.Name = "teamsToSaveListBox";
            this.teamsToSaveListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.teamsToSaveListBox.Size = new System.Drawing.Size(166, 95);
            this.teamsToSaveListBox.TabIndex = 2;
            // 
            // teamsToSaveLabel
            // 
            this.teamsToSaveLabel.AutoSize = true;
            this.teamsToSaveLabel.Location = new System.Drawing.Point(12, 9);
            this.teamsToSaveLabel.Name = "teamsToSaveLabel";
            this.teamsToSaveLabel.Size = new System.Drawing.Size(112, 13);
            this.teamsToSaveLabel.TabIndex = 3;
            this.teamsToSaveLabel.Text = "Choose teams to save";
            // 
            // SaveFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(190, 153);
            this.Controls.Add(this.teamsToSaveLabel);
            this.Controls.Add(this.teamsToSaveListBox);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.saveBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaveFileForm";
            this.Text = "Save Dialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.ListBox teamsToSaveListBox;
        private System.Windows.Forms.Label teamsToSaveLabel;
    }
}