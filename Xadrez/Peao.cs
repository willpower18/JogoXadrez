using Jogo.Tabuleiro;

namespace Jogo.Xadrez{
    class Peao : Peca
    {
          private PartidaXadrez Partida;
        public Peao(Jogo.Tabuleiro.Tabuleiro tab, Cor cor, PartidaXadrez partida) : base(tab, cor)
        {
          this.Partida = partida;
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

                //#Jogada Especial En Passant
                if(Posicao.Linha == 3){
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if(Tabuleiro.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tabuleiro.ObterPeca(esquerda) == Partida.VulneravelEnPassant){
                         matriz[esquerda.Linha - 1, esquerda.Coluna] = true;
                    }

                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if(Tabuleiro.PosicaoValida(direita) && ExisteInimigo(direita) && Tabuleiro.ObterPeca(direita) == Partida.VulneravelEnPassant){
                         matriz[direita.Linha - 1, direita.Coluna] = true;
                    }
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

               //#Jogada Especial En Passant
                if(Posicao.Linha == 4){
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if(Tabuleiro.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tabuleiro.ObterPeca(esquerda) == Partida.VulneravelEnPassant){
                         matriz[esquerda.Linha + 1, esquerda.Coluna] = true;
                    }

                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if(Tabuleiro.PosicaoValida(direita) && ExisteInimigo(direita) && Tabuleiro.ObterPeca(direita) == Partida.VulneravelEnPassant){
                         matriz[direita.Linha + 1, direita.Coluna] = true;
                    }
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