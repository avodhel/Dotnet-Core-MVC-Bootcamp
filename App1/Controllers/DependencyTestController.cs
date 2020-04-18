using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App1.Services;
using Microsoft.AspNetCore.Mvc;

namespace App1.Controllers
{
    public class DependencyTestController : Controller
    {
        private readonly TransientService _transientService1;
        private readonly TransientService _transientService2;
        private readonly ScopedService _scopedService1;
        private readonly ScopedService _scopedService2;
        public DependencyTestController(TransientService transientService1,
            TransientService transientService2,
            ScopedService scopedService1,
            ScopedService scopedService2)
        {
            _transientService1 = transientService1;
            _transientService2 = transientService2;
            _scopedService1 = scopedService1;
            _scopedService2 = scopedService2;
        }
        public IActionResult Index()
        {
            Dictionary<string, bool> instanceStatuses = new Dictionary<string, bool>();

            bool areInstancesSame = _transientService1 == _transientService2;
            instanceStatuses.Add("TransientService", areInstancesSame);

            areInstancesSame = _scopedService1 == _scopedService2;
            instanceStatuses.Add("ScopedService", areInstancesSame);

            ViewBag.InstanceStatuses = instanceStatuses;
            return View();
        }
    }
}