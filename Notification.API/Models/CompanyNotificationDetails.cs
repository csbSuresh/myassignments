using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Notification.API.Models
{
    public class CompanyNotificationDetails
    {
        public string CompanyId { get; set; }
        public string[] Notifications { get; set; }
    }
}