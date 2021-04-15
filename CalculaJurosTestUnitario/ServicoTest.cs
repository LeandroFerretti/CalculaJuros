using CalculaJuros.Servico;
using ConexoesApi.Interface;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CalculaJurosTestUnitario
{
    public class ServicoTest
    {
        [Fact]
        public void Servico_CalculaJuros_Sucess()
        {
            //Preparacao
            decimal valorInicial = 100;
            int meses = 5;
            var mock = new Mock<ITaxaJurosApi>();
            mock.Setup(x => x.RetornaTaxaJuros()).Returns(Task.FromResult(0.01));
            CalculaJurosAppService service = new CalculaJurosAppService(mock.Object);
            //Execução
            var resultado = service.CalcularJuros(valorInicial, meses);
            //Asserts
            Assert.Equal("105,10", resultado);
            Assert.IsType<string>(resultado);
            Assert.NotNull(resultado);
            Assert.NotEmpty(resultado);
        }

        [Theory]
        [InlineData(0, 12)]  //ValorInicial inválido
        [InlineData(100, -5)] //Tempo Inválido
        public void Servico_CalulaJuros_Erro_ArgumentException(decimal valorInicial, int meses)
        {
            var mock = new Mock<ITaxaJurosApi>();
            mock.Setup(x => x.RetornaTaxaJuros()).Returns(Task.FromResult(0.01));
            CalculaJurosAppService service = new CalculaJurosAppService(mock.Object);

            Assert.ThrowsAny<ArgumentException>(() =>
                service.CalcularJuros(valorInicial, meses));
        }
    }
}