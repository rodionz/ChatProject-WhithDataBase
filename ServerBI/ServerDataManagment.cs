using Chat.DAL;
using CommonTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerBI
{
    class ServerDataManagment
    {
        internal static bool UserNametoDataBaseValidation()
        {
            using ( var context = new ChatContext())
            {

                return true;

            }

        }

        internal static void AddUsertoDataBase(Client c )
        {
            using (var context = new ChatContext())
            {
               

                context.Clients.Add(c);

                context.SaveChanges();


            }


        }

        internal static void RemoveUserfromDataBase()
        {
            using (var context = new ChatContext())
            {



            }


        }

       internal static void SaveMessagetoDataBase()
        {
            using (var context = new ChatContext())
            {



            }


        }

        internal static List<Client> ReturnListofAllRegisteredUsers()
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
    }
}
