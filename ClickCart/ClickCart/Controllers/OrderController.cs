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
    public class OrderController : ApiController
    {
        [HttpGet]
        [Route("api/allorder")]
        public HttpResponseMessage Order()
        {
            try
            {
                var data = OrderService.GetOrder();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Massage = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/order/{id}")]
        public HttpResponseMessage GetOrder(int id)
        {
            try
            {
                var data = OrderService.GetOrder(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }

        }


        [HttpPost]
        [Route("api/order/add")]
        public HttpResponseMessage AddOrder(OrderDTO order)
        {
            try
            {
                var data = OrderService.Create(order);
                return Request.CreateResponse(HttpStatusCode.OK, "Product has been added");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/order/Update/{id}")]
        public HttpResponseMessage UpdateOrder(Order order)
        {
            try
            {
                var data = OrderService.Update(order);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/order/delete/{id}")]
        public HttpResponseMessage DeleteOrder(int id)
        {
            try
            {
                var data = OrderService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.NotFound, "Product has been deleted.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }

    }
}
