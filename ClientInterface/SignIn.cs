using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using CommonTypes;
using ClientBL;

namespace ClientInterface
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
            
        }

        
        IPAddress clientIpAddr;       
         internal   Client new_user;
        CommonTypes.Message mData;
        internal string userNIckname;
        internal string IPasString;
        internal int userPort;
        internal List<Client> localListofUsers;
        internal List<Client> listofregisteredUsers;


        RegistrationtoDataBase RDB = new RegistrationtoDataBase();



        /* Please Pay Attention that attempt to check IP address and port of unexisting server will cause
               a delay (7 - 10 seconds) untill it throws an exeption
               */

        public void ConfirmIPandPortClick(object sender, EventArgs e)
        {

           
           
          

            this.IPmaskedTextBox.ValidatingType = typeof(IPAddress);
            char[] delimit = { ' ' };
            string[] str = IPmaskedTextBox.Text.Split();
            string separator = "";
            IPasString = string.Join(separator, str);
            bool b = IPAddress.TryParse(IPasString, out clientIpAddr);


            
         bool portvalid = int.TryParse(portTextBox.Text, out userPort);

            if(!portvalid)
            {
                MessageBox.Show("Please Fill Number of Port and IPAdress", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

           else if (!b)
            {
                WarningLabel.ForeColor = Color.Red;
                WarningLabel.Text = "Illigal IP, please enter IP adress in correct format";
            }

           else if(!userPort.PortisValid())
            {
                WarningLabel.ForeColor = Color.Red;
                WarningLabel.Text = "Port Number is Illigal \n Pelease choose port \n from 10000 to 65535";

            }

            else
            {
                ClientInterfaceProps.thisClient = new Client(IPasString, userPort);
                mData = new CommonTypes.Message(ClientInterfaceProps.thisClient, NetworkAction.IpandPortValidaton);
               UserLogic.IPAndPortValidation_andRequestforUserLists(mData);



                if ( UserLogic.GlobalValidIpandPort)
                {
                    WarningLabel.ForeColor = Color.Lime;
                    WarningLabel.Text = "IP Adress and Port are Confirmed";
                    ConfirmIPandPortButton.Enabled = false;
                    localListofUsers = ClientProps.listofUserfortheUsers;
                    listofregisteredUsers = ClientProps.listofRegisteredUsers;
                    ClientInterfaceProps.IPandPortconfirmed = UserLogic.GlobalValidIpandPort;

                }

                else
                {
                    WarningLabel.ForeColor = Color.Red;
                    WarningLabel.Text = "Service is Unavavailble, please try another adress or port";
                }
               

            }

         
        }

        private void clearIP_Click(object sender, EventArgs e)
        {
            ConfirmIPandPortButton.Enabled = true;
            IPmaskedTextBox.Clear();
            WarningLabel.Text = "";
        }

        private void UsernameClearButton_Click(object sender, EventArgs e)
        {
            UserNameBox.Clear();
            WarningLabel.Text = "";
        }

        private void Clearportbutton_Click(object sender, EventArgs e)
        {
            ConfirmIPandPortButton.Enabled = true;
            portTextBox.Clear();
           
        }

        private void ClearAll()
        {
            IPmaskedTextBox.Clear();
            UserNameBox.Clear();
            portTextBox.Clear();
            WarningLabel.Text = "";
            ConfirmIPandPortButton.Enabled = true;
            NickNameConfirmationLabel.Text = "";
           
        }

     

        private void NicknameConfirmationButton_Click(object sender, EventArgs e)
        {


            if (ClientInterfaceProps.IPandPortconfirmed)
            {


                var listofnames = from n in localListofUsers
                                  where n!= null
                                  select (n.Username);

                var listofRegestred = from name in listofregisteredUsers
                                      where name != null
                                      select (name.Username);
                    


                bool notuniqName = listofnames.Contains(UserNameBox.Text);

                bool registered = listofRegestred.Contains(UserNameBox.Text);


                if (UserNameBox.Text != "")
                {
                    if (!notuniqName)
                    {
                        NickNameConfirmationLabel.ForeColor = Color.Lime;
                        NickNameConfirmationLabel.Text = "UserName confirmed";
                        userNIckname = UserNameBox.Text;
                        ClientInterfaceProps.uNmake = userNIckname;
                        ClientInterfaceProps.NicnameConfirmed = true;
                    }

                    else if (!registered)
                    {
                     DialogResult dresult  =  MessageBox.Show("User Unregistred", "You are unregistred, please sign up", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);

                        if(dresult == DialogResult.Cancel)
                        {
                            UserNameBox.Clear();
                            NickNameConfirmationLabel.ForeColor = Color.Red;
                            NickNameConfirmationLabel.Text = "Authorisation failed, please try again";
                        }

                        else
                        {
                            RDB.ShowDialog();
                        }


                    }

                    else
                    {
                        NickNameConfirmationLabel.ForeColor = Color.Red;
                        NickNameConfirmationLabel.Text = "UserName wae already taken, please choose another one";
                    }
                }

                else
                {
                    WarningLabel.ForeColor = Color.Red;
                    WarningLabel.Text = "Name is illigal";
                }

            }

            else
            {
                WarningLabel.ForeColor = Color.Red;
                WarningLabel.Text = "Please confiirm IP Adress and port before choosing Username";
            }
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (ClientInterfaceProps.UserIsValid)
            {

                new_user = new Client( IPasString, userPort, userNIckname);
                CommonTypes.Message mData = new CommonTypes.Message(new_user);
                mData.action = NetworkAction.Connection;
                UserLogic.LolacAction = NetworkAction.Connection;               
                UserLogic.ConnecttoServer(mData , new_user);
                ClientProps.shutdown = false;
                ClearAll();
                Close();
            }

            else
            {
                MessageBox.Show("You need to confirm IPAdress, Port and UserName before connecting server", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                //ClientInterfaceProps.ResetBooleans();

            }
        }


        private void SignIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfirmIPandPortButton.Enabled = true;
            ClearAll();
        }
    }
}
