using System;

namespace CommonTypes
{
    [Serializable]
   public class Server : CommonVariables
    {
        public string IPadress
        { get; set; }

        public int Portnumber
        { get; set; }
    }
}
