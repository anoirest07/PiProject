using DATA;
using Domain.Entities;
using Domaine.Entities;
using EventManage.Models;
using Microsoft.AspNet.Identity;
using Service.TicketSer;
using Stripe;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

using System.Web;
using System.Web.Mvc;
using static EventManage.Models.TicketViewModel;

namespace EventManage.Controllers
{
    
    public class TicketController : Controller
    {
        ITicketService it = new TicketService();
        // GET: Ticket
        public ActionResult Index()
        {
            //List<TicketViewModel> ticket = new List<TicketViewModel>();
            //var r = it.GetAll();
            //foreach (var item in r)
            //{
            //    TicketViewModel pvm = new TicketViewModel();
            //    if (item.IdEvent == id)
            //    {
            //        pvm.IdTicket = item.IdTicket;
            //        pvm.Prix = item.Prix;
            //        pvm.IdEvent = item.IdEvent;




            //    ticket.Add(pvm);
            //    }
            //}
            
           
            



            return View();
            
        }

        // GET: Ticket/Details/5
        public ActionResult Details(int id)

        {
            var t = new Ticket();
            TicketViewModel tvm = new TicketViewModel();
            tvm.IdTicket = t.IdTicket;
            tvm.Prix = t.Prix;
            
            return View(tvm);
            
        }

        // GET: Ticket/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ticket/Create
        [HttpPost]
        public ActionResult Create(TicketViewModel tvm, int id)
        {

            Ticket T = new Ticket();
            //Context ctx = new Context();
            //ctx.Ticket.Add(new  Ticket {
            //    IdEvent = tvm.IdEvent , 
            //    Prix = tvm.Prix ,

            //     });

            //ctx.SaveChanges();
            T.IdEvent = tvm.IdEvent=id;
            T.Prix = tvm.Prix;
            
            
            
            it.Add(T);
            it.Commit();


            return View(tvm);
         }
           
        

        // GET: Ticket/Edit/5
        public ActionResult Edit(int id)
        {
            var t = it.GetById(id);
            TicketViewModel tvm = new TicketViewModel();
            tvm.IdTicket = t.IdTicket;
            tvm.Prix = t.Prix;
            tvm.Evenement.Methodepai = t.Evenement.Methodepai;
            return View(tvm);
        }

        // POST: Ticket/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Ticket t = it.GetById(id);
            TicketViewModel tvm = new TicketViewModel();
            t.Prix = tvm.Prix;
            t.Evenement.Methodepai = tvm.Evenement.Methodepai;
            t.Evenement.NbPlaceEvent = tvm.Evenement.NbPlaceEvent;
            it.Update(t);
            it.Commit();
            return RedirectToAction("Details","Ticket");
        }

        // GET: Ticket/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ticket/Delete/5
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
        public ActionResult Custom()
        {
            string stripePublishableKey = ConfigurationManager.AppSettings["stripePublishableKey"];
            var model = new CustomViewModel() { StripePublishableKey = stripePublishableKey, PaymentForHidden = true };
            return View(model);
        }
        public ActionResult Charge(string stripeEmail, string stripeToken)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                SourceToken = stripeToken
            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = 500,
                Description = "Sample Charge",
                Currency = "usd",
                CustomerId = customer.Id
            });

            return View();
        }
        [HttpPost]
        public ActionResult Create2( int id)
        {
            int userconnect = Int32.Parse(User.Identity.GetUserId());

            Ticket T = new Ticket();
            //Context ctx = new Context();
            //ctx.Ticket.Add(new  Ticket {
            //    IdEvent = tvm.IdEvent , 
            //    Prix = tvm.Prix ,

            //     });

            //ctx.SaveChanges();
            TicketViewModel tvm = new TicketViewModel();
            T.IdTicket = tvm.IdTicket = id;
           // T.ParticipantAchat = ;
           

            it.Add(T);
            it.Commit();


            return View(tvm);
        }

    }
}
