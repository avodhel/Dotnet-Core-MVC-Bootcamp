using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using App5.UI.Models.Request;
using App5.UI.Models.ViewModel;
using App5.UI.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App5.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ProductService _productService;
        private readonly CategoryService _categoryService;
        public ProductController(IMapper mapper, ProductService productService, CategoryService categoryService)
        {
            _mapper = mapper;
            _productService = productService;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProducts();
            var categories = await _categoryService.GetCategories();

            var model = new ProductIndexModel()
            {
                Products = _mapper.Map<List<ProductViewModel>>(products),
                Categories = _mapper.Map<List<CategoryViewModel>>(categories)
            };

            return View(model);
        }

        public async Task<IActionResult> Delete(int productId)
        {
            var responseStatusCode = await _productService.Delete(productId);

            switch (responseStatusCode)
            {
                case HttpStatusCode.OK:
                    TempData["Message"] = "Ürün Silindi";
                    TempData["DeleteStatus"] = "Success";
                    break;
                case HttpStatusCode.NotFound:
                    TempData["Message"] = "Ürün Bulunamadı";
                    TempData["DeleteStatus"] = "NotFound";
                    break;
                case HttpStatusCode.UnprocessableEntity:
                    TempData["Message"] = "Ürün Silme Başarısız.";
                    TempData["DeleteStatus"] = "Failed";
                    break;
            }

            return RedirectToAction("Index", "Product");
        }

        public async Task<IActionResult> Update(int productId)
        {
            var product = await _productService.Get(productId);

            var model = _mapper.Map<ProductViewModel>(product);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductViewModel model)
        {
            var productUpdateRequest = _mapper.Map<ProductUpdateRequest>(model);
            await _productService.Update(productUpdateRequest);

            return RedirectToAction("Update", "Product", new { productId = model.Id });
        }
    }
}