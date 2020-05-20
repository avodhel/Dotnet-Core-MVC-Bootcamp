using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App3.Filters
{
    public class ViewDataActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var controller = context.Controller as Controller;
            controller.ViewData["Message"] = "ViewDataActionFilter executed.";
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
