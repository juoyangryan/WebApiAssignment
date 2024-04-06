using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Web;
using System.Web.Http;
using WebApiAssignment.AuthenticationProvider;
using WebApiAssignment.DAL;
using WebApiAssignment.Models;

namespace WebApiAssignment.Controllers
{
    public class AccountController: ApiController
    {
        private UserContext _userContext = new UserContext();

        [HttpPost]
        [Route("api/register")]
        public IHttpActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                var previous = _userContext.Users.FirstOrDefault(data => data.UserName == user.UserName);
                if (previous == null)
                {
                    _userContext.Users.Add(user);
                    _userContext.SaveChanges();
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