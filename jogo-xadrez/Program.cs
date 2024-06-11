

using jogo_xadrez;
using tabuleiro;
using xadrez;

namespace xadrez_console {
    class Program {
        static void Main( string[] args ) {
            try {
                
                PartidaDeXadrez partida = new PartidaDeXadrez();
                while ( !partida.terminada ) {
                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tab);

                    Console.WriteLine("\n");
                    Console.WriteLine("Origem: ");
                    Posicao origem = Tela.lerPosicaoXadrez().ToPosicao();
                    Console.WriteLine("Destino:");
                    Posicao destino = Tela.lerPosicaoXadrez().ToPosicao();

                    partida.executarMovimento(origem, destino);

                }

            } catch (TabuleiroException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
