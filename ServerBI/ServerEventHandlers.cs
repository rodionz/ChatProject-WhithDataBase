﻿using System;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using CommonTypes;
using System.IO;
using System.Collections.Generic;
using Chat.DAL;
using ServerBI;

namespace ServerBI
{
    public class ServerEventHandlers
    {
      
        public static event Action<Message> newuserconnected;
        public static event Action<Message> messgesent;
        public static event Action<Client> UserRemovalfromtheInterface;
        public static event Action<Message, NetworkStream, int> UserDisconnectedUnexpected;


        internal static void IPandPortValidationHandler( Message mData, NetworkStream nStr)

        {          
                BinaryFormatter bf = new BinaryFormatter();
                mData.ListofTakenUserNames = ServerProps.listofUsersontheserver;
                mData.ListofUserinDatabase = ServerDataManagment.ReturnListofAllRegisteredUsers();
                bf.Serialize(nStr, mData);
                return;           
        }


        internal static void ConnectionHandler( Message mData, NetworkStream nStr)
        {
            mData.SendingUserData.UseridinLists = ServerProps.StreamsofClients.Count;
            BinaryFormatter bf = new BinaryFormatter();
            ServerProps.StreamsofClients.Add(nStr);
            ServerProps.listofUsersontheserver.Add(mData.SendingUserData);            
            mData.SendingTime = DateTime.Now;
            mData.Textmessage = mData.SendingUserData.Username.ToString() + " Connected ";
            newuserconnected(mData);
            mData.action = NetworkAction.ConectionREsponse;
            //mData.SendingUserData.IsConnected = true;
            //mData.SendingUserData.LastConnectionDate = DateTime.Now;
            ServerDataManagment.ConnectionUpdate(mData.SendingUserData);
  

        }

        internal static void PublicMessageHandler( Message mData, NetworkStream nstr)
        {
            for (int i = 0; i < ServerProps.StreamsofClients.Count; i++)
            {
                try
                {
                    if (ServerProps.StreamsofClients[i] != null)
                    {
                        NetworkStream netStream = ServerProps.StreamsofClients[i];
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(netStream, mData);
                    }

                    
                }

                // Unexpected Client Disconnection
                catch(IOException)
                {
                    UserDisconnectedUnexpected(mData, nstr, i);
                }             
            }
            messgesent(mData);

        }


       internal static void UsersList_andDataBaseRequestHandler( Message mData, NetworkStream nStr)
        {           
           BinaryFormatter bf = new BinaryFormatter();
            mData.ListofTakenUserNames = new List<Client>();
            foreach(Client ud in ServerProps.listofUsersontheserver)
            {
                if (ud != null)
                    mData.ListofTakenUserNames.Add(ud);
            }
        
            mData.action = NetworkAction.RequestforListofUsers;
            bf.Serialize(nStr, mData);
        }


    //Usuall Disconnection
        internal static void DisconnectUser(Message mData, NetworkStream nStr, Client uData)
        {
            ServerDataManagment.DisConnectionUpdate(uData);
            BinaryFormatter bf = new BinaryFormatter();         

            for (int i = 0; i < ServerProps.StreamsofClients.Count; i++)
            {
               mData.Textmessage =  mData.SendingUserData.Username + " was disconnected";

                if (ServerProps.StreamsofClients[i] != null)
                {
                    mData.action = NetworkAction.UserDisconnection;
                    NetworkStream netStream = ServerProps.StreamsofClients[i];
                    bf = new BinaryFormatter();
                   
                    bf.Serialize(netStream, mData);
                }
               
            }
            UserRemovalfromtheInterface(uData);
        }


        internal static  void UnexpectedDisconnectionHandler(Message mData, NetworkStream nStream, int index)
        {
            mData = new Message();
            Client LostUser = ServerProps.listofUsersontheserver[index];
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                ServerProps.StreamsofClients[index].Close();
                ServerProps.StreamsofClients[index].Dispose();
            }

            catch { }
                            
            ServerProps.listofUsersontheserver[index] = null;
            ServerProps.StreamsofClients[index] = null;
            mData.Textmessage = LostUser.Username + " was disconnected";


            for (int x = 0; x < ServerProps.StreamsofClients.Count; x++)
            {
                if (ServerProps.StreamsofClients[x] != null)
                {
                    mData.action = NetworkAction.UserDisconnection;
                    NetworkStream _netStream = ServerProps.StreamsofClients[x];
                    bf = new BinaryFormatter();
                    bf.Serialize(_netStream, mData);
                }
            }
            ServerDataManagment.DisConnectionUpdate(LostUser);
            UserRemovalfromtheInterface(LostUser);
        }




        internal static List<int> PrivatemessageHandler(Message mData, NetworkStream nStream)
        {

            List<int> allrecipients = new List<int>();

            for (int i = 0; i < ServerProps.StreamsofClients.Count; i++)
            {
                try
                {
                    if (ServerProps.StreamsofClients[i] != null && mData.listofnamesforPrivateMessage.Contains(ServerProps.listofUsersontheserver[i].Username))
                    {
                        NetworkStream netStream = ServerProps.StreamsofClients[i];
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(netStream, mData);
                        allrecipients.Add(i);
                    }
                }
                catch(IOException)
                {
                    UserDisconnectedUnexpected(mData, nStream, i);
                }
            }
            return allrecipients;
        }
    }
}
