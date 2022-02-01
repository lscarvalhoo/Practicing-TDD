using LeilaoOnline.Core;
using System;

namespace LeilaoOnline.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var leilao = new Leilao("Van Gogh");
            var pessoa = new Interessada("João", leilao);
            var pessoaDois = new Interessada("Maria", leilao);

            leilao.RecebeLance(pessoa, 800);
            leilao.RecebeLance(pessoaDois, 900);
            leilao.RecebeLance(pessoa, 1000);
            leilao.RecebeLance(pessoaDois, 1100);

            leilao.TerminaPregao();

            Console.WriteLine(leilao.Ganhador.Valor);
        }
    }
}
