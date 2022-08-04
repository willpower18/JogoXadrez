using Jogo.Tabuleiro;

namespace Jogo.Xadrez{
    class Bispo : Peca
    {
        public Bispo(Jogo.Tabuleiro.Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

         public override bool[,] MovimentosPossiveis(){
            bool[,] matriz = new bool[Tabuleiro.NumeroLinhas, Tabuleiro.NumeroColunas];

            Posicao pos = new Posicao(0,0);
            
            //NO
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            while(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                matriz[pos.Linha, pos.Coluna] = true;
                if(Tabuleiro.ObterPeca(pos) != null && Tabuleiro.ObterPeca(pos).Cor != Cor)
                    break;
                
                  pos.DefinirValores(pos.Linha - 1, pos.Coluna - 1);
            }   

            //NE
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            while(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                matriz[pos.Linha, pos.Coluna] = true;
                if(Tabuleiro.ObterPeca(pos) != null && Tabuleiro.ObterPeca(pos).Cor != Cor)
                    break;
                
                pos.DefinirValores(pos.Linha - 1, pos.Coluna + 1);
            }     

            //SE
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            while(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                matriz[pos.Linha, pos.Coluna] = true;
                if(Tabuleiro.ObterPeca(pos) != null && Tabuleiro.ObterPeca(pos).Cor != Cor)
                    break;
                
                pos.DefinirValores(pos.Linha + 1, pos.Coluna + 1);
            }     

             //SO
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            while(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                matriz[pos.Linha, pos.Coluna] = true;
                if(Tabuleiro.ObterPeca(pos) != null && Tabuleiro.ObterPeca(pos).Cor != Cor)
                    break;
                
                pos.DefinirValores(pos.Linha + 1, pos.Coluna - 1);
            }     

            return matriz;
        }

        public override string ToString()
        {
            return "B";
        }

        private bool PodeMover(Posicao posicao){
            Peca peca = Tabuleiro.ObterPeca(posicao);
            return peca == null || peca.Cor != Cor;
        }
    }
}