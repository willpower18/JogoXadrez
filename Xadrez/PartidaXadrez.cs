using Jogo.Tabuleiro;
using System.Collections.Generic;

namespace Jogo.Xadrez{

    class PartidaXadrez{

        public PartidaXadrez()
        {
            Tabuleiro = new Tabuleiro.Tabuleiro(8,8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            Xeque = false;
            VulneravelEnPassant = null;
            Pecas = new HashSet<Peca>();
            PecasCapturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public Tabuleiro.Tabuleiro Tabuleiro {get; private set;}
        public int Turno {get; private set;}
        public Cor JogadorAtual  {get; private set;}
        public bool Terminada {get; private set;}
        public bool Xeque { get; private set; } 
        public Peca VulneravelEnPassant {get; private set;}
        private HashSet<Peca> Pecas;
        private HashSet<Peca> PecasCapturadas;


        public Peca ExecutarMovimento(Posicao origem, Posicao destino){
            Peca peca = Tabuleiro.RetirarPeca(origem);
            peca.IncrementarQuantidadeMovimentos();
            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(peca, destino);
           
            if(pecaCapturada != null)
                PecasCapturadas.Add(pecaCapturada);

            //# Jogada Especial Roque Pequeno
            if(peca is Rei && destino.Coluna == origem.Coluna + 2){
                Posicao origemTorre = new Posicao(origem.Linha, origem.Coluna + 3);
                Posicao destinoTorre = new Posicao(origem.Linha, origem.Coluna + 1);
                Peca TorreRoque = Tabuleiro.RetirarPeca(origemTorre);
                TorreRoque.IncrementarQuantidadeMovimentos();
                Tabuleiro.ColocarPeca(TorreRoque, destinoTorre);
            }

            //# Jogada Especial Roque Grande
            if(peca is Rei && destino.Coluna == origem.Coluna - 2){
                Posicao origemTorre = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao destinoTorre = new Posicao(origem.Linha, origem.Coluna - 1);
                Peca TorreRoque = Tabuleiro.RetirarPeca(origemTorre);
                TorreRoque.IncrementarQuantidadeMovimentos();
                Tabuleiro.ColocarPeca(TorreRoque, destinoTorre);
            }

            //#Jogada Especial En Passant
            if(peca is Peao){
                if(origem.Coluna != destino.Coluna && pecaCapturada == null){
                    Posicao posicaoPeaoASerCapturado;
                    if(peca.Cor == Cor.Branca)
                        posicaoPeaoASerCapturado = new Posicao(destino.Linha + 1, destino.Coluna);
                    else
                         posicaoPeaoASerCapturado = new Posicao(destino.Linha - 1, destino.Coluna);

                         pecaCapturada = Tabuleiro.RetirarPeca(posicaoPeaoASerCapturado);
                         PecasCapturadas.Add(pecaCapturada);
                }
            }

            return pecaCapturada;
        }

        public void DesfazerMovimento(Posicao origem, Posicao destino, Peca pecaCapturada){
            Peca peca = Tabuleiro.RetirarPeca(destino);
            peca.DecrementarQuantidadeMovimentos();
            if(pecaCapturada != null){
                Tabuleiro.ColocarPeca(pecaCapturada, destino);
                PecasCapturadas.Remove(pecaCapturada);
            }

            Tabuleiro.ColocarPeca(peca, origem);

             //# Jogada Especial Roque Pequeno
            if(peca is Rei && destino.Coluna == origem.Coluna + 2){
                Posicao origemTorre = new Posicao(origem.Linha, origem.Coluna + 3);
                Posicao destinoTorre = new Posicao(origem.Linha, origem.Coluna + 1);
                Peca TorreRoque = Tabuleiro.RetirarPeca(destinoTorre);
                TorreRoque.DecrementarQuantidadeMovimentos();
                Tabuleiro.ColocarPeca(TorreRoque, origemTorre);
            }

            //# Jogada Especial Roque Grande
            if(peca is Rei && destino.Coluna == origem.Coluna - 2){
                Posicao origemTorre = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao destinoTorre = new Posicao(origem.Linha, origem.Coluna - 1);
                Peca TorreRoque = Tabuleiro.RetirarPeca(destinoTorre);
                TorreRoque.DecrementarQuantidadeMovimentos();
                Tabuleiro.ColocarPeca(TorreRoque, origemTorre);
            }

            //#Jogada Especial En Passant
            if(peca is Peao){
                if(origem.Coluna != destino.Coluna && pecaCapturada == VulneravelEnPassant){
                    Peca PeaoCapturadoEnPassant = Tabuleiro.RetirarPeca(destino);
                    Posicao posicaoPeaoEnPassant;
                    if(peca.Cor == Cor.Branca){
                        posicaoPeaoEnPassant = new Posicao(3, destino.Coluna);
                    }
                    else{
                        posicaoPeaoEnPassant = new Posicao(4, destino.Coluna);
                    }

                    Tabuleiro.ColocarPeca(PeaoCapturadoEnPassant, posicaoPeaoEnPassant);
                }
            }
        }

        public void RealizaJogada(Posicao origem, Posicao destino){
            Peca pecaCapturada = ExecutarMovimento(origem, destino);

            if(EstaEmXeque(JogadorAtual)){
                DesfazerMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }

            Peca peca = Tabuleiro.ObterPeca(destino); 

            //#Jogada Especial Promoção
            if(peca is Peao){
                if((peca.Cor == Cor.Branca && destino.Linha == 0) || (peca.Cor == Cor.Preta && destino.Linha == 7)){
                    peca = Tabuleiro.RetirarPeca(destino);
                    Pecas.Remove(peca);
                    Peca dama = new Dama(Tabuleiro, peca.Cor);
                    Tabuleiro.ColocarPeca(dama, destino);
                    Pecas.Add(dama);
                }
            }

            if(EstaEmXeque(ObterCorAdversaria(JogadorAtual)))
                Xeque = true;
            else
                Xeque = false;

            if(TesteXequeMate(ObterCorAdversaria(JogadorAtual))){
                Terminada = true;
            }
            else{
                Turno++;
                MudaJogador();
            }   

            //#Jogada Especial En Passant
            if(peca is Peao && destino.Linha == origem.Linha - 2 || destino.Linha == origem.Linha + 2){
                VulneravelEnPassant = peca;
            }
            else
                VulneravelEnPassant = null;
        }

        public bool TesteXequeMate(Cor cor){
            if(!EstaEmXeque(cor)){
                return false;
            }

            foreach(Peca peca in ObterPecasEmJogo(cor)){
                bool[,] matrizMovimentosPossiveis = peca.MovimentosPossiveis();
                for(int linha = 0; linha < Tabuleiro.NumeroLinhas; linha++){
                    for(int coluna = 0; coluna < Tabuleiro.NumeroColunas; coluna++){
                        if(matrizMovimentosPossiveis[linha, coluna]){
                            Posicao origem = peca.Posicao;
                            Posicao destino = new Posicao(linha, coluna);
                            Peca pecaCapturada = ExecutarMovimento(origem, destino);
                            bool ReiEstaEmXeque = EstaEmXeque(cor);
                            DesfazerMovimento(origem, destino, pecaCapturada);
                            if(!ReiEstaEmXeque){
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
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
            if(!Tabuleiro.ObterPeca(origem).MovimentoPossivel(destino))
                throw new TabuleiroException("Posicao de Destino Inválida");
        }

        private void MudaJogador(){
            if(JogadorAtual == Cor.Branca)
                JogadorAtual = Cor.Preta;
            else
                JogadorAtual = Cor.Branca;
        }

        private Cor ObterCorAdversaria(Cor cor){
            if(cor == Cor.Branca)
                return Cor.Preta;
            else
                return Cor.Branca;
        }

        private Peca ObterRei(Cor cor){
            foreach(Peca peca in ObterPecasEmJogo(cor)){
                if(peca is Rei)
                    return peca;
            }

            return null;
        }

        public bool EstaEmXeque(Cor cor){
            Peca rei = ObterRei(cor);
            if(rei == null)
                throw new TabuleiroException($"Não existe rei da cor {cor} em jogo.");

            foreach(Peca peca in ObterPecasEmJogo(ObterCorAdversaria(cor))){
                bool[,] movimentosPossiveis = peca.MovimentosPossiveis();
                if(movimentosPossiveis[rei.Posicao.Linha, rei.Posicao.Coluna])
                    return true;
            }

            return false;
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
            ColocarNovaPeca('a', 1, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('b', 1, new Cavalo(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('c', 1, new Bispo(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('d', 1, new Dama(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('e', 1, new Rei(Tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('f', 1, new Bispo(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('g', 1, new Cavalo(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('h', 1, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('a', 2, new Peao(Tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('b', 2, new Peao(Tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('c', 2, new Peao(Tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('d', 2, new Peao(Tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('e', 2, new Peao(Tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('f', 2, new Peao(Tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('g', 2, new Peao(Tabuleiro, Cor.Branca, this));
            ColocarNovaPeca('h', 2, new Peao(Tabuleiro, Cor.Branca, this));

            ColocarNovaPeca('a', 8, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('b', 8, new Cavalo(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('c', 8, new Bispo(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('d', 8, new Dama(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('e', 8, new Rei(Tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('f', 8, new Bispo(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('g', 8, new Cavalo(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('h', 8, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('a', 7, new Peao(Tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('b', 7, new Peao(Tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('c', 7, new Peao(Tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('d', 7, new Peao(Tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('e', 7, new Peao(Tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('f', 7, new Peao(Tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('g', 7, new Peao(Tabuleiro, Cor.Preta, this));
            ColocarNovaPeca('h', 7, new Peao(Tabuleiro, Cor.Preta, this));

        }
    }
}