using System;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using CommonTypes;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading;
using System.Collections.Generic;
using System.Collections;

namespace ClientBL
{
    public class UserLogic

    {

        public static event Action<string> NoConnectionWhithServerEvent;
        public static event Action ServerDisconnected;
        public static event Action<Message> MessageRecieved;



        public static bool GlobalValidIpandPort;
        public static NetworkAction LolacAction;
        public static Message LockalmesData;
        private static TcpClient client;

        static Task listening;






        /*         
         The separate function fot IP and Port validation was intended,
         besides validating it returns list of Usernames for the folowing username validation
            */
        public static void IPAndPortValidation_andRequestforUserLists(Message premesData)

        {

            Message returning;

            TcpClient preclient = new TcpClient();
           

            try
            {

                /* Please Pay Attention that attempt to connect to unexisting server will cause
                a delay (7 - 10 seconds) untill it throws an exeption
                */
                preclient.Connect(premesData.SendingUserData.IPadress, premesData.SendingUserData.Portnumber);

                using (NetworkStream netStream = preclient.GetStream())
                {
                    BinaryFormatter bFormat = new BinaryFormatter();
                    bFormat.Serialize(netStream, premesData);
                    returning = (Message)bFormat.Deserialize(netStream);
                    ClientProps.listofUserfortheUsers = returning.ListofTakenUserNames;
                    ClientProps.listofRegisteredUsers = returning.ListofUserinDatabase;
                    GlobalValidIpandPort = true;
                }
            }

            catch (SocketException)
            {
                GlobalValidIpandPort = false;
                NoConnectionWhithServerEvent("There is no server whith these parameters ");
            }

            finally
            {
                preclient.Close();
            }

        }

        public static void RegistrationtoDataBase(Client newclient)
        {
            TcpClient register = new TcpClient();

            try
            {
                register.Connect(newclient.IPadress, newclient.Portnumber);
                using (NetworkStream nStream = register.GetStream())
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    Message reg = new Message();
                    reg.action = NetworkAction.DataBaseRegistration;
                    reg.SendingUserData = newclient;
                    bf.Serialize(nStream, reg);
                }

            }

            catch
            {

            }

            finally
            {
                register.Close();
            }

        }

        public static bool CheckifClientisRegistered(Client newclient)
        {
            TcpClient register = new TcpClient();

            try
            {
                register.Connect(newclient.IPadress, newclient.Portnumber);
                using (NetworkStream nStream = register.GetStream())
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    Message reg = new Message();
                    reg.action = NetworkAction.Checkifregisterd;               
                    reg.SendingUserData = newclient;


                    // This Feature Provides information about each clent's IP and Port to the Server

                    string local = register.Client.LocalEndPoint.ToString();
                   
                    char[] separ = { ':' };
                    string[] ipandport = local.Split(separ); 
                    reg.SendingUserData.IPadress = ipandport[0];                   
                    reg.SendingUserData.Portnumber = int.Parse(ipandport[1]);
                    ClientProps.RealIP = reg.SendingUserData.IPadress;
                    ClientProps.RealPort = reg.SendingUserData.Portnumber;
                    //////////////////////////////////////////////////////////////////////////



                    bf.Serialize(nStream, reg);
                    Message ANSWER = (Message)bf.Deserialize(nStream);
                    if (ANSWER.SendingUserData.Registered)
                        return true;
                    else
                        return false;
                }

            }

           

            finally
            {
                register.Close();
            }

        }


        public async static void ConnecttoServer(Message mData, Client uData)
        {

            try
            {
                client = new TcpClient();
                Message returning = new Message();
                Client Localuser = uData;
                client.Connect(IPAddress.Parse(mData.SendingUserData.IPadress), mData.SendingUserData.Portnumber);
                ClientProps.LocalClient = client;
                BinaryFormatter Bformat = new BinaryFormatter();
                NetworkStream stream = client.GetStream();
                ClientProps.clientStream = stream;


                mData.SendingUserData.IPadress = ClientProps.RealIP;
                mData.SendingUserData.Portnumber = ClientProps.RealPort;
                //////////////////////////////////////////////////////////////////////////


                Bformat.Serialize(stream, mData);
                ClientProps.UserisOnline = true;
                stream.Flush();
                listening = Task.Run(() => StariListenToIncomingMessages(Localuser));
                await listening;
                listening.Dispose();
            }


            catch
            {
                NoConnectionWhithServerEvent("Server is offline");
                ServerDisconnected();
            }
            


            }
        private static void StariListenToIncomingMessages(Client currentUser)
        {
            BinaryFormatter listerformatter = new BinaryFormatter();
            Message incoming = new Message();
            NetworkStream usernetstream = ClientProps.clientStream;

            

            while (ClientProps.UserisOnline)
            {
                /* I found out that every infinity loop creates heavy load on the processor. 
               For example this apllication took close to 100% of CPU, the simpliest solution
               that i found was to include small time delay in every infinity loop
                   */
                Thread.Sleep(100);




                /*
        This property servs as a detector of network interferences (like Network Cable disconnection)
        Please see more information inside of ClientProps class
              */
                if (!ClientProps.NetworkisOK)
                {
                    NoConnectionWhithServerEvent("Internet connection was lost");

                    Disconnection(currentUser);

                    return;
                }


                if (!usernetstream.CanRead || ClientProps.shutdown)
                {
                    client.Close();
                    return;
                }

                if (usernetstream.DataAvailable)
                {
                    incoming = (Message)listerformatter.Deserialize(usernetstream);

                    if (incoming.action == NetworkAction.ConectionREsponse && incoming.SendingUserData.Username == currentUser.Username)
                    {
                        currentUser.UseridinLists = incoming.SendingUserData.UseridinLists;
                        MessageRecieved(incoming);
                    }




                    else if (incoming.action == NetworkAction.SeverDisconnection)
                    {
                        MessageRecieved(incoming);
                        ServerDisconnected();
                        ClientProps.UserisOnline = false;

                        usernetstream.Dispose();
                        client.Close();
                    }

                    else
                        MessageRecieved(incoming);

                }

                incoming.action = NetworkAction.None;
            }

            return;
        }


        public static void SendMessage(Message outcoming)
        {

            try
            {

                BinaryFormatter sendingformatter = new BinaryFormatter();
                NetworkStream localstrem = ClientProps.clientStream;
                sendingformatter.Serialize(localstrem, outcoming);


          /*
          This property servs as a detector of network interferences (like Network Cable disconnection)
          Please see more information inside of ClientProps class
                */
                if (!ClientProps.Network_Works)
                {

                    ClientProps.UserisOnline = false;
                    NoConnectionWhithServerEvent("Connection Was Lost!");
                    client.Close();
                    return;
                }

               
            }

            catch (Exception io)

            {
                ClientProps.UserisOnline = false;
                NoConnectionWhithServerEvent("Connection whith the server Was Lost!");
                client.Close();
                return;
            }


          
            
        }






        public static void Disconnection(Client uData)

        {
            
            GlobalValidIpandPort = false;
            Message mData = new Message(uData, NetworkAction.UserDisconnection);
            BinaryFormatter disconnect = new BinaryFormatter();
            NetworkStream local = ClientProps.clientStream;

          


            try
            {
                disconnect.Serialize(local, mData);
                
            }

           catch
            {
                
            }




            try
            {
                ClientProps.clientStream.Close();
                ClientProps.clientStream.Dispose();
            }


            finally
            {
                client.Close();
            }

        }


    }
}