namespace Exercise08
{
    partial class Form1
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
            this.chooseDirBtn = new System.Windows.Forms.Button();
            this.chosenDirTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.infoListBox = new System.Windows.Forms.ListBox();
            this.saveToFileCheckBox = new System.Windows.Forms.CheckBox();
            this.showDirInfoCheckBox = new System.Windows.Forms.CheckBox();
            this.analyseBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chooseDirBtn
            // 
            this.chooseDirBtn.Location = new System.Drawing.Point(546, 74);
            this.chooseDirBtn.Name = "chooseDirBtn";
            this.chooseDirBtn.Size = new System.Drawing.Size(127, 23);
            this.chooseDirBtn.TabIndex = 0;
            this.chooseDirBtn.Text = "Choose directory";
            this.chooseDirBtn.UseVisualStyleBackColor = true;
            this.chooseDirBtn.Click += new System.EventHandler(this.chooseDirBtn_Click);
            // 
            // chosenDirTextBox
            // 
            this.chosenDirTextBox.Location = new System.Drawing.Point(148, 74);
            this.chosenDirTextBox.Name = "chosenDirTextBox";
            this.chosenDirTextBox.Size = new System.Drawing.Size(374, 22);
            this.chosenDirTextBox.TabIndex = 1;
            this.chosenDirTextBox.Text = ".";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chosen directory:";
            // 
            // infoListBox
            // 
            this.infoListBox.FormattingEnabled = true;
            this.infoListBox.HorizontalScrollbar = true;
            this.infoListBox.ItemHeight = 16;
            this.infoListBox.Location = new System.Drawing.Point(15, 170);
            this.infoListBox.Name = "infoListBox";
            this.infoListBox.ScrollAlwaysVisible = true;
            this.infoListBox.Size = new System.Drawing.Size(677, 260);
            this.infoListBox.TabIndex = 3;
            // 
            // saveToFileCheckBox
            // 
            this.saveToFileCheckBox.AutoSize = true;
            this.saveToFileCheckBox.Location = new System.Drawing.Point(159, 130);
            this.saveToFileCheckBox.Name = "saveToFileCheckBox";
            this.saveToFileCheckBox.Size = new System.Drawing.Size(100, 21);
            this.saveToFileCheckBox.TabIndex = 4;
            this.saveToFileCheckBox.Text = "Save to file";
            this.saveToFileCheckBox.UseVisualStyleBackColor = true;
            // 
            // showDirInfoCheckBox
            // 
            this.showDirInfoCheckBox.AutoSize = true;
            this.showDirInfoCheckBox.Location = new System.Drawing.Point(15, 130);
            this.showDirInfoCheckBox.Name = "showDirInfoCheckBox";
            this.showDirInfoCheckBox.Size = new System.Drawing.Size(138, 21);
            this.showDirInfoCheckBox.TabIndex = 5;
            this.showDirInfoCheckBox.Text = "Show information";
            this.showDirInfoCheckBox.UseVisualStyleBackColor = true;
            // 
            // analyseBtn
            // 
            this.analyseBtn.Location = new System.Drawing.Point(569, 130);
            this.analyseBtn.Name = "analyseBtn";
            this.analyseBtn.Size = new System.Drawing.Size(75, 23);
            this.analyseBtn.TabIndex = 6;
            this.analyseBtn.Text = "Analyse";
            this.analyseBtn.UseVisualStyleBackColor = true;
            this.analyseBtn.Click += new System.EventHandler(this.AnalyseBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 450);
            this.Controls.Add(this.analyseBtn);
            this.Controls.Add(this.showDirInfoCheckBox);
            this.Controls.Add(this.saveToFileCheckBox);
            this.Controls.Add(this.infoListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chosenDirTextBox);
            this.Controls.Add(this.chooseDirBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button chooseDirBtn;
        private System.Windows.Forms.TextBox chosenDirTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox infoListBox;
        private System.Windows.Forms.CheckBox saveToFileCheckBox;
        private System.Windows.Forms.CheckBox showDirInfoCheckBox;
        private System.Windows.Forms.Button analyseBtn;
    }
}

