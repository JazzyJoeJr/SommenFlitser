using SommenFlitser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SommenFlitser.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET, POST")]
    public class ActiveOefeningController : ApiController
    {

        private OefeningRepository repo;

        public ActiveOefeningController() { 
            repo = OefeningRepository.GetInstance();
        }

        // GET: api/ActiveOefening
        public IEnumerable<Oefening> Get()
        {
            return repo.GetActiveOefening();
        }

        // GET: api/ActiveOefening/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ActiveOefening
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ActiveOefening/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ActiveOefening/5
        public void Delete(int id)
        {
        }
    }
}
