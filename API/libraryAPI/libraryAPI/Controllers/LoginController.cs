using libraryAPI.Entities;
using libraryAPI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace libraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration config) 
        {
            _configuration = config;
        }


        [HttpPost]
        public ActionResult<object> Login([FromBody] User user)
        {
            string secret = this._configuration.GetValue<string>("Secret");
            var jwtHelper = new JWTHelper(secret);
            var token = jwtHelper.CreateToken(user.Name);

            return Ok(new
            {
                ok = true,
                msg = "Logeado con exíto.",
                token
            });
        }
    }
}
