using System;

namespace Jogo.Tabuleiro{
    class TabuleiroException : Exception
    {
        public TabuleiroException(string mensagem) : base(mensagem)
        {
            
        }
    }
}