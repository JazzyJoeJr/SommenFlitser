using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SommenFlitser.Models;
using System.Web.Http.Cors;

namespace SommenFlitser.Controllers
{
    [EnableCors(origins: "*", headers:"*", methods:"GET, POST")]

    public class OefeningController : ApiController
    {
        private OefeningRepository repo;

        //De Constructor
        public OefeningController()
        {
            repo = OefeningRepository.GetInstance();
        }

        // GET: api/Oefening
        public IEnumerable<Oefening> Get()
        {
            return repo.GetOefeningen();
        }

        // GET: api/Oefening/5
        public IEnumerable<Oefening> Get(int id)
        {
            return repo.SetOef(id);
        }

        // POST: api/Oefening
        public IHttpActionResult Post([FromBody]Oefening value)
        {
            repo.SaveOef(value);
            return Ok();
        }

        // PUT: api/Oefening/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Oefening/5
        public void Delete(int id)
        {
        }
    }
}
