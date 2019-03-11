namespace MessageLogger
{
    partial class MessageLoggerApplicationForm
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
            this.SendBtn = new System.Windows.Forms.Button();
            this.LogEnabledPanel = new System.Windows.Forms.Panel();
            this.LogToFileCheckBox = new System.Windows.Forms.CheckBox();
            this.RightPanelCheckBox = new System.Windows.Forms.CheckBox();
            this.LeftPanelCheckBox = new System.Windows.Forms.CheckBox();
            this.InputMessageEditControl = new System.Windows.Forms.TextBox();
            this.LeftOutputTextBox = new System.Windows.Forms.TextBox();
            this.LeftOutputGroupBox = new System.Windows.Forms.GroupBox();
            this.RightOutputGroupBox = new System.Windows.Forms.GroupBox();
            this.RightOutputTextBox = new System.Windows.Forms.TextBox();
            this.LogEnabledPanel.SuspendLayout();
            this.LeftOutputGroupBox.SuspendLayout();
            this.RightOutputGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SendBtn
            // 
            this.SendBtn.Location = new System.Drawing.Point(346, 53);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(75, 23);
            this.SendBtn.TabIndex = 0;
            this.SendBtn.Text = "Send";
            this.SendBtn.UseVisualStyleBackColor = true;
            this.SendBtn.Click += new System.EventHandler(this.SendBtnClick);
            // 
            // LogEnabledPanel
            // 
            this.LogEnabledPanel.Controls.Add(this.LogToFileCheckBox);
            this.LogEnabledPanel.Controls.Add(this.RightPanelCheckBox);
            this.LogEnabledPanel.Controls.Add(this.LeftPanelCheckBox);
            this.LogEnabledPanel.Location = new System.Drawing.Point(12, 21);
            this.LogEnabledPanel.Name = "LogEnabledPanel";
            this.LogEnabledPanel.Size = new System.Drawing.Size(328, 28);
            this.LogEnabledPanel.TabIndex = 1;
            // 
            // LogToFileCheckBox
            // 
            this.LogToFileCheckBox.AutoSize = true;
            this.LogToFileCheckBox.Location = new System.Drawing.Point(202, 4);
            this.LogToFileCheckBox.Name = "LogToFileCheckBox";
            this.LogToFileCheckBox.Size = new System.Drawing.Size(72, 17);
            this.LogToFileCheckBox.TabIndex = 2;
            this.LogToFileCheckBox.Text = "Log to file";
            this.LogToFileCheckBox.UseVisualStyleBackColor = true;
            // 
            // RightPanelCheckBox
            // 
            this.RightPanelCheckBox.AutoSize = true;
            this.RightPanelCheckBox.Location = new System.Drawing.Point(101, 4);
            this.RightPanelCheckBox.Name = "RightPanelCheckBox";
            this.RightPanelCheckBox.Size = new System.Drawing.Size(80, 17);
            this.RightPanelCheckBox.TabIndex = 1;
            this.RightPanelCheckBox.Text = "Right panel";
            this.RightPanelCheckBox.UseVisualStyleBackColor = true;
            // 
            // LeftPanelCheckBox
            // 
            this.LeftPanelCheckBox.AutoSize = true;
            this.LeftPanelCheckBox.Location = new System.Drawing.Point(15, 4);
            this.LeftPanelCheckBox.Name = "LeftPanelCheckBox";
            this.LeftPanelCheckBox.Size = new System.Drawing.Size(73, 17);
            this.LeftPanelCheckBox.TabIndex = 0;
            this.LeftPanelCheckBox.Text = "Left panel";
            this.LeftPanelCheckBox.UseVisualStyleBackColor = true;
            this.LeftPanelCheckBox.CheckedChanged += new System.EventHandler(this.OutputEnabledCheckBox_CheckedChanged);
            // 
            // InputMessageEditControl
            // 
            this.InputMessageEditControl.Location = new System.Drawing.Point(12, 55);
            this.InputMessageEditControl.Multiline = true;
            this.InputMessageEditControl.Name = "InputMessageEditControl";
            this.InputMessageEditControl.Size = new System.Drawing.Size(328, 57);
            this.InputMessageEditControl.TabIndex = 2;
            // 
            // LeftOutputTextBox
            // 
            this.LeftOutputTextBox.Location = new System.Drawing.Point(0, 19);
            this.LeftOutputTextBox.Multiline = true;
            this.LeftOutputTextBox.Name = "LeftOutputTextBox";
            this.LeftOutputTextBox.Size = new System.Drawing.Size(166, 307);
            this.LeftOutputTextBox.TabIndex = 0;
            // 
            // LeftOutputGroupBox
            // 
            this.LeftOutputGroupBox.Controls.Add(this.LeftOutputTextBox);
            this.LeftOutputGroupBox.Location = new System.Drawing.Point(12, 118);
            this.LeftOutputGroupBox.Name = "LeftOutputGroupBox";
            this.LeftOutputGroupBox.Size = new System.Drawing.Size(167, 326);
            this.LeftOutputGroupBox.TabIndex = 5;
            this.LeftOutputGroupBox.TabStop = false;
            this.LeftOutputGroupBox.Text = "Left output";
            // 
            // RightOutputGroupBox
            // 
            this.RightOutputGroupBox.Controls.Add(this.RightOutputTextBox);
            this.RightOutputGroupBox.Location = new System.Drawing.Point(185, 118);
            this.RightOutputGroupBox.Name = "RightOutputGroupBox";
            this.RightOutputGroupBox.Size = new System.Drawing.Size(155, 326);
            this.RightOutputGroupBox.TabIndex = 6;
            this.RightOutputGroupBox.TabStop = false;
            this.RightOutputGroupBox.Text = "Right output";
            // 
            // RightOutputTextBox
            // 
            this.RightOutputTextBox.Location = new System.Drawing.Point(-1, 19);
            this.RightOutputTextBox.Multiline = true;
            this.RightOutputTextBox.Name = "RightOutputTextBox";
            this.RightOutputTextBox.Size = new System.Drawing.Size(155, 307);
            this.RightOutputTextBox.TabIndex = 0;
            // 
            // MessageLoggerApplicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 456);
            this.Controls.Add(this.RightOutputGroupBox);
            this.Controls.Add(this.LeftOutputGroupBox);
            this.Controls.Add(this.InputMessageEditControl);
            this.Controls.Add(this.LogEnabledPanel);
            this.Controls.Add(this.SendBtn);
            this.Name = "MessageLoggerApplicationForm";
            this.Text = "MessageLoggerApplicationForm";
            this.LogEnabledPanel.ResumeLayout(false);
            this.LogEnabledPanel.PerformLayout();
            this.LeftOutputGroupBox.ResumeLayout(false);
            this.LeftOutputGroupBox.PerformLayout();
            this.RightOutputGroupBox.ResumeLayout(false);
            this.RightOutputGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SendBtn;
        private System.Windows.Forms.Panel LogEnabledPanel;
        private System.Windows.Forms.CheckBox LogToFileCheckBox;
        private System.Windows.Forms.CheckBox RightPanelCheckBox;
        private System.Windows.Forms.CheckBox LeftPanelCheckBox;
        private System.Windows.Forms.TextBox InputMessageEditControl;
        private System.Windows.Forms.TextBox LeftOutputTextBox;
        private System.Windows.Forms.GroupBox LeftOutputGroupBox;
        private System.Windows.Forms.GroupBox RightOutputGroupBox;
        private System.Windows.Forms.TextBox RightOutputTextBox;
    }
}

