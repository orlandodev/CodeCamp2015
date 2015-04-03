
using IdentityProvider.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityProvider.Utility
{
    public class AuthProvider
    {
        public List<Claim> Claims { get; set; }

        public bool Authenticate(LoginModel model)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, model.UserId),
                new Claim(ClaimTypes.Country, "USA"),
                new Claim("http://mysite.com/claims/culture", "en-US")
            };

            this.Claims = claims;

            return true;
        }
    }
}