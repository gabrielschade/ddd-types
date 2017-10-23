namespace App.Dominio.Functional

module JogoDeCartas =

    type Naipe = Ouros | Espadas | Copas | Paus

    type Valor = Dois | Tres | Quatro | Cinco | Seis | Sete
                  | Oito | Nove | Dez | Valete | Dama | Rei | As

    type Carta = | Carta of (Valor * Naipe)

    type Mao = | Mao of Carta list

    type Baralho = | Baralho of Carta list

    type Jogador = {
        Nome : string
        Mao : Mao
        };

    type Partida = {
        Jogadores: Jogador list
        Baralho : Baralho
        };

    let comprar (baralho: Baralho) =
        let (Baralho baralho') = baralho
        baralho'.Head
        

    let main =
        let jogador = {
            Nome = "Fulano" ; 
            Mao = [] |> Mao 
        } 

        let carta = comprar jogador.Mao

        jogador.Nome
