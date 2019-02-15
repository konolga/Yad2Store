using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using yad2.Models;

namespace yad2.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Login login, string returnUrl)
        {
            if (ModelState.IsValid)

            using (var context = new Yad2DbContext())
            {
                var users = context.Users.ToList();
                
                User loggeduser = context.Users
                    .FirstOrDefault(u => u.UserName == login.UserName && u.Password == login.Password);
                if (loggeduser != null)
                {
                    FormsAuthentication.SetAuthCookie(login.UserName, true);

                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

                else
                {
                    ModelState.AddModelError("", "The username or password is incorrect");
                }
            }

            return View();
            
        }




        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                using (Yad2DbContext context = new Yad2DbContext())
                {
                    try
                    {
                        User NewUser = new User()
                        {
                            UserName = user.UserName,
                            Email = user.Email,
                            LastName = user.LastName,
                            FirstName = user.FirstName,
                            BirthDate = user.BirthDate,
                            Id = user.Id,
                            Password = user.Password
                        };

                        context.Users.Add(NewUser);
                        context.SaveChanges();
                        FormsAuthentication.SetAuthCookie(NewUser.UserName, false);
                        return RedirectToAction("Index", "Home");
                        
                    }
                    catch (MembershipCreateUserException e)
                    {
                        ModelState.AddModelError("Registration Error",
                        "Registration error: " + e.StatusCode.ToString());
                    }
                }
            }

            return View(user);
        }

        [HttpPost]
        public JsonResult doesUserNameExist(string UserName)
        {

            var user = Membership.GetUser(UserName);

            return Json(user == null);
        }
    }

}