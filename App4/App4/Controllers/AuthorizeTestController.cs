using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App4.Controllers
{
    [Authorize]
    public class AuthorizeTestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}