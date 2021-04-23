using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace TropicalServer.DAL
{
    public class ReportsDAL
    {
        string connString = Convert.ToString(ConfigurationManager.AppSettings["TropicalServerConnectionString"]);


        //get specific user's login information
        public DataSet GetLogin(string UserID, string Password)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                { 
                    string query = "select UserID, Password from dbo.tblUserLogin where UserID = @UserID and Password = @Password";
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.CommandType = CommandType.Text;
                    command.CommandTimeout = 6000;
                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@Password", Password);

                    SqlDataAdapter adp = new SqlDataAdapter(command);
                    adp.Fill(ds, "Login");
                    connection.Close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while retrieving User Login Info - " + ex.Message.ToString());
            }
        }

        /*
         * Insert item description to get the #, description, 
         * pre-price and size of the item           
         */
        public DataSet GetProductByProductCategory_DAL(string newItemDescription)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            DataSet ds = new DataSet();

            parameters[0] = new SqlParameter("@itemDescription", SqlDbType.NVarChar);

            if (newItemDescription.Trim() != string.Empty)
                parameters[0].Value = newItemDescription.Trim();

            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetProductByProductCategory", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        SqlParameter p = null;
                        foreach (SqlParameter sqlP in parameters)
                        {
                            p = sqlP;
                            if (p != null)
                            {
                                if (p.Direction == ParameterDirection.InputOutput ||
                                   p.Direction == ParameterDirection.Input && p.Value == null)
                                {
                                    p.Value = DBNull.Value;
                                }
                                command.Parameters.Add(p);
                            }
                        }
                    }
                    command.CommandTimeout = 6000;
                    SqlDataAdapter adp = new SqlDataAdapter(command);
                    adp.Fill(ds);
                    connection.Close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while retrieving Product Categories - " + ex.Message.ToString());
            }
        }//End of GetProductByProductCategory_DAL method...

        /*
         *Enter a number to populate 
         * the CustSalesRepNumber
         */
        public DataSet GetCustSalesRepNumber_DAL(int newCustSaleRepNum)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            DataSet ds = new DataSet();

            parameters[0] = new SqlParameter("@custSaleRepNum", SqlDbType.Int);

            if (newCustSaleRepNum != 0)
                parameters[0].Value = newCustSaleRepNum;

            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetCustSalesRepNumber", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    if (parameters != null)
                    {
                        SqlParameter p = null;
                        foreach (SqlParameter sqlP in parameters)
                        {
                            p = sqlP;
                            if (p != null)
                            {
                                if (p.Direction == ParameterDirection.InputOutput ||
                                   p.Direction == ParameterDirection.Input && p.Value == null)
                                {
                                    p.Value = DBNull.Value;
                                }
                                command.Parameters.Add(p);
                            }
                        }
                    }
                    command.CommandTimeout = 6000;
                    SqlDataAdapter adp = new SqlDataAdapter(command);
                    adp.Fill(ds);
                    connection.Close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while retrieving Sales Representative Number - " + ex.Message.ToString());
            }
        }// End of GetCustSalesRepNumber_DAL method...

        /*
         * Select custSalesRepNum on the 
         * side bar to get the route info.
         */
        public DataSet GetRouteInfo_DAL(int newRouteID)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            DataSet ds = new DataSet();

            parameters[0] = new SqlParameter("@roleID", SqlDbType.Int);

            parameters[0].Value = newRouteID;

            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetRouteInfo", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    if (parameters != null)
                    {
                        SqlParameter p = null;
                        foreach (SqlParameter sqlP in parameters)
                        {
                            p = sqlP;
                            if (p != null)
                            {
                                if (p.Direction == ParameterDirection.InputOutput ||
                                   p.Direction == ParameterDirection.Input && p.Value == null)
                                {
                                    p.Value = DBNull.Value;
                                }
                                command.Parameters.Add(p);
                            }
                        }
                    }
                    command.CommandTimeout = 6000;
                    SqlDataAdapter adp = new SqlDataAdapter(command);
                    adp.Fill(ds);
                    connection.Close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while retrieving Route Info - " + ex.Message.ToString());
            }

        }// End of GetRouteInfo_DAL method...

        /*
         * Get the Name,LoginID, password, Role Description
         * of the User who are active(true).
         */
        public DataSet GetUsersSetting_DAL()
        {
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetUsersSetting", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 6000;
                    SqlDataAdapter adp = new SqlDataAdapter(command);
                    adp.Fill(ds);
                    connection.Close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while retrieving Route Info - " + ex.Message.ToString());
            }
        }// End of GetRouteInfo_DAL method...


        /*
         * Get the Customers for Setting page.
         */
        public DataSet GetCustomersSetting_DAL()
        {
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetCustomersSetting", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 6000;
                    SqlDataAdapter adp = new SqlDataAdapter(command);
                    adp.Fill(ds);
                    connection.Close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while retrieving Route Info - " + ex.Message.ToString());
            }
        }// End of GetCustomersSetting_DAL method...

        /*
         * Get the Price Group Info for Setting page.
         */
        public DataSet GetPriceGroupSetting_DAL()
        {
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetPriceGroupSetting", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 6000;
                    SqlDataAdapter adp = new SqlDataAdapter(command);
                    adp.Fill(ds);
                    connection.Close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while retrieving Route Info - " + ex.Message.ToString());
            }
        }// End of GetPriceGroup_DAL method...

        public DataSet GetItemTypeID_DAL()
        {
            //[ItemTypeID]

            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("select ItemTypeDescription from tblItemType", connection);
                 //   command.CommandType = CommandType.StoredProcedure;
                  //  command.CommandTimeout = 6000;
                    SqlDataAdapter adp = new SqlDataAdapter(command);
                    adp.Fill(ds);
                    connection.Close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while retrieving item Type - " + ex.Message.ToString());
            }
        }//////////

        public DataSet GetItemsDetail_DAL(string itemType)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            DataSet ds = new DataSet();

          //  parameters[0] = new SqlParameter("@itemID", SqlDbType.VarChar);

            //parameters[0].Value = itemType;

            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("getItemsDetails", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@itemID", itemType);

                    if (parameters != null)
                    {
                        SqlParameter p = null;
                        foreach (SqlParameter sqlP in parameters)
                        {
                            p = sqlP;
                            if (p != null)
                            {
                                if (p.Direction == ParameterDirection.InputOutput ||
                                   p.Direction == ParameterDirection.Input && p.Value == null)
                                {
                                    p.Value = DBNull.Value;
                                }
                                
                            }
                        }
                    }
                    command.CommandTimeout = 6000;
                    SqlDataAdapter adp = new SqlDataAdapter(command);
                    adp.Fill(ds);
                    connection.Close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while retrieving items - " + ex.Message.ToString());
            }

        }

        public DataSet Sample_DAL()
        {
            DataSet ds = new DataSet();

            //  parameters[0] = new SqlParameter("@itemID", SqlDbType.VarChar);

            //parameters[0].Value = itemType;

            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("Sample_procedure", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 6000;
                    SqlDataAdapter adp = new SqlDataAdapter(command);
                    adp.Fill(ds);
                    connection.Close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while retrieving items - " + ex.Message.ToString());
            }

        }

    }
}
