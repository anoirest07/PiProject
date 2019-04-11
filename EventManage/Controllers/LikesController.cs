using Domain.Entities;

using EventManage.Models;
using Microsoft.AspNet.Identity;
using Service.LikeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManage.Controllers
{
    public class LikesController : Controller
    {
        LikeService LS = new LikeService();
        // GET: Likes
        public ActionResult Index()
        {
            return View();
        }

        // GET: Likes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Likes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Likes/Create
        [HttpPost]
        public ActionResult Create(LikesViewModel lvm, int idp)
        {
            
            Likes like = new Likes();
         
            like.IdParticipant = int.Parse(User.Identity.GetUserId());
            like.LikedDate = DateTime.Now;
           
            like.IdPost = idp;
            LS.Add(like);
            LS.Commit();


            return RedirectToAction("../Post/Details");
        }

        public ActionResult Like(int id, LikesViewModel lvm)
        {
            int u = int.Parse(User.Identity.GetUserId());
            if (LS.Test(id,u).Equals(true)) {
                return RedirectToAction("Details", "Post", new { id });
            }
            else { 
            List<LikesViewModel> list = new List<LikesViewModel>();

           
                Likes l = new Likes();
                l.IdParticipant = int.Parse(User.Identity.GetUserId());
                l.IdPost = id;
                l.LikedDate = DateTime.Now;
                LS.Add(l);
                LS.Commit();
                return RedirectToAction("Details", "Post", new { id });

            }


        }
        public Boolean Exist(int id, int idu)
        {
            var a = LS.GetAll();
            foreach (var i in a)
            {
                if (i.IdPost == id && i.IdParticipant == idu)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

            return true;
        }

        // GET: Likes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Likes/Edit/5
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

        // GET: Likes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Likes/Delete/5
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
        //public string LikeThis(int id)
        //{
        //    Post art =new Post();
            
        //        art.Like++;
        //        Likes like = new Likes();
        //        like.IdLike = id;
        //        like.IdParticipant = int.Parse(User.Identity.GetUserId()); 
        //        like.LikedDate = DateTime.Now;
        //        like.Liked = true;
        //        LS.Add(like);
        //      LS.Commit();
        //    string l = art.Like.ToString();

            

        //    return l ;
        //}
    }
}
