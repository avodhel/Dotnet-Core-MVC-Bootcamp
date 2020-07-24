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

        /// <summary>
        /// Get All Products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ProductResponse> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]int id)
        {
            var product = _service.Get(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        /// <summary>
        /// Get Products By Query
        /// </summary>
        /// <param name="productQuery">product query parameter</param>
        /// <returns>product response</returns>
        [HttpPost]
        public List<ProductResponse> Query([FromBody]ProductQueryRequest productQuery)
        {
            return _service.Query(productQuery);
        }

        [HttpGet("{categoryId}")]
        public List<ProductResponse> ByCategory(int categoryId)
        {
            return _service.GetByCategory(categoryId);
        }

        //HttpPut genelde update metotları için kullanılır.
        /// <summary>
        /// Update spesific product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        /// <response code="200">Güncelleme Başarılı</response>
        /// <response code="404">İlgili ürün bulunamadı/güncellenemedi</response>
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

        /// <summary>
        /// Delete product by product id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        /// <response code="200">Ürün silindi</response>
        /// <response code="404">Silinecek ürün bulunamadı</response>
        /// <response code="422">Silme işlemi gerçekleşmedi</response>
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