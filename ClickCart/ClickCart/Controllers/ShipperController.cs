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
    public class ShipperController : ApiController
    {
        [HttpGet]
        [Route("api/allShipper")]
        public HttpResponseMessage Shippers()
        {
            try
            {
                var data = ShipperService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/Shipper/{username}")]
        public HttpResponseMessage SingleShipper(string username)
        {
            try
            {
                var data = ShipperService.Get(username);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        [Route("api/shipper/add")]
        public HttpResponseMessage Create(ShipperDTO obj)
        {
            try
            {
                var data = ShipperService.Create(obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }




        [HttpPost]
        [Route("api/shipper/Update/{username}")]
        public HttpResponseMessage UpdateShipper(Shipper username)
        {
            try
            {
                var data = ShipperService.Update(username);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/shipper/delete/{username}")]
        public HttpResponseMessage DeleteUser(string username)
        {
            try
            {
                var data = ShipperService.Delete(username);
                return Request.CreateResponse(HttpStatusCode.NotFound, "Product has been deleted.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }
    }
}
