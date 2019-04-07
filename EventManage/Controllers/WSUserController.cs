using Domain.Entities;
using EventManage.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace EventManage.Controllers
{
    public class WSUserController : ApiController
    {
        private UserService service = new UserService();
        // GET: WSIdentity
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public WSUserController()
        {
        }
        public WSUserController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        // POST: /Account/Login
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        [ValidateAntiForgeryToken]
        [System.Web.Http.Route("api/Login")]
        public async Task<IHttpActionResult> login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                string currentUserId = User.Identity.GetUserId();

                return Ok(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return Ok(model);
                case SignInStatus.LockedOut:
                    return Ok();
                case SignInStatus.RequiresVerification:
                    return Ok();
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return Ok();
            }
        }

        // POST: /Account/Register
        [System.Web.Http.HttpPost]

        [System.Web.Http.AllowAnonymous]
        [ValidateAntiForgeryToken]
        [System.Web.Http.Route("api/Register")]
        public async Task<IHttpActionResult> Register(RegisterViewModel model)
        {
            if (model.Role == "Participant")
            {
                //var fileName = Path.GetFileName(Image.FileName);
                //var path = Path.Combine(Server.MapPath("~/Content/Upload/"), fileName);
                //Image.SaveAs(path);
                var user = new Participant { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName, Password = model.Password, PhoneNumber = model.PhoneNumber, PhoneNumberConfirmed = true, Gender = model.Gender, BirthDate = model.BirthDate, City = model.City, HomeAddress = model.HomeAddress };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {

                    //  await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // Pour plus d'informations sur l'activation de la confirmation du compte et la réinitialisation du mot de passe, consultez http://go.microsoft.com/fwlink/?LinkID=320771
                    // Envoyer un message électronique avec ce lien
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirmez votre compte", "Confirmez votre compte en cliquant <a href=\"" + callbackUrl + "\">ici</a>");

                    return Ok(model);

                }

                // Si nous sommes arrivés là, un échec s’est produit. Réafficher le formulaire
                return Ok("Echec");
            }
            else if (model.Role == "President")
            {
                var user = new President { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName, Password = model.Password, PhoneNumber = model.PhoneNumber, PhoneNumberConfirmed = true, Gender = model.Gender, BirthDate = model.BirthDate, City = model.City, HomeAddress = model.HomeAddress };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {

                    //  await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // Pour plus d'informations sur l'activation de la confirmation du compte et la réinitialisation du mot de passe, consultez http://go.microsoft.com/fwlink/?LinkID=320771
                    // Envoyer un message électronique avec ce lien
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirmez votre compte", "Confirmez votre compte en cliquant <a href=\"" + callbackUrl + "\">ici</a>");

                    return Ok(model);

                }

                // Si nous sommes arrivés là, un échec s’est produit. Réafficher le formulaire
                return Ok("Echec");
            }
            else
            {

                var user = new User { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName, Password = model.Password, PhoneNumber = model.PhoneNumber, PhoneNumberConfirmed = true, Gender = model.Gender, BirthDate = model.BirthDate, City = model.City, HomeAddress = model.HomeAddress };

                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {

                    //  await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // Pour plus d'informations sur l'activation de la confirmation du compte et la réinitialisation du mot de passe, consultez http://go.microsoft.com/fwlink/?LinkID=320771
                    // Envoyer un message électronique avec ce lien
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirmez votre compte", "Confirmez votre compte en cliquant <a href=\"" + callbackUrl + "\">ici</a>");

                    return Ok(model);

                }

                // Si nous sommes arrivés là, un échec s’est produit. Réafficher le formulaire
                return Ok("Echec");
            }

        }


        [System.Web.Http.Route("api/UserWS/getusers")]
        public IQueryable<WSUserModel> GetUsers()

        {
          var  roles = ClaimsIdentity.DefaultRoleClaimType.ToList();
            List<User> applicationUsers = service.getUsers();
            List<WSUserModel> applicationUsersToXml = new List<WSUserModel>();
            foreach (User i in applicationUsers)
            {
                applicationUsersToXml.Add(new WSUserModel
                {

                    Id = i.Id,
                    LastName = i.LastName,
                    FirstName = i.FirstName,
                    Email = i.Email,
                    Image = i.Image,
                    Password = i.Password,
                    Gender = i.Gender,
                    BirthDate = i.BirthDate,
                    City = i.City,
                    HomeAddress = i.HomeAddress
                    
                    




            });
            }
            return applicationUsersToXml.AsQueryable();
        }

        // GET: api/WSUser
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/WSUser/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/WSUser
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/WSUser/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/WSUser/5
        public void Delete(int id)
        {
        }

    }
}
