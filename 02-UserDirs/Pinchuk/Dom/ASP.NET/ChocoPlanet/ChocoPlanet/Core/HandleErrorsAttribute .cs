using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChocoPlanet.Core
{
    public class HandleErrorsAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            var exception = filterContext.Exception;

            var httpContext = filterContext.HttpContext;

            

        }
    }
}