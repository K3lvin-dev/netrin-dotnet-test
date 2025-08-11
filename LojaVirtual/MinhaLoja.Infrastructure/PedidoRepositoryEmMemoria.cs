using MinhaLoja.Application;
using MinhaLoja.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MinhaLoja.Infrastructure
{
    public class PedidoRepositoryEmMemoria : IPedidoRepository
    {
        // Usamos um dicionário estático para que os dados persistam enquanto a aplicação
        // estiver rodando. O Guid é a chave para um acesso rápido.
        private static readonly Dictionary<Guid, Pedido> _pedidos = new Dictionary<Guid, Pedido>();

        public Pedido? BuscarPorId(Guid id)
        {
            // Tenta obter o valor. Se não encontrar, retorna null (comportamento padrão).
            _pedidos.TryGetValue(id, out var pedido);
            return pedido;
        }

        public IEnumerable<Pedido> BuscarPorStatus(StatusPedido status)
        {
            // Usa LINQ para filtrar os valores do dicionário que correspondem ao status.
            return _pedidos.Values.Where(p => p.Status == status);
        }

        public void Salvar(Pedido pedido)
        {
            // Se o pedido já existe no dicionário, ele é atualizado.
            // Se não, é adicionado.
            _pedidos[pedido.Id] = pedido;
        }
    }
}