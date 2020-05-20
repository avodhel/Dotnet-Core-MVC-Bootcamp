using App3.Logging;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App3.Filters
{
    public class ExceptionLogFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            //hata alındığında ne yapmak istiyorsan
            AppLogger.AddLog(new Data.Entities.Log
            {
                LogType = "Exception",
                Message = context.Exception.Message,
                Url = context.HttpContext.Request.Host.Value + context.HttpContext.Request.Path + context.HttpContext.Request.QueryString.Value
            });
            base.OnException(context);
        }
    }
}
