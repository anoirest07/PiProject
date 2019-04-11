using Domain.Entities;
using EventManage.Models;
using Microsoft.AspNet.Identity;
using Service.OrganizerSer;
using Service.TacheSer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManage.Controllers
{
    public class OrganizerController : Controller
    {
        public static int test = 0;
        NotificationComponent NC;
        ITacheService Ts;
        IOrganizerService Os;
        // GET: Organizer
        public ActionResult Index()
        {
            test = Int32.Parse(User.Identity.GetUserId());

            return View();
        }

        // GET: Organizer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Organizer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Organizer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Organizer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Organizer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Organizer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Organizer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public JsonResult GetNotificationContacts()
        {
            test = Int32.Parse(User.Identity.GetUserId());
            //test = 1;
            //var currentU = Int32.Parse(User.Identity.GetUserId());
            //// Ts = new TacheService();
            //if (ts.Matache(3) == true)
            //{
            //    ViewBag.myid = currentU;
            //}

            Ts = new TacheService();
            Os = new OrganizerService();
            List<TacheModelView> list = new List<TacheModelView>();
            List<Tache> liststache = new List<Tache>();
            var notificationRegisterTime = Session["LastUpdated"] != null ? Convert.ToDateTime(Session["LastUpdated"]) : DateTime.Now;
            //  NC = new NotificationComponent();
            var currentUserId = Int32.Parse(User.Identity.GetUserId());
            liststache = Ts.gettachenotification(notificationRegisterTime, currentUserId).ToList();
            // ViewBag.myid = "test";
            foreach (var item in liststache)
            {
                TacheModelView dvm = new TacheModelView();
                dvm.IdTache = item.IdTache;
                dvm.Nom = (EventManage.Models.NomTache)item.Nom;
                if (item.DescTache.Length > 50)
                {
                    var des = item.DescTache.Substring(0, 23) + " ...";
                    dvm.DescTache = des;
                }
                else
                {
                    dvm.DescTache = item.DescTache;
                }

                dvm.DeadlineTache = item.DeadlineTache;
                dvm.EtatdeTache = (EventManage.Models.EtatTache)item.EtatdeTache;
                dvm.OrgNom = Os.GetById(item.OragnisateurFk).FirstName;
                //dvm.Etat.Equals(item.Etat);
                list.Add(dvm);

            }




            //update session here for get only new added contacts (notification)
            Session["LastUpdate"] = DateTime.Now;


            return new JsonResult { Data = list, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult GetNotification()
        {
            ViewBag.myid = "test";
            Ts = new TacheService();
            Os = new OrganizerService();
            List<TacheModelView> list = new List<TacheModelView>();
            List<Tache> liststache = new List<Tache>();
            var currentUserId = Int32.Parse(User.Identity.GetUserId());
            liststache = Ts.Listedemestaches(currentUserId).ToList();

            // List<Tache> liststache = new List<Tache>();  
            var notificationRegisterTime = Session["LastUpdated"] != null ? Convert.ToDateTime(Session["LastUpdated"]) : DateTime.Now;
            // NC = new NotificationComponent();
            foreach (var item in liststache)
            {
                TacheModelView dvm = new TacheModelView();
                dvm.IdTache = item.IdTache;
                dvm.Nom = (EventManage.Models.NomTache)item.Nom;
                if (item.DescTache.Length > 50)
                {
                    var des = item.DescTache.Substring(0, 23) + " ...";
                    dvm.DescTache = des;
                }
                else
                {
                    dvm.DescTache = item.DescTache;
                }

                dvm.DeadlineTache = item.DeadlineTache;
                dvm.EtatdeTache = (EventManage.Models.EtatTache)item.EtatdeTache;
                dvm.OrgNom = Os.GetById(item.OragnisateurFk).FirstName;
                //dvm.Etat.Equals(item.Etat);
                list.Add(dvm);

            }
            //list = NC.GetContacts(notificationRegisterTime);
            //update session here for get only new added contacts (notification)
            Session["LastUpdate"] = DateTime.Now;


            return Json(list, JsonRequestBehavior.AllowGet);
        }

    }
}
