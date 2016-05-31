using System.Web.Mvc;

namespace Guldborgen.Booking.Web
{
    public abstract class BaseViewPage : WebViewPage
    {
        //public virtual new CustomPrincipal User => base.User as CustomPrincipal;
    }

    public abstract class BaseViewPage<TModel> : WebViewPage<TModel>
    {
        //public virtual new CustomPrincipal User => base.User as CustomPrincipal;
    }
}