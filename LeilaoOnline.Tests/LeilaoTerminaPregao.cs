using LeilaoOnline.Core;
using Xunit;

namespace LeilaoOnline.Tests
{
    public class LeilaoTerminaPregao
    {
        [Theory]
        [InlineData(1200, new double[] { 800, 900, 1000, 1200 })]
        [InlineData(1000, new double[] { 800, 900, 1000, 990 })]
        [InlineData(800, new double[] { 800 })]
        public void RetornaMaiorValorLeilaoAoMenosUmLance(double valorEsperado, double[] ofertas)
        {
            //Arraje
            var leilao = new Leilao("Van Gogh");
            var pessoa = new Interessada("Jao", leilao);

            leilao.IniciaPregao();
            foreach (var valor in ofertas)
            {
                leilao.RecebeLance(pessoa, valor);
            }

            //Act
            leilao.TerminaPregao();

            //Assert 
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void RetornaZeroLeilaoSemLance()
        {
            //Arange 
            var leilao = new Leilao("Van Gogh");
            leilao.IniciaPregao();

            //Act
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 0;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }
    }
}
