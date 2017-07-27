using MyProjectWebApiDotNET.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyProjectWebApiDotNET.Domain
{
    public class Context : DbContext
    {
        // local server db connection string 
        public Context() : base("Data Source=MIC12143;Initial Catalog=MyProject;Integrated Security=True") { }

        // remove server connection string - for deploy uncomment this line
        // public Context() : base ("workstation id=MyProjectDatabase.mssql.somee.com;packet size=4096;user id=nikolabojkovic6_SQLLogin_1;pwd=fdeo7l2nbc;data source=MyProjectDatabase.mssql.somee.com;persist security info=False;initial catalog=MyProjectDatabase") { }
        public DbSet<Hero> Heroes { get; set; }
    }
}