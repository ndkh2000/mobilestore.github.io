using System.Web.Mvc;

namespace TestUngDung.Areas.KHANHHUNG
{
    public class KHANHHUNGAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "KHANHHUNG";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "KHANHHUNG_default",
                "KHANHHUNG/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}