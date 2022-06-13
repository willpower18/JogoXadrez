using Jogo.Tabuleiro;

namespace Jogo.Xadrez{
    class Torre : Peca
    {
        public Torre(Jogo.Tabuleiro.Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

         public override bool[,] MovimentosPossiveis(){
            bool[,] matriz = new bool[Tabuleiro.NumeroLinhas, Tabuleiro.NumeroColunas];

            Posicao pos = new Posicao(0,0);
            
            //Acima
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            while(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                matriz[pos.Linha, pos.Coluna] = true;
                if(Tabuleiro.ObterPeca(pos) != null && Tabuleiro.ObterPeca(pos).Cor != Cor)
                    break;
                
                pos.Linha = pos.Linha - 1;
            }   

            //Abaixo
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            while(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                matriz[pos.Linha, pos.Coluna] = true;
                if(Tabuleiro.ObterPeca(pos) != null && Tabuleiro.ObterPeca(pos).Cor != Cor)
                    break;
                
                pos.Linha = pos.Linha + 1;
            }     

            //Direita
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            while(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                matriz[pos.Linha, pos.Coluna] = true;
                if(Tabuleiro.ObterPeca(pos) != null && Tabuleiro.ObterPeca(pos).Cor != Cor)
                    break;
                
                pos.Coluna = pos.Coluna + 1;
            }     

           //Esquerda
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            while(Tabuleiro.PosicaoValida(pos) && PodeMover(pos)){
                matriz[pos.Linha, pos.Coluna] = true;
                if(Tabuleiro.ObterPeca(pos) != null && Tabuleiro.ObterPeca(pos).Cor != Cor)
                    break;
                
                pos.Coluna = pos.Coluna - 1;
            }     

            return matriz;
        }

        public override string ToString()
        {
            return "T";
        }

        private bool PodeMover(Posicao posicao){
            Peca peca = Tabuleiro.ObterPeca(posicao);
            return peca == null || peca.Cor != Cor;
        }
    }
}