using System;
using System.Collections.Generic;

namespace App.Dominio
{
    public enum Naipe
    {
        Ouros, Espadas, Copas, Paus
    }

    public enum Valor
    {
        Dois, Tres, Quatro, Cinco, Seis, Sete,
        Oito, Nove, Dez, Valete, Dama, Rei, As
    }

    public class Carta
    {
        public Naipe Naipe { get; set; }
        public Valor Valor { get; set; }
    }

    public class Jogador
    {
        public string Nome { get; set; }
        public List<Carta> Mao { get; set; }
    }

    public class Partida
    {
        public List<Carta> Baralho { get; set; }
        public List<Jogador> Jogadores { get; set; }
    }
}
