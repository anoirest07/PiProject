using Domain.Entities;
using EventManage.Models;
using Microsoft.AspNet.Identity;
using Service;
using Service.CommentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManage.Controllers
{
    public class CommentController : Controller
    {
        ServiceUser us = new ServiceUser();
        CommentService repo = new CommentService();

        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }

        // GET: Comment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {

            //List<CommentViewModel> List = new List<CommentViewModel>();


            //var a = repo.GetAll();
            //foreach (var i in a)
            //{
            //    CommentViewModel avm = new CommentViewModel();
            //    avm.CommentId = i.CommentId;
            //    avm.ContenuCom = i.ContenuCom;
            //    avm.ParticipantName = i.ParticipantName;
            //    avm.ParticipantName = i.ParticipantName;
            //    List.Add(avm);
            //}


            //ViewBag.plus = List; //objemp is employee class object  
            //                     //OR You can use ViewBag OR ViewData.ViewData is more efficiant way as compare to ViewBag  
            //ViewData["plus"] = List; //objemp is employee class object  
            return View();



            
        }


        // POST: Comment/Create

        [HttpPost]
        public ActionResult Create(int id, CommentViewModel cvm)
        {
            
             User u = new User();
            UserService userService = new UserService();
            
            Comment c = new Comment();
            c.CommentId =cvm.CommentId;
            c.DateCom = DateTime.Now;
            c.ParticipantId = int.Parse(User.Identity.GetUserId()); ;
            c.PostId = id;
            c.ParticipantName = us.GetUserById(c.ParticipantId).FirstName + " " + us.GetUserById(c.ParticipantId).LastName;
            c.ContenuCom = cvm.ContenuCom;
            
            repo.Add(c);
            repo.Commit();

            return RedirectToAction("../Post/Details", new { id = c.PostId });
        }

        // GET: Comment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Comment/Edit/5
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

        // GET: Comment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Comment/Delete/5
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
