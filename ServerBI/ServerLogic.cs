﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using CommonTypes;
using System.IO;

namespace ServerBI
{
    public class ServerLogic
    {
        public delegate void ServerActivity(MessageData delMesData);
        public static event ServerActivity newuserconnected ;
        public static event ServerActivity messgesent;

        public static List<UserData> listofUsersontheserver;





   
        public static void ServerOnline(ServerData sData)
       
          {
            TcpListener server = new TcpListener( IPAddress.Parse(sData.IPadress), sData.Portnumber);            
            Task t1 = Task.Run(() => StartListening(server));        
          }



        public static void StartListening(TcpListener serv)

        {
            listofUsersontheserver = new List<UserData>();
            try
            {
                serv.Start();
                
                while (true)
                {
                    TcpClient client = serv.AcceptTcpClient();
                    //TcpClient client = serv.AcceptTcpClient();                        
                    NetworkStream netStream = client.GetStream();                       
                        BinaryFormatter bf = new BinaryFormatter();
                        MessageData mData = (MessageData)bf.Deserialize(netStream);
                        




                    switch(mData.action)

                    {       // IP and Port Validation
                        case ClientAction.IpandPortValidaton:
                            mData.listofUsers = listofUsersontheserver;
                            bf.Serialize(netStream, mData);
                            break;



                        //User Connection

                        case ClientAction.Connection:
                            mData.Time = DateTime.Now;
                            mData.Textmessage = mData.Userdat.Username.ToString() + " Connected: ";
                            newuserconnected(mData);
                            listofUsersontheserver.Add(mData.Userdat);
                            bf.Serialize(netStream, mData);
                            break;

                        //Messages
                        case ClientAction.Sendmessage:
                            messgesent(mData);
                            bf.Serialize(netStream, mData);
                            break;

                    }
                        
                     
                       
                                                       
                                   
                }
            }
            finally
            {
                serv.Stop();

            }

        }
            
        public static void StopListening()

        {


        }

    }
}
