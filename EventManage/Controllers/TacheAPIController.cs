using Domain.Entities;
using Newtonsoft.Json;
using Service.TacheSer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace EventManage.Controllers
{
    public class TacheAPIController : ApiController
    {
        private ITacheService ts = new TacheService();

        [Route("api/Taches")]
        public IQueryable<Tache> GetTache()
        {
            List<Tache> taches = ts.GetAll().ToList() ;

            return taches.AsQueryable();
        }
        // GET: api/TacheAPI
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TacheAPI/5
        public Tache Get(int id)
        {
            return ts.GetById(id);
        }

        // POST: api/TacheAPI
        public IHttpActionResult Post([FromBody]Tache value)
        {
            ts.Add(value);
            ts.Commit();
            return Ok("ajoute");
        }

        // PUT: api/TacheAPI/5
       // [Route("api/updateTache")]
        public IHttpActionResult Put( [FromBody]Tache value)
        {
            Tache tc = new Tache();
            // tc= ts.GetById(id);
            tc = ts.Get(x => x.IdTache == value.IdTache);
            tc.DeadlineTache = value.DeadlineTache;
            tc.DescTache = value.DescTache;
            tc.Nom = value.Nom;
            tc.OragnisateurFk = value.OragnisateurFk;
            tc.EtatdeTache = value.EtatdeTache;
            tc.IsDeleted = value.IsDeleted;
            tc.OrgNom = value.OrgNom;
            ts.Update(tc);
            ts.Commit();
            return Ok();
        }

        // DELETE: api/TacheAPI/5
        public IHttpActionResult Delete(int id)
        {
            Tache tc = new Tache();
            
            tc = ts.GetById(id);
            ts.Delete(tc);
            ts.Commit();
            return Ok("supprime");

        }
        [Route("api/MesTaches/{id}")]
        public IQueryable<Tache> GetMyTache(int Id)
        {
            List<Tache> taches = ts.Listedemestaches(Id).ToList();

            return taches.AsQueryable();
        }
        
    }
}
