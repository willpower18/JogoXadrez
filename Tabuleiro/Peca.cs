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

        public abstract bool[,] MovimentosPossiveis();
    }
}