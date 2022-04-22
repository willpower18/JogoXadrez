namespace Jogo.Tabuleiro{
    class Peca{

        public Peca(Posicao posicao, Tabuleiro tabuleiro, Cor cor)
        {
            Posicao = posicao;
            Tabuleiro = tabuleiro;
            Cor = cor;
            QuantidadeMovimentos = 0;
        }

        public Posicao Posicao { get; set; }
        public Cor Cor { get; set; }
        public int QuantidadeMovimentos { get; set; }
        public Tabuleiro Tabuleiro { get; set; }
    }
}