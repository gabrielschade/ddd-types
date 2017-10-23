using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Dominio;

namespace App.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ErroAoComprarCarta();
        }

        private static void ErroAoComprarCarta()
        {
            Partida partida = new Partida();
            partida.Baralho = new List<Carta>();

            //...
            Jogador jogador = new Jogador();
            jogador.Nome = "Fulano";
            jogador.Mao = new List<Carta>();

            jogador.Mao.Add(
                Comprar(jogador.Mao)
                );
        }

        static Carta Comprar(List<Carta> baralho)
            => new Carta();


        void Programa()
        {
            Jogador jogador = new Jogador();
            jogador.Mao = new List<Carta>();
            jogador.Mao.Add(new Carta() {
                Naipe = Naipe.Copas,
                Valor = Valor.As
            });
            jogador.Mao.Add(new Carta()
            {
                Naipe = Naipe.Espadas,
                Valor = Valor.Dama
            });
            jogador.Mao.Add(new Carta()
            {
                Naipe = Naipe.Ouros,
                Valor = Valor.As
            });

            Talvez<Carta> cartaPaus2 = 
                Consultas.TentarObter(
                    jogador.Mao, 
                    carta => carta.Naipe == Naipe.Paus);

            Talvez<Carta> cartaPaus =
                jogador.Mao
                       .TentarObter(carta => carta.Naipe == Naipe.Paus);
               

            cartaPaus.Obter(
                quandoTiverAlgo: carta => carta.Valor,
                quandoVazio: () => Valor.As
                );

            int[] numeros = new int[5] { 3, 5, 1, 9, 7 };
            Talvez<int> primeiroPar =
                numeros.TentarObter(numero => numero % 2 == 0);

            int dobroDoParOuNada =
                primeiroPar.Obter(
                    quandoTiverAlgo: numeroPar => numeroPar * 2,
                    quandoVazio: () => 0);
        }

    }

    public static class Consultas
    {
        public static Talvez<T> TentarObter<T>(
            this IEnumerable<T> colecao, 
            Func<T,bool> predicado)
            => colecao.FirstOrDefault(predicado);
    }

    public class Talvez<T>
    {
        private T _valor;

        public bool EstaVazio => _valor.Equals(default(T));
        public bool EstaComAlgo => !EstaVazio;

        public Talvez(T valor)
        {
            _valor = valor;
        }

        public TResult Obter<TResult>(
            Func<T, TResult> quandoTiverAlgo, 
            Func<TResult> quandoVazio)
            => EstaComAlgo ?
                quandoTiverAlgo(_valor)
                : quandoVazio();

        public static implicit operator Talvez<T>(T valor)
            => new Talvez<T>(valor);




    }


}
