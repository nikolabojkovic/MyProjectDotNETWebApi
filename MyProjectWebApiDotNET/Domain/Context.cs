using MyProjectWebApiDotNET.Models;
using System.Configuration;
using System.Data.Entity;
using System.Web;

namespace MyProjectWebApiDotNET.Domain
{
    public class Context : DbContext
    {
        // local server db connection string 
         public Context() : base (ConfigurationManager.ConnectionStrings[HttpContext.Current.Request.Url.Host].ConnectionString) { }
        public DbSet<Hero> Heroes { get; set; }
    }
}