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
        public Context() : base("Data Source=MIC12143;Initial Catalog=MyProject;Integrated Security=True") { }
        public DbSet<Hero> Heroes { get; set; }
    }
}