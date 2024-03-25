using Microsoft.AspNetCore.Mvc;
using Ordering.System.Api.Entities;
using Ordering.System.Api.Models;
using Ordering.System.Api.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Ordering.System.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService) => _productService = productService;

        /// <summary>
        /// Obtém todos os produtos.
        /// </summary>
        /// <returns>Uma lista de todos os produtos.</returns>
        /// <param name="pagination">Parâmetros de paginação (número da página e tamanho da página).</param>
        /// <response code="200">Retorna a lista de produtos.</response>
        /// <response code="404">Se não houverem registos de produtos.</response>
        /// <response code="500">Se ocorrer um erro interno do servidor.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetProducts([FromQuery][Required] Pagination pagination)
        {
            var products = await _productService.GetProductsAsync(pagination);
            return products.Any()
                ? Ok(products)
                : NotFound();
        }

        /// <summary>
        /// Obtém um produto por ID.
        /// </summary>
        /// <param name="id">O ID do produto a ser obtido.</param>
        /// <returns>O produto correspondente ao ID especificado.</returns>
        /// <response code="200">Retorna o produto encontrado.</response>
        /// <response code="404">Se o produto com o ID especificado não for encontrado.</response>
        /// <response code="500">Se ocorrer um erro interno do servidor.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Product), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetProductById([FromRoute][Required] Guid id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            return product is null
                ? NotFound()
                : Ok(product);
        }

        /// <summary>
        /// Cria um novo produto.
        /// </summary>
        /// <param name="product">Os detalhes do produto a serem criados.</param>
        /// <returns>O produto criado.</returns>
        /// <response code="201">Retorna o produto criado.</response>
        /// <response code="400">Se os dados do produto forem inválidos.</response>
        /// <response code="500">Se ocorrer um erro interno do servidor.</response>
        [HttpPost("create")]
        [ProducesResponseType(typeof(Product), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateProduct([FromBody][Required] ProductInputModel product)
        {
            var entity = await _productService.CreateProductAsync(product);
            return entity is null
                ? Conflict("Já eiste um produto cadastrado com esse ID.")
                : Ok(product);
        }

        /// <summary>
        /// Atualiza um produto existente.
        /// </summary>
        /// <param name="product">Os novos detalhes do produto.</param>
        /// <returns>O produto atualizado.</returns>
        /// <response code="200">Retorna o produto atualizado.</response>
        /// <response code="400">Se os dados do produto forem inválidos.</response>
        /// <response code="404">Se o produto com o ID especificado não for encontrado.</response>
        /// <response code="500">Se ocorrer um erro interno do servidor.</response>
        [HttpPut("update")]
        [ProducesResponseType(typeof(Product), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateProduct([FromBody][Required] ProductInputModel product)
        {
            var entity = await _productService.UpdateProductAsync(product);
            return entity is null
                ? BadRequest()
                : Ok(product);
        }

        /// <summary>
        /// Remove um produto existente.
        /// </summary>
        /// <param name="id">O ID do produto a ser removido.</param>
        /// <response code="204">Se o produto foi removido com sucesso.</response>
        /// <response code="404">Se o produto com o ID especificado não for encontrado.</response>
        /// <response code="500">Se ocorrer um erro interno do servidor.</response>
        [HttpDelete("delete/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteProduct([FromRoute][Required] Guid id)
        {
            var product = await _productService.DeleteProductByIdAsync(id);
            return product is null
                ? NotFound()
                : NoContent();
        }
    }
}
