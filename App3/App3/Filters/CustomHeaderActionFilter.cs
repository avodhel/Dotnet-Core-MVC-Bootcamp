using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App3.Filters
{
    public class CustomHeaderActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            context.HttpContext.Response.Headers.Add("Execution-Complete-Time", DateTime.Now.ToString());
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
