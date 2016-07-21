using System;
using System.Collections.Generic;

namespace CommonTypes
{
    [Serializable]
  public  class Message : CommonVariables

    {
        

        public Client SendingUserData
        { get; set; }
     
        public NetworkAction action
        { get; set; }

        public string Textmessage
        { get; set; }

        public List<string> listofnamesforPrivateMessage
        { get; set; }


        public ICollection<Client> ListofUserinDatabase;

        public List<Client> ListofTakenUserNames
        { get; set; }










        public Message() { }

        public Message(Client ud)
        {
            this.SendingUserData = ud;

        }

        public Message(Client ud, NetworkAction act)
        {
            this.SendingUserData = ud;
            action = act;

        }
        
    }
}
