using MinhaLoja.Domain;
using System;
using System.Collections.Generic;

namespace MinhaLoja.Application
{
    public interface IPedidoRepository
    {
        void Salvar(Pedido pedido);
        Pedido? BuscarPorId(Guid id);
        IEnumerable<Pedido> BuscarPorStatus(StatusPedido status);
    }
}