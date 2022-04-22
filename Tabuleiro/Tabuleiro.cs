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

        public Peca ObterPeca(Posicao posicao){
             return Pecas[posicao.Linha, posicao.Coluna];
        }

        public void ColocarPeca(Peca peca, Posicao posicao){
            
            if(ExistePeca(posicao))
                throw new TabuleiroException("Já existe uma peça nesta posição!");
            
            Pecas[posicao.Linha, posicao.Coluna] = peca;
            peca.Posicao = posicao;
        }

        public bool ExistePeca(Posicao posicao){
            ValidarPosicao(posicao);
            return ObterPeca(posicao) != null;
        }

        public bool PosicaoValida(Posicao posicao){
            if(posicao.Linha < 0 || posicao.Linha >= NumeroLinhas || posicao.Coluna < 0 || posicao.Coluna >= NumeroColunas)
                return false;
            
            return true;
        }

        public void ValidarPosicao(Posicao posicao){
            if(!PosicaoValida(posicao))
                throw new TabuleiroException("Posição Inválida!");
        }
    }
}