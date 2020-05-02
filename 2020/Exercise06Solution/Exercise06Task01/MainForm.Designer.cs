namespace Exercise05Task01
{
    partial class ChampionsLeagueForm
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
            this.playersGridView = new System.Windows.Forms.DataGridView();
            this.nameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clubCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goalsCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addBtn = new System.Windows.Forms.Button();
            this.removeBtn = new System.Windows.Forms.Button();
            this.modifyBtn = new System.Windows.Forms.Button();
            this.bestClubBtn = new System.Windows.Forms.Button();
            this.registerBtn = new System.Windows.Forms.Button();
            this.unregisterBtn = new System.Windows.Forms.Button();
            this.quitBtn = new System.Windows.Forms.Button();
            this.detailsListBox = new System.Windows.Forms.ListBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.loadBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.playersGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // playersGridView
            // 
            this.playersGridView.AllowUserToAddRows = false;
            this.playersGridView.AllowUserToDeleteRows = false;
            this.playersGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.playersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.playersGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameCol,
            this.clubCol,
            this.goalsCol});
            this.playersGridView.Location = new System.Drawing.Point(9, 13);
            this.playersGridView.Name = "playersGridView";
            this.playersGridView.ReadOnly = true;
            this.playersGridView.Size = new System.Drawing.Size(505, 306);
            this.playersGridView.TabIndex = 0;
            // 
            // nameCol
            // 
            this.nameCol.FillWeight = 35.23809F;
            this.nameCol.HeaderText = "Name";
            this.nameCol.Name = "nameCol";
            this.nameCol.ReadOnly = true;
            this.nameCol.Width = 59;
            // 
            // clubCol
            // 
            this.clubCol.FillWeight = 76.68014F;
            this.clubCol.HeaderText = "Club";
            this.clubCol.Name = "clubCol";
            this.clubCol.ReadOnly = true;
            this.clubCol.Width = 128;
            // 
            // goalsCol
            // 
            this.goalsCol.FillWeight = 188.0817F;
            this.goalsCol.HeaderText = "Goals";
            this.goalsCol.Name = "goalsCol";
            this.goalsCol.ReadOnly = true;
            this.goalsCol.Width = 315;
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(518, 13);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(76, 30);
            this.addBtn.TabIndex = 1;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(518, 49);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(76, 30);
            this.removeBtn.TabIndex = 2;
            this.removeBtn.Text = "Remove";
            this.removeBtn.UseVisualStyleBackColor = true;
            this.removeBtn.Click += new System.EventHandler(this.RemoveBtn_Click);
            // 
            // modifyBtn
            // 
            this.modifyBtn.Location = new System.Drawing.Point(518, 84);
            this.modifyBtn.Name = "modifyBtn";
            this.modifyBtn.Size = new System.Drawing.Size(76, 30);
            this.modifyBtn.TabIndex = 3;
            this.modifyBtn.Text = "Modify";
            this.modifyBtn.UseVisualStyleBackColor = true;
            this.modifyBtn.Click += new System.EventHandler(this.ModifyBtn_Click);
            // 
            // bestClubBtn
            // 
            this.bestClubBtn.Location = new System.Drawing.Point(518, 119);
            this.bestClubBtn.Name = "bestClubBtn";
            this.bestClubBtn.Size = new System.Drawing.Size(76, 30);
            this.bestClubBtn.TabIndex = 4;
            this.bestClubBtn.Text = "Best club";
            this.bestClubBtn.UseVisualStyleBackColor = true;
            this.bestClubBtn.Click += new System.EventHandler(this.BestClubBtn_Click);
            // 
            // registerBtn
            // 
            this.registerBtn.Location = new System.Drawing.Point(518, 154);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(76, 30);
            this.registerBtn.TabIndex = 5;
            this.registerBtn.Text = "Register";
            this.registerBtn.UseVisualStyleBackColor = true;
            this.registerBtn.Click += new System.EventHandler(this.RegisterBtn_Click);
            // 
            // unregisterBtn
            // 
            this.unregisterBtn.Location = new System.Drawing.Point(518, 188);
            this.unregisterBtn.Name = "unregisterBtn";
            this.unregisterBtn.Size = new System.Drawing.Size(76, 30);
            this.unregisterBtn.TabIndex = 6;
            this.unregisterBtn.Text = "Unregister";
            this.unregisterBtn.UseVisualStyleBackColor = true;
            this.unregisterBtn.Click += new System.EventHandler(this.UnregisterBtn_Click);
            // 
            // quitBtn
            // 
            this.quitBtn.Location = new System.Drawing.Point(518, 289);
            this.quitBtn.Name = "quitBtn";
            this.quitBtn.Size = new System.Drawing.Size(76, 30);
            this.quitBtn.TabIndex = 7;
            this.quitBtn.Text = "Quit";
            this.quitBtn.UseVisualStyleBackColor = true;
            this.quitBtn.Click += new System.EventHandler(this.QuitBtn_Click);
            // 
            // detailsListBox
            // 
            this.detailsListBox.FormattingEnabled = true;
            this.detailsListBox.Location = new System.Drawing.Point(9, 329);
            this.detailsListBox.Name = "detailsListBox";
            this.detailsListBox.ScrollAlwaysVisible = true;
            this.detailsListBox.Size = new System.Drawing.Size(586, 82);
            this.detailsListBox.TabIndex = 0;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(518, 221);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(76, 30);
            this.saveBtn.TabIndex = 8;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // loadBtn
            // 
            this.loadBtn.Location = new System.Drawing.Point(518, 256);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(76, 30);
            this.loadBtn.TabIndex = 9;
            this.loadBtn.Text = "Load";
            this.loadBtn.UseVisualStyleBackColor = true;
            this.loadBtn.Click += new System.EventHandler(this.LoadBtn_Click);
            // 
            // ChampionsLeagueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 422);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.loadBtn);
            this.Controls.Add(this.playersGridView);
            this.Controls.Add(this.quitBtn);
            this.Controls.Add(this.unregisterBtn);
            this.Controls.Add(this.registerBtn);
            this.Controls.Add(this.bestClubBtn);
            this.Controls.Add(this.modifyBtn);
            this.Controls.Add(this.removeBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.detailsListBox);
            this.Name = "ChampionsLeagueForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.playersGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView playersGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn clubCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn goalsCol;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button removeBtn;
        private System.Windows.Forms.Button modifyBtn;
        private System.Windows.Forms.Button bestClubBtn;
        private System.Windows.Forms.Button registerBtn;
        private System.Windows.Forms.Button unregisterBtn;
        private System.Windows.Forms.Button quitBtn;
        private System.Windows.Forms.ListBox detailsListBox;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button loadBtn;
    }
}

