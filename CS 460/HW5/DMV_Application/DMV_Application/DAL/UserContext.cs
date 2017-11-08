using DMV_Application.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DMV_Application.DAL
{
    public class UserContext : DbContext
    {
        public UserContext() : base("name=OurDBContext")
        { }

        public virtual DbSet<User> Users { get; set; }
    }
}