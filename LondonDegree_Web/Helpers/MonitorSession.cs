using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using LondonDegree_Web.Controllers;
using LondonDegree_Web.BO;
using LondonDegree_Web.Models;

namespace LondonDegree_Web.Helpers
{
    public class MonitorSession : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Variable - Declaration
            int vl_counter_i = 0;
            RouteData vl_routeData_o = null;
            Guid vl_userSession_gu = Guid.Empty;
            Guid vl_userPerson_gu = Guid.Empty;
            string vl_commaSeperatedParams_s = "";
            PersonSessionModel vl_sessionActivityLog_o = new PersonSessionModel();

            Person_BO vl_PersonBO_o = new Person_BO();
            Support_BO vl_SupportBO_o = new Support_BO();

            //Get controller and action from the user request
            vl_routeData_o = filterContext.HttpContext.Request.RequestContext.RouteData;
            string vl_currentAction_o = vl_routeData_o.GetRequiredString("action");
            string vl_currentController_o = vl_routeData_o.GetRequiredString("controller");

            //Collect request parameters
            ParameterDescriptor[] vl_parameters_o = filterContext.ActionDescriptor.GetParameters();
            foreach (ParameterDescriptor vl_paramDescriptor_o in vl_parameters_o)
            {
                vl_commaSeperatedParams_s += vl_paramDescriptor_o.ParameterName + "=";
                vl_commaSeperatedParams_s += filterContext.HttpContext.Request[vl_paramDescriptor_o.ParameterName];
                if (vl_counter_i != (vl_parameters_o.Length - 1))
                {
                    vl_commaSeperatedParams_s += ",";
                }
                vl_counter_i = vl_counter_i + 1;
            }


             vl_userSession_gu = vl_SupportBO_o.getCurrentSession();

            vl_sessionActivityLog_o.PK_PersonSession_ID_gu = Guid.NewGuid();
            vl_sessionActivityLog_o.FK_PersonLogin_ID_gu = vl_userSession_gu;
            vl_sessionActivityLog_o.PersonSession_Controller_s = vl_currentController_o;
            vl_sessionActivityLog_o.PersonSession_Action_s = vl_currentAction_o;
            vl_sessionActivityLog_o.PersonSession_Created_d = DateTime.Now;
            vl_sessionActivityLog_o.PersonSession_Parameter_s = vl_commaSeperatedParams_s;

            //Insert session activity
            if (vl_sessionActivityLog_o.PK_PersonSession_ID_gu != Guid.Empty)
            {
                vl_PersonBO_o.InsertPersonSession(vl_sessionActivityLog_o);
            }

            //Continue with action as usual
            base.OnActionExecuting(filterContext);
        }

    }
}