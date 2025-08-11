using Microsoft.AspNetCore.Mvc;
using MinhaLoja.Application;
using MinhaLoja.Application.DTOs;
using MinhaLoja.Domain;
using System;
using System.Linq;

namespace MinhaLoja.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // A URL base será /api/pedidos
    public class PedidosController : ControllerBase
    {
        private readonly PedidoService _pedidoService;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidosController(PedidoService pedidoService, IPedidoRepository pedidoRepository)
        {
            _pedidoService = pedidoService;
            _pedidoRepository = pedidoRepository;
        }

        // Endpoint 1: Criar um novo pedido
        // POST /api/pedidos
        [HttpPost]
        public IActionResult CriarPedido([FromBody] CriarPedidoRequest request)
        {
            var novoPedido = _pedidoService.CriarNovoPedido(request);
            // Retorna 201 Created com a localização do novo recurso e o objeto criado.
            return CreatedAtAction(nameof(BuscarPedidoPorId), new { id = novoPedido.Id }, novoPedido);
        }

        // Endpoint 3: Consultar os pedidos por status
        // GET /api/pedidos?status=Pendente
        [HttpGet]
        public IActionResult BuscarPedidosPorStatus([FromQuery] StatusPedido status)
        {
            var pedidos = _pedidoRepository.BuscarPorStatus(status);
            return Ok(pedidos);
        }

        // Endpoint de apoio para o CreatedAtAction
        // GET /api/pedidos/{id}
        [HttpGet("{id}")]
        public IActionResult BuscarPedidoPorId(Guid id)
        {
            var pedido = _pedidoRepository.BuscarPorId(id);
            if (pedido == null)
            {
                return NotFound(); // Retorna 404 se não encontrar
            }
            return Ok(pedido);
        }

        // Endpoint 4: Atualizar o status de um pedido existente
        // PATCH /api/pedidos/{id}/status
        [HttpPatch("{id}/status")]
        public IActionResult AtualizarStatus(Guid id, [FromBody] StatusPedido novoStatus)
        {
            var pedido = _pedidoRepository.BuscarPorId(id);
            if (pedido == null)
            {
                return NotFound();
            }

            pedido.AtualizarStatus(novoStatus);
            _pedidoRepository.Salvar(pedido); // Salva a alteração

            return Ok(pedido);
        }
    }
}