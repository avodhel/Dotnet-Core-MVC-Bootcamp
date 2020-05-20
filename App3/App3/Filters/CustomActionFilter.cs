using App3.Data.Context;
using App3.Data.Entities;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App3.Filters
{
    public class CustomActionFilter : IActionFilter
    {
        private readonly BlogDbContext _context;
        public CustomActionFilter(BlogDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// action'a girmeden önce çalışır
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var log = new Log
            {
                LogType = "Info",
                Message = $"OnActionExecuting Controller: {context.RouteData.Values["controller"]}, Action{context.RouteData.Values["action"]}"
            };

            _context.Log.Add(log);
            _context.SaveChanges();
        }

        /// <summary>
        /// action'dan çıktıktan sonra çalışır
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var log = new Log
            {
                LogType = "Info",
                Message = $"OnActionExecuted Controller: {context.RouteData.Values["controller"]}, Action{context.RouteData.Values["action"]}"
            };

            _context.Log.Add(log);
            _context.SaveChanges();
        }

    }
}
