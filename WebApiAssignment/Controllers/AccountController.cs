using DomainLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebApiAssignment.AuthenticationProvider;
using WebApiAssignment.Models;

namespace WebApiAssignment.Controllers
{
    public class AccountController: ApiController
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("api/register")]
        public async Task<IHttpActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                var previous =  await _userService.GetUserAsync(user.UserName);
                if (previous == null)
                {
                    DomainLayer.Models.User domainUser = new DomainLayer.Models.User { 
                        Username = user.UserName, 
                        Password = user.Password 
                    };
                    await _userService.AddUserAsync(domainUser);
                    return Ok(user);
                } else
                {
                    return BadRequest("Username Already Exist!");
                }
            } else
            {
                return BadRequest();
            }
        }
    }
}