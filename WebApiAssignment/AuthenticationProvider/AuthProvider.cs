using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using WebApiAssignment.DAL;

namespace WebApiAssignment.AuthenticationProvider
{
    public class AuthProvider : OAuthAuthorizationServerProvider
    {
        private UserContext _userContext = new UserContext();
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            var foundUser = _userContext.Users.FirstOrDefault(user => user.UserName == context.UserName && user.Password == context.Password);
            if (foundUser != null)
            {

                identity.AddClaim(new Claim("username", context.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Role, foundUser.Role));
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