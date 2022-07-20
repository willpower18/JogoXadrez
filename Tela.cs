using Jogo.Tabuleiro;
using Jogo.Xadrez;

    class Tela{
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro){
            for(int indiceLinha = 0; indiceLinha < tabuleiro.NumeroLinhas; indiceLinha++){
                Console.Write(8 - indiceLinha + " ");
                for(int indiceColuna = 0; indiceColuna < tabuleiro.NumeroColunas; indiceColuna++){
                    ImprimirPeca(tabuleiro.ObterPeca(indiceLinha, indiceColuna));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void ImprimirPartida(PartidaXadrez partida){
            Tela.ImprimirTabuleiro(partida.Tabuleiro);
            Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            Console.WriteLine($"Turno: {partida.Turno}");

            if(!partida.Terminada){
                Console.WriteLine($"Aguardando jogada: {partida.JogadorAtual}");

                if(partida.Xeque)
                    Console.WriteLine($"Possibilidade de Xeque Mate!");
            }
            else{
                Console.WriteLine("Xeque Mate!");
                Console.WriteLine("Vencedor: " + partida.JogadorAtual);
            }
           
        }

        public static void ImprimirPecasCapturadas(PartidaXadrez partida){
            Console.WriteLine("Peças Capturadas: ");
            Console.Write("Brancas: ");
            ImprimirConjunto(partida.ObterPecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor auxiliar = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            ImprimirConjunto(partida.ObterPecasCapturadas(Cor.Preta));
            Console.ForegroundColor = auxiliar;
            Console.WriteLine();
        }

        public static void ImprimirConjunto(HashSet<Peca> pecas){
            Console.Write("[ ");
            foreach(Peca peca in pecas){
                Console.Write(peca + " ");
            }
            Console.Write("]");
        }

        public static void ImprimirTabuleiro(Tabuleiro tabuleiro, bool[,] posicoesPossiveis){
            
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;
            
            for(int indiceLinha = 0; indiceLinha < tabuleiro.NumeroLinhas; indiceLinha++){
                Console.Write(8 - indiceLinha + " ");
                for(int indiceColuna = 0; indiceColuna < tabuleiro.NumeroColunas; indiceColuna++){
                    if(posicoesPossiveis[indiceLinha, indiceColuna])
                        Console.BackgroundColor = fundoAlterado;
                    else
                        Console.BackgroundColor = fundoOriginal;

                    ImprimirPeca(tabuleiro.ObterPeca(indiceLinha, indiceColuna));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }

            Console.WriteLine("  A B C D E F G H");
            Console.BackgroundColor = fundoOriginal;
        }

        public static void ImprimirPeca(Peca peca){

            if(peca == null){
                Console.Write("- ");
            }
            else{
                if(peca.Cor == Cor.Branca){
                    Console.Write(peca);
                }
                else{
                    ConsoleColor corConsole = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = corConsole;
                }
                Console.Write(" ");
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