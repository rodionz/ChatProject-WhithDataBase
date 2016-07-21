using System;
using System.Windows.Forms;
using CommonTypes;
using ServerBI;

namespace ServerInterface
{

    // I prefered to use a partial class instead of separate class for convenience
    public partial class ServerInterfaceClass : Form
    {

      
        public  void NewUserEvenHandler(CommonTypes.Message mymesdata)

        {
         
            if (CurrentUsersListbox.InvokeRequired || HistoryListbox.InvokeRequired)
            {
                Action<CommonTypes.Message> stc = NewUserEvenHandler;
                this.Invoke(stc, new object[] { mymesdata });

            }

            else
            {
              
                CurrentUsersListbox.Items.Add(mymesdata.SendingUserData.Username +" IP: " + mymesdata.SendingUserData.IPadress + 
                    " Port: " + mymesdata.SendingUserData.Portnumber);
                HistoryListbox.Items.Add(mymesdata.Textmessage + mymesdata.Time.ToLongTimeString()  );
            }
        }



        public static void AtemmttoconnectWhithWrongIPandPort_Handler()
        {

            MessageBox.Show("Creating of Server has failed, please choose another IP adress and port and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ServerLogic.ConnecionWhithWrongIPorPort -= ServerInterfaceClass.AtemmttoconnectWhithWrongIPandPort_Handler;
        }

    
        public void MessagesentHandler(CommonTypes.Message mData)
        {
            DateTime current = DateTime.Now;


            if (ChatListBox.InvokeRequired || CurrentUsersListbox.InvokeRequired || HistoryListbox.InvokeRequired )
            {
                Action<CommonTypes.Message> dicon = MessagesentHandler;
                this.Invoke(dicon, new object[] { mData });
            }



            else
            {     if (mData.action == NetworkAction.ConectionREsponse)
                {
                    ChatListBox.Items.Add("Server says: " + mData.Textmessage);
                }

            // In the case of unexpected user disconnection
                   else if (mData.action == NetworkAction.UserDisconnection)
                {
                    ChatListBox.Items.Add("Server says: " + mData.SendingUserData.Username + " was disconnected");

                    for (int i = 0; i < CurrentUsersListbox.Items.Count; i++)

                    {
                        if (CurrentUsersListbox.Items[i].ToString().Contains(mData.SendingUserData.Username))
                        {
                            CurrentUsersListbox.Items.Remove(CurrentUsersListbox.Items[i]);
                            break;
                        }

                    }

                    HistoryListbox.Items.Add(mData.SendingUserData.Username + " was disconnected" + current.ToLongTimeString());
                }


            else if (mData.action == NetworkAction.SeverDisconnection)
                {

                    ChatListBox.Items.Add(mData.Textmessage);
                }
                else
                {
                    ChatListBox.Items.Add(mData.SendingUserData.Username + " says: " + mData.Textmessage);
                }
            }
        }

        public  void NoServerHandler()
        {


            try
        {
                if (ServerPanel.InvokeRequired)
                {
                    Action dicon = NoServerHandler;
                    this.Invoke(dicon, new object[] { });

                }

                else
                {
                    CurrentUsersListbox.Items.Clear();
                    HistoryListbox.Items.Clear();
                    ChatListBox.Items.Clear();
                    RedLightPanel.Visible = true;
                    GreenLightPanel.Visible = false;
                    StartServerButton.Enabled = true;
                    StopServerButton.Enabled = false;
                    //if(!ServerBools.WasPrinted)
                        //MessageBox.Show("Connection was suddenly lost ", "Network Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        //ServerBools.WasPrinted = true;
                }
            }
            catch 
            {
                return;
            }
            }

      
        public void DisconnectUserHAndler(Client uData)
        {
            if (ServerPanel.InvokeRequired)
            {
                Action <Client> dicon = DisconnectUserHAndler;
                Invoke(dicon, new object[] {uData });
            }


            else
            {
                DateTime current = DateTime.Now;
                    
             for(int i = 0;  i< CurrentUsersListbox.Items.Count; i++)

                {
                    if (CurrentUsersListbox.Items[i].ToString().Contains(uData.Username))
                    {
                        CurrentUsersListbox.Items.Remove(CurrentUsersListbox.Items[i]);
                        break;
                    }

                }
                            
                
                HistoryListbox.Items.Add(uData.Username + " was disconnected " + current.ToLongTimeString());
                ChatListBox.Items.Add("Server says: " + uData.Username + " was disconnected " );

            }
            
        }

}
}
