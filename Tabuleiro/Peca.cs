namespace Jogo.Tabuleiro{
    abstract class Peca{

        public Peca(Tabuleiro tabuleiro, Cor cor)
        {
            Posicao = null;
            Tabuleiro = tabuleiro;
            Cor = cor;
            QuantidadeMovimentos = 0;
        }

        public Posicao? Posicao { get; set; }
        public Cor Cor { get; set; }
        public int QuantidadeMovimentos { get; set; }
        public Tabuleiro Tabuleiro { get; set; }

        public void IncrementarQuantidadeMovimentos(){
            QuantidadeMovimentos++;
        } 

        public void DecrementarQuantidadeMovimentos(){
            QuantidadeMovimentos--;
        } 

        public bool ExisteMovimentosPossiveis(){
            bool [,] movimentosPossiveis = MovimentosPossiveis();
            for(int linha = 0; linha < Tabuleiro.NumeroLinhas; linha++){
                for(int coluna = 0; coluna < Tabuleiro.NumeroColunas; coluna++){
                    if(movimentosPossiveis[linha, coluna] == true){
                        return true;
                    }
                }
            }

            return false;
        }

        public bool PodeMoverParaPosicao(Posicao posicao){
            return MovimentosPossiveis()[posicao.Linha, posicao.Coluna];
        }

        public abstract bool[,] MovimentosPossiveis();
    }
}