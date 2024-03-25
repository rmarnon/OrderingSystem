using Microsoft.AspNetCore.Mvc;
using Ordering.System.Api.Entities;
using Ordering.System.Api.Models;
using Ordering.System.Api.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Ordering.System.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService) => _supplierService = supplierService;

        /// <summary>
        /// Obtém todos os fornecedores.
        /// </summary>
        /// <returns>Uma lista de todos os fornecedores.</returns>
        /// <param name="pagination">Parâmetros de paginação (número da página e tamanho da página).</param>
        /// <response code="200">Retorna a lista de fornecedores.</response>
        /// <response code="404">Se não houverem registos de fornecedores.</response>
        /// <response code="500">Se ocorrer um erro interno do servidor.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Supplier>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetSuppliers([FromQuery][Required] Pagination pagination)
        {
            var supplier = await _supplierService.GetSuppliersAsync(pagination);
            return supplier.Any()
                ? Ok(supplier)
                : NotFound();
        }

        /// <summary>
        /// Obtém um fornecedor por ID.
        /// </summary>
        /// <param name="id">O ID do fornecedor a ser obtido.</param>
        /// <returns>O fornecedor correspondente ao ID especificado.</returns>
        /// <response code="200">Retorna o fornecedor encontrado.</response>
        /// <response code="404">Se o fornecedor com o ID especificado não for encontrado.</response>
        /// <response code="500">Se ocorrer um erro interno do servidor.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Supplier), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetSupplierById([FromRoute][Required] Guid id)
        {
            var supplier = await _supplierService.GetSupplierByIdAsync(id);
            return supplier is null
                ? NotFound()
                : Ok(supplier);
        }

        /// <summary>
        /// Cria um novo fornecedor.
        /// </summary>
        /// <param name="supplier">Os detalhes do fornecedor a serem criados.</param>
        /// <returns>O fornecedor criado.</returns>
        /// <response code="201">Retorna o fornecedor criado.</response>
        /// <response code="400">Se os dados do fornecedor forem inválidos.</response>
        /// <response code="500">Se ocorrer um erro interno do servidor.</response>
        [HttpPost("create")]
        [ProducesResponseType(typeof(Supplier), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateSupplier([FromBody][Required] SupplierInputModel supplier)
        {
            var entity = await _supplierService.CreateSupplierAsync(supplier);
            return entity is null
                ? Conflict("Já eiste um fornecedor cadastrado com esse ID.")
                : Ok(supplier);
        }

        /// <summary>
        /// Atualiza um fornecedor existente.
        /// </summary>
        /// <param name="product">Os novos detalhes do fornecedor.</param>
        /// <returns>O fornecedor atualizado.</returns>
        /// <response code="200">Retorna o fornecedor atualizado.</response>
        /// <response code="400">Se os dados do fornecedor forem inválidos.</response>
        /// <response code="404">Se o fornecedor com o ID especificado não for encontrado.</response>
        /// <response code="500">Se ocorrer um erro interno do servidor.</response>
        [HttpPut("update")]
        [ProducesResponseType(typeof(Supplier), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateSupplier([FromBody][Required] SupplierInputModel product)
        {
            var entity = await _supplierService.UpdateSupplierAsync(product);
            return entity is null
                ? BadRequest()
                : Ok(product);
        }

        /// <summary>
        /// Remove um fornecedor existente.
        /// </summary>
        /// <param name="id">O ID do fornecedor a ser removido.</param>
        /// <response code="204">Se o fornecedor foi removido com sucesso.</response>
        /// <response code="404">Se o fornecedor com o ID especificado não for encontrado.</response>
        /// <response code="500">Se ocorrer um erro interno do servidor.</response>
        [HttpDelete("delete/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteSupplier([FromRoute][Required] Guid id)
        {
            var supplier = await _supplierService.DeletSupplierByIdAsync(id);
            return supplier is null
                ? NotFound()
                : NoContent();
        }
    }
}
