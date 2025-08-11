using MinhaLoja.Application.DTOs;
using MinhaLoja.Domain;
using System;
using System.Linq;

namespace MinhaLoja.Application
{
    public class PedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        // O serviço DEPENDE do contrato (interface), não da implementação.
        // Isso é Injeção de Dependência!
        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public Pedido CriarNovoPedido(CriarPedidoRequest request)
        {
            // 1. Converter o DTO para Entidades de Domínio
            var itensPedido = request.Itens.Select(itemDto => new ItemPedido
            {
                Produto = itemDto.Produto,
                Quantidade = itemDto.Quantidade,
                PrecoUnitario = itemDto.PrecoUnitario
            }).ToList();

            // 2. Criar a entidade Pedido principal
            var novoPedido = new Pedido(request.NomeCliente, itensPedido);

            // 3. Usar o repositório para salvar o pedido
            _pedidoRepository.Salvar(novoPedido);

            return novoPedido;
        }
    }
}