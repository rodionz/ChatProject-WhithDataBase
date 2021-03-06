﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using CommonTypes;
using System.Net.NetworkInformation;
using System.Threading;
using System.Collections.Generic;

namespace ServerBI
{
    public class ServerLogic
    {
      
        public static event Action ServerShutDown;
        public static event Action ConnecionWhithWrongIPorPort;     
        public static event Action<Message, NetworkStream>   ipandportvalidation;
        public static event Action<Message, NetworkStream> connection;
        public static event Action<Message, NetworkStream> publicmessage;
        public static event Action<Message, NetworkStream> ListofUsersRequest;
        public static event Action<Message, NetworkStream, Client> Userdicsconnecter;      
        public static event Action<Message, NetworkStream> PrivateMessage;
        private static TcpListener server;
        static Task mainTask;
        static Task StarttoListen;



        public async static void ServerOnline(Server sData)

        {           
                server = new TcpListener(IPAddress.Parse(sData.IPadress), sData.Portnumber);
                ServerProps.ServerisOnline = true;
                ipandportvalidation += ServerEventHandlers.IPandPortValidationHandler;
                connection += ServerEventHandlers.ConnectionHandler;
                publicmessage += ServerEventHandlers.PublicMessageHandler;
                ListofUsersRequest += ServerEventHandlers.UsersList_andDataBaseRequestHandler;
                Userdicsconnecter += ServerEventHandlers.DisconnectUser;              
                ServerEventHandlers.UserDisconnectedUnexpected += ServerEventHandlers.UnexpectedDisconnectionHandler;
                mainTask = Task.Run(() => WaitingforNewConnections(server, NetworkAction.Connection));
                await mainTask;
                mainTask.Dispose();         
        }

        public static void WaitingforNewConnections(TcpListener serv, NetworkAction NecAct)

        {
            try
            {                               
                serv.Start();

                while (ServerProps.ServerisOnline)
                {
                    //exit point for function in order to complete task
                    if (!ServerProps.ServerisOnline)
                        return;

                    /*
         This property servs as a detector of network interferences (like Network Cabble disconnection)
         Please see more information inside of ClientProps class
               */
                    if (!ServerProps.NetworkisOK)
                    {
                        ServerProps.ServerisOnline = false;
                        ServerShutDown();
                        Finalising();
                        return;
                    }
                    TcpClient client = serv.AcceptTcpClient();                
                     StarttoListen = Task.Run(() => StartListeningtoMessages(client));                                      
                }
                return;              
            }

            catch (SocketException)
            {
                         
               if (!ServerProps.ManualSidconnection && ServerProps.ServerisOnline)
                {
                    ConnecionWhithWrongIPorPort();
                    
                }
                Finalising();
                // another exit point in the case of exeption
                ServerProps.ServerisOnline = false;
                return;
            }

            catch(Exception ex)
            {
                Finalising();
                return;
            }
        }                                                                                   
                                                       

        private static void StartListeningtoMessages(TcpClient localient)
        {
            BinaryFormatter bf = new BinaryFormatter();
            NetworkStream netStr = localient.GetStream();   
                 
            while (ServerProps.ServerisOnline)
            {
                try
                {
                    while (!netStr.DataAvailable)
                    {
                        //exit point for the function in order to complete the task  
                        if (!ServerProps.ServerisOnline)
                            return;

                        if (!ServerProps.NetworkisOK)
                        {
                            ServerProps.ServerisOnline = false;
                            Finalising();
                            return;
                        }
                        /* I found out that every infinity loop creates heavy load on the processor. 
                    For example this apllication took close to 100% of CPU, he simpliest solution
                    that i found was to include small time delay in every infinity loop
                        */
                        Thread.Sleep(100);
                    }
                }

                catch
                {
                    return;
                }



                Message mData = (Message)bf.Deserialize(netStr);

            
                // Server handles each message according to its "Network Action" parameter
                switch (mData.action)

                {
                    case NetworkAction.IpandPortValidaton:
                        ipandportvalidation(mData, netStr);
                        mData.action = NetworkAction.None;
                        break;

                    case NetworkAction.Connection:
                        connection(mData, netStr);
                        mData.action = NetworkAction.ConectionREsponse;
                        publicmessage(mData, netStr);
                        mData.action = NetworkAction.None;
                        break;

                    
                    case NetworkAction.Sendmessage:
                        publicmessage(mData, netStr);
                        mData.RecipientsID = null;
                        ServerDataManagment.MessageSavingtoDatabase(mData);
                        mData.action = NetworkAction.None;
                        break;

                    case NetworkAction.SendPrivateMessage:
                     List<int> allrecipientslist  =  ServerEventHandlers.PrivatemessageHandler(mData, netStr);

                        /* In the case, when you have more then one recipient you need to store
                         all id's in collection, and it is very difficult ( at least i didn't found any simple solution)
                         to store any kind of collection (List, Array, ICollection) as a column to the database. So i've decided to
                         convert it to the string.
                           */

                        mData.RecipientsID = ""; 
                       foreach (int n in allrecipientslist)
                        {
                            mData.RecipientsID = mData.RecipientsID + " " + n.ToString();
                        }

                        ServerDataManagment.MessageSavingtoDatabase(mData);                      
                        mData.action = NetworkAction.None;
                        break;

                    case NetworkAction.RequestforListofUsers:
                        ListofUsersRequest( mData, netStr);
                        mData.action = NetworkAction.None;
                        break;


                    case NetworkAction.UserDisconnection:
                        Client uData = mData.SendingUserData;

                        /* Deleting of users from those lists costed a lot of troubles 
                         * because of inconsistency of list sizes, 
                        so i decided to replase them whith null's
                            */
                      ServerProps.StreamsofClients[mData.SendingUserData.UseridinLists].Close();
                      ServerProps.StreamsofClients[mData.SendingUserData.UseridinLists].Dispose();                                      
                        ServerProps.listofUsersontheserver[mData.SendingUserData.UseridinLists] = null;
                        ServerProps.StreamsofClients[mData.SendingUserData.UseridinLists] = null;                                                                                     
                        Userdicsconnecter(mData, netStr, uData);
                        mData.action = NetworkAction.None;
                        break;


                    case NetworkAction.DataBaseRegistration:
                       
                        mData.SendingUserData.IsConnected = false;
                        mData.SendingUserData.LastConnectionDate = DateTime.Now;
                        ServerDataManagment.AddUsertoDataBase(mData.SendingUserData);
                        break;

                    case NetworkAction.Checkifregisterd:
                    mData.SendingUserData.Registered = ServerDataManagment.ChekifUserRegistred(mData.SendingUserData);
                        bf.Serialize(netStr, mData);
                        break;

                    case NetworkAction.None:                      
                        break;
                        
                }
            }
            return;
        }


        public static void StopListening()
        {
            ServerProps.ServerisOnline = false;
            Message byebye = new Message();
            byebye.Textmessage = "\n Goodbye to Everyone \n You were disconnected ";
            byebye.action = NetworkAction.SeverDisconnection;
            NetworkStream ns = null;        
            ServerEventHandlers.PublicMessageHandler(byebye, ns);
            Finalising();

        }

        public static void Finalising()
        {
            try
            {

                foreach (NetworkStream ns in ServerProps.StreamsofClients)
                {
                    if (ns != null && ns.CanRead)
                    {
                        ns.Close();
                        ns.Dispose();
                    }
                }

                foreach (Client c in ServerProps.listofUsersontheserver)
                    ServerDataManagment.DisConnectionUpdate(c);

                ServerShutDown();
                server.Stop();
                ServerProps.listofUsersontheserver.Clear();
                ServerProps.StreamsofClients.Clear();
                ipandportvalidation -= ServerEventHandlers.IPandPortValidationHandler;
                connection -= ServerEventHandlers.ConnectionHandler;
                publicmessage -= ServerEventHandlers.PublicMessageHandler;
                ListofUsersRequest -= ServerEventHandlers.UsersList_andDataBaseRequestHandler;
                Userdicsconnecter -= ServerEventHandlers.DisconnectUser;
                ServerEventHandlers.UserDisconnectedUnexpected -= ServerEventHandlers.UnexpectedDisconnectionHandler;
            }         
            catch
            {
                return;
            }
            }
        }
    }

