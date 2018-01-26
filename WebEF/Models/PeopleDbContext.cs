using System;
using System.Collections.Generic;
using System.Data.Entity; // add this
using System.Linq;
using System.Web;

namespace WebEF.Models
{
    public class PeopleDbContext : DbContext
    {
        public PeopleDbContext() : base("name=PeopleDbContext")
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}