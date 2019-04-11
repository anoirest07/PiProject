using Domain.Entities;
using EventManage.Models;
using Microsoft.AspNet.Identity;
using Service;
using Service.CommentService;
using Service.LikeService;
using Service.servicePosts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EventManage.Controllers
{

    public class PostController : Controller
    {

        ServiceUser us = new ServiceUser();
        ServicePost SP = new ServicePost();
        CommentService CommentService = new CommentService();
        // GET: Post
        public ActionResult Index()
        {
            List<string> categories = new List<string> { "type1", "type2" };
            ViewData["filtre"] = new SelectList(categories);
            List<PostViewModel> List = new List<PostViewModel>();


            var a = SP.GetAll();
            foreach (var i in a)
            {
                PostViewModel avm = new PostViewModel();
                avm.IdPost = i.IdPost;
                avm.Title = i.Title;
                avm.Description = i.Description;
                avm.Photo = i.Photo;
                avm.Like = i.Like;
                avm.PostedOn = i.PostedOn;
                avm.Category = (Models.Categories)i.Category;
                avm.ParticipantName = i.ParticipantName;
                avm.commentss = i.commentss;
                List.Add(avm);
            }
            return View(List);

        }
        [HttpPost]
        public ActionResult Index(string searchString, string filtre)
        {
            //création d'une liste de genre pour le filtrage (filtrer par genre)
            List<string> Category = new List<string> { "type1", "type2" };
            List<PostViewModel> lists = new List<PostViewModel>();
            // viewdata pour stocker le filtre 
            ViewData["filtre"] = new SelectList(Category);

            List<Post> Posts = (List<Post>)Session["Posts"];

            // recherche par le 1er parametre searchString
            if (!String.IsNullOrEmpty(searchString))
            {
                lists = lists.Where(m => m.Title.Contains(searchString)).ToList();
                return View(lists);
            }




            // recherche par le 2eme parametre x
            //if (!String.IsNullOrEmpty(x.ToString()))
            //{
            //    Posts = Posts.Where(m => m.Prix == x).ToList();
            //}

            // filtrage 
            if (filtre.ToString().Equals("type1"))
            {
                List<PostViewModel> List = new List<PostViewModel>();
                var a = SP.ListCategorie();
                foreach (var i in a)
                {
                    PostViewModel avm = new PostViewModel();
                    avm.IdPost = i.IdPost;
                    avm.Title = i.Title;
                    avm.Description = i.Description;
                    avm.Photo = i.Photo;
                    avm.PostedOn = i.PostedOn;
                    avm.ParticipantName = i.ParticipantName;
                    List.Add(avm);
                }
                return View(List);
            }
            else if (filtre.ToString().Equals("type2"))
            {
                List<PostViewModel> List = new List<PostViewModel>();
                var a = SP.ListCategorie2();
                foreach (var i in a)
                {
                    PostViewModel avm = new PostViewModel();
                    avm.IdPost = i.IdPost;
                    avm.Title = i.Title;
                    avm.Description = i.Description;
                    avm.Photo = i.Photo;
                    avm.PostedOn = i.PostedOn;
                    avm.ParticipantName = i.ParticipantName;
                    List.Add(avm);
                }
                return View(List);
            }
            else
            {
                return View(Posts);

            }
            
        }
        public int likes(int id)
        {
            LikeService likeService = new LikeService();

            int likess = likeService.nbrLike(id).Count();
            return likess;
        }

        // GET: Post/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post p;
            p = SP.GetById((int)id);
            if (p == null) { return HttpNotFound(); }
            PostViewModel pvm = new PostViewModel()
            {
                PostedOn = p.PostedOn,
                Description = p.Description,
                Photo = p.Photo,
                //OwnerId=p.OwnerId,
                IdPost = p.IdPost,
                Title = p.Title,
                ParticipantName =p.ParticipantName,
                Like=likes((int)id),
              //  visibility = (VisibilityVM)p.visibility
            };
            GetComments((int)id);
            return View(pvm);
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        public ActionResult Create(Post p, HttpPostedFileBase Image)
        {
            //  int userconnect = Int32.Parse(User.Identity.GetUserId());

            Post ps = new Post() { Category = (Domain.Entities.Categories)p.Category };



            ps.IdPost = p.IdPost;
            //ps.Category = p.Category;
            ps.Title = p.Title;
            ps.Description = p.Description;
            ps.PostedOn = DateTime.Now;
            ps.Like = 0;
            ps.ParticipantId = int.Parse(User.Identity.GetUserId());
            // ps.ParticipantName = User.Identity.GetUserName();
            ps.ParticipantName = us.GetUserById(ps.ParticipantId).FirstName + " " + us.GetUserById(ps.ParticipantId).LastName;

            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
            Image.SaveAs(path);
            ps.Photo = Image.FileName;

            SP.Add(ps);
            SP.Commit();

            // TODO: Add insert logic here



            return RedirectToAction("Index");


            //return View();

        }

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {

            var bib = SP.GetById(id);


            PostViewModel bvm = new PostViewModel();
            bvm.IdPost = bib.IdPost;
            bvm.Title = bib.Title;
            bvm.Description = bib.Description;
            bvm.PostedOn = bib.PostedOn;


            bvm.Category.Equals(bib.Category);

            return View(bvm);
        }

        // POST: Post/Edit/5
        [HttpPost]
        ActionResult Edit(int id, PostViewModel DVM)
        {
            Post d = SP.GetById(id);


            d.IdPost = DVM.IdPost;
            d.Title = DVM.Title;
            d.Description = DVM.Description;
            d.PostedOn = DVM.PostedOn;
            d.Category = (Domain.Entities.Categories)DVM.Category;

            SP.Update(d);
            SP.Commit();
            return RedirectToAction("Index");
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            var bib = SP.GetById(id);


            PostViewModel bvm = new PostViewModel();
            bvm.Title = bib.Title;
            bvm.IdPost = bib.IdPost;
            bvm.Category.Equals(bib.Category);
            bvm.Description = bib.Description;

            return View(bvm);
        }

        // POST: Post/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PostViewModel pvm)
        {
            Post d = SP.GetById(id);
            pvm.IdPost = d.IdPost;
            pvm.Category.Equals(d.Category);
            pvm.Title = d.Title;
            pvm.Description = d.Description;
            pvm.Like = d.Like;

            SP.Delete(d);
            SP.Commit();
            return RedirectToAction("Index");
        }
        public int comments(int id)
        {
            CommentService commentService = new CommentService();

            int commentss = commentService.nbrComment(id).Count();
            return commentss;
        }

        public ActionResult DetailsPost(int id)
        {
            List<CommentViewModel> listComment = new List<CommentViewModel>();
            PostViewModel bvm = new PostViewModel();
            List<PostViewModel> listEventScheduler = new List<PostViewModel>();
            var eventt = SP.GetAll();
            var schedulers = CommentService.GetAll();
            foreach (var pr in eventt)
            {
                if (pr.IdPost == id)
                {
                    bvm.IdPost = pr.IdPost;
                    bvm.Title = pr.Title;
                    bvm.Description = pr.Description;
                    bvm.PostedOn = pr.PostedOn;
                    bvm.Photo = pr.Photo;
                     bvm.Category = (Models.Categories)pr.Category;
                    bvm.ParticipantName = pr.ParticipantName;
                    foreach (Comment s in pr.Comments)
                    {
                        CommentViewModel sv = new CommentViewModel();
                        sv.CommentId = s.CommentId;
                        sv.ContenuCom = s.ContenuCom;
                        sv.DateCom = s.DateCom;
                        sv.ParticipantId = s.ParticipantId;
                        sv.ParticipantName = s.ParticipantName;
                        listComment.Add(sv);
                    }

                    bvm.ListComments = listComment;

                }
            }
            return View(bvm);
        }

        public ActionResult MostLiked()
        {
            List<PostViewModel> List = new List<PostViewModel>();
            var a = SP.MostLikedPost();
            foreach (var i in a)
            {
                PostViewModel avm = new PostViewModel();
                avm.IdPost = i.IdPost;
                avm.Title = i.Title;
                avm.Description = i.Description;
                avm.Photo = i.Photo;
                avm.Like = i.Like;
                avm.PostedOn = i.PostedOn;
                avm.Category = (Models.Categories)i.Category;
                avm.ParticipantName = i.ParticipantName;
                avm.commentss = i.commentss;
                List.Add(avm);
            }
            return View(List);
        }

        //********************************************************************************//

        [HttpPost]
        public ActionResult CreateComment(int PostId, string ContenuCom)
        {


            Comment comment = new Comment()
            {
                
                ContenuCom = ContenuCom,
                PostId = PostId,
                ParticipantId = Int32.Parse(User.Identity.GetUserId()),
                DateCom = DateTime.Now,
                ParticipantName = User.Identity.GetUserName(),


            };

            CommentService.Add(comment);
            CommentService.Commit();



            return Json(comment, JsonRequestBehavior.AllowGet);

        }

        public PartialViewResult GetComments(int PostId)
        {
            var Comments = new List<CommentViewModel>();
            foreach (Comment p in CommentService.GetMany())
            {
                if (p.PostId == PostId)
                {
                    Comments.Add(new CommentViewModel()
                    {
                        CommentId = p.CommentId,
                        ContenuCom = p.ContenuCom,
                        DateCom = p.DateCom,
                        ParticipantName=p.ParticipantName,
                        
                    });
                }


            }

            return PartialView("Comments", Comments);
        }

        [HttpPost]
        public PartialViewResult PostComment(string contenu, int idpub )
        {

            
            Comment comment = new Comment()
            {
               
                ContenuCom = contenu,
                PostId = idpub,
                ParticipantId = Int32.Parse(User.Identity.GetUserId()),
                DateCom= DateTime.Now,
                ParticipantName ="mokhtar",


        };

            CommentService.Add(comment);
           CommentService.Commit();


            return PartialView("SingleComment", new CommentViewModel
            {
                CommentId = comment.CommentId,
                PostId = comment.PostId,
                ContenuCom = comment.ContenuCom
            });

        }

        public ActionResult allcomments(int idpub)
        {
            var Comments = new List<CommentViewModel>();
            foreach (Comment p in CommentService.GetMany())
            {
                if (p.PostId == idpub)
                {
                    Comments.Add(new CommentViewModel()
                    {
                        CommentId = p.CommentId,
                        ContenuCom = p.ContenuCom
                    });
                }

            }
            return View(Comments);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            CommentViewModel c = new CommentViewModel();
            return View(c);
        }
        [HttpPost]
        public ActionResult AddOrEdit(CommentViewModel cm, int id)
        {

            ViewBag.id = id;
            Comment comment = new Comment()
            {
                ContenuCom = cm.ContenuCom,
                PostId = 2

            };

            CommentService.Add(comment);
            CommentService.Commit();
            return RedirectToAction("allcomments");
        }



        //////////test search ////////////////////


        public JsonResult GetSearchingData(string SearchBy, string SearchValue)
        {
            List<Post> StuList = new List<Post>();
            if (SearchBy == "Title")
            {
                try
                {
                    SP.Search(SearchValue);
                  //  StuList = db.RendezVous.Where(x => x.nom.ToString().StartsWith(SearchValue) || SearchValue == null).Where(x => x.idMedecien == Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId())).ToList();
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0} Is Not A ID ", SearchValue);
                }
                
            }
            return Json(StuList, JsonRequestBehavior.AllowGet);


        }






    }
}