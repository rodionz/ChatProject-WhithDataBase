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
        public static bool UserNametoDataBaseValidation()
        {
            using ( var context = new ChatContext())
            {

                return true;

            }

        }

        public static void AddUsertoDataBase(Client c )
        {
            using (var context = new ChatContext())
            {



            }


        }

        public static void RemoveUserfromDataBase()
        {
            using (var context = new ChatContext())
            {



            }


        }

        public static void SaveMessagetoDataBase()
        {
            using (var context = new ChatContext())
            {



            }


        }

    }
}
