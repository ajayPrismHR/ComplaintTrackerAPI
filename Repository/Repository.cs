using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ComplaintTrackerAPI.Models;
namespace ComplaintTrackerAPI
{
    
    public class Repository
    {
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["ConComplaintTracker"].ConnectionString;
        DataSet ds;
        public DataSet ValidateUser(Models.ModelUser user)
        {
            try
            {
                SqlParameter[] param ={
                    new SqlParameter("@Username",user.LoginId.Trim()),
                    new SqlParameter("@Password",Utility.EncryptText(user.Password.Trim()) )
                                       };

                ds = SqlHelper.ExecuteDataset(connStr, CommandType.StoredProcedure, "Validate_User", param);
                
            }
            catch (Exception ex)
            {
                
            }
            return ds;
        }


    }
}