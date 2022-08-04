using Jogo.Tabuleiro;

namespace Jogo.Xadrez{
    class Rei : Peca
    {
        private PartidaXadrez Partida;

        public Rei(Jogo.Tabuleiro.Tabuleiro tab, Cor cor, PartidaXadrez partida) : base(tab, cor)
        {
            Partida = partida;
        }

        public override string ToString()
        {
            return "R";
        }

        public override bool[,] MovimentosPossiveis(){
            bool[,] matriz = new bool[Tabuleiro.NumeroLinhas, Tabuleiro.NumeroColunas];

            Posicao pos = new Posicao(0,0);
            
            //Acima
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
                matriz[pos.Linha, pos.Coluna] = true;

            //Nordeste
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
                matriz[pos.Linha, pos.Coluna] = true;

            //Direita
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
                matriz[pos.Linha, pos.Coluna] = true;

            //Sudeste
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
                matriz[pos.Linha, pos.Coluna] = true;

             //Abaixo
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
                matriz[pos.Linha, pos.Coluna] = true;

             //Sudoeste
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
                matriz[pos.Linha, pos.Coluna] = true;

            //Esquerda
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
                matriz[pos.Linha, pos.Coluna] = true;

            //Noroeste
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if(Tabuleiro.PosicaoValida(pos) && PodeMover(pos))
                matriz[pos.Linha, pos.Coluna] = true;

            //#Jogada Especial - Roque Pequeno
            if(QuantidadeMovimentos == 0 && !Partida.Xeque){
                Posicao posicaoTorre1 = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
                if(TesteTorreParaRoque(posicaoTorre1)){
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);
                    if(Tabuleiro.ObterPeca(p1) == null && Tabuleiro.ObterPeca(p2) == null){
                        matriz[Posicao.Linha, Posicao.Coluna + 2] = true;
                    }
                }
            }

            //#Jogada Especial - Roque Grande
            if(QuantidadeMovimentos == 0 && !Partida.Xeque){
                Posicao posicaoTorre2 = new Posicao(Posicao.Linha, Posicao.Coluna - 4);
                if(TesteTorreParaRoque(posicaoTorre2)){
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                    Posicao p3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);
                    if(Tabuleiro.ObterPeca(p1) == null && Tabuleiro.ObterPeca(p2) == null && Tabuleiro.ObterPeca(p3) == null){
                        matriz[Posicao.Linha, Posicao.Coluna - 2] = true;
                    }
                }
            }

            return matriz;
        }

        private bool TesteTorreParaRoque(Posicao posicao){
            Peca peca = Tabuleiro.ObterPeca(posicao);
            return peca != null && peca is Torre && peca.Cor == Cor && peca.QuantidadeMovimentos == 0;
        }

        private bool PodeMover(Posicao posicao){
            Peca peca = Tabuleiro.ObterPeca(posicao);
            return peca == null || peca.Cor != Cor;
        }
    }
}