

using jogo_xadrez;
using tabuleiro;
using xadrez;

namespace xadrez_console {
    class Program {
        static void Main( string[] args ) {

            PosicaoXadrez pos = new PosicaoXadrez('c', 7);
            
            Console.WriteLine( pos.ToPosicao() );


            /*try {
                Tabuleiro tabuleiro = new Tabuleiro(8, 8);

                tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(0, 0));
                tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(1, 3));
                tabuleiro.colocarPeca(new Rei(tabuleiro, Cor.Preta), new Posicao(0, 4));

                Tela.imprimirTabuleiro(tabuleiro);
            } catch (TabuleiroException e) {
                Console.WriteLine(e.Message);
            }*/
        }
    }
}
