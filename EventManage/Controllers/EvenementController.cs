
using Domain.Entities;
using EventManage.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Rotativa;
using System.Diagnostics;
using System.IO;

namespace EventManage.Controllers
{   

    public class EvenementController : Controller
    {

        ITeamService ts;
        IEvenementService Es;
        // GET: Evenement
        public EvenementController()
        {
            service = new EvenementService();

        }
        public ActionResult Index( string search)
        {
           
            ts =new TeamService();
            Es = new EvenementService();
            List<EvenementViewModel> lists = new List<EvenementViewModel>();
            List<string> cats = new List<string>();

            cats.Add("Academic");
            cats.Add("Entertaining");
            cats.Add("Cultural");
            cats.Add("Other");
            foreach (var item in Es.GetAll())
            {
                EvenementViewModel evm = new EvenementViewModel();
                evm.IdEvent = item.IdEvent;
                evm.NomEvent = item.NomEvent;
                evm.DateEventDebut = item.DateEventDebut;
                evm.DateEventFin = item.DateEventFin;
                evm.LocationEvent = item.LocationEvent;
                evm.DescriptionEvent = item.DescriptionEvent;
                evm. NbPlaceEvent= item.NbPlaceEvent;
                evm.ImageEvent = item.ImageEvent;
                evm.Welcometext = item.Welcometext;
                evm.Category = (EventManage.Models.Categorie)item.Category;
                evm.Methodepai = (EventManage.Models.Methodepaiement)item.Methodepai;
                evm.EtatEvenement = (EventManage.Models.EtatEvent)item.EtatEvenement;
                
                //dvm.Etat.Equals(item.Etat);
                lists.Add(evm);

            }
            ViewBag.cats = cats;

           
            return View(lists);
        }


        public ActionResult IndexParticipant(string search)
        {

            ts = new TeamService();
            Es = new EvenementService();
            List<EvenementViewModel> lists = new List<EvenementViewModel>();
            List<string> cats = new List<string>();

            cats.Add("Academic");
            cats.Add("Entertaining");
            cats.Add("Cultural");
            cats.Add("Other");
            foreach (var item in Es.GetAll())
            {
                EvenementViewModel evm = new EvenementViewModel();
                evm.IdEvent = item.IdEvent;
                evm.NomEvent = item.NomEvent;
                evm.DateEventDebut = item.DateEventDebut;
                evm.DateEventFin = item.DateEventFin;
                evm.LocationEvent = item.LocationEvent;
                evm.DescriptionEvent = item.DescriptionEvent;
                evm.NbPlaceEvent = item.NbPlaceEvent;
                evm.ImageEvent = item.ImageEvent;
                evm.Welcometext = item.Welcometext;
                evm.Category = (EventManage.Models.Categorie)item.Category;
                evm.Methodepai = (EventManage.Models.Methodepaiement)item.Methodepai;
                evm.EtatEvenement = (EventManage.Models.EtatEvent)item.EtatEvenement;

                //dvm.Etat.Equals(item.Etat);
                lists.Add(evm);

            }
            ViewBag.cats = cats;


            return View(lists);
        }

        public ActionResult filter(string cat)
        {
            EvenementViewModel path = new EvenementViewModel();
            Es = new EvenementService();
            var even = Es.GetMany(e=> e.Category.ToString()==cat).ToList();
            return Json(new { success = true ,message=even }, JsonRequestBehavior.AllowGet);

        }
    


        // GET: Evenement/Details/5
        public ActionResult Details(int id)
        {   
            ts = new TeamService();
            Es = new EvenementService();
            var even = Es.GetById(id);


            EvenementViewModel evm = new EvenementViewModel();
           
            evm.NomEvent = even.NomEvent;
            evm.EtatEvenement = (EventManage.Models.EtatEvent)even.EtatEvenement;
            evm.LocationEvent = even.LocationEvent;
            evm.NbPlaceEvent = even.NbPlaceEvent;
            evm.DateEventDebut = even.DateEventDebut;
            evm.DateEventFin = even.DateEventFin;
            evm.TeamFk = even.TeamFk;

            return View(evm);
        }


