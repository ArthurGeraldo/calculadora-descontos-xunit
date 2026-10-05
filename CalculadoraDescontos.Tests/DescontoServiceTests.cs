using Xunit;
using CalculadoraDescontos.App;

namespace CalculadoraDescontos.Tests
{
    public class DescontoServiceTests
    {
        private readonly DescontoService _service;

        public DescontoServiceTests()
        {
            _service = new DescontoService();
        }

        // Teste 1 (string) - Validando as categorias de cliente
        [Theory]
        [InlineData(2, "BRONZE")]
        [InlineData(7, "PRATA")]
        [InlineData(15, "OURO")]
        public void ObterCategoriaCliente_DeveRetornarCategoriaCorreta(int totalCompras, string categoriaEsperada)
        {
            var resultado = _service.ObterCategoriaCliente(totalCompras);
            Assert.Equal(categoriaEsperada, resultado);
        }

        // Teste 2 (int) - Validando o cálculo matemático do desconto
        [Theory]
        [InlineData(100, 10, 90)]
        [InlineData(200, 20, 160)]
        [InlineData(50, 0, 50)]
        public void CalcularDesconto_DeveRetornarValorComDesconto(int valorOriginal, int percentualDesconto, int valorEsperado)
        {
            var resultado = _service.CalcularDescontoPorPercentual(valorOriginal, percentualDesconto);
            Assert.Equal(valorEsperado, resultado);
        }

        // Teste 3 (bool) - Validando a regra do cupom (Maior de 18 ou Primeira Compra)
        [Theory]
        [InlineData(20, false, true)] // Maior de idade, não primeira compra -> true
        [InlineData(16, true, true)]  // Menor de idade, primeira compra -> true
        [InlineData(17, false, false)]// Menor de idade, não primeira compra -> false
        public void EValidoParaCupom_DeveValidarElegibilidade(int idade, bool primeiraCompra, bool resultadoEsperado)
        {
            var resultado = _service.EValidoParaCupom(idade, primeiraCompra);
            Assert.Equal(resultadoEsperado, resultado);
        }
    }
}