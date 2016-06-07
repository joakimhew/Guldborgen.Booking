using System;
using System.Web;
using System.Web.Mvc;
using Guldborgen.Booking.Common;
using Guldborgen.Booking.Common.Extensions;

namespace Guldborgen.Booking.Web.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAuthorizeUserAttribute : AuthorizeAttribute
    {
        public CustomAuthorizeUserAttribute()
        {
        }

        public CustomAuthorizeUserAttribute(DistinctRole requiredRole)
        {
            RequiredRole = requiredRole;
        }

        public DistinctRole? RequiredRole { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.User == null)
                return false;

            if (RequiredRole == null)
                return httpContext.User != null;

            return Current.User.HasRole(RequiredRole.Value) && Current.User != null;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
        }
    }
}