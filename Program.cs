using Jogo.Tabuleiro;
using Jogo.Xadrez;

try{
   
    PartidaXadrez partida = new PartidaXadrez();

    while(!partida.Terminada){
        try{
            Console.Clear();
            
            Tela.ImprimirPartida(partida);

            Console.WriteLine();
            Console.Write("Origem: ");
            Posicao origem = Tela.LerPosicaoXadrez().ConverterPosicao();
            partida.ValidarPosicaoOrigem(origem);

            bool[,] posicoesPossiveis = partida.Tabuleiro.ObterPeca(origem).MovimentosPossiveis();

            Console.Clear();
            Tela.ImprimirTabuleiro(partida.Tabuleiro, posicoesPossiveis);

            Console.WriteLine();
            Console.Write("Destino: ");
            Posicao destino = Tela.LerPosicaoXadrez().ConverterPosicao();
            partida.ValidarPosicaoDestino(origem, destino);

            partida.RealizaJogada(origem, destino);
        }
        catch(TabuleiroException ex){
            Console.WriteLine(ex.Message);
            Console.ReadLine();
        }
        
    }

    Console.ReadLine();
}
catch(TabuleiroException ex){
    Console.WriteLine($"Atenção! {ex.Message}");
}



