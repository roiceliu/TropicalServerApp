using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TropicalServer.BLL;
using System.Data;
using TropicalServerApp.Models;
using System.Web.Security;

namespace TropicalServerApp.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        // GET: Products
        public ActionResult Product()
        { 
            return View();
        }


        public ActionResult ShowItemType(string ItemTypeDescription)
        {
            
            //get default view
            if(ItemTypeDescription == null)
            {
                ItemTypeDescription = "Caribbean Line";
            }
            DataSet db = new ReportsBLL().GetProductByProductCategory_BLL(ItemTypeDescription);
            return PartialView(db);
        }

        public ActionResult Orders()
        {
            return View();
        }
    }
}