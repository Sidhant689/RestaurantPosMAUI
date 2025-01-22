using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace RestaurantPosMAUI.API
{
    public class LogAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filtercontext)
        {
            Log("OnActionExecuted", filtercontext.RouteData);
        }
        public override void OnActionExecuting(ActionExecutingContext filtercontext)
        {
            Log("OnActionExecuting", filtercontext.RouteData);
        }
        public override void OnResultExecuted(ResultExecutedContext filtercontext)
        {
            Log("OnResultExecuted", filtercontext.RouteData);
        }
        public override void OnResultExecuting(ResultExecutingContext filtercontext)
        {
            Log("OnResultExecuting", filtercontext.RouteData);
        }
        private void Log(string methodName, RouteData routeData)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = String.Format("{0} controller:{1} action:{2}", methodName, controllerName, actionName);
            Debug.WriteLine(message);
        }
    }
}
