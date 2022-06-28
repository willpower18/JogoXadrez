using Jogo.Tabuleiro;
using System.Collections.Generic;

namespace Jogo.Xadrez{

    class PartidaXadrez{

        public PartidaXadrez()
        {
            Tabuleiro = new Tabuleiro.Tabuleiro(8,8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Pecas = new HashSet<Peca>();
            PecasCapturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public Tabuleiro.Tabuleiro Tabuleiro {get; private set;}
        public int Turno {get; private set;}
        public Cor JogadorAtual  {get; private set;}
        public bool Terminada {get; private set;}
        private HashSet<Peca> Pecas;
        private HashSet<Peca> PecasCapturadas;


        public void ExecutarMovimento(Posicao origem, Posicao destino){
            Peca peca = Tabuleiro.RetirarPeca(origem);
            peca.IncrementarQuantidadeMovimentos();
            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
            if(pecaCapturada != null)
                PecasCapturadas.Add(pecaCapturada);

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

        public HashSet<Peca> ObterPecasCapturadas(Cor cor){
            HashSet<Peca> auxiliar = new HashSet<Peca>();
            foreach(Peca peca in PecasCapturadas){
                if(peca.Cor == cor)
                    auxiliar.Add(peca);
            }

            return auxiliar;
        }

        public HashSet<Peca> ObterPecasEmJogo(Cor cor){
            HashSet<Peca> auxiliar = new HashSet<Peca>();
            foreach(Peca peca in Pecas){
                if(peca.Cor == cor)
                    auxiliar.Add(peca);
            }

            auxiliar.ExceptWith(ObterPecasCapturadas(cor));
            return auxiliar;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca){
            Tabuleiro.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ConverterPosicao());
            Pecas.Add(peca);
        }
        private void ColocarPecas(){
            ColocarNovaPeca('c', 1, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('c', 2, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('d', 2, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('e', 2, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('e', 1, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('d', 1, new Rei(Tabuleiro, Cor.Branca));

            ColocarNovaPeca('c', 7, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('c', 8, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('d', 7, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('e', 7, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('e', 8, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('d', 8, new Rei(Tabuleiro, Cor.Preta));
        }
    }
}