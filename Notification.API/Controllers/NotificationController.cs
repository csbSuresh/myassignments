using Notification.API.Models;
using Notification.API.Repositories;
using Notification.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Notification.API.Controllers
{
    [RoutePrefix("api/v1.0/schedule")]
    public class NotificationController : ApiController
    {
        private readonly INotification notification;
        public NotificationController(INotification _notification)
        {
            notification = _notification;
        }

        /// <summary>
        /// Gets the rectangle details.
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Route("getschedule/{entityId}")]
        public HttpResponseMessage GetCompany([FromUri] string entityId)
        {
            try
            {
                var scheduledetails = notification.GetNotificationDetails(entityId);

                if (scheduledetails != null && scheduledetails.Count > 0)
                {
                    //modify the response as required
                    CompanyNotificationDetails details = new CompanyNotificationDetails();
                    details.CompanyId = entityId;
                    details.Notifications = scheduledetails.Select(x => x.Notification_Date.ToString("dd/MM/yyy")).ToArray();
                    return Request.CreateResponse(HttpStatusCode.OK, details);
                }
                else
                    return Request.CreateResponse(HttpStatusCode.NoContent,"No schedule found for the given entity Id");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
