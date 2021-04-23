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
            string userName = objContext.Request["userName"];
            string userPassword = objContext.Request["userPassword"];
            UserAccount user = new UserAccount
            {
                UserName = userName,
                UserPassword = userPassword
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
            ReportsBLL Bll = new ReportsBLL();
            DataSet ds = Bll.GetUsersSetting_BLL();
            Console.WriteLine("getting user setting" + ds);
            //Bll.IsValidUser(obj.UserName, obj.UserPassword);
            return View("LoginResult", obj);
        }

    }
}