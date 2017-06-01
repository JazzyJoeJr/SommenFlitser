using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SommenFlitser.Controllers
{
    public class OplossingController : ApiController
    {
        // GET: api/Oplossing
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Oplossing/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Oplossing
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Oplossing/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Oplossing/5
        public void Delete(int id)
        {
        }
    }
}
