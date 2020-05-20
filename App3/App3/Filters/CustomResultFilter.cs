using App3.Data.Context;
using App3.Data.Entities;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App3.Filters
{
    public class CustomResultFilter : IResultFilter
    {
        private readonly BlogDbContext _context;

        public CustomResultFilter(BlogDbContext context)
        {
            _context = context;
        }
        public void OnResultExecuted(ResultExecutedContext context)
        {
            var log = new Log()
            {
                LogType = "Info",
                Message = "OnResultExecuted"
            };
            _context.Log.Add(log);
            _context.SaveChanges();
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            var log = new Log()
            {
                LogType = "Info",
                Message = "OnResultExecuting"
            };
            _context.Log.Add(log);
            _context.SaveChanges();
        }
    }
}
