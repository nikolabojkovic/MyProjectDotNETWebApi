using MyProjectWebApiDotNET.App_Start;
using MyProjectWebApiDotNET.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyProjectWebApiDotNET.Domain
{
    public class Context : DbContext
    {
        // local server db connection string 
         public Context() : base (WebApiConfig.DbConnectionString) { }
        public DbSet<Hero> Heroes { get; set; }
    }
}