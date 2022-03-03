using Notification.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.API.Services
{
    public interface ICompany
    {
        Company AddCompany(Company company);
        Company GetCompanyById(string id);
        Company GetCompanyByName(string name);
    }
}
