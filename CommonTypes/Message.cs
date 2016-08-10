using System;
using System.Collections.Generic;

namespace CommonTypes
{
    [Serializable]
  public  class Message : CommonVariables

    {
        

        public Client SendingUserData
        { get; set; }

        public NetworkAction action;
  

        public string Textmessage
        { get; set; }

        public List<string> listofnamesforPrivateMessage;
      


        public List<Client> ListofUserinDatabase;

        public List<Client> ListofTakenUserNames;


        public DateTime SendingTime
        { get; set; }


        /* In the case, when you have more then one recipient you need to store
        all id's in collection, and it is very difficult ( at least i didn't found any simple solution)
        to store any kind of collection (List, Array, ICollection) as a column to the database. So i've decided to
        convert it to the string
    */
        public string RecipientsID
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
