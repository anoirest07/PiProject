using Domain.Entities;
using EventManage.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;

namespace EventManage.Controllers
{
    public class WSReclamationController : ApiController
    {
        IReclamationService rs = new ReclamationService();


        [System.Web.Http.Route("api/getRecmlamation")]
        public IQueryable<Reclamation> GetAll()
        {
             return rs.GetAll().AsQueryable();
           

        }
        [System.Web.Http.Route("api/getRecmlamation/{id}")]
        [ResponseType(typeof(Reclamation))]
        // GET: api/getRecmlamation/1
        public IHttpActionResult GetOneReclamation(int id)
        {
            Reclamation r = rs.GetById(id);
            if (r == null)
            {
                return NotFound();
            }

            return Ok(r);
            
        }



        [System.Web.Http.Route("api/addRecmlamation")]
        // POST: api/WebApiProject
        public IHttpActionResult Post([FromBody]ReclamationViewModels RVM)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data gateau.");
            Reclamation P = new Reclamation();
            P.ID = RVM.ID;
            P.Descriptions = RVM.Descriptions;
            P.IdEvent = RVM.IdEvent;
            P.Idpar = RVM.Idpar;

            rs.Add(P);
            rs.Commit();
            return Ok(P);
        }
        //[ResponseType(typeof(Reclamation))]
        //// GET: api/WebApiProject/5
        //public IHttpActionResult GetOneReclamation(int id)
        //{
        //    Reclamation R = service.GetById(id);
        //    if (R == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(R);
        //}

        // GET: api/Reclamation
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Reclamation/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Reclamation
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Reclamation/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Reclamation/5
        public void Delete(int id)
        {
        }
    }
}
