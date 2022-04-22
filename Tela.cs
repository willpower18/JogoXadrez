using Jogo.Tabuleiro;

    class Tela{
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro){
            for(int indiceLinha = 0; indiceLinha < tabuleiro.NumeroLinhas; indiceLinha++){
                for(int indiceColuna = 0; indiceColuna < tabuleiro.NumeroColunas; indiceColuna++){
                    Peca pecaNaPosicaoAtual = tabuleiro.ObterPeca(indiceLinha, indiceColuna);
                    if(pecaNaPosicaoAtual == null)
                        Console.Write("- ");
                    else
                        Console.Write($"{tabuleiro.ObterPeca(indiceLinha, indiceColuna)} ");
                }

                Console.WriteLine();
            }
        }
    }