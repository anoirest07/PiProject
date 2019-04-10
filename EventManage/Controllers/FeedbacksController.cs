using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DATA;
using Domain.Entities;
using EventManage.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;

namespace EventManage.Controllers
{
    public class FeedbacksController : Controller
    {
        private Context db = new Context();


        // GET: Charts
        public ActionResult charts()
        {
            return View();
        }
        
        public ActionResult GetData()
        { 
            int Excellent = db.Feedback.Where(x => x.Answer == "Excellent").Count();
            int Good = db.Feedback.Where(x => x.Answer == "Good").Count();
            int Neutral = db.Feedback.Where(x => x.Answer == "Neutral").Count();
            int Poor = db.Feedback.Where(x => x.Answer == "Poor").Count();

            ratio obj = new ratio();
            obj.Excellent = Excellent;
            obj.Good = Good;
            obj.Neutral = Neutral;
            obj.Poor = Poor;

             return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public class ratio
        {
            public int Excellent { get; set; }
            public int Good { get; set; }
            public int Neutral { get; set; }
            public int Poor { get; set; }

        }


        // GET: Feedbacks
        public ActionResult Index()
        {
            var feedbacks = db.Feedback.Include(f => f.Events).Include(f => f.Participant);
            return View(feedbacks.ToList());

        }

        // GET: Feedbacks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedback.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // GET: Feedbacks/Create
        public ActionResult Create()
        {
            ViewBag.IdEvent = new SelectList(db.Evenement, "IdEvent", "NomEvent");
            ViewBag.Id = new SelectList(db.Users, "Id", "LastName");
            return View();
        }

        // POST: Feedbacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdFB,Answer,DescFB,IdEvent,Date,Id")] Feedback feedback)
        {
            int userconnect = Int32.Parse(User.Identity.GetUserId());
            if (ModelState.IsValid)
            {
                db.Feedback.Add(feedback);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEvent = new SelectList(db.Evenement, "IdEvent", "NomEvent", feedback.IdEvent);
            ViewBag.Id = new SelectList(db.Users, "Id", "LastName", feedback.Id= userconnect);
            return View(feedback);
        }

        // GET: Feedbacks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedback.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEvent = new SelectList(db.Evenement, "IdEvent", "NomEvent", feedback.IdEvent);
            ViewBag.Id = new SelectList(db.Users, "Id", "LastName", feedback.Id);
            return View(feedback);
        }

        // POST: Feedbacks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdFB,Answer,DescFB,IdEvent,Date,Id")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feedback).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEvent = new SelectList(db.Evenement, "IdEvent", "NomEvent", feedback.IdEvent);
            ViewBag.Id = new SelectList(db.Users, "Id", "LastName", feedback.Id);
            return RedirectToAction("Index","Event2gateau");
        }

        // GET: Feedbacks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedback.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // POST: Feedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Feedback feedback = db.Feedback.Find(id);
            db.Feedback.Remove(feedback);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
