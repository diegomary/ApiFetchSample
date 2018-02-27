using ApiFetchSample.Models;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Net.Http.Headers;
using System.Text;

namespace ApiFetchSample.Controllers
{
    public class FormFetchController : ApiController
    {
        // GET: api/Fetch
        public HttpResponseMessage Get()
        {
            // First of all we get the querystring data from the request
            var qs = this.Request.GetQueryNameValuePairs();
            // Using Linq firstordefault we get name and surname
            string name = qs.FirstOrDefault(m => m.Key.Equals("name")).Value;
            string surname = qs.FirstOrDefault(m => m.Key.Equals("surname")).Value;
            // We create a new class using the provided data from the user
            Person prs = new Person() { Name = name, Surname = surname };
            // We use the File.ReadAlltext to read in a string variable the html file
            // We use Server.MapPath to map the location of the file
            string res = File.ReadAllText(HttpContext.Current.Server.MapPath("/response.html"));
            // We replace the placeholders with real properties
            string outcome =res.Replace("@NAME", prs.Name).Replace("@SURNAME", prs.Surname);
            // We create the response with status code 200
            var response = Request.CreateResponse(HttpStatusCode.OK);
            // We create the Content from the response using the string from the file encoded with UTF8
            response.Content = new StringContent(outcome, Encoding.UTF8);
            // We set the ContentType header for the response being of type text/html
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            // We return the response of type HttpResponseMessage
            return response; 
        }
       
    }
}


