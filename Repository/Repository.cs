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


        public int SaveComplaint(Models.COMPLAINT modelComplaint)
        {
            SqlParameter parmretStatus = new SqlParameter();
            parmretStatus.ParameterName = "@retStatus";
            parmretStatus.DbType = DbType.Int32;
            parmretStatus.Size = 8;
            parmretStatus.Direction = ParameterDirection.Output;

            SqlParameter parmretMsg = new SqlParameter();
            parmretMsg.ParameterName = "@retMsg";
            parmretMsg.DbType = DbType.String;
            parmretMsg.Size = 8;
            parmretMsg.Direction = ParameterDirection.Output;


            SqlParameter parmretComplaint_no = new SqlParameter();
            parmretComplaint_no.ParameterName = "@retComplaint_no";
            parmretComplaint_no.DbType = DbType.Int32;
            parmretComplaint_no.Size = 8;
            parmretComplaint_no.Direction = ParameterDirection.Output;




            SqlParameter[] param ={
                    new SqlParameter("@OFFICE_CODE",modelComplaint.OFFICE_CODE_ID),
                    new SqlParameter("@CONSUMER_TYPE",modelComplaint.CONSUMER_TYPE),
                    new SqlParameter("@COMPLAINT_TYPE",modelComplaint.ComplaintTypeId),
                    new SqlParameter("@COMPLAINT_SOURCE_ID",1),//modelComplaint.com),
                    new SqlParameter("@COMPLAINT_CURRENT_STATUS_ID",3),//modelComplaint.COMPLAINT_status_ID),
                    new SqlParameter("@JE_AREA_ID",modelComplaint.JE_AREA),
                    new SqlParameter("@COMPLAINT_status",1),//modelComplaint.COMPLAINT_status_ID),
                    new SqlParameter("@SDO_CODE",modelComplaint.SDO_CODE),
                    new SqlParameter("@NAME",modelComplaint.NAME),

                    new SqlParameter("@FATHER_NAME",modelComplaint.FATHER_NAME),
                    new SqlParameter("@KNO",modelComplaint.KNO),
                    new SqlParameter("@LANDLINE_NO",modelComplaint.LANDLINE_NO),
                    new SqlParameter("@MOBILE_NO",modelComplaint.MOBILE_NO),
                    new SqlParameter("@ALTERNATE_MOBILE_NO",modelComplaint.ALTERNATE_MOBILE_NO),
                    new SqlParameter("@EMAIL",modelComplaint.EMAIL),
                    new SqlParameter("@ACCOUNT_NO",modelComplaint.ACCOUNT_NO),
                    new SqlParameter("@ADDRESS1",modelComplaint.ADDRESS1),
                    new SqlParameter("@ADDRESS2",modelComplaint.ADDRESS2),
                    new SqlParameter("@ADDRESS3",modelComplaint.ADDRESS3),

                    new SqlParameter("@LANDMARK",modelComplaint.LANDMARK),
                    new SqlParameter("@CONSUMER_STATUS",modelComplaint.CONSUMER_STATUS),
                    new SqlParameter("@FEEDER_NAME",modelComplaint.FEEDER_NAME),
                    new SqlParameter("@AREA_CODE",modelComplaint.AREA_CODE),
                    new SqlParameter("@SUB_COMPLAINT_TYPE",modelComplaint.SUB_COMPLAINT_TYPE_ID),//modelComplaint.SUB_COMPLAINT_TYPE_ID),
                    new SqlParameter("@REMARKS",modelComplaint.REMARKS),
                    new SqlParameter("@IS_ACTIVE",true),
                    new SqlParameter("@IS_DELETED",false),
                    new SqlParameter("@TIME_STAMP",DateTime.Now),
                    new SqlParameter("@IS_UPDATED",false),

                    new SqlParameter("@UPDATED_TIME_STAMP",DateTime.Now),
                    new SqlParameter("@PROCESS","I"),
                    new SqlParameter("@REMARK",modelComplaint.REMARKS),
                    new SqlParameter("@REMARK_DATE_TIME",DateTime.Now),
                     new SqlParameter("@USER_ID",modelComplaint.UserId),
                    parmretStatus,parmretMsg,parmretComplaint_no};

            int retStatus = 0;
            try
            {
               
                SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "COMPLAINTS_REGISTER", param);

                if (param[36].Value != DBNull.Value)// status
                    retStatus = Convert.ToInt32(param[36].Value);
                else
                    retStatus = 0;
            }
            catch (Exception ex)
            {
                retStatus = -1;
            }
            return retStatus;
        }


    }
}