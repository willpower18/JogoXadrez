using Jogo.Tabuleiro;
using Jogo.Xadrez;

try{
   
    PartidaXadrez partida = new PartidaXadrez();

    while(!partida.Terminada){
        Console.Clear();
        Tela.ImprimirTabuleiro(partida.Tabuleiro);


        Console.WriteLine();
        Console.Write("Origem: ");
        Posicao origem = Tela.LerPosicaoXadrez().ConverterPosicao();

        Console.Write("Destino: ");
        Posicao destino = Tela.LerPosicaoXadrez().ConverterPosicao();

        partida.ExecutarMovimento(origem, destino);
    }

    Console.ReadLine();
}
catch(TabuleiroException ex){
    Console.WriteLine($"Atenção! {ex.Message}");
}



