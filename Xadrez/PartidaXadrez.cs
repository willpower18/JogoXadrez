using Jogo.Tabuleiro;

namespace Jogo.Xadrez{

    class PartidaXadrez{

        public PartidaXadrez()
        {
            Tabuleiro = new Tabuleiro.Tabuleiro(8,8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            ColocarPecas();
        }

        public Tabuleiro.Tabuleiro Tabuleiro {get; private set;}
        public int Turno {get; private set;}
        public Cor JogadorAtual  {get; private set;}
        public bool Terminada {get; private set;}

        public void ExecutarMovimento(Posicao origem, Posicao destino){
            Peca peca = Tabuleiro.RetirarPeca(origem);
            peca.IncrementarQuantidadeMovimentos();
            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(peca, destino);
        }

        public void RealizaJogada(Posicao origem, Posicao destino){
            ExecutarMovimento(origem, destino);
            Turno++;

            MudaJogador();
        }

        public void ValidarPosicaoOrigem(Posicao posicao){
            if(Tabuleiro.ObterPeca(posicao) == null)
                throw new TabuleiroException("Não existe peça na posição de origem escolhida.");

            if(JogadorAtual != Tabuleiro.ObterPeca(posicao).Cor)
                throw new TabuleiroException("A peça de origem escolhida não pertence ao jogador atual.");

            if(!Tabuleiro.ObterPeca(posicao).ExisteMovimentosPossiveis())
                throw new TabuleiroException("Não existem movimentos possíveis para a peça selecionada.");
        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao destino){
            if(!Tabuleiro.ObterPeca(origem).PodeMoverParaPosicao(destino))
                throw new TabuleiroException("Posicao de Destino Inválida");
        }

        private void MudaJogador(){
            if(JogadorAtual == Cor.Branca)
                JogadorAtual = Cor.Preta;
            else
                JogadorAtual = Cor.Branca;
        }

        private void ColocarPecas(){
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez('c', 1).ConverterPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez('c', 2).ConverterPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez('d', 2).ConverterPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez('e', 2).ConverterPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez('e', 1).ConverterPosicao());
            Tabuleiro.ColocarPeca(new Rei(Tabuleiro, Cor.Branca), new PosicaoXadrez('d', 1).ConverterPosicao());

            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez('c', 7).ConverterPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez('c', 8).ConverterPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez('d', 7).ConverterPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez('e', 7).ConverterPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Preta), new PosicaoXadrez('e', 8).ConverterPosicao());
            Tabuleiro.ColocarPeca(new Rei(Tabuleiro, Cor.Preta), new PosicaoXadrez('d', 8).ConverterPosicao());
        }
    }
}