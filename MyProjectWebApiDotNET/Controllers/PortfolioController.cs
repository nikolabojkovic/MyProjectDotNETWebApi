using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace MyProjectWebApiDotNET.Controllers
{
    [RoutePrefix("")]
    public class PortfolioController: ApiController
    {
        [Route("")]
        [HttpGet]
         public HttpResponseMessage Get()
        {
            var path = HttpContext.Current.Server.MapPath("~/View/Portfolio.html");
            var response = new HttpResponseMessage();
            response.Content = new StringContent(File.ReadAllText(path));
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;
        }
    }
}