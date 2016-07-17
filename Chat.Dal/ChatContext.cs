using CommonTypes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.DAL
{
    public class ChatContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Server> Server { get; set; }


    }
}
