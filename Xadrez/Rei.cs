using Jogo.Tabuleiro;

namespace Jogo.Xadrez{
    class Rei : Peca
    {
        public Rei(Jogo.Tabuleiro.Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        public override string ToString()
        {
            return "R";
        }
    }
}