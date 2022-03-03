using Notification.API.Data;
using Notification.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Notification.API.Repositories
{
    public class NotificationDetails : INotification
    {
        private SchedulingSystemEntities context = new SchedulingSystemEntities();

        /// <summary>
        /// Retrieves the notification details for the given company
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public List<CompanyNotification> GetNotificationDetails(string entityId)
        {
            //get the company id based on entity Id
            var company = context.CompanyInfoes.Where(x => x.Entity_Id == entityId).SingleOrDefault();
            if (company != null)
                return context.CompanyNotifications.Where(x => x.Company_Id == company.Id).ToList();
            else return null;
        }
    }
}