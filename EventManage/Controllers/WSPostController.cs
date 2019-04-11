using Domain.Entities;
using Service.servicePosts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EventManage.Controllers
{
    public class WSPostController : ApiController
    {
        private ServicePost ts = new ServicePost();
        [Route("api/Post")]
        public IQueryable<Post> GetTache()
        {
            List<Post> taches = ts.GetAll().ToList();

            return taches.AsQueryable();
        }
        // GET: api/WSPost
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/WSPost/5
        public Post Get(int id)
        {
            return ts.GetById(id);
        }

        // POST: api/WSPost
        public IHttpActionResult Post([FromBody]Post value)
        {
            ts.Add(value);
            ts.Commit();
            return Ok("ajoute");
        }

        // PUT: api/WSPost/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/WSPost/5
        public IHttpActionResult Delete(int id)
        {
            Post tc = new Post();

            tc = ts.GetById(id);
            ts.Delete(tc);
            ts.Commit();
            return Ok("supprime");

        }
    }
}
