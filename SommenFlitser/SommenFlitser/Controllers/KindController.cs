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
    public class KindController : ApiController
    {
        private OefeningRepository repo;

        public KindController ()
        {
            repo = OefeningRepository.GetInstance();
        }

        // GET: api/Kind
        public IEnumerable<Kind> Get()
        {
            return repo.GetKids();
        }

        // GET: api/Kind/5
        public IEnumerable<Kind> Get(int id)
        {
            return repo.SetKid(id); 
        }

        // POST: api/Kind
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Kind/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Kind/5
        public void Delete(int id)
        {
        }
    }
}
