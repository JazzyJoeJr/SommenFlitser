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
    public class OplossingController : ApiController
    {
        private OefeningRepository repo;

        public OplossingController()
        {
            repo = OefeningRepository.GetInstance();
        }

        // GET: api/Oplossing
        public IEnumerable<Oplossing> Get()
        {
            return repo.GetOplossingen();
        }

        // GET: api/Oplossing/5
        public IEnumerable<Oplossing> Get(int id, int kindId, int oefeningId)
        {
            return repo.SendOplossing(id, kindId, oefeningId);
        }

        //public IEnumerable<Oplossing> Get(int id, Kind k)
        //{
        //    return repo.SendOplossing(id);
        //}

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
