using System.Web.Http;

namespace MY_TASK
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}