
using Domain.Entities;
using EventManage.Models;
using Microsoft.AspNet.Identity;
using Nexmo.Api;
using Service.OrganizerSer;
using Service.TacheSer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManage.Controllers
{
    public class TacheController : Controller
    {
        public static int test = 0;
        NotificationComponent NC;
        ITacheService Ts;
        IOrganizerService Os;
        // GET: Tache
        public ActionResult Index()
        {
            return View();
        }

        // GET: Tache/Details/5
        public ActionResult Details(int id)
        {
          
            Ts = new TacheService();
            TacheModelView dvm = new TacheModelView();
            var item = Ts.GetById(id);


            
            dvm.IdTache = item.IdTache;
            dvm.Nom = (EventManage.Models.NomTache)item.Nom;

                dvm.DescTache = item.DescTache;
            

            dvm.DeadlineTache = item.DeadlineTache;
            dvm.EtatdeTache = (EventManage.Models.EtatTache)item.EtatdeTache;
            

            return View(dvm);
        }

        // GET: Tache/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tache/Create
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

        // GET: Tache/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tache/Edit/5
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

        // GET: Tache/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tache/Delete/5
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

        //--------------------------------------------------------------------------------------------------------------
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
        public ActionResult IndexTache()

        {
            test= Int32.Parse(User.Identity.GetUserId());
            Os = new OrganizerService();
            Ts = new TacheService();
            ViewBag.myid = "";
            var currentUserId = Int32.Parse(User.Identity.GetUserId());
           // ViewBag.myid = currentUserId;
            if (Ts.Matache(currentUserId) == true)
            {
                ViewBag.myid = true;
            }
            else
            {
                ViewBag.myid = false;
            }






            List<TacheModelView> lists = new List<TacheModelView>();
            List<Tache> liststache = new List<Tache>();
            liststache = Ts.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach (var item in liststache)
            {
                TacheModelView dvm = new TacheModelView();
                dvm.IdTache = item.IdTache;
                dvm.Nom = (EventManage.Models.NomTache)item.Nom;
                if (item.DescTache.Length > 50) {
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
                lists.Add(dvm);

            }
            var orgservice = Os.ListOrganizers();
            List<OrganizerModelView> lorg = new List<OrganizerModelView>();
            foreach (var item in orgservice)
            {
                OrganizerModelView org = new OrganizerModelView();
                org.Id = item.Id;
                org.FirstName = item.FirstName;
                org.LastName = item.LastName;
              
                org.Password = item.Password;
                org.Email = item.Email;
                org.EmailConfirmed = item.EmailConfirmed;
                org.PasswordHash = item.PasswordHash;
                org.PhoneNumber = item.PhoneNumber;
                org.PhoneNumberConfirmed = item.PhoneNumberConfirmed;
                org.TwoFactorEnabled = item.TwoFactorEnabled;
                org.LockoutEndDateUtc = item.LockoutEndDateUtc;
                org.LockoutEnabled = item.LockoutEnabled;
                org.AccessFailedCount = item.AccessFailedCount;
                org.UserName = item.UserName;
                // org.Roles = item.Roles;
                org.SecurityStamp = item.SecurityStamp;

                lorg.Add(org);

            }

            // ViewData["Organ"] = new SelectList(lorg, "Id", "FirstName");
            ViewData["Organ"] = new SelectList(lorg, "Id", "FirstName");
            ViewBag.OrganisateurList = new SelectList(lorg, "Id", "FirstName");
            ViewBag.TacheList = lists;
            //CustomersEntities entities = new CustomersEntities();
            return View();
        }

        [HttpPost]
        public ActionResult IndexTache(TacheModelView model)
        {
            string strDDLValue = Request.Form["Id"].ToString();
            Os = new OrganizerService();
            Ts = new TacheService();
            try
            {

                //  MVCTutorialEntities db = new MVCTutorialEntities();
                // List<Department> list = db.Departments.ToList();
                var orgservice = Os.ListOrganizers();
                List<OrganizerModelView> lorg = new List<OrganizerModelView>();
                foreach (var item in orgservice)
                {
                    OrganizerModelView org = new OrganizerModelView();
                    org.Id = item.Id;
                    org.FirstName = item.FirstName;
                    org.LastName = item.LastName;
            
                    org.Password = item.Password;
                    org.Email = item.Email;
                    org.EmailConfirmed = item.EmailConfirmed;
                    org.PasswordHash = item.PasswordHash;
                    org.PhoneNumber = item.PhoneNumber;
                    org.PhoneNumberConfirmed = item.PhoneNumberConfirmed;
                    org.TwoFactorEnabled = item.TwoFactorEnabled;
                    org.LockoutEndDateUtc = item.LockoutEndDateUtc;
                    org.LockoutEnabled = item.LockoutEnabled;
                    org.AccessFailedCount = item.AccessFailedCount;
                    org.UserName = item.UserName;
                    // org.Roles = item.Roles;
                    org.SecurityStamp = item.SecurityStamp;

                    lorg.Add(org);

                }
                ViewData["Organ"] = new SelectList(lorg, "Id", "FirstName");
                ViewBag.OrganisateurList = new SelectList(lorg, "Id", "FirstName");

                //{ EtatdeTache = (Domain.Entity.EtatTache)model.EtatdeTache, Nom = (Domain.Entity.NomTache)model.Nom };
                if (model.IdTache > 0)
                {
                    Tache t = new Tache();
                    t = Ts.Get(x => x.IdTache == model.IdTache);//&& x.IsDeleted==false);
                    //update
                    //Employee emp = db.Employees.SingleOrDefault(x => x.EmployeeId == model.EmployeeId && x.IsDeleted == false);
                    t.EtatdeTache = (Domain.Entities.EtatTache)model.EtatdeTache;
                    t.Nom = (Domain.Entities.NomTache)model.Nom;
                    t.OragnisateurFk = int.Parse(strDDLValue);
                    t.DescTache = model.DescTache;
                    t.DeadlineTache = model.DeadlineTache;
                    Ts.Update(t);


                }
                else
                {
                   


                    var client = new Client(creds: new Nexmo.Api.Request.Credentials
                    {
                        ApiKey = "46703f47",
                        ApiSecret = "dzbFZkgQHi8FCzDz"
                    });
                    var results = client.SMS.Send(request: new SMS.SMSRequest
                    {
                        from = "Nexmo",
                        to = "21628861641",
                        text = "You have a new task to do before : "+model.DeadlineTache
                    });


                    Tache t = new Tache();
                    //Insert
                 
                        t.EtatdeTache = (Domain.Entities.EtatTache)model.EtatdeTache;
                        t.Nom = (Domain.Entities.NomTache)model.Nom;
                        t.OragnisateurFk = int.Parse(strDDLValue); //2;// model.OragnisateurFk;
                        t.DescTache = model.DescTache;
                        t.DeadlineTache = model.DeadlineTache;
                        t.IsDeleted = false;
                        Ts.Add(t);
                        Ts.Commit();
        

                }
                return View(model);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public ActionResult AddEditTache(int IdTache)
        {
            Os = new OrganizerService();
            Ts = new TacheService();
            var orgservice = Os.ListOrganizers();
            List<OrganizerModelView> lorg = new List<OrganizerModelView>();
            foreach (var item in orgservice)
            {
                OrganizerModelView org = new OrganizerModelView();
                org.Id = item.Id;
                org.FirstName = item.FirstName;
                org.LastName = item.LastName;
            
                org.Password = item.Password;
                org.Email = item.Email;
                org.EmailConfirmed = item.EmailConfirmed;
                org.PasswordHash = item.PasswordHash;
                org.PhoneNumber = item.PhoneNumber;
                org.PhoneNumberConfirmed = item.PhoneNumberConfirmed;
                org.TwoFactorEnabled = item.TwoFactorEnabled;
                org.LockoutEndDateUtc = item.LockoutEndDateUtc;
                org.LockoutEnabled = item.LockoutEnabled;
                org.AccessFailedCount = item.AccessFailedCount;
                org.UserName = item.UserName;
                // org.Roles = item.Roles;
                org.SecurityStamp = item.SecurityStamp;

                lorg.Add(org);

            }
            ViewData["Organ"] = new SelectList(lorg, "Id", "FirstName");
            ViewBag.OrganisateurList = new SelectList(lorg, "OragnisateurFk", "FirstName");
            TacheModelView model = new TacheModelView();
            // EmployeeViewModel model = new EmployeeViewModel();
            Tache t = new Tache();

            if (IdTache > 0)
            {
                t = Ts.GetById(IdTache);
                //t = Ts.Get(x => x.IdTache == model.IdTache && x.IsDeleted == false);

                model.EtatdeTache = (EventManage.Models.EtatTache)t.EtatdeTache;
                model.Nom = (EventManage.Models.NomTache)t.Nom;
                model.OragnisateurFk = t.OragnisateurFk;
                model.DescTache = t.DescTache;
                model.DeadlineTache = t.DeadlineTache;

            }
            return PartialView("Partial2", model);
        }
        public JsonResult DeleteTache(int IdTache)
        {
            Ts = new TacheService();

            bool result = Ts.DeleteTache(IdTache);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult GetNotificationContacts()
        //{
        //    var notificationRegisterTime = Session["LastUpdated"] != null ? Convert.ToDateTime(Session["LastUpdated"]) : DateTime.Now;
        //    NotificationViewModel NC = new NotificationViewModel();
        //    var list = NC.GetAllThetasksnotif(notificationRegisterTime);
        //    //update session here for get only new added contacts (notification)
        //    Session["LastUpdate"] = DateTime.Now;
        //    return new JsonResult { Data = list, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //}
        public ActionResult GetMyTasks()
        {
            Os = new OrganizerService();
            Ts = new TacheService();
            var currentUserId = Int32.Parse(User.Identity.GetUserId()); 
           


            List<TacheModelView> lists = new List<TacheModelView>();
            List<Tache> liststache = new List<Tache>();
            liststache = Ts.Listedemestaches(currentUserId).ToList();
           
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
                lists.Add(dvm);

            }
          
            ViewBag.TacheList = lists;



            return View(lists);
        }
    }
}
