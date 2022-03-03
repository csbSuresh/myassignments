using Notification.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.API.Services
{
    public interface INotification
    {
        List<CompanyNotification> GetNotificationDetails(string entityId);

    }
}