        public ActionResult DetailsParticipant (int id)
        {
            ts = new TeamService();
            Es = new EvenementService();
            var even = Es.GetById(id);


            EvenementViewModel evm = new EvenementViewModel();

            evm.NomEvent = even.NomEvent;
            evm.EtatEvenement = (EventManage.Models.EtatEvent)even.EtatEvenement;
            evm.LocationEvent = even.LocationEvent;
            evm.NbPlaceEvent = even.NbPlaceEvent;
            evm.DateEventDebut = even.DateEventDebut;
            evm.DateEventFin = even.DateEventFin;
            evm.TeamFk = even.TeamFk;

            return View(evm);
        }




        // GET: Evenement/Create
        public ActionResult Create()
        {
            ts = new TeamService();
            var even = ts.GetAll();
            List<TeamViewModel> ltvm = new List<TeamViewModel>();
            foreach(var item in even)
            {

                TeamViewModel tvm = new TeamViewModel();
                tvm.IdTeam = item.IdTeam;
                tvm.NomTeam = item.NomTeam;
                ltvm.Add(tvm);

            }

            ViewData["Biblio"] = new SelectList(ltvm, "IdTeam", "NomTeam");
            return View();
        }

        // POST: Evenement/Create
        [HttpPost]
        public ActionResult Create(EvenementViewModel EVM, HttpPostedFileBase file)
        {
            Evenement e = new Evenement() { EtatEvenement = (Domain.Entities.EtatEvent)EVM.EtatEvenement, Methodepai = (Domain.Entities.Methodepaiement)EVM.Methodepai, Category = (Domain.Entities.Categorie)EVM.Category };
            Es = new EvenementService();

            
            
            // string request = Request.Form["IdTeam"].ToString();
           
            e.NomEvent = EVM.NomEvent;
            e.DateEventDebut = EVM.DateEventDebut;
            e.LocationEvent = "Tunisia";
            e.DateEventFin = EVM.DateEventFin;
            e.NbPlaceEvent = EVM.NbPlaceEvent;
            // e.ImageEvent = file.FileName;
            //// var path = Path.Combine(Server.MapPath("~/Content/"), file.FileName);
            // file.SaveAs(Path.Combine(Server.MapPath("~/Content/"), file.FileName));
            var fileName = Path.GetFileName(file.FileName);
            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), fileName);
            file.SaveAs(path);
            e.ImageEvent = file.FileName;
            e.Welcometext = EVM.Welcometext;
            e.TeamFk = EVM.TeamFk;
                         
            //Debug.WriteLine(EVM);
           Es.Add(e);
            Es.Commit();

            




            return RedirectToAction("Index");

           
        }

        // GET: Evenement/Edit/5
        public ActionResult Edit(int id)
        {
            ts = new TeamService();
            return View();
        }

        // POST: Evenement/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            ts = new TeamService();
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

        // GET: Evenement/Delete/5
        public ActionResult Delete(int id)
        {
            Es = new EvenementService();
           

            Es.Delete(Es.GetById(id));
            Es.Commit();
            return RedirectToAction("Index");
        }

        // POST: Evenement/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            ts = new TeamService();
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
        IEvenementService service = null;
        public ActionResult get_nbplace_dispo() 
        {
             Es = new EvenementService();
            ViewBag.expproj = service.get_nbplace_dispo();
            return View();
        }

        // GET: Evenement/Create

        public ActionResult MyCalendar()
        {
            Es = new EvenementService();
            return View();
        }

        public JsonResult GetEvents()
        {
            Es = new EvenementService();
            var Events = Es.GetAll();

            return new JsonResult { Data = Events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };


        }
        public ActionResult PrintDetails()
        {

            var report = new ActionAsPdf("Index");
            return report;
        }
    }
}
