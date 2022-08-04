using Jogo.Tabuleiro;

namespace Jogo.Xadrez{
    class Dama : Peca
    {
        public Dama(Jogo.Tabuleiro.Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

         public override bool[,] MovimentosPossiveis(){
            bool[,] matriz = new bool[Tabuleiro.NumeroLinhas, Tabuleiro.NumeroColunas];
            char[,] posicoesVerificadas = new char[Tabuleiro.NumeroLinhas, Tabuleiro.NumeroColunas];

            Posicao pos = new Posicao(0,0);
            
            //Esquerda
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos) && !TodasPosicoesDaMatrizForamVerificadas(posicoesVerificadas))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                posicoesVerificadas[pos.Linha, pos.Coluna] = 'S';
                if (Tabuleiro.ObterPeca(pos) != null && Tabuleiro.ObterPeca(pos).Cor != Cor)
                    break;

                pos.DefinirValores(pos.Linha, pos.Coluna - 1);
            }

            //Direita
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos) && !TodasPosicoesDaMatrizForamVerificadas(posicoesVerificadas))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                posicoesVerificadas[pos.Linha, pos.Coluna] = 'S';
                if (Tabuleiro.ObterPeca(pos) != null && Tabuleiro.ObterPeca(pos).Cor != Cor)
                    break;

                pos.DefinirValores(pos.Linha, pos.Coluna + 1);
            }

            //Acima
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            while(Tabuleiro.PosicaoValida(pos) && PodeMover(pos) && !TodasPosicoesDaMatrizForamVerificadas(posicoesVerificadas)){
                matriz[pos.Linha, pos.Coluna] = true;
                posicoesVerificadas[pos.Linha, pos.Coluna] = 'S';
                if(Tabuleiro.ObterPeca(pos) != null && Tabuleiro.ObterPeca(pos).Cor != Cor)
                    break;

                pos.DefinirValores(pos.Linha - 1, pos.Coluna);
            }   

            //Abaixo
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            while(Tabuleiro.PosicaoValida(pos) && PodeMover(pos) && !TodasPosicoesDaMatrizForamVerificadas(posicoesVerificadas)){
                matriz[pos.Linha, pos.Coluna] = true;
                   posicoesVerificadas[pos.Linha, pos.Coluna] = 'S';
                if(Tabuleiro.ObterPeca(pos) != null && Tabuleiro.ObterPeca(pos).Cor != Cor)
                    break;
                
                pos.DefinirValores(pos.Linha + 1, pos.Coluna);
            }     
              

            //NO
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            while(Tabuleiro.PosicaoValida(pos) && PodeMover(pos) && !TodasPosicoesDaMatrizForamVerificadas(posicoesVerificadas)){
                matriz[pos.Linha, pos.Coluna] = true;
                   posicoesVerificadas[pos.Linha, pos.Coluna] = 'S';
                if(Tabuleiro.ObterPeca(pos) != null && Tabuleiro.ObterPeca(pos).Cor != Cor)
                    break;
                
                  pos.DefinirValores(pos.Linha - 1, pos.Coluna - 1);
            }   

            //NE
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            while(Tabuleiro.PosicaoValida(pos) && PodeMover(pos) && !TodasPosicoesDaMatrizForamVerificadas(posicoesVerificadas)){
                matriz[pos.Linha, pos.Coluna] = true;
                   posicoesVerificadas[pos.Linha, pos.Coluna] = 'S';
                if(Tabuleiro.ObterPeca(pos) != null && Tabuleiro.ObterPeca(pos).Cor != Cor)
                    break;
                
                pos.DefinirValores(pos.Linha - 1, pos.Coluna + 1);
            }     

            //SE
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            while(Tabuleiro.PosicaoValida(pos) && PodeMover(pos) && !TodasPosicoesDaMatrizForamVerificadas(posicoesVerificadas)){
                matriz[pos.Linha, pos.Coluna] = true;
                posicoesVerificadas[pos.Linha, pos.Coluna] = 'S';
                if(Tabuleiro.ObterPeca(pos) != null && Tabuleiro.ObterPeca(pos).Cor != Cor)
                    break;
                
                pos.DefinirValores(pos.Linha + 1, pos.Coluna + 1);
            }     

             //SO
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            while(Tabuleiro.PosicaoValida(pos) && PodeMover(pos) && !TodasPosicoesDaMatrizForamVerificadas(posicoesVerificadas)){
                matriz[pos.Linha, pos.Coluna] = true;
                posicoesVerificadas[pos.Linha, pos.Coluna] = 'S';
                if(Tabuleiro.ObterPeca(pos) != null && Tabuleiro.ObterPeca(pos).Cor != Cor)
                    break;
                
                pos.DefinirValores(pos.Linha + 1, pos.Coluna - 1);
            }     

            return matriz;
        }

        public override string ToString()
        {
            return "D";
        }

        private bool PodeMover(Posicao posicao){
            Peca peca = Tabuleiro.ObterPeca(posicao);
            return peca == null || peca.Cor != Cor;
        }

        private bool TodasPosicoesDaMatrizForamVerificadas(char[,] matrizVerificacao){
            for(int linha = 0; linha < Tabuleiro.NumeroLinhas; linha++){
                for(int coluna = 0; coluna < Tabuleiro.NumeroColunas; coluna++){
                    if(matrizVerificacao[linha, coluna] != 'S')
                        return false;
                }
            }

            return true;
        }
    }
}