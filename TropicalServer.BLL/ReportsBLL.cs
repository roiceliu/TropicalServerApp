using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TropicalServer.DAL;//need to import DAL to use its funcitions

namespace TropicalServer.BLL
{
    public class ReportsBLL
    {
       public Boolean IsValidUser(string UserName, string Password)
        {
            DataSet ds = new ReportsDAL().GetLogin(UserName, Password);
            var userCount = ds.Tables["Login"].Rows.Count;
            if(userCount > 0)
            {
                return true;
            }
            return false;
        }

        public DataSet GetUserSetting_BLL()
        {
            return (new ReportsDAL().GetUsersSetting_DAL());
        }

        public DataSet GetProductByProductCategory_BLL(string newItemDescription)
        {
            return (new ReportsDAL().GetProductByProductCategory_DAL(newItemDescription));
        }

        public DataSet GetCustSalesRepNumber_BLL(int newCustSaleRepNum)
        {
            return (new ReportsDAL().GetCustSalesRepNumber_DAL(newCustSaleRepNum));
        }

       

        public DataSet GetCustomersSetting_BLL()
        {
            return (new ReportsDAL().GetCustomersSetting_DAL());
        }

        public DataSet GetPriceGroupSetting_BLL()
        {
            return (new ReportsDAL().GetPriceGroupSetting_DAL());
        }

        public DataSet GetRouteInfo_BLL(int newRouteID)
        {
            return (new ReportsDAL().GetRouteInfo_DAL(newRouteID));
        }
        public DataSet GetItemTypeID_BLL()
        {
            return (new ReportsDAL().GetItemTypeID_DAL());
        }

        public DataSet GetItemsDetail_BLL(string itemType)
        {
            return (new ReportsDAL().GetItemsDetail_DAL(itemType));
        }

        public DataSet Sample_BLL()
        {
            return (new ReportsDAL().Sample_DAL());
        }
    }
}
