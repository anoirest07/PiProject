using Domain.Entities;
using EventManage.Models;
using Microsoft.AspNet.Identity;
using Service;
using Service.RewardService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManage.Controllers
{
    public class RewardController : Controller
    {
        ServiceUser us = new ServiceUser();
        RewardService RS = new RewardService();
        // GET: Reward
        public ActionResult Index()
        {
            return View();
        }

        // GET: Reward/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reward/Create
        public ActionResult Create(RewardViewModel rvm, int id)
        {
            //int userconnect = 1;
            Reward r = new Reward();
            r.UserId = 1;
            r.EventId = rvm.EventId = id;
            r.description1 = rvm.description1;
            r.firstReward = rvm.firstReward;
            r.description2 = rvm.description2;
            r.SecondReward = rvm.SecondReward;
            r.description3 = rvm.description3;
            r.ThirdReward = rvm.ThirdReward;
           
            RS.Add(r);
            RS.Commit();



            return View(rvm);
        }

        // POST: Reward/Create
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

        // GET: Reward/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reward/Edit/5
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

        // GET: Reward/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reward/Delete/5
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
