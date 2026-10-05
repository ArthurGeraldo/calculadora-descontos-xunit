namespace CalculadoraDescontos.App
{
    public class DescontoService
    {
        // 1. Regra para retornar a categoria do cliente
        public string ObterCategoriaCliente(int totalCompras)
        {
            if (totalCompras < 5)
            {
                return "BRONZE";
            }
            else if (totalCompras >= 5 && totalCompras <= 10)
            {
                return "PRATA";
            }
            else
            {
                return "OURO";
            }
        }

        // 2. Regra para calcular o valor com desconto
        public int CalcularDescontoPorPercentual(int valorOriginal, int percentualDesconto)
        {
            int valorDesconto = (valorOriginal * percentualDesconto) / 100;
            return valorOriginal - valorDesconto;
        }

        // 3. Regra para validar se tem direito a cupom
        public bool EValidoParaCupom(int idade, bool primeiraCompra)
        {
            return idade >= 18 || primeiraCompra;
        }
    }
}