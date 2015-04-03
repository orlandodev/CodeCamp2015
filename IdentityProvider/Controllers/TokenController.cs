
using System.Web.Http.Cors;
using IdentityProvider.Models;
using IdentityProvider.Utility;
using System;
using System.IdentityModel.Protocols.WSTrust;
using System.IdentityModel.Tokens;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;

namespace IdentityProvider.Controllers
{
    [EnableCors(origins: "http://localhost:4439", headers: "*", methods: "*")]
    public class TokenController : ApiController
    {
        public HttpResponseMessage Post([FromBody] TokenRequest tokenRequest)
        {
            // authenticate against external data source
            var provider = new AuthProvider();
            var model = new LoginModel {Password = tokenRequest.Password, UserId = tokenRequest.UserId};

            if (!provider.Authenticate(model))
            {
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid credentials");
            }

            var descriptor = new SecurityTokenDescriptor
            {
                Lifetime = new Lifetime(DateTime.UtcNow, DateTime.UtcNow.AddHours(1)),
                SigningCredentials =
                    new X509SigningCredentials(CertificateUtility.GetCert(StoreName.My, StoreLocation.LocalMachine,
                        "CN=TokenSigning")),
                Subject = new ClaimsIdentity(provider.Claims),
                TokenIssuerName = "TokenSigning"
            };

            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.CreateToken(descriptor);
            var token = handler.WriteToken(jwt);

            var response = new TokenResponse{AccessToken = token, ExpiresIn = 3600, TokenType = "Bearer"};

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
