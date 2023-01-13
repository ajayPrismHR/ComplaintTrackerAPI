using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ComplaintTrackerAPI.Models;

namespace ComplaintTrackerAPI.Controllers
{
    public class ComplaintController : ApiController
    {
        Repository repository = new Repository();

        [HttpPost]
        public HttpResponseMessage SaveComplaint(Models.COMPLAINT modelComplaint)
        {

            COMPLAINT obj = new COMPLAINT();

            int complaintNo = repository.SaveComplaint(modelComplaint);
            if (complaintNo <=0)
            {
            
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Error in save");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK,"Save Successfully Complaint No." + complaintNo.ToString());
            }

        }

    }
}
