using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using TropicalServerApp.Models;
using TropicalServer.BLL;
using System.Web.Security;


namespace TropicalServerApp.Controllers
{
    public class UserAccountBinder : IModelBinder
    {
        //bind the input from user account to UserAccount object
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpContextBase objContext = controllerContext.HttpContext;
            string userName = objContext.Request["UserID"];
            string userPassword = objContext.Request["Password"];
            UserAccount user = new UserAccount
            {
                UserID = userName,
                Password = userPassword
            };

            return user;
        }
    }

    public class LoginController : Controller
    {


        // GET: Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            //if cookie saved userID, display it
            UserAccount user = new UserAccount();
            if (Request.Cookies["Login"] != null)
            {
                user.UserID = Request.Cookies["Login"].Values["UserID"];
                user.RememberMe = true;
            }
            return View(user);
        }

        //get all user filled data from Login form: userName & userpassword => check if correct
        // public ActionResult SubmitLogin([ModelBinder(typeof(UserAccountBinder))] UserAccount obj)
        [HttpPost]
        [AllowAnonymous]
        public ActionResult SubmitLogin(UserAccount obj)
        {
            if (ModelState.IsValid)
            {
                ReportsBLL Bll = new ReportsBLL();
                var isValid = Bll.IsValidUser(obj.UserID, obj.Password);
                if (isValid)
                {
                    Session["UserId"] = obj.UserID;
                    FormsAuthentication.SetAuthCookie(obj.UserID, obj.RememberMe);

                    //use RememberMe checkbox to decide if saving UserID or not
                    if (obj.RememberMe)
                    {
                        HttpCookie cookie = new HttpCookie("Login");
                        cookie.Values.Add("UserID", obj.UserID);
                        cookie.Expires = DateTime.Now.AddDays(15);
                        Response.Cookies.Add(cookie);
                    }
                    else
                    {
                        HttpCookie cookie = new HttpCookie("Login");
                        cookie.Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies.Add(cookie);
                    }
                    return RedirectToAction("Product", "Product");
                }

                ViewData["ErrorMessage"] = "UserID or Password is incorrect";
                return View("Login");
               
            }
            else
            {
                return View("Login");
            }

        }

        [AllowAnonymous]
        public ActionResult Forget()
        {
            return View("LoginResult");
        }

        [HttpPost]
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}