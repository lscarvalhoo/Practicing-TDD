using LeilaoOnline.Core;
using System.Linq;
using Xunit;

namespace LeilaoOnline.Tests
{
    public class LeilaoRecebeOferta
    {
        [Fact]
        public void NaoPermiteNovosLancesQuandoFinalizado()
        {
            //Arange 
            var leilao = new Leilao("Van Gogh");
            var interessado = new Interessada("Leo", leilao);
            var interessado2 = new Interessada("Leo", leilao);

            leilao.IniciaPregao();
            leilao.RecebeLance(interessado, 800);
            leilao.RecebeLance(interessado2, 800);
            leilao.TerminaPregao();

            //Act
            leilao.RecebeLance(interessado, 1000);

            //Assert
            var valorEsperado = 2;
            var valorObtido = leilao.Lances.Count();

            Assert.Equal(valorEsperado, valorObtido);
        }

        [Theory]
        [InlineData(4, new double[] { 100, 1200, 1300, 1250 })]
        [InlineData(2, new double[] { 800, 900 })]
        public void NaoPermiteNovosLancesQuandoFinalizadoComParametros(
            int quantidadeEsperada, double[] ofertas)
        {
            //Arange 
            var leilao = new Leilao("Van Gogh");
            var interessado = new Interessada("Leo", leilao);
            leilao.IniciaPregao();

            foreach (var valor in ofertas)
            {
                leilao.RecebeLance(interessado, valor);
            }
            leilao.TerminaPregao();

            //Act
            leilao.RecebeLance(interessado, 1000);

            //Assert 
            var quantidadesObitidas = leilao.Lances.Count();

            Assert.Equal(quantidadeEsperada, quantidadesObitidas);
        }
    }
}
