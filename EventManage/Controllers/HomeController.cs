using Domain.Entities;
using Microsoft.AspNet.Identity;
using Service;
using System;
using ServicePattern;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManage.Controllers
{
    public class HomeController : Controller

    {
        ServiceUser us = new ServiceUser();
        IUserService uus = new UserService();

        [HttpPost]
        public void getId(String email, String password)
        {
            int id = 0;
            var users = us.GetAll();
            foreach (var i in users)
            {
                if (i.Email.Equals(email) && i.Password.Equals(password))
                {
                    id = i.Id;
                }

            }

        }
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public PartialViewResult UserConnected()
        {
            int currentUserId = 0;
            if (User.Identity.GetUserId() != "")
            {
                currentUserId = Int32.Parse(User.Identity.GetUserId());

            }

            var cuser = new User();
            if (uus.GetById(currentUserId) != null)
            {
                cuser = uus.GetById(currentUserId);

            }
            string userstring = us.GetUserById(currentUserId).ToString();
            if (userstring.Contains("President") == true)

            {
                ViewBag.role = "President";
                TempData["role"] = "President";
                President pvm = new President();
                pvm.Id = cuser.Id;
                pvm.LastName = cuser.LastName;
                pvm.FirstName = cuser.FirstName;
                pvm.City = cuser.City;
                pvm.BirthDate = cuser.BirthDate;
                
                pvm.Gender = cuser.Gender;
                pvm.HomeAddress = cuser.HomeAddress;
                

                pvm.PhoneNumber = cuser.PhoneNumber;
                List<President> listuser = new List<President>();
                listuser.Add(pvm);
                return PartialView(listuser);


            }
            else if (userstring.Contains("Participant") == true)
            {
                ViewBag.role = "Participant";

                TempData["role"] = "Participant";
                Participant pvm = new Participant();
                pvm.Id = cuser.Id;
                pvm.LastName = cuser.LastName;
                pvm.FirstName = cuser.FirstName;
                pvm.City = cuser.City;
                pvm.BirthDate = cuser.BirthDate;
                
                pvm.Gender = cuser.Gender;
                pvm.HomeAddress = cuser.HomeAddress;
               

                pvm.PhoneNumber = cuser.PhoneNumber;
                List<Participant> listuser = new List<Participant>();
                listuser.Add(pvm);
                return PartialView(listuser);


            }
            else
            {
                User pvm = new User();
                pvm.Id = cuser.Id;

                pvm.LastName = cuser.LastName;
                pvm.FirstName = cuser.FirstName;
                pvm.City = cuser.City;
                pvm.BirthDate = cuser.BirthDate;
                
                pvm.Gender = cuser.Gender;
                pvm.HomeAddress = cuser.HomeAddress;
               

                pvm.PhoneNumber = cuser.PhoneNumber;
                List<User> listuser = new List<User>();

                ViewBag.role = "None";

                TempData["role"] = "No type";
                listuser.Add(pvm);
                return PartialView(listuser);


            }




        }
    }
}