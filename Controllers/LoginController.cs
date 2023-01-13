using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ComplaintTrackerAPI;
using ComplaintTrackerAPI.ExceptionHandler;
using ComplaintTrackerAPI.Models;
namespace ComplaintTrackerAPI.Controllers
{
    public class LoginController : ApiController
    {
        Repository repository = new Repository();
        DataSet dsResponse;
        // GET: api/DoLogin
        [HttpGet]
        [CustomExceptionFilter]
        public HttpResponseMessage DoLogin(ModelUser modelUser)
        {
            dsResponse =   repository.ValidateUser(modelUser);
            if (dsResponse == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else {
                return Request.CreateResponse(HttpStatusCode.OK, dsResponse);
            }
        }
    }
}
