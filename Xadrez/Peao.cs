using Jogo.Tabuleiro;

namespace Jogo.Xadrez{
    class Peao : Peca
    {
        public Peao(Jogo.Tabuleiro.Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

         public override bool[,] MovimentosPossiveis(){
            bool[,] matriz = new bool[Tabuleiro.NumeroLinhas, Tabuleiro.NumeroColunas];

            Posicao pos = new Posicao(0,0);
            
           if(Cor == Cor.Branca){
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
                if(Tabuleiro.PosicaoValida(pos) && Livre(pos)){
                     matriz[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna);
                if(Tabuleiro.PosicaoValida(pos) && Livre(pos) && QuantidadeMovimentos == 0){
                     matriz[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
                if(Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos)){
                     matriz[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
                if(Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos)){
                     matriz[pos.Linha, pos.Coluna] = true;
                }
           }
           else{
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
                if(Tabuleiro.PosicaoValida(pos) && Livre(pos)){
                     matriz[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);
                if(Tabuleiro.PosicaoValida(pos) && Livre(pos) && QuantidadeMovimentos == 0){
                     matriz[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
                if(Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos)){
                     matriz[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
                if(Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos)){
                     matriz[pos.Linha, pos.Coluna] = true;
                }
           }
           

            return matriz;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool PodeMover(Posicao posicao){
            Peca peca = Tabuleiro.ObterPeca(posicao);
            return peca == null || peca.Cor != Cor;
        }

        private bool ExisteInimigo(Posicao posicao){
            Peca peca = Tabuleiro.ObterPeca(posicao);
            return peca != null && peca.Cor != Cor;
        }

        private bool Livre(Posicao posicao){
            return Tabuleiro.ObterPeca(posicao) == null;
        }
    }
}