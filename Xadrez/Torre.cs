using Jogo.Tabuleiro;

namespace Jogo.Xadrez{
    class Torre : Peca
    {
        public Torre(Jogo.Tabuleiro.Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        public override string ToString()
        {
            return "T";
        }
    }
}