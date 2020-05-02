namespace Exercise07
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
            this.imagePicBox = new System.Windows.Forms.PictureBox();
            this.loadFileBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imagePicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // imagePicBox
            // 
            this.imagePicBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imagePicBox.BackColor = System.Drawing.SystemColors.Control;
            this.imagePicBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.imagePicBox.Location = new System.Drawing.Point(-1, -1);
            this.imagePicBox.Name = "imagePicBox";
            this.imagePicBox.Size = new System.Drawing.Size(803, 419);
            this.imagePicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imagePicBox.TabIndex = 0;
            this.imagePicBox.TabStop = false;
            // 
            // loadFileBtn
            // 
            this.loadFileBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.loadFileBtn.AutoSize = true;
            this.loadFileBtn.Location = new System.Drawing.Point(370, 424);
            this.loadFileBtn.Name = "loadFileBtn";
            this.loadFileBtn.Size = new System.Drawing.Size(75, 23);
            this.loadFileBtn.TabIndex = 1;
            this.loadFileBtn.Text = "Load file";
            this.loadFileBtn.UseVisualStyleBackColor = true;
            this.loadFileBtn.Click += new System.EventHandler(this.loadFileBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.loadFileBtn);
            this.Controls.Add(this.imagePicBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.imagePicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imagePicBox;
        private System.Windows.Forms.Button loadFileBtn;
    }
}

