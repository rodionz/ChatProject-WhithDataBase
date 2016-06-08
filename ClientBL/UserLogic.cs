﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using CommonTypes;
using System.IO;

namespace ClientBL
{
    public class UserLogic
    {

        public  delegate void Exseptions();
        public delegate void ClientBLEvents(MessageData mDAta);
        public static event Exseptions NoServer;
        public static event ClientBLEvents MessageRecieved;
        public static List<UserData> listofUserfortheUsers;
        public static bool ipandportvalid;






        public static void MainClienFinction(UserData uData)

        {            
         Task t1 = Task.Run(() =>   ConnecttoServer(uData));
        }



        public static void MainClienFinction(MessageData mesData)

        {
            Task t2 = Task.Run(() => SendMessage(mesData));
        }



        public static void  IPAndPortValidation(MessageData premesData)

        {
            MessageData returning;
            premesData.ActionCode = 1;
            TcpClient preclient = new TcpClient();

            try
            {
                preclient.Connect(premesData.Userdat.IPadress, premesData.Userdat.Portnumber);

                using (NetworkStream netStream = preclient.GetStream())
                {
                    BinaryFormatter bFormat = new BinaryFormatter();
                    bFormat.Serialize(netStream, premesData);
                    returning = (MessageData)bFormat.Deserialize(netStream);
                    listofUserfortheUsers = returning.listofUsers;
                    ipandportvalid = true;
                }
            }

            catch (SocketException SE)
            {
                NoServer();
            }

            finally
            {
                //preclient.Close();
            }

        }




        public static void ConnecttoServer (UserData uData)
        {
            TcpClient client = new TcpClient();
            MessageData returning;

            client.Connect(IPAddress.Parse (uData.IPadress), uData.Portnumber );


            NetworkStream usernetstream = client.GetStream();
            

                BinaryFormatter Bformat = new BinaryFormatter();

                Bformat.Serialize(usernetstream, new MessageData(uData, 2));
                returning = (MessageData)Bformat.Deserialize(usernetstream);
                //if (returning.ActionCode == 3)
                //{
                //    MessageRecieved(returning);
                //}

                Task UserOnline = Task.Run(() => UserisOnline(usernetstream));

            
           
        }

        public static void SendMessage(MessageData mData)
        {
            TcpClient client = new TcpClient();
            MessageData returning;

            client.Connect(IPAddress.Parse(mData.Userdat.IPadress), mData.Userdat.Portnumber);

            using (NetworkStream usernetstream = client.GetStream())
            {

                BinaryFormatter Bformat = new BinaryFormatter();
                Bformat.Serialize(usernetstream, mData);
                //returning = (MessageData)Bformat.Deserialize(usernetstream);

               

            }
        }



        public static void UserisOnline(NetworkStream online)
        {
            
           
            while(true)
            {
                NetworkStream userstream = online;
                BinaryFormatter Bformat = new BinaryFormatter();             
                 MessageData  returning = (MessageData)Bformat.Deserialize(online);
                returning = (MessageData)Bformat.Deserialize(online);
                if (returning.ActionCode == 3)
                    {
                        MessageRecieved(returning);
                    }


                


            }

        }

        public void Disconnect()
        {

        }

      

        public static void ColorwasChanged(UserData uData)
        {


        }

        public static void FontwasChanged(UserData uData)
        {

        }
    }
}
