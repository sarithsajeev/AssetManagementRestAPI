using AssetManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //1
        private IConfiguration _config;
        private readonly AssetManagementContext _context;
        //2
        public LoginController(IConfiguration config, AssetManagementContext context)
        {
            _config = config;
            this._context = context;
        }


        //generate token
        #region login token

        //login method -- iactionresult
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] Login detail)
        {
            IActionResult response = Unauthorized();

            //authenticate user
            var user = AuthenticateUser(detail);

            //validate
            if (user != null)
            {
                var _token = GenerateJSONWebToken(user);
                response = Ok(new
                {
                    token = _token,
                    UserName = user.UserName,
                    UserType = user.UserType
                });
            }
            return response;
        }

        private object GenerateJSONWebToken(Login user)
        {
            //securitykey
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            //signing cred
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            //generate token
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                null,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private Login AuthenticateUser(Login login)
        {
            /*Login user = null;*/

            //retrieve data from db
            var cred = _context.Login.FirstOrDefault(un => un.UserName == login.UserName && un.Password == login.Password);

            //validate the user credentials
            if (cred != null)
            {
                return cred;
                /*user = new Login
                {
                    UserName = login.UserName,
                    Password = login.Password
                };*/
            }
            return null;
        }

        #endregion
    }
}
