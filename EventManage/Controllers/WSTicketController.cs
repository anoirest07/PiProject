using Domain.Entities;
using Service.TicketSer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EventManage.Controllers
{
    public class WSTicketController : ApiController
    {
        private ITicketService ts = new TicketService();


        [Route("api/Tickets")]
        public IQueryable<Ticket> GetTache()
        {
            List<Ticket> taches = ts.GetAll().ToList();

            return taches.AsQueryable();
        }
        // GET: api/WSTicket
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/WSTicket/5
        public Ticket Get(int id)
        {
            return ts.GetById(id);
        }

        // POST: api/WSTicket
        public IHttpActionResult Post([FromBody]Ticket value)
        {
            ts.Add(value);
            ts.Commit();
            return Ok("ajoute");
        }

        // PUT: api/WSTicket/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/WSTicket/5
        public IHttpActionResult Delete(int id)
        {
            Ticket tc = new Ticket();

            tc = ts.GetById(id);
            ts.Delete(tc);
            ts.Commit();
            return Ok("supprime");

        }
    }
}
