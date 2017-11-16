using DMV_Application.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DMV_Application.DAL
{
    public class DMVContext : DbContext
    {
        public DMVContext() : base("name=MyDB")
        { }

        public virtual DbSet<DMVRequest> DMVRequests { get; set; }
    }
}