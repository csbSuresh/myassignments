using Notification.API.Data;
using Notification.API.Models;
using Notification.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Notification.API.Repositories
{
    public class ScheduleDetails: ISchedule
    {
        private SchedulingSystemEntities context = new SchedulingSystemEntities();
        /// <summary>
        /// Create schedule as per the company type and market
        /// </summary>
        /// <param name="company"></param>
        public void CreateSchedule(Company company)
        {       
            //get the schedule details from the backend to create the notifications.
            var schedule = context.CompanyScheduleDetails
                .Where(x => x.Market == company.Market.Trim() && x.Type == company.Type.Trim()).SingleOrDefault();

            //if the schedule exists add notification details
            if (schedule != null)
            {
                var scheduleDays = schedule.Frequency.Split(',').Select(x => int.Parse(x));
                foreach (var item in scheduleDays)
                {
                    CompanyNotification notify = new CompanyNotification();
                    notify.Company_Id = company.Id;
                    notify.Notification_Date = company.Created.AddDays(item);
                    context.CompanyNotifications.Add(notify);
                }
                context.SaveChanges();
            }
        }
    }
}