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
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("api/alluser")]
        public HttpResponseMessage Users()
        {
            try
            {
                var data = UserService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/user/{username}")]
        public HttpResponseMessage SingleUser(string username)
        {
            try
            {
                var data = UserService.Get(username);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        [Route("api/user/add")]
        public HttpResponseMessage Create(UserDTO obj)
        {
            try
            {
                var data = UserService.Create(obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }




        [HttpPost]
        [Route("api/user/Update/{username}")]
        public HttpResponseMessage UpdateUser(User username)
        {
            try
            {
                var data = UserService.Update(username);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/user/delete/{username}")]
        public HttpResponseMessage DeleteUser(string username)
        {
            try
            {
                var data = UserService.Delete(username);
                return Request.CreateResponse(HttpStatusCode.NotFound, "Product has been deleted.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }

       
    }
}
