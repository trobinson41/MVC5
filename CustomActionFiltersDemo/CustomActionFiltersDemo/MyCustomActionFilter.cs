using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CustomActionFiltersDemo
{
    public class MyCustomActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            DoLogging("OnActionExecuting", filterContext.RouteData);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            DoLogging("OnActionExecuted", filterContext.RouteData);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            DoLogging("OnResultExecuting", filterContext.RouteData);

            int Hours = Convert.ToInt32(DateTime.Now.ToString("HH"));

            if (Hours < 8)
            {
                filterContext.HttpContext.Response.Write("<h1>You can\'t access this area before 8 AM.</h1>");
                filterContext.Cancel = true;
            }
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            DoLogging("OnResultExecuted", filterContext.RouteData);
        }

        public void DoLogging(string FunctionName, RouteData routeData)
        {
            string Controller, Action;

            Controller = routeData.Values["controller"].ToString();
            Action = routeData.Values["action"].ToString();
            string str = string.Format("1 - Function Name={0}, Controller Name={1}, Action={2}", FunctionName, Controller, Action);
            HttpContext.Current.Response.Write("<br>" + str + "<br>");
        }
    }

    public class MyNewCustomActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            DoLogging("OnActionExecuting", filterContext.RouteData);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            DoLogging("OnActionExecuted", filterContext.RouteData);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            DoLogging("OnResultExecuting", filterContext.RouteData);

            int Hours = Convert.ToInt32(DateTime.Now.ToString("HH"));
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            DoLogging("OnResultExecuted", filterContext.RouteData);
        }

        public void DoLogging(string FunctionName, RouteData routeData)
        {
            string Controller, Action;

            Controller = routeData.Values["controller"].ToString();
            Action = routeData.Values["action"].ToString();
            string str = string.Format("2 - Function Name={0}, Controller Name={1}, Action={2}", FunctionName, Controller, Action);
            HttpContext.Current.Response.Write("<br>" + str + "<br>");
        }
    }
}