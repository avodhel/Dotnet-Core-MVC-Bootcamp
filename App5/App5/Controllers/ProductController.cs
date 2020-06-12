using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App5.Service.Model.Request;
using App5.Service.Model.Response;
using App5.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace App5.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _service;
        public ProductController(ProductService service)
        {
            _service = service;
        }

        public List<ProductResponse> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public ProductResponse Get([FromRoute]int id)
        {
            return _service.Get(id);
        }

        [HttpPost]
        public List<ProductResponse> Query([FromBody]ProductQuery productQuery)
        {
            return _service.Query(productQuery);
        }
    }
}