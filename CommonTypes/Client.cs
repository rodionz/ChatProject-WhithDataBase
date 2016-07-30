using System;

namespace CommonTypes
{
    [Serializable]
    public class Client : CommonVariables
    {

        public  int UseridinLists
        { get; set; }

        public string Username
        { get; set; }

        public DateTime? LastConnectionDate
        { get; set; }

        public bool? IsConnected
        { get; set; }


        public bool Registered;




        public Client()
        {

        }

        public Client(int numofuser)
        {
            this.UseridinLists = numofuser;
        }

        public Client(string IP, int PORT)
        {
            this.IPadress = IP;
            this.Portnumber = PORT;
        }

        public Client( string IP, int Port, string Username)
        {
            
            this.IPadress = IP;
            this.Portnumber = Port;
            this.Username = Username;

        }

    

        
    }
}
