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
                messageListBox.Items.AddRange(results);
            }

            else
            {
                messageListBox.Items.Add("No results ");
            }
        }

        private void searchbydate(object sender, EventArgs e)
        {
            CommonTypes.Message[] results = ServerDataManagment.MessageSearchbyDate(dateTimePicker1.Value);
        }

        private void deleteUser_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
