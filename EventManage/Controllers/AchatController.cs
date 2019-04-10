using Domaine.Entities;
using EventManage.Models;
using Microsoft.AspNet.Identity;
using Service.AchatSer;
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
   
    public class AchatController : Controller
    {
        IAchatService AS = new AchatService();
        // GET: Achat
        public ActionResult Index()
        {
            return View();
        }

        // GET: Achat/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Achat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Achat/Create
        [HttpPost]
        public ActionResult Create(AchatViewModel tvm,int id)
        {
            int userconnect = Int32.Parse(User.Identity.GetUserId());
            Achat a = new Achat();
            

            a.IdTicket = tvm.IdTicket = id;
            a.IdParticipant = userconnect;
            a.Quantites = tvm.Quantites;

            AS.Add(a);
            AS.Commit();


            return RedirectToAction("Charge", "Achat");


        }

        // GET: Achat/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Achat/Edit/5
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

        // GET: Achat/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Achat/Delete/5
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
    }
}
