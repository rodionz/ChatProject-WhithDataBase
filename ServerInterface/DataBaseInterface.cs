using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServerBI;
using CommonTypes;

namespace ServerInterface
{
    public partial class DataBaseInterface : Form
    {
        public DataBaseInterface()
        {
            InitializeComponent();
        }


        List<Client> allClients;


        private void SearchUserByName_Click(object sender, EventArgs e)
        {
            Client[] clients = ServerDataManagment.UserSearchbyName(textBox3.Text);

            if (clients.Length != 0)
            {
                foreach(Client c in clients)
                {
                    userListBox.Items.Add(c.Username);
                }
            }

            else
            {
                userListBox.Items.Add("No results ");
            }
        }

        private void serchUserbyId_Click(object sender, EventArgs e)
        {
            Client[] results = ServerDataManagment.UserSearchbyID(int.Parse(IDTextBox.Text));

            if (results.Length != 0)
            {
                foreach (Client c in results)
                {
                    userListBox.Items.Add(c.Username);
                }
            }

            else
            {
                userListBox.Items.Add("No results ");
            }
        }
    

        private void SearchByKeywordClick(object sender, EventArgs e)
        {
            CommonTypes.Message[] results = ServerDataManagment.MessageSearchbyText(textBox1.Text);

            if(results.Length != 0)
            {
                foreach(CommonTypes.Message m in results)
                {
                    messageListBox.Items.Add(m.Textmessage);
                }
            }

            else
            {
                messageListBox.Items.Add("No results ");
            }
        }

        private void searchbydate(object sender, EventArgs e)
        {
            CommonTypes.Message[] results = ServerDataManagment.MessageSearchbyDate(dateTimePicker1.Value);

            foreach(CommonTypes.Message m in results)
            {
                messageListBox.Items.Add(m.Textmessage);
            }
        }

        private void deleteUser_Click(object sender, EventArgs e)

           
        {

            if (comboBox1.SelectedText != null)
            {



                Client usertoDelete = allClients.FirstOrDefault(n => n.Username == comboBox1.SelectedItem.ToString());



                DialogResult dr = MessageBox.Show("Are you sure that you want to delete " + usertoDelete.Username + " from the Data Base ?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (dr == DialogResult.OK)
                {
                    ServerDataManagment.RemoveUserfromDataBase(usertoDelete);
                }

                comboBox1.Items.Remove(usertoDelete.Username);

               
                comboBox1.SelectedText = "";
                comboBox1.Text = "";
                MessageBox.Show(usertoDelete.Username + " Was deleted !", "User Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void DataBaseInterface_Load(object sender, EventArgs e)
        {
             allClients = ServerDataManagment.ReturnListofAllRegisteredUsers();

            foreach (Client c in allClients)
            {
                comboBox1.Items.Add(c.Username);
            }
        }

        private void ClearMessageResultsButton_Click(object sender, EventArgs e)
        {
            messageListBox.Items.Clear();
        }

        private void CleanUsersResultsButton_Click(object sender, EventArgs e)
        {
            userListBox.Items.Clear();
        }
    }
}
