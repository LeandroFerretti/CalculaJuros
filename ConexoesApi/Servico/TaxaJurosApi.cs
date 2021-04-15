using ConexoesApi.Interface;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConexoesApi.Servico
{
    public class TaxaJurosApi : ITaxaJurosApi
    {
        public TaxaJurosApi()
        {
        }

        public async Task<double> RetornaTaxaJuros()
        {
            double taxaJuros;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:54608/taxaJuros"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    taxaJuros = Convert.ToDouble(apiResponse.Replace(".", ","));
                }
            }
            return taxaJuros;
        }
    }
}