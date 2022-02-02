using LeilaoOnline.Core;
using System.Linq;
using Xunit;

namespace LeilaoOnline.Tests
{
    public class LeilaoRecebeOferta
    {
        [Fact]
        public void NaoAceitaProximoLanceDadoMesmoClienteRealizouUltimoLance()
        {
            //Arranje 
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var pessoa = new Interessada("Leo", leilao);
            leilao.IniciaPregao();
            leilao.RecebeLance(pessoa, 800);

            //Act 
            leilao.RecebeLance(pessoa, 1000);

            //Assert
            var quantidadeEsperada = 1;
            var quantidadeObtida = leilao.Lances.Count();
            Assert.Equal(quantidadeEsperada, quantidadeObtida);
        }

        [Fact]
        public void NaoPermiteNovosLancesQuandoFinalizado()
        {
            //Arange 
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
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
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var interessado = new Interessada("Leo", leilao);
            var interessado2 = new Interessada("Maria", leilao);
            leilao.IniciaPregao();

            for (int i = 0; i < ofertas.Length; i++)
            {
                if ((i % 2) ==0 )
                {
                    leilao.RecebeLance(interessado, 800);
                }
                else
                {
                    leilao.RecebeLance(interessado2, 900);
                }

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
