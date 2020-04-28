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
            this.detailsListBox = new System.Windows.Forms.ListBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.removeBtn = new System.Windows.Forms.Button();
            this.modifyBtn = new System.Windows.Forms.Button();
            this.bestClubBtn = new System.Windows.Forms.Button();
            this.registerBtn = new System.Windows.Forms.Button();
            this.unregisterBtn = new System.Windows.Forms.Button();
            this.quitBtn = new System.Windows.Forms.Button();
            this.playersGridView = new System.Windows.Forms.DataGridView();
            this.nameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clubCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goalsCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.playersGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // detailsListBox
            // 
            this.detailsListBox.FormattingEnabled = true;
            this.detailsListBox.Location = new System.Drawing.Point(9, 258);
            this.detailsListBox.Margin = new System.Windows.Forms.Padding(2);
            this.detailsListBox.Name = "detailsListBox";
            this.detailsListBox.ScrollAlwaysVisible = true;
            this.detailsListBox.Size = new System.Drawing.Size(583, 95);
            this.detailsListBox.TabIndex = 0;
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(518, 13);
            this.addBtn.Margin = new System.Windows.Forms.Padding(2);
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
            this.removeBtn.Margin = new System.Windows.Forms.Padding(2);
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
            this.modifyBtn.Margin = new System.Windows.Forms.Padding(2);
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
            this.bestClubBtn.Margin = new System.Windows.Forms.Padding(2);
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
            this.registerBtn.Margin = new System.Windows.Forms.Padding(2);
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
            this.unregisterBtn.Margin = new System.Windows.Forms.Padding(2);
            this.unregisterBtn.Name = "unregisterBtn";
            this.unregisterBtn.Size = new System.Drawing.Size(76, 30);
            this.unregisterBtn.TabIndex = 6;
            this.unregisterBtn.Text = "Unregister";
            this.unregisterBtn.UseVisualStyleBackColor = true;
            this.unregisterBtn.Click += new System.EventHandler(this.UnregisterBtn_Click);
            // 
            // quitBtn
            // 
            this.quitBtn.Location = new System.Drawing.Point(518, 223);
            this.quitBtn.Margin = new System.Windows.Forms.Padding(2);
            this.quitBtn.Name = "quitBtn";
            this.quitBtn.Size = new System.Drawing.Size(76, 30);
            this.quitBtn.TabIndex = 7;
            this.quitBtn.Text = "Quit";
            this.quitBtn.UseVisualStyleBackColor = true;
            this.quitBtn.Click += new System.EventHandler(this.QuitBtn_Click);
            // 
            // playersGridView
            // 
            this.playersGridView.AllowUserToAddRows = false;
            this.playersGridView.AllowUserToDeleteRows = false;
            this.playersGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.playersGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.playersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.playersGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameCol,
            this.clubCol,
            this.goalsCol});
            this.playersGridView.Location = new System.Drawing.Point(9, 10);
            this.playersGridView.Margin = new System.Windows.Forms.Padding(2);
            this.playersGridView.Name = "playersGridView";
            this.playersGridView.ReadOnly = true;
            this.playersGridView.RowHeadersVisible = false;
            this.playersGridView.RowHeadersWidth = 10;
            this.playersGridView.RowTemplate.Height = 24;
            this.playersGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.playersGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.playersGridView.Size = new System.Drawing.Size(505, 244);
            this.playersGridView.TabIndex = 8;
            // 
            // nameCol
            // 
            this.nameCol.FillWeight = 35.23809F;
            this.nameCol.HeaderText = "Name";
            this.nameCol.Name = "nameCol";
            this.nameCol.ReadOnly = true;
            // 
            // clubCol
            // 
            this.clubCol.FillWeight = 76.68014F;
            this.clubCol.HeaderText = "Club";
            this.clubCol.Name = "clubCol";
            this.clubCol.ReadOnly = true;
            // 
            // goalsCol
            // 
            this.goalsCol.FillWeight = 188.0817F;
            this.goalsCol.HeaderText = "Goals";
            this.goalsCol.Name = "goalsCol";
            this.goalsCol.ReadOnly = true;
            // 
            // ChampionsLeagueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.playersGridView);
            this.Controls.Add(this.quitBtn);
            this.Controls.Add(this.unregisterBtn);
            this.Controls.Add(this.registerBtn);
            this.Controls.Add(this.bestClubBtn);
            this.Controls.Add(this.modifyBtn);
            this.Controls.Add(this.removeBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.detailsListBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ChampionsLeagueForm";
            this.Text = "Champions League";
            ((System.ComponentModel.ISupportInitialize)(this.playersGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox detailsListBox;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button removeBtn;
        private System.Windows.Forms.Button modifyBtn;
        private System.Windows.Forms.Button bestClubBtn;
        private System.Windows.Forms.Button registerBtn;
        private System.Windows.Forms.Button unregisterBtn;
        private System.Windows.Forms.Button quitBtn;
        private System.Windows.Forms.DataGridView playersGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn clubCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn goalsCol;
    }
}

