﻿using ClientBL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientInterface
{
    public partial class RegistrationtoDataBase : Form
    {
        public RegistrationtoDataBase()
        {
            InitializeComponent();
        }

       

        private void NicknameConfirmationButton_Click(object sender, EventArgs e)
        {
            if (UserNameBox.Text == "")
            {
                WarnigLabel.ForeColor = Color.Red;
                WarnigLabel.Text = "Name is illigal";
            }

            else
            {
                ClientInterfaceProps.thisClient.Username = UserNameBox.Text;
                UserLogic.RegistrationtoDataBase(ClientInterfaceProps.thisClient);



                MessageBox.Show("Registration Successful", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();
            }
        }
    }
}
