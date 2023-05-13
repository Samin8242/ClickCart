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
    public class ProductController : ApiController
    {
        [HttpGet]
        [Route("api/allproduct")]
        public HttpResponseMessage Product()
        {
            try
            {
                var data = ProductService.GetProduct();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Massage = ex.Message });
            }
        }
        
        [HttpGet]
        [Route("api/product/{id}")]
        public HttpResponseMessage GetProduct(int id)
        {
            try
            {
                var data = ProductService.GetProduct(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }

        }


        [HttpPost]
        [Route("api/product/add")]
        public HttpResponseMessage AddProduct(ProductDTO product)
        {
            try
            {
                var data = ProductService.Create(product);
                return Request.CreateResponse(HttpStatusCode.OK, "Product has been added");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/product/Update/{id}")]
        public HttpResponseMessage UpdateProduct(Product product)
        {
            try
            {
                var data = ProductService.Update(product);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/product/delete/{id}")]
        public HttpResponseMessage DeleteProduct(int id)
        {
            try
            {
                var data = ProductService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.NotFound, "Product has been deleted.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }



        [HttpGet]
        [Route("api/Product/{id}/Review")]
        public HttpResponseMessage ProductReview(int id)
        {
            try
            {
                var data = ProductService.GetwithReviews(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
