using Jogo.Tabuleiro;
using Jogo.Xadrez;

    class Tela{
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro){
            for(int indiceLinha = 0; indiceLinha < tabuleiro.NumeroLinhas; indiceLinha++){
                Console.Write(8 - indiceLinha + " ");
                for(int indiceColuna = 0; indiceColuna < tabuleiro.NumeroColunas; indiceColuna++){
                    Peca pecaNaPosicaoAtual = tabuleiro.ObterPeca(indiceLinha, indiceColuna);
                    if(pecaNaPosicaoAtual == null)
                        Console.Write("- ");
                    else
                        ImprimirPeca(tabuleiro.ObterPeca(indiceLinha, indiceColuna));
                }

                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void ImprimirPeca(Peca peca){
            if(peca.Cor == Cor.Branca){
                Console.Write($"{peca} ");
            }
            else{
                ConsoleColor corConsole = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{peca} ");
                Console.ForegroundColor = corConsole;
            }
        }

        public static PosicaoXadrez LerPosicaoXadrez(){
            
            string valorDigitado = Console.ReadLine();
            
            if(!string.IsNullOrWhiteSpace(valorDigitado) && valorDigitado.Length == 2){
                char coluna = valorDigitado[0];
                int linha = int.Parse(valorDigitado[1] + "");

                return new PosicaoXadrez(coluna, linha);
            }

            throw new TabuleiroException("O Valor Digitado é inválido!");
            
        }
    }