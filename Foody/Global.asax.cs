using Autofac;
using Foody.App_Start;
using Foody.Config;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using log4net;
using System.IO;
using System;
using System.Web;
using System.Net;

namespace Foody
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
    (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/Web.config")));

            AutofacConfig.ConfigureContainer();
            AreaRegistration.RegisterAllAreas();
            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            AutoMapperConfig.RegisterMappings();            
        }

        protected void Application_Error()
        {
            Exception unhandledException = Server.GetLastError();
            HttpException httpException = unhandledException as HttpException;
            if (httpException == null)
            {
                Exception innerException = unhandledException.InnerException;
                httpException = innerException as HttpException;
            }

            if (httpException != null)
            {
                int httpCode = httpException.GetHttpCode();
                log.Error(httpException.Message);
                switch (httpCode)
                {
                    case (int)HttpStatusCode.InternalServerError:
                        Response.Redirect("/Errors/Unknown");
                        break;
                }
            }
        }
    }
}