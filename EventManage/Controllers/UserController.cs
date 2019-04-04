using Domain.Entities;
using EventManage.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EventManage.Controllers
{
    public class UserController : Controller
    {
        IUserService US = new UserService();
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        // GET: User/Details/5
        public async Task<ActionResult> Details(int id)
        {
            
            var user = UserManager.FindById(id);
            //String username = doctor.UserName;
            //User user = await UserManager.FindByEmailAsync(doctor.UserName);

            UserViewModel UserViewModel = new UserViewModel();
            UserViewModel.Id = user.Id;
            UserViewModel.FirstName = user.FirstName;
            UserViewModel.LastName = user.LastName;
            UserViewModel.HomeAddress = user.HomeAddress;
            UserViewModel.City = user.City;
            UserViewModel.Gender = user.Gender;
            UserViewModel.BirthDate = user.BirthDate;
            UserViewModel.Image = user.Image;
            


            return View(UserViewModel);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
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

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var bib = US.GetById(id);


            UserViewModel uvm = new UserViewModel();
          
            uvm.LastName = bib.LastName;
            uvm.FirstName = bib.FirstName;
            uvm.Gender = bib.Gender;
            uvm.City = bib.City;
            uvm.Image = bib.Image;
            uvm.HomeAddress = bib.HomeAddress;

            return View(uvm);
        }
           


        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserViewModel DVM, HttpPostedFileBase Image)
        {

            User d = US.GetById(id);


            d.Id = DVM.Id;
            d.LastName = DVM.LastName;
            d.FirstName = DVM.FirstName;
            d.Gender = DVM.Gender;
            d.City = DVM.City;
            var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
            Image.SaveAs(path);
            d.Image = Image.FileName;
            d.HomeAddress = DVM.HomeAddress;

            US.Update(d);
            US.Commit();
            return RedirectToAction("Details", new { id = d.Id });


            
            
           
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
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
