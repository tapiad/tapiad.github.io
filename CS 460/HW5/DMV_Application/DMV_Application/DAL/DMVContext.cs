using DMV_Application.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DMV_Application.DAL
{
    /// <summary>
    /// Context Class
    /// </summary>
    public class DMVContext : DbContext
    {
        /// <summary>
        /// Connects to 'MyDB'
        /// </summary>
        public DMVContext() : base("name = MyDB")
        { }

        /// <summary>
        /// Get and Set for a DMV Application
        /// </summary>
        public virtual DbSet<DMVRequest> DMVRequests { get; set; }
    }
}