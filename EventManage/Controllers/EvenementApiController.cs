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
        public Evenement Get(int id)
        {
            return Es.GetById(id);
        }

        // POST: api/EvenementApi
        public IHttpActionResult Post([FromBody]Evenement value)
        {
            Es.Add(value);
            Es.Commit();
            return Ok("ajoute");
        }

        // PUT: api/EvenementApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/EvenementApi/5
        public IHttpActionResult Delete(int id)
        {
            Evenement tc = new Evenement();

            tc = Es.GetById(id);
            Es.Delete(tc);
            Es.Commit();
            return Ok("supprime");

        }
    }
}
