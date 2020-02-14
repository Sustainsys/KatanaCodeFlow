using Microsoft.Owin;
using Microsoft.Owin.Logging;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace MvcOwinApp
{
    public partial class Startup
    {
        private void ConfigureAuth(IAppBuilder app)
        {
            var cookieOptions = new CookieAuthenticationOptions();

            app.UseCookieAuthentication(cookieOptions);

            app.SetDefaultSignInAsAuthenticationType(cookieOptions.AuthenticationType);

            OpenIdConnectAuthenticationOptions oidcOptions = new OpenIdConnectAuthenticationOptions
            {
                Authority = "https://localhost:5000",
                ClientId = "mvc",
                ClientSecret = "49C1A7E1-0C79-4A89-A3D6-A37998FB86B0",
                RedirectUri = "https://localhost:44348/signin-oidc",
                ResponseType = "code",
                RedeemCode = true,
                SaveTokens = true

            };

            app.UseOpenIdConnectAuthentication(oidcOptions);
        }
    }
}