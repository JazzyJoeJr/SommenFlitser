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
    public class GetOefeningByIdController : ApiController
    {
        private OefeningRepository repo;

        public GetOefeningByIdController()
        {
            repo = OefeningRepository.GetInstance();
        }

        // GET: api/GetOefeningById
        public IEnumerable<string> Get()
        {
            return new string[] { "value1000", "value2" };
        }

        // GET: api/GetOefeningById/5
        public IEnumerable<Oefening> Get(int id)
        {
            return repo.GetOefById(id);
        }

        // POST: api/GetOefeningById
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GetOefeningById/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GetOefeningById/5
        public void Delete(int id)
        {
        }
    }
}
