using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App1.Services;
using Microsoft.AspNetCore.Mvc;

namespace App1.Controllers
{
    public class MessageController : Controller
    {
        private readonly MessageService _messageService;

        public MessageController()
        {
            _messageService = new MessageService();
        }

        public IActionResult Index()
        {
            string message = _messageService.GetMessage();
            return View("Index" , message);
        }
    }
}