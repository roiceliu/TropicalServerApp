using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using TropicalServerApp.Models;
using TropicalServer.BLL;


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
        // static user object 
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        //get all user filled data from Login form: userName & userpassword => check if correct
        // public ActionResult SubmitLogin([ModelBinder(typeof(UserAccountBinder))] UserAccount obj)
        public ActionResult SubmitLogin(UserAccount obj)
        {
            if (ModelState.IsValid)
            {
                ReportsBLL Bll = new ReportsBLL();
                var isValid = Bll.IsValidUser(obj.UserID, obj.Password);
                if (isValid)
                {
                    Session["UserId"] = obj.UserID;
                    Session["Password"] = obj.Password;
                    return RedirectToAction("Product", "Product");
                }
                else
                {
                    return View("Login");
                }
            }
            else
            {
                return View("Login");
            }



        }

    }
}