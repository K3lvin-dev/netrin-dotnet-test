namespace MinhaLoja.Application.DTOs
{
    public class ItemPedidoRequest
    {
        public string Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
    }
}