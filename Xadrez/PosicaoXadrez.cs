using Jogo.Tabuleiro;

namespace Jogo.Xadrez{
    class PosicaoXadrez{

        public PosicaoXadrez(char coluna, int linha)
        {
            Coluna = coluna;
            Linha = linha;
        }

        public char Coluna { get; set; }
        public int Linha { get; set; }

        public Posicao ConverterPosicao(){
            return new Posicao(8 - Linha, Coluna - 'a');
        }

        public override string ToString()
        {
            return "" + Coluna + Linha;
        }
    }
}