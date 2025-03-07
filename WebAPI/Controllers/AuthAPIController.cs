using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain.Entities;
using Data.Users;
using System.Linq;

namespace WebAPI.Controllers
{
    [RoutePrefix("Auth")]
    public class AuthApiController : ApiController
    {
        private readonly IUserService _userService = new UserService();

        [HttpPost]
        [Route("Login")]
        public HttpResponseMessage Login([FromBody] LoginRequest loginRequest)
        {
            try
            {
                if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Email) || string.IsNullOrEmpty(loginRequest.Password))
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Email and password are required.");   
                }

                var user = _userService.GetUsers().FirstOrDefault(u => u.Email == loginRequest.Email && u.Password == loginRequest.Password);

                if (user == null)
                {
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid credentials.");
                }

                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
