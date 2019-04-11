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

namespace EventManage.Controllers
{
    public class RewardsController : Controller
    {
        private Context db = new Context();

        // GET: Rewards
        public ActionResult Index()
        {
            var rewards = db.Rewards.Include(r => r.Event).Include(r => r.Organizer);
            return View(rewards.ToList());
        }

        // GET: Rewards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reward reward = db.Rewards.Find(id);
            if (reward == null)
            {
                return HttpNotFound();
            }
            return View(reward);
        }

        // GET: Rewards/Create
        public ActionResult Create()
        {
            ViewBag.EventId = new SelectList(db.Evenement, "IdEvent", "NomEvent");
            ViewBag.UserId = new SelectList(db.Users, "Id", "LastName");
            return View();
        }

        // POST: Rewards/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RewardId,description1,firstReward,description2,SecondReward,description3,ThirdReward,EventId,UserId")] Reward reward)
        {
            if (ModelState.IsValid)
            {
                db.Rewards.Add(reward);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventId = new SelectList(db.Evenement, "IdEvent", "NomEvent", reward.EventId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "LastName", reward.UserId);
            return View(reward);
        }

        // GET: Rewards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reward reward = db.Rewards.Find(id);
            if (reward == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventId = new SelectList(db.Evenement, "IdEvent", "NomEvent", reward.EventId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "LastName", reward.UserId);
            return View(reward);
        }

        // POST: Rewards/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RewardId,description1,firstReward,description2,SecondReward,description3,ThirdReward,EventId,UserId")] Reward reward)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reward).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventId = new SelectList(db.Evenement, "IdEvent", "NomEvent", reward.EventId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "LastName", reward.UserId);
            return View(reward);
        }

        // GET: Rewards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reward reward = db.Rewards.Find(id);
            if (reward == null)
            {
                return HttpNotFound();
            }
            return View(reward);
        }

        // POST: Rewards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reward reward = db.Rewards.Find(id);
            db.Rewards.Remove(reward);
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
