using NHibernate.Linq;
using SimpleBlog.Models;
using SimpleBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SimpleBlog.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToRoute("home");
        }
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AuthLogin form,string returnUrl)
        {
           
           
           var user = Database.Session.Query<User>().FirstOrDefault(u => u.Username == form.username);
            if (user == null)
                SimpleBlog.Models.User.FakeHash();
            if (user == null || !user.checkPassword(form.password))
                    ModelState.AddModelError("Username", "Userame or Password not match");

            if (!ModelState.IsValid)
                return View(form);

            FormsAuthentication.SetAuthCookie(user.Username, true);

                 if (!string.IsNullOrWhiteSpace(returnUrl))
                 return Redirect(returnUrl);

                 return RedirectToRoute("home");
            }
        }
    }
