namespace ServerInterface
{
    partial class DataBaseInterface
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SearchByKeyword = new System.Windows.Forms.Button();
            this.SearchByDate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SearchUserByName = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.serchUserbyId = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.deleteUser = new System.Windows.Forms.Button();
            this.messageListBox = new System.Windows.Forms.ListBox();
            this.messageSearchResultsLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.userListBox = new System.Windows.Forms.ListBox();
            this.CleanUsersResultsButton = new System.Windows.Forms.Button();
            this.ClearMessageResultsButton = new System.Windows.Forms.Button();
            this.IDTextBox = new System.Windows.Forms.MaskedTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(107, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search Message";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(121, 56);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 22);
            this.textBox1.TabIndex = 1;
            // 
            // SearchByKeyword
            // 
            this.SearchByKeyword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SearchByKeyword.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchByKeyword.Location = new System.Drawing.Point(331, 56);
            this.SearchByKeyword.Name = "SearchByKeyword";
            this.SearchByKeyword.Size = new System.Drawing.Size(77, 22);
            this.SearchByKeyword.TabIndex = 2;
            this.SearchByKeyword.Text = "Search";
            this.SearchByKeyword.UseVisualStyleBackColor = true;
            this.SearchByKeyword.Click += new System.EventHandler(this.SearchByKeywordClick);
            // 
            // SearchByDate
            // 
            this.SearchByDate.Location = new System.Drawing.Point(331, 108);
            this.SearchByDate.Name = "SearchByDate";
            this.SearchByDate.Size = new System.Drawing.Size(75, 23);
            this.SearchByDate.TabIndex = 5;
            this.SearchByDate.Text = "Search";
            this.SearchByDate.UseVisualStyleBackColor = true;
            this.SearchByDate.Click += new System.EventHandler(this.searchbydate);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(12, 349);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(263, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "Delete User fron Database : ";
            // 
            // SearchUserByName
            // 
            this.SearchUserByName.Location = new System.Drawing.Point(331, 50);
            this.SearchUserByName.Name = "SearchUserByName";
            this.SearchUserByName.Size = new System.Drawing.Size(75, 23);
            this.SearchUserByName.TabIndex = 8;
            this.SearchUserByName.Text = "Search";
            this.SearchUserByName.UseVisualStyleBackColor = true;
            this.SearchUserByName.Click += new System.EventHandler(this.SearchUserByName_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(121, 53);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(120, 22);
            this.textBox3.TabIndex = 7;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(129, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 28);
            this.label3.TabIndex = 6;
            this.label3.Text = "Search User";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.SearchByDate);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.SearchByKeyword);
            this.panel1.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(64, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(422, 145);
            this.panel1.TabIndex = 9;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(121, 113);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(194, 22);
            this.dateTimePicker1.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "By date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "By Keyword";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.IDTextBox);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.serchUserbyId);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.textBox3);
            this.panel2.Controls.Add(this.SearchUserByName);
            this.panel2.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(64, 186);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(422, 157);
            this.panel2.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(29, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "By Id";
            // 
            // serchUserbyId
            // 
            this.serchUserbyId.Location = new System.Drawing.Point(331, 100);
            this.serchUserbyId.Name = "serchUserbyId";
            this.serchUserbyId.Size = new System.Drawing.Size(75, 23);
            this.serchUserbyId.TabIndex = 11;
            this.serchUserbyId.Text = "Search";
            this.serchUserbyId.UseVisualStyleBackColor = true;
            this.serchUserbyId.Click += new System.EventHandler(this.serchUserbyId_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(29, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "By name";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(351, 349);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 11;
            // 
            // deleteUser
            // 
            this.deleteUser.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteUser.ForeColor = System.Drawing.Color.Red;
            this.deleteUser.Location = new System.Drawing.Point(225, 399);
            this.deleteUser.Name = "deleteUser";
            this.deleteUser.Size = new System.Drawing.Size(94, 31);
            this.deleteUser.TabIndex = 12;
            this.deleteUser.Text = "Delete User";
            this.deleteUser.UseVisualStyleBackColor = true;
            this.deleteUser.Click += new System.EventHandler(this.deleteUser_Click);
            // 
            // messageListBox
            // 
            this.messageListBox.FormattingEnabled = true;
            this.messageListBox.Location = new System.Drawing.Point(570, 12);
            this.messageListBox.Name = "messageListBox";
            this.messageListBox.Size = new System.Drawing.Size(196, 95);
            this.messageListBox.TabIndex = 13;
            // 
            // messageSearchResultsLabel
            // 
            this.messageSearchResultsLabel.AutoSize = true;
            this.messageSearchResultsLabel.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageSearchResultsLabel.Location = new System.Drawing.Point(506, 12);
            this.messageSearchResultsLabel.Name = "messageSearchResultsLabel";
            this.messageSearchResultsLabel.Size = new System.Drawing.Size(58, 18);
            this.messageSearchResultsLabel.TabIndex = 14;
            this.messageSearchResultsLabel.Text = "Results :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(492, 186);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 18);
            this.label8.TabIndex = 16;
            this.label8.Text = "Results :";
            // 
            // userListBox
            // 
            this.userListBox.FormattingEnabled = true;
            this.userListBox.Location = new System.Drawing.Point(570, 198);
            this.userListBox.Name = "userListBox";
            this.userListBox.Size = new System.Drawing.Size(196, 95);
            this.userListBox.TabIndex = 15;
            // 
            // CleanUsersResultsButton
            // 
            this.CleanUsersResultsButton.BackColor = System.Drawing.Color.Red;
            this.CleanUsersResultsButton.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CleanUsersResultsButton.Location = new System.Drawing.Point(620, 311);
            this.CleanUsersResultsButton.Name = "CleanUsersResultsButton";
            this.CleanUsersResultsButton.Size = new System.Drawing.Size(96, 32);
            this.CleanUsersResultsButton.TabIndex = 18;
            this.CleanUsersResultsButton.Text = "Clear";
            this.CleanUsersResultsButton.UseVisualStyleBackColor = false;
            // 
            // ClearMessageResultsButton
            // 
            this.ClearMessageResultsButton.BackColor = System.Drawing.Color.Red;
            this.ClearMessageResultsButton.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearMessageResultsButton.Location = new System.Drawing.Point(620, 125);
            this.ClearMessageResultsButton.Name = "ClearMessageResultsButton";
            this.ClearMessageResultsButton.Size = new System.Drawing.Size(88, 33);
            this.ClearMessageResultsButton.TabIndex = 19;
            this.ClearMessageResultsButton.Text = "Clear";
            this.ClearMessageResultsButton.UseVisualStyleBackColor = false;
            // 
            // IDTextBox
            // 
            this.IDTextBox.Location = new System.Drawing.Point(121, 101);
            this.IDTextBox.Mask = "00000";
            this.IDTextBox.Name = "IDTextBox";
            this.IDTextBox.Size = new System.Drawing.Size(120, 22);
            this.IDTextBox.TabIndex = 13;
            this.IDTextBox.ValidatingType = typeof(int);
            // 
            // DataBaseInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(860, 455);
            this.Controls.Add(this.ClearMessageResultsButton);
            this.Controls.Add(this.CleanUsersResultsButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.userListBox);
            this.Controls.Add(this.messageSearchResultsLabel);
            this.Controls.Add(this.messageListBox);
            this.Controls.Add(this.deleteUser);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Name = "DataBaseInterface";
            this.Text = "DataBaseInterface";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button SearchByKeyword;
        private System.Windows.Forms.Button SearchByDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SearchUserByName;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button serchUserbyId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button deleteUser;
        private System.Windows.Forms.ListBox messageListBox;
        private System.Windows.Forms.Label messageSearchResultsLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox userListBox;
        private System.Windows.Forms.Button CleanUsersResultsButton;
        private System.Windows.Forms.Button ClearMessageResultsButton;
        private System.Windows.Forms.MaskedTextBox IDTextBox;
    }
}