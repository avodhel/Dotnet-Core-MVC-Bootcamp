﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace App1.Controllers
{
    public class CookieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}