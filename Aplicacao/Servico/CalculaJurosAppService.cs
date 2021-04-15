using CalculaJuros.Interface;
using ConexoesApi.Interface;
using System;

namespace CalculaJuros.Servico
{
    public class CalculaJurosAppService : ICalculaJurosAppService
    {
        private readonly ITaxaJurosApi _taxaJurosApi;

        public CalculaJurosAppService(ITaxaJurosApi taxaJurosApi)
        {
            _taxaJurosApi = taxaJurosApi;
        }

        public string CalcularJuros(decimal valorInicial, int meses)
        {
            //Queria retornar um decimal mas o resultado estava cortando o '0' da ultima casa.
            //Retornei string para ficar igual o pedido na tarefa.
            var juros = _taxaJurosApi.RetornaTaxaJuros().Result;
            if (!ValidadarCalculoJuros(valorInicial, meses, out string mensagemErro))
                throw new ArgumentException(mensagemErro);

            var valorFinal = ((double)valorInicial * (Math.Pow((1 + juros), meses))).ToString("N2");

            return valorFinal;
        }

        private static bool ValidadarCalculoJuros(decimal valorInicial, int tempo, out string mensagemErro)
        {
            mensagemErro = "";
            if (valorInicial <= 0)
                mensagemErro = "ValorInicial informado deve ser maior do que 0.";
            if (tempo < 0)
                mensagemErro = "Tempo informado inválido.";

            if (string.IsNullOrEmpty(mensagemErro))
                return true;

            return false;
        }
    }
}