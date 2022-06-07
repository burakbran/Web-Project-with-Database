using Chatflix.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Chatflix.dB
{
    public class Db : DbContext 
    {

        public Db() : base(@"Server=DESKTOP-6HJ3FVT\LOCAL;Database=Chatflix;Trusted_Connection=True;")
        {

        }

        public DbSet<Users> Users { get; set; }

    }
}
