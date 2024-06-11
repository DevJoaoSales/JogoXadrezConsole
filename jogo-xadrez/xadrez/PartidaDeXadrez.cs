using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace xadrez;
internal class PartidaDeXadrez {
    public Tabuleiro tab { get; private set; }
    private int turno;
    private Cor JogadorAtual;
    public bool terminada { get; private set; }

    public PartidaDeXadrez() {
        tab = new Tabuleiro(8, 8);
        turno = 1;
        JogadorAtual = Cor.Branca;
        terminada = false;
        colocarPecas();
    }

    public void executarMovimento(Posicao origem, Posicao destino) {
        Peca p = tab.retirarPeca(origem);
        p.IncrementarQtdMovimentos();
        Peca pecaCapturada = tab.retirarPeca(destino);
        tab.colocarPeca(p,destino);
    }

    private void colocarPecas() {
        tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('c', 1).ToPosicao());
        tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('e', 1).ToPosicao());
        tab.colocarPeca(new Rei(tab, Cor.Preta), new PosicaoXadrez('d', 1).ToPosicao());
    }
}

