using Domain.Entities;
using EventManage.Models;
using Microsoft.AspNet.Identity;
using Service;
using Service.RecommendationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace EventManage.Controllers
{
    public class RecommendationController : Controller
    {
        RecommendationService RS = new RecommendationService();
        ServiceUser us = new ServiceUser();
        // GET: Recommendation
        public ActionResult Index(int id)
        {


            List<RecommendationViewModel> list = new List<RecommendationViewModel>();
            var r = RS.GetAll();
            foreach (var i in r)
            {
                RecommendationViewModel recommendationModel = new RecommendationViewModel();
                if (i.IdEvent == id)
                {
                    recommendationModel.EmailParticipent = i.EmailParticipent;
                    recommendationModel.Nom = i.Nom;
                    recommendationModel.Prenom = i.Prenom;
                    list.Add(recommendationModel);

                }

            }
            return View(list);
        }

        // GET: Recommendation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public void SendingMail(string From, string To, string Subject, string Body)
        {
            MailMessage mail = new MailMessage(From, To, Subject, Body);
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("mokhtarammar.ma@gmail.com", "princemma");
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }

        //GET: Recommendation/Create
        public ActionResult Create()
        {
            // Recomendation R = new Recomendation();


            //R.IdRecom=RVM.IdRecom;
            //R.ParticipantId = int.Parse(User.Identity.GetUserId());

            //R.MailRecomd = "test";
            //R.RefRecommendation = RVM.RefRecommendation;
            //R.EtaRec = Domain.Entities.EtatRecom.inprogress;
            //R.EventId = id;
            //RS.Add(R);
            //RS.Commit();
            return View();


        }

        // POST: Recommendation/Create
        [HttpPost]
        //public ActionResult Create( RecommendationViewModel RVM,int id)
        //{
        //    //Recomendation R = new Recomendation();


        //    //R.IdRecom = RVM.IdRecom;
        //    //R.ParticipantId = int.Parse(User.Identity.GetUserId());

        //    //R.MailRecomd = "test";
        //    //R.RefRecommendation = RVM.RefRecommendation;
        //    //R.EtaRec = Domain.Entities.EtatRecom.inprogress;
        //    //R.EventId = RVM.EventId=id;
        //    //SendingMail("mohamedmokhtar.ammar.ma@esprit.com", R.MailRecomd, "recommendation", "test recommendation ");
        //    //RS.Add(R);
        //    //RS.Commit();
        //    //return View(RVM);
        //}








        public ActionResult Create(RecommendationViewModel rvm, int id)
        {

            Recomendation r = new Recomendation();

            r.ID = rvm.ID;
            r.IdParticipant = int.Parse(User.Identity.GetUserId());
            r.IdEvent = rvm.IdEvent = id;
            r.Nom = us.GetUserById(r.IdParticipant).FirstName;
            r.Prenom = us.GetUserById(r.IdParticipant).LastName;
            r.EmailParticipent = rvm.EmailParticipent;
            SendingMail("mokhtarammar.ma@gmail.com", r.EmailParticipent, "[Recommendation for an Event]", "check this link :http://localhost:59686/Evenement/details/"+id);
            RS.Add(r);
            RS.Commit();

            return RedirectToAction("DetailsParticipant","Evenement");

        }








        // GET: Recommendation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Recommendation/Edit/5
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

        // GET: Recommendation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Recommendation/Delete/5
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
    }
}
