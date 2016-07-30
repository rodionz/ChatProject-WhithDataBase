using ClientBL;
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

            ClientInterfaceProps.thisClient.Username = UserNameBox.Text;
            UserLogic.RegistrationtoDataBase(ClientInterfaceProps.thisClient);

            ClientInterfaceProps.ListofRegesterdUsernames.Add(ClientInterfaceProps.thisClient.Username);

            MessageBox.Show("Registration Successful", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Close();
        }
    }
}
