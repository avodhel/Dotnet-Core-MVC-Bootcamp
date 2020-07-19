using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}