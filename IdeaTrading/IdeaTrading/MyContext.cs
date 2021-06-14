using IdeaTrading.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IdeaTrading
{
    public class MyContext : DbContext
    {
        public MyContext() : base("name=dbTest")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<MyContext>());
        }
        public virtual DbSet<User> Users { get; set; }
    }
}