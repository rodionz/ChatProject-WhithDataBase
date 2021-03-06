﻿using System;
using System.Linq;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using CommonTypes;

namespace ClientInterface
{
    public partial  class UserInterfaceClass : Form
    {

       

        public  void NoServerHandler(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             UserInterfaceDisconnection();
        }


        public  void IncomingMessageHandler(CommonTypes.Message mData)
        {

            if (ChatrichTextBox.InvokeRequired)
            {
                Action<CommonTypes.Message> messent = IncomingMessageHandler;
                this.Invoke(messent, new object[] { mData });
            }

            else
            {
                
                if (mData.action == NetworkAction.RequestforListofUsers)

                {
                    var names = from n in mData.ListofTakenUserNames
                                select n.Username; 


                    for(int i = 0; i < mData.ListofTakenUserNames.Count; i++)
                    {
                    
                        PrivatecheckedListBox.Items.Add(names.ToArray()[i]);

                    }
                       
                }

                else if (mData.action == NetworkAction.ConectionREsponse)
                {
                    ChatrichTextBox.SelectionColor = Color.Black;
                    ChatrichTextBox.AppendText("\nServer says: ");
                    ChatrichTextBox.SelectionColor = Color.Green;
                    ChatrichTextBox.AppendText("\n\t" + mData.Textmessage);
               

                }

                else if (mData.action == NetworkAction.UserDisconnection)
                {
                    ChatrichTextBox.SelectionColor = Color.Black;
                    ChatrichTextBox.AppendText("\n Server says: ");
                    ChatrichTextBox.SelectionColor = Color.Red;
                    ChatrichTextBox.AppendText("\n\t" + mData.Textmessage);
                    

                }

                else if (mData.action == NetworkAction.SeverDisconnection)
                {
                    ChatrichTextBox.SelectionColor = Color.Black;
                    ChatrichTextBox.AppendText("\n Server says: ");
                    ChatrichTextBox.SelectionColor = Color.Red;
                    ChatrichTextBox.AppendText("\n\t" + mData.Textmessage);
                    ChatrichTextBox.SelectionColor = Color.Black;
                }

                else
                {
                    ChatrichTextBox.SelectionColor = Color.Black;
                    ChatrichTextBox.AppendText("\n" + mData.SendingUserData.Username + " says: ");
                    ChatrichTextBox.SelectionColor = mData.color;
                    ChatrichTextBox.AppendText("\n\t" + mData.Textmessage);
                    ChatrichTextBox.SelectionColor = Color.Black;
                }
            }


        }

    }
}
