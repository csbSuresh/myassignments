using Notification.API.Models;
using Notification.API.Repositories;
using Notification.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Notification.API.Controllers
{
    [RoutePrefix("api/v1.0/company")]
    public class CompanyController : ApiController
    {
        private readonly ICompany company;
        private readonly ISchedule schedule;       
        public CompanyController(ICompany _company, ISchedule _schedule)
        {
            company = _company;
            schedule = _schedule;
        }

        /// <summary>
        /// Gets the company details.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("byId/{entityId}")]
        public HttpResponseMessage GetCompanyById([FromUri] string entityId)
        {
            try
            {
                var companydetails = company.GetCompanyById(entityId);
                if (companydetails != null)
                    return Request.CreateResponse(HttpStatusCode.OK, companydetails);
                else
                    return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Gets the company details.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("byName/{name}")]
        public HttpResponseMessage GetCompanyByName([FromUri] string name)
        {
            try
            {
                var companydetails = company.GetCompanyByName(name);
                if (companydetails != null)
                    return Request.CreateResponse(HttpStatusCode.OK, companydetails);
                else
                    return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Save the company details
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>

        [HttpPost]
        [Route("savecompany")]
        public HttpResponseMessage Save([FromBody] Company entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //save company details to database
                    var companydetails = company.AddCompany(entity);

                    //create schedule for the company
                    schedule.CreateSchedule(companydetails);
                    return Request.CreateResponse(HttpStatusCode.OK, companydetails);
                }
                else
                {
                    //retrieve errors from model state and send the response, we can also do this using the global filters
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
