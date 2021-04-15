namespace CalculaJuros.Interface
{
    public interface ICalculaJurosAppService
    {
        string CalcularJuros(decimal valorInicial, int meses);
    }
}