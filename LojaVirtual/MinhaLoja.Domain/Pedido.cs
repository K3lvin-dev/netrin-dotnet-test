namespace MinhaLoja.Domain
{
    public class Pedido
    {
        // Construtor: Usado para criar um novo pedido.
        public Pedido(string cliente, List<ItemPedido> itens)
        {
            Id = Guid.NewGuid(); // Gera um ID único para cada novo pedido.
            Cliente = cliente;
            Itens = itens;
            Status = StatusPedido.Pendente; // Todo novo pedido começa como "Pendente".
        }

        public Guid Id { get; private set; }
        public string Cliente { get; private set; }
        public List<ItemPedido> Itens { get; private set; }
        public StatusPedido Status { get; private set; }

        // Esta é a propriedade que calcula o valor total.
        // A lógica de negócio está encapsulada aqui dentro.
        public decimal ValorTotal
        {
            get
            {
                // Calcula o valor bruto, sem desconto.
                decimal subtotal = Itens.Sum(item => item.Quantidade * item.PrecoUnitario);

                // Calcula o total de unidades no carrinho.
                int totalDeItens = Itens.Sum(item => item.Quantidade);

                // Aplica a regra de negócio do desconto.
                if (totalDeItens > 10)
                {
                    // Calcula o valor do desconto (5%)
                    decimal desconto = subtotal * 0.05m;

                    // Retorna o subtotal menos o desconto
                    return subtotal - desconto;
                }

                return subtotal;
            }
        }

        // Método para permitir a atualização do status
        public void AtualizarStatus(StatusPedido novoStatus)
        {
            Status = novoStatus;
        }
    }
}