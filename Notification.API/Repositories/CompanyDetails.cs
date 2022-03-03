using Notification.API.Data;
using Notification.API.Models;
using Notification.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Notification.API.Repositories
{
    public class CompanyDetails : ICompany
    {
        private SchedulingSystemEntities context = new SchedulingSystemEntities();

        /// <summary>
        /// This method will create the new company
        /// </summary>
        /// <param name="company"></param>
        public Company AddCompany(Company company)
        {
            CompanyInfo info = new CompanyInfo()
            {
                Entity_Id = company.EntityId.ToString(),
                C_Name = company.Name,
                C_Number = company.Number,
                C_Type = company.Type,
                Market = company.Market
            };
            context.CompanyInfoes.Add(info);
            context.SaveChanges();
            Company createdcompany = new Company()
            {
                Id = info.Id,
                EntityId = Guid.Parse(info.Entity_Id),
                Market = info.Market,
                Name = info.C_Name,
                Number = info.C_Number,
                Type = info.C_Type,
                Created = info.CreatedDttm
            };
            return createdcompany;

        }

        /// <summary>
        /// Gets the company details based on the entity id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Company GetCompanyById(string id)
        {
            var details = context.CompanyInfoes.Where(x => x.Entity_Id == id).SingleOrDefault();
            if (details != null)
            {
                Company company = new Company()
                {
                    Id = details.Id,
                    EntityId = Guid.Parse(details.Entity_Id),
                    Market = details.Market,
                    Name = details.C_Name,
                    Number = details.C_Number,
                    Type = details.C_Type
                };
                return company;
            }
            else return null;
        }

        /// <summary>
        /// Gets the company details based on the entity id
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Company GetCompanyByName(string name)
        {
            var details = context.CompanyInfoes.Where(x => x.C_Name == name).SingleOrDefault();
            if (details != null)
            {
                Company company = new Company()
                {
                    Id = details.Id,
                    EntityId = Guid.Parse(details.Entity_Id),
                    Market = details.Market,
                    Name = details.C_Name,
                    Number = details.C_Number,
                    Type = details.C_Type
                };
                return company;
            }
            else return null;
        }
    }
}