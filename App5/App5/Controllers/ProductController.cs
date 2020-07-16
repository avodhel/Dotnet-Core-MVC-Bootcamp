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

        [HttpGet("{categoryId}")]
        public List<ProductResponse> ByCategory(int categoryId)
        {
            return _service.GetByCategory(categoryId);
        }

        //HttpPut genelde update metotları için kullanılır.
        [HttpPut]
        public IActionResult Update([FromBody]ProductUpdateRequest product)
        {
            var affectedRowCount = _service.Update(product);
            if (affectedRowCount > 0)
            {
                return Ok("Güncelleme Başarılı");
            }
            return NotFound("İlgili ürün bulunamadı/güncellenemedi");
        }

        [HttpDelete("{productId}")]
        public IActionResult Delete(int productId)
        {
            int affectedRowCount = _service.Delete(productId);

            if (affectedRowCount > 0)
            {
                return Ok();
            }
            if (affectedRowCount == -1)
            {
                return NotFound();
            }
            return UnprocessableEntity();
        }
    }
}