﻿using Microsoft.AspNetCore.Mvc;
using Ordering.System.Api.Entities;
using Ordering.System.Api.Services.Interfaces;

namespace Ordering.System.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] Guid id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            return product is null
                ? NotFound()
                : Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetProductsAsync();
            return products.Any()
                ? Ok(products)
                : NotFound();
        }

        [HttpPost("create")]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            var entity = await _productService.CreateProductAsync(product);
            return entity is null
                ? BadRequest()
                : Ok(product);
        }

        [HttpPut("update")]
        public async Task<ActionResult<Product>> UpdateProduct(Product product)
        {
            var entity = await _productService.UpdateProductAsync(product);
            return entity is null
                ? BadRequest()
                : Ok(product);
        }
    }
}
