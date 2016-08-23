﻿namespace AW.WebAPI.Controllers
{

    #region Using
    using AW.Common.Constants;
    using AW.Common.Utils;
    using Bussiness.Customer;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    #endregion

    public class CustomersController : ApiController
    {
        private ICustomerManager customerManager;
        public CustomersController(ICustomerManager customerManager)
        {
            this.customerManager = customerManager;
        }

        [HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            if (id == 0)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, Message.Common.RequestInvalid);

            return Request.CreateResponse(HttpStatusCode.OK, customerManager.GetById(id));
        }

        [HttpGet]
        public HttpResponseMessage Search(string sorting = null, int pageIndex = 1, int pageSize = 100)
        {
            var sortParsed = CommonUtils.ParseSorting(sorting);

            string error = string.Empty;
            var result = customerManager.Search(pageIndex, pageSize, out error, sortParsed);
            if (!string.IsNullOrEmpty(error))
                return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, error);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        public HttpResponseMessage InsertOrUpdate(Models.Customer customer)
        {
            if(customer == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, Message.Common.RequestInvalid);

            if (customer.CustomerID != 0)
                return Request.CreateResponse(HttpStatusCode.OK, customerManager.Update(customer));
            else
                return Request.CreateResponse(HttpStatusCode.OK, customerManager.Create(customer));
        }
    }
}
