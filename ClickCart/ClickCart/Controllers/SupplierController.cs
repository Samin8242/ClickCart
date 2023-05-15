using BLL.DTOs;
using BLL.Services;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ClickCart.Controllers
{
    public class SupplierController : ApiController
    {
        [HttpGet]
        [Route("api/allsupplier")]
        public HttpResponseMessage Suppliers()
        {
            try
            {
                var data = SupplierService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/supplier/{username}")]
        public HttpResponseMessage SingleSupplier(string username)
        {
            try
            {
                var data = SupplierService.Get(username);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        [Route("api/supplier/add")]
        public HttpResponseMessage Create(SupplierDTO obj)
        {
            try
            {
                var data = SupplierService.Create(obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }




        [HttpPost]
        [Route("api/supplier/Update/{username}")]
        public HttpResponseMessage UpdateSupplier(Supplier username)
        {
            try
            {
                var data = SupplierService.Update(username);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/supplier/delete/{username}")]
        public HttpResponseMessage DeleteUser(string username)
        {
            try
            {
                var data = SupplierService.Delete(username);
                return Request.CreateResponse(HttpStatusCode.NotFound, "Product has been deleted.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }
    }
}
