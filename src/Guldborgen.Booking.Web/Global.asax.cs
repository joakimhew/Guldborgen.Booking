using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Guldborgen.Booking.Common.Models;
using Guldborgen.Booking.Domain;

namespace Guldborgen.Booking.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        internal protected void Application_BeginRequest(object sender, EventArgs e)
        {

            var ip = GetIP(Context);
        }

        internal protected void Application_EndRequest(object sender, EventArgs e)
        {
            if (Response.StatusCode == 401)
            {
                Response.RedirectToRoute("Login");
            }
        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies["SESSION_ID"];

            if (authCookie == null)
            {
                HttpContext.Current.User = null;
                return;
            }

            Guid sessionId = Guid.Parse(authCookie.Value);

            var accountService =
                System.Web.Mvc.DependencyResolver.Current.GetService<IAccountService>();

            var session =accountService.GetUserSessionById(sessionId);

            HttpContext.Current.User = 
                accountService.GetUserBySession(session);
        }

        public static String GetIP(HttpContext context)
        {
            var ip =
                context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(ip))
            {
                ip = context.Request.ServerVariables["REMOTE_ADDR"];
            }

            return ip;
        }
    }
}
