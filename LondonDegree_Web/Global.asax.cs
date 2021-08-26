using log4net.Config;
using LondonDegree_Web.BO;
using LondonDegree_Web.Helpers;
using LondonDegree_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LondonDegree_Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static readonly log4net.ILog vm_Log_o = log4net.LogManager.GetLogger("ErrorLogger");

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            string vl_LogConfig_s = new System.IO.FileInfo(Server.MapPath("~/bin/log4net_config.xml")).FullName;
            XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(Server.MapPath("~/bin/log4net_config.xml")));
            vm_Log_o.Info("Starting Application");
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Guid vl_currentuser_gu = Guid.Empty;
            Guid vl_errorTracker_gu = Guid.NewGuid();
            Support_BO vl_support_o = new Support_BO();
            //Get last error
            Exception vl_exception_o = Server.GetLastError();
            vm_Log_o.Error("[" + vl_errorTracker_gu + "]" + vl_exception_o.Message, vl_exception_o);

            var model = new ErrorModel();
            model.Reference = vl_errorTracker_gu;
            model.Exception = vl_exception_o;

            Server.ClearError();
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            Response.Redirect(urlHelper.Action("Error", "Home", new { error = vl_errorTracker_gu }));

        }
    }
}
