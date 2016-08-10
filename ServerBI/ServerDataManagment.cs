using Chat.DAL;
using CommonTypes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerBI
{
   public  class ServerDataManagment
    {
       
        internal static void AddUsertoDataBase(Client c )
        {
            using (var context = new ChatContext())
            {
               

                context.Clients.Add(c);

                context.SaveChanges();


            }


        }

        public static void RemoveUserfromDataBase(Client toDEL)
        {
            using (var context = new ChatContext())
            {

                context.Entry(toDEL).State = EntityState.Deleted;

                context.SaveChanges();



            }


        }

    

        public static List<Client> ReturnListofAllRegisteredUsers()
        {
            using (var context = new ChatContext())
            {
                var names = from n in context.Clients
                            select n;

                return names.ToList();

            }
        }

        internal static bool ChekifUserRegistred(Client c)
        {

            using (var context = new ChatContext())
            {
                var names = from n in context.Clients
                            select n.Username;

                if (names.Contains(c.Username))
                    return true;

                else
                    return false;

                        


            }


        }

        internal static void ConnectionUpdate(Client c)
        {
            Client toupdate;
            using (var context = new ChatContext())
            {
                toupdate = context.Clients.Where(s => s.Username == c.Username).FirstOrDefault();
            }

            if(toupdate != null)
            {
                toupdate.IPadress = c.IPadress;
                toupdate.Portnumber = c.Portnumber;
                toupdate.IsConnected = true;
                toupdate.LastConnectionDate = DateTime.Now;
            }

            using (var context = new ChatContext())
            {

                context.Entry(toupdate).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();

            }

        }


        internal static void DisConnectionUpdate(Client c)
        {
            Client toupdate;
            using (var context = new ChatContext())
            {
                toupdate = context.Clients.Where(s => s.Username == c.Username).FirstOrDefault<Client>();
            }

            if (toupdate != null)
            {

                toupdate.IsConnected = false;



                using (var context = new ChatContext())
                {

                    context.Entry(toupdate).State = EntityState.Modified;
                    context.SaveChanges();

                }
            }

        }

        internal static void DisconnectEveryone()
        {


        }

        internal static void PublicMessagetoDatabase(Message mData)
        {
            Client x;

            using (var context = new ChatContext())
            {

                x = context.Clients.Where(n => n.Username == mData.SendingUserData.Username).FirstOrDefault();

            }




            using (var context = new ChatContext())
            {
                mData.SendingUserData = x;
                context.Messages.Attach(mData);

                context.Entry(mData).State = EntityState.Added;

                context.SaveChanges();
            }
        }


        public static Message [] MessageSearchbyText (string text)
        {

            using (var context = new ChatContext())
            {
                var results = from m in context.Messages
                              where m.Textmessage.Contains(text)
                              select m;

                return results.ToArray();

            }


        }

        public static Client [] UserSearchbyName(string text)
        {
            using (var context = new ChatContext())
            {
                var results = from u in context.Clients
                              where u.Username.Contains(text)
                              select u;

                return results.ToArray();
            }
        }

        public static Client[] UserSearchbyID(int clientID)
        {
            using (var context = new ChatContext())
            {
                var results = from u in context.Clients
                              where u.ID == clientID
                              select u;

                return results.ToArray();
            }
        }

        public static Message [] MessageSearchbyDate (DateTime dt)
        {
            using (var context = new ChatContext())
            {

                //  Entity framework does not exept any ToString() functions.  This is the only solution i found.

                var allitems = context.Messages.ToList();



                var results = from m in allitems
                              where m.SendingTime.ToShortDateString()  == dt.ToShortDateString()
                              select m ;
                
                return results.ToArray();
            }

        }
    }
}
