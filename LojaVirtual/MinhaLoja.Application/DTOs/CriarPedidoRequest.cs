using System.Collections.Generic;

namespace MinhaLoja.Application.DTOs
{
    public class CriarPedidoRequest
    {
        public string NomeCliente { get; set; }
        public List<ItemPedidoRequest> Itens { get; set; }
    }
}