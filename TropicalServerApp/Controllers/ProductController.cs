using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TropicalServer.BLL;
using System.Data;
using TropicalServerApp.Models;

namespace TropicalServerApp.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Product()
        {
            
            return View();
        }

        //[ChildActionOnly]
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