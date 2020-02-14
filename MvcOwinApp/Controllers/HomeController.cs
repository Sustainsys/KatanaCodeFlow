using Microsoft.Owin.Security.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MvcOwinApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<ActionResult> About()
        {
            var authenticationResult = await HttpContext.GetOwinContext().Authentication.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationType);

            var accessToken = authenticationResult.Properties.Dictionary["access_token"];

            ViewBag.Message = "Access token: " + accessToken;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";

            return View();
        }
    }
}