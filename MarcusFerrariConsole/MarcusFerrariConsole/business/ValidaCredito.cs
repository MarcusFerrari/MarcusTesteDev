using Enum;
using MarcusFerrariConsole.dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarcusFerrariConsole.business
{
    public class ValidaCredito
    {
        public ResultadoCredito ValidaCred(double valor, int tipoCredito, int qtdParcela, DateTime dtVencimento)
        {
            ResultadoCredito result = new ResultadoCredito();
            double jurosAux = 0.0;

            switch (tipoCredito)
            {
                case 1:
                    jurosAux = 0.02;
                    break;
                case 2:
                    jurosAux = 0.01;
                    break;
                case 3:
                    jurosAux = 0.05;
                    break;
                case 4:
                    jurosAux = 0.03;
                    break;
                case 5:
                    jurosAux = 0.09;
                    break;
            }


            result.ValorJuros = (valor * jurosAux) * qtdParcela;
            result.ValorTotalJuros = valor + result.ValorJuros;

            if(valor > 1000000.00)
            {
                result.StatusCredito = "Recusado. O valor máximo para emprestimo é R$ 1.000.000,00";
                return result;
            }

            if(qtdParcela > 72)
            {
                result.StatusCredito = "Recusado. A quantidade máxima de parcela é 72";
                return result;
            }
            else if(qtdParcela < 5)
            {
                result.StatusCredito = "Recusado. A quantidade minima de parcela é 5";
                return result;
            }

            if(tipoCredito == (int)TipoCreditoEnum.TipoCredito.CreditoPJ && valor < 15000)
            {
                result.StatusCredito = "Recusado. O valor minimo liberado para pessoa jurídica é R$ 15.000,00";
                return result;
            }


            DateTime dtMinima = DateTime.Now.AddDays(15);
            DateTime dtMaxima = DateTime.Now.AddDays(40);
            if (dtVencimento < dtMinima)
            {
                result.StatusCredito = "Recusado. A data minima do primeiro vencimento é D+15. " + dtMinima.ToString("dd/MM/yyyy");
                return result;
            }
            else if(dtVencimento > dtMaxima)
            {
                result.StatusCredito = "Recusado. A data máxima do primeiro vencimento é D+40. " + dtMaxima.ToString("dd/MM/yyyy");
                return result;
            }

            result.StatusCredito = "Aprovado";
            return result;
        }

        
    }
}
