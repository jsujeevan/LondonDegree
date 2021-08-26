using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LondonDegree_Web.Models;
using LondonDegree_Web.BO;

namespace LondonDegree_Web.Helpers
{
    public class MonitorError : HandleErrorAttribute
    {
        public class MonitorErrorServerAttribute : HandleErrorAttribute
        {
            readonly log4net.ILog vm_dblogger_o = log4net.LogManager.GetLogger("DatabaseLogger");
            Support_BO vl_support_o = new Support_BO();
            public override void OnException(ExceptionContext exceptionContext)
            {

                Guid vl_errorReference_gu = Guid.NewGuid();
                Guid vl_currentuser_gu = Guid.Empty;
                Exception vl_exception_o = exceptionContext.Exception;
                exceptionContext.ExceptionHandled = true;
                vm_dblogger_o.Error("[" + vl_errorReference_gu + "]" + vl_exception_o.Message, vl_exception_o);
                var model = new ErrorModel();
                model.Reference = vl_errorReference_gu;
                model.Exception = vl_exception_o;
                if (!(exceptionContext.Exception is SessionNotFoundException))
                {
                    vl_currentuser_gu = vl_support_o.getCurrentUser();
                }

                if (exceptionContext.HttpContext.Request.IsAjaxRequest())
                {
                    exceptionContext.Result = new JsonResult()
                    {
                        Data = new
                        {
                            Reference = vl_errorReference_gu
                        },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                else
                {
                    exceptionContext.Result = new ViewResult()
                    {
                        ViewName = "~/Views/Home/Error.cshtml",
                        ViewData = new ViewDataDictionary(model)

                    };
                }
                exceptionContext.HttpContext.Response.StatusCode = 500;
            }

        }
    }
}