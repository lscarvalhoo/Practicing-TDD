using LeilaoOnline.Core;
using LeilaoOnline.Tests;
using System;

namespace LeilaoOnline.ConsoleApp
{
    class Program
    {
        private static void Verifica(double esperado, double obtido)
        {
            var cor = Console.ForegroundColor;
            if (esperado == obtido)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("TESTE OK");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(
                    $"TESTE FALHOU! Esperado: {esperado}, obtido: {obtido}.");
            }
            Console.ForegroundColor = cor;
        }

        private static void LeilaoComVariosLances()
        {
            //Arranje
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var pessoa = new Interessada("Leo", leilao);
            var pessoa2 = new Interessada("Maria", leilao);

            leilao.RecebeLance(pessoa, 800);
            leilao.RecebeLance(pessoa2, 900);
            leilao.RecebeLance(pessoa, 1000);
            leilao.RecebeLance(pessoa2, 990);

            //Act 
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 1200;
            var valorObtido = leilao.Ganhador.Valor;
            Verifica(valorEsperado, valorObtido);

        }

        private static void LeilaoComApenasUmLance()
        {
            //Arranje 
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            var pessoa = new Interessada("Fulano", leilao);

            leilao.RecebeLance(pessoa, 800);

            //Act 
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 800;
            var valorObtido = leilao.Ganhador.Valor;

            Verifica(valorEsperado, valorObtido);
        }

        static void Main()
        {
            LeilaoComVariosLances();
            LeilaoComApenasUmLance();
        }
    }
}
