using Microsoft.AspNetCore.Mvc;
using Ordering.System.Api.Entities;
using Ordering.System.Api.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Ordering.System.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService) => _orderService = orderService;

        /// <summary>
        /// Obtém todos os pedidos.
        /// </summary>
        /// <returns>Uma lista de todos os pedidos.</returns>
        /// <param name="pagination">Parâmetros de paginação (número da página e tamanho da página).</param>
        /// <response code="200">Retorna a lista de pedidos.</response>
        /// <response code="404">Se não houverem registos de pedidos.</response>
        /// <response code="500">Se ocorrer um erro interno do servidor.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Order>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetOrders([FromQuery] Pagination pagination)
        {
            var products = await _orderService.GetOrdersAsync(pagination);
            return products.Any()
                ? Ok(products)
                : NotFound();
        }

        /// <summary>
        /// Obtém um pedido por ID.
        /// </summary>
        /// <param name="id">O ID do pedido a ser obtido.</param>
        /// <returns>O pedido correspondente ao ID especificado.</returns>
        /// <response code="200">Retorna o pedido encontrado.</response>
        /// <response code="404">Se o pedido com o ID especificado não for encontrado.</response>
        /// <response code="500">Se ocorrer um erro interno do servidor.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Order), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetOrderById([FromRoute][Required] Guid id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            return order is null
                ? NotFound()
                : Ok(order);
        }

        /// <summary>
        /// Cria um novo pedido.
        /// </summary>
        /// <param name="order">Os detalhes do pedido a serem criados.</param>
        /// <returns>O pedido criado.</returns>
        /// <response code="201">Retorna o pedido criado.</response>
        /// <response code="400">Se os dados do pedido forem inválidos.</response>
        /// <response code="500">Se ocorrer um erro interno do servidor.</response>
        [HttpPost("create")]
        [ProducesResponseType(typeof(Order), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateOrder([FromBody][Required] Order order)
        {
            var entity = await _orderService.CreateOrderAsync(order);
            return entity is null
                ? Conflict("Já eiste um pedido cadastrado com esse ID.")
                : Ok(order);
        }

        /// <summary>
        /// Atualiza um pedido existente.
        /// </summary>
        /// <param name="order">Os novos detalhes do pedido.</param>
        /// <returns>O pedido atualizado.</returns>
        /// <response code="200">Retorna o pedido atualizado.</response>
        /// <response code="400">Se os dados do pedido forem inválidos.</response>
        /// <response code="404">Se o pedido com o ID especificado não for encontrado.</response>
        /// <response code="500">Se ocorrer um erro interno do servidor.</response>
        [HttpPut("update")]
        [ProducesResponseType(typeof(Order), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateOrder([FromBody][Required] Order order)
        {
            var entity = await _orderService.UpdateOrderAsync(order);
            return entity is null
                ? BadRequest()
                : Ok(order);
        }

        /// <summary>
        /// Remove um pedido existente.
        /// </summary>
        /// <param name="id">O ID do pedido a ser removido.</param>
        /// <response code="204">Se o pedido foi removido com sucesso.</response>
        /// <response code="404">Se o pedido com o ID especificado não for encontrado.</response>
        /// <response code="500">Se ocorrer um erro interno do servidor.</response>
        [HttpDelete("delete/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteOrder([FromRoute][Required] Guid id)
        {
            var order = await _orderService.DeletOrderByIdAsync(id);
            return order is null
                ? NotFound()
                : NoContent();
        }
    }
}
