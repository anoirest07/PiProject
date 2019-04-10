using Domain.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EventManage.Controllers
{
    public class EvenementApiController : ApiController
    {
        ITeamService ts;
        IEvenementService Es;

        // GET: api/EvenementApi
        public IQueryable<Evenement> Get()
        {
            ts = new TeamService();
            Es = new EvenementService();
            List<Evenement> list = Es.GetAll().ToList();
            return list.AsQueryable();
        }

        // GET: api/EvenementApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/EvenementApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/EvenementApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/EvenementApi/5
        public void Delete(int id)
        {
        }
    }
}
