using DomainLayer.Interfaces;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace WebApiAssignment.AuthenticationProvider
{
    public class AuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly IUserService _userService;
        public AuthProvider(IUserService userService) { _userService = userService; }
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            var foundUser = await _userService.GetUserAsync(context.UserName);
            if (foundUser != null && foundUser.Password == context.Password)
            {

                identity.AddClaim(new Claim("username", context.UserName));
                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid_grant", "Provided username and password is incorrect");
            return;
            }
        }
    }
}