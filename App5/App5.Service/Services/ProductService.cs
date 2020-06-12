﻿using App5.Data.Context;
using App5.Service.Model.Request;
using App5.Service.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App5.Service.Services
{
    public class ProductService
    {
        private readonly ECommerceContext _context;
        public ProductService(ECommerceContext context)
        {
            _context = context;
        }

        public List<ProductResponse> GetAll()
        {
            var products = _context.Product.ToList().Select(x => new ProductResponse()
            {
                Brand = x.Brand,
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                StockCount = x.StockCount
            }).ToList();

            return products;
        }

        public ProductResponse Get(int id)
        {
            var productEntity = _context.Product.FirstOrDefault(x => x.Id == id);
            return new ProductResponse
            {
                Brand = productEntity.Brand,
                Id = productEntity.Id,
                Name = productEntity.Name,
                Price = productEntity.Price,
                StockCount = productEntity.StockCount
            };
        }

        public List<ProductResponse> Query(ProductQuery productQuery)
        {
            return _context.Product.Where(x => x.Id == productQuery.Id || x.Brand == productQuery.Brand)
                .ToList().Select(x => new ProductResponse()
                {
                    Brand = x.Brand,
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    StockCount = x.StockCount
                }).ToList();
        }
    }
}
