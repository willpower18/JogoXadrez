using Jogo.Tabuleiro;
using Jogo.Xadrez;

try{
   
   PosicaoXadrez posicaoX = new PosicaoXadrez('a', 1);

   Console.WriteLine(posicaoX);
   Console.WriteLine(posicaoX.ConverterPosicao());

    Console.ReadLine();
}
catch(TabuleiroException ex){
    Console.WriteLine($"Atenção! {ex.Message}");
}



