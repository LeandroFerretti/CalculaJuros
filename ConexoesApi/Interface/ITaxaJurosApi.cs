using System.Threading.Tasks;

namespace ConexoesApi.Interface
{
    public interface ITaxaJurosApi
    {
        Task<double> RetornaTaxaJuros();
    }
}