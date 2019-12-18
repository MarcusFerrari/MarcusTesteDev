using MarcusFerrariConsole.business;
using System;
using System.Globalization;

namespace MarcusFerrariConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Seja bem vindo ao sistema de crédito...");
            
            Console.WriteLine("Digite o valor que deseja(Ex.: 5000.00): ");
            double valor;
            Double.TryParse(Console.ReadLine(), out valor);

            Console.WriteLine("Digite um número entre 1 e 5 para selecionar a opção desejada:");
            Console.WriteLine("1 - Crédito Direto");
            Console.WriteLine("2 - Crédito Consignado");
            Console.WriteLine("3 - Crédito Jurídica");
            Console.WriteLine("4 - Crédito Física");
            Console.WriteLine("5 - Crédito Imobiliário");
            int tipoCredito;
            Int32.TryParse(Console.ReadLine(), out tipoCredito);

            Console.WriteLine("Digite a quantidade de parcelas: ");
            int qtdParcela;
            Int32.TryParse(Console.ReadLine(), out qtdParcela);

            Console.WriteLine("Digite a data do primeiro vencimento(Ex.: 20/01/2020): ");
            CultureInfo ptBR = new CultureInfo("pt-BR");
            DateTime dtVencimento;
            DateTime.TryParseExact(Console.ReadLine(),"dd/MM/yyyy", ptBR, DateTimeStyles.None, out dtVencimento);


            Console.WriteLine("Calculando...por favor, aguarde!");

            ValidaCredito val = new ValidaCredito();
            var result = val.ValidaCred(valor, tipoCredito, qtdParcela, dtVencimento);

            Console.WriteLine("Status do crédito: {0}", result.StatusCredito);
            Console.WriteLine("Valor total com juros: {0}", result.ValorTotalJuros);
            Console.WriteLine("Valor do juros: {0}", result.ValorJuros);

        }
    }
}
