namespace ClientInterface
{
    partial class RegistrationtoDataBase
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
            this.NicknameRegistrationButton = new System.Windows.Forms.Button();
            this.UsernameClearButton = new System.Windows.Forms.Button();
            this.UserNameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.WarnigLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(109, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(441, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Plese sign in before connectiong ChatRoom";
            // 
            // NicknameRegistrationButton
            // 
            this.NicknameRegistrationButton.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NicknameRegistrationButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.NicknameRegistrationButton.Location = new System.Drawing.Point(270, 163);
            this.NicknameRegistrationButton.Name = "NicknameRegistrationButton";
            this.NicknameRegistrationButton.Size = new System.Drawing.Size(86, 34);
            this.NicknameRegistrationButton.TabIndex = 28;
            this.NicknameRegistrationButton.Text = "Register";
            this.NicknameRegistrationButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.NicknameRegistrationButton.UseVisualStyleBackColor = true;
            this.NicknameRegistrationButton.Click += new System.EventHandler(this.NicknameConfirmationButton_Click);
            // 
            // UsernameClearButton
            // 
            this.UsernameClearButton.BackColor = System.Drawing.Color.Red;
            this.UsernameClearButton.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameClearButton.Location = new System.Drawing.Point(471, 106);
            this.UsernameClearButton.Name = "UsernameClearButton";
            this.UsernameClearButton.Size = new System.Drawing.Size(79, 27);
            this.UsernameClearButton.TabIndex = 27;
            this.UsernameClearButton.Text = "Clear";
            this.UsernameClearButton.UseVisualStyleBackColor = false;
            // 
            // UserNameBox
            // 
            this.UserNameBox.Location = new System.Drawing.Point(254, 113);
            this.UserNameBox.Name = "UserNameBox";
            this.UserNameBox.Size = new System.Drawing.Size(143, 20);
            this.UserNameBox.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 26);
            this.label2.TabIndex = 25;
            this.label2.Text = "Enter Your UserName:";
            // 
            // WarnigLabel
            // 
            this.WarnigLabel.AutoSize = true;
            this.WarnigLabel.Location = new System.Drawing.Point(270, 213);
            this.WarnigLabel.Name = "WarnigLabel";
            this.WarnigLabel.Size = new System.Drawing.Size(35, 13);
            this.WarnigLabel.TabIndex = 29;
            this.WarnigLabel.Text = "label3";
            // 
            // RegistrationtoDataBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(589, 261);
            this.Controls.Add(this.WarnigLabel);
            this.Controls.Add(this.NicknameRegistrationButton);
            this.Controls.Add(this.UsernameClearButton);
            this.Controls.Add(this.UserNameBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RegistrationtoDataBase";
            this.Text = "RegistrationtoDataBase";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button NicknameRegistrationButton;
        private System.Windows.Forms.Button UsernameClearButton;
        public System.Windows.Forms.TextBox UserNameBox;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label WarnigLabel;
    }
}