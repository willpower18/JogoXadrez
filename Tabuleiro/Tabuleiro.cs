namespace Jogo.Tabuleiro{
    class Tabuleiro{

        public Tabuleiro(int nLinhas, int nColunas)
        {
            NumeroLinhas = nLinhas;
            NumeroColunas = nColunas;
            Pecas = new Peca[nLinhas, nColunas];
        }

        public int NumeroLinhas { get; set; }
        public int NumeroColunas { get; set; }
        private Peca[,] Pecas;

        public Peca ObterPeca(int linha, int coluna){
            return Pecas[linha, coluna];
        }

        public void ColocarPeca(Peca peca, Posicao posicao){
            Pecas[posicao.Linha, posicao.Coluna] = peca;
            peca.Posicao = posicao;
        }
    }
}