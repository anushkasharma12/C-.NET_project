using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignement_2_Tickets
{
    
    public class DataContext : DbContext
    {
        //overriding method in the DbContext and configuring with Sqlite
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = ticketsDB.db");
        }

        //define table in Sqlite database and Ticket class
        public DbSet<Ticket> TicketsTable { get; set; }
    }
}
