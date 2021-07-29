using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Common
{
    public class AppDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public AppDbContext() : base("DefaultConnection")
        { }
    }
}
