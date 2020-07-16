using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App5.Service.Model.Response;
using App5.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App5.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _service;
        public CategoryController(CategoryService service)
        {
            _service = service;
        }

        public List<CategoryResponse> GetAll()
        {
            return _service.GetCategories();
        }
    }
}