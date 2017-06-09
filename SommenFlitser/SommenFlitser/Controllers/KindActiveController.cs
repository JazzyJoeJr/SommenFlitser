using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using SommenFlitser.Models;

namespace SommenFlitser.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "GET, POST")]
    public class KindActiveController : ApiController
    {
        private OefeningRepository repo;

        public KindActiveController()
        {
            repo = OefeningRepository.GetInstance();
        }

        // GET: api/KindActive
        public IEnumerable<Kind> Get()
        {
            return repo.GetActiveKids();
        }

        // GET: api/KindActive/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/KindActive
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/KindActive/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/KindActive/5
        public void Delete(int id)
        {
        }
    }
}
