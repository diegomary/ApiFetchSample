using ApiFetchSample.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Http;

namespace ApiFetchSample.Controllers
{
    public class AjaxFetchController : ApiController
    {
        // GET: api/AjaxFetch
        public Person Get()
        {
            // First of all we get the querystring data from the request
            var qs = this.Request.GetQueryNameValuePairs();
            // Using Linq firstordefault we get name and surname
            string name = qs.FirstOrDefault(m => m.Key.Equals("name")).Value;
            string surname = qs.FirstOrDefault(m => m.Key.Equals("surname")).Value;
            // We create a new class using the provided data from the user
            Person prs = new Person() { Name = name, Surname = surname };           
            return prs;
        }

      
    }
}
