using MinhaLoja.Domain;
using System.Collections.Generic;
using Xunit;

namespace MinhaLoja.Tests
{
    public class PedidoTests
    {
        [Fact]
        public void ValorTotal_DeveCalcularCorretamente_QuandoNaoHaDesconto()
        {
            // Arrange (Organizar)
            // Criamos uma lista de itens cuja soma das quantidades NÃO ultrapassa 10.
            var itens = new List<ItemPedido>
            {
                new ItemPedido { Produto = "Produto A", Quantidade = 5, PrecoUnitario = 10.00m }, // 5 * 10 = 50
                new ItemPedido { Produto = "Produto B", Quantidade = 5, PrecoUnitario = 10.00m }  // 5 * 10 = 50
            };
            var pedido = new Pedido("Cliente Teste", itens);
            decimal valorEsperado = 100.00m; // O total deve ser 50 + 50 = 100

            // Act (Agir)
            // A ação é simplesmente obter o valor da propriedade que contém a lógica.
            decimal valorCalculado = pedido.ValorTotal;

            // Assert (Verificar)
            // Verificamos se o valor calculado é igual ao valor que esperávamos.
            Assert.Equal(valorEsperado, valorCalculado);
        }

        [Fact]
        public void ValorTotal_DeveAplicarDesconto_QuandoTotalDeItensMaiorQueDez()
        {
            // Arrange (Organizar)
            // Agora, a soma das quantidades é 11, o que deve ativar o desconto.
            var itens = new List<ItemPedido>
            {
                new ItemPedido { Produto = "Produto A", Quantidade = 6, PrecoUnitario = 10.00m }, // 6 * 10 = 60
                new ItemPedido { Produto = "Produto B", Quantidade = 5, PrecoUnitario = 10.00m }  // 5 * 10 = 50
            };
            var pedido = new Pedido("Cliente Teste", itens);
            // Subtotal = 110.00. Desconto de 5% = 5.50. Valor final esperado = 104.50
            decimal valorEsperado = 104.50m;

            // Act (Agir)
            decimal valorCalculado = pedido.ValorTotal;

            // Assert (Verificar)
            Assert.Equal(valorEsperado, valorCalculado);
        }
    }
}