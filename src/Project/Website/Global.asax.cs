using System.Web.Mvc;

namespace Website
{
    public class Global : Sitecore.Web.Application
    {
        protected void Application_Start()
        {
            MvcHandler.DisableMvcResponseHeader = true;
            AreaRegistration.RegisterAllAreas();
        }
    }
}