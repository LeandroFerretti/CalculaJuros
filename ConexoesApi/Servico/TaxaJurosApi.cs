using ConexoesApi.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConexoesApi.Servico
{
    public class TaxaJurosApi : ITaxaJurosApi
    {
        private readonly IConfiguration _configuration;

        public TaxaJurosApi(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<double> RetornaTaxaJuros()
        {
            double taxaJuros;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_configuration.GetSection("ApiTaxaJuros").Get<string>()))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    taxaJuros = Convert.ToDouble(apiResponse.Replace(".", ","));
                }
            }
            return taxaJuros;
        }
    }
}