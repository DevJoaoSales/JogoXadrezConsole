using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace xadrez;
internal class PartidaDeXadrez {
    public Tabuleiro tab { get; private set; }
    public int turno { get; private set; }
    public Cor JogadorAtual { get; private set; }
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

    public void realizaJogada( Posicao origem, Posicao destino) {
        executarMovimento(origem, destino);
        turno++;
        mudarJogador();
    }

    public void validarPosicaoDeOrigem(Posicao pos) {
        if (tab.peca(pos) == null) {
            throw new TabuleiroException("Não existe peça na posição de origem!");
        }
        if ( JogadorAtual != tab.peca(pos).cor ) {
            throw new TabuleiroException("A peça de origem escolhida não é sua");
        }
        if ( !tab.peca(pos).existeMovimentosPossiveis() ) {
            throw new TabuleiroException("Não há movimentos possiveis para a peça de origem escolhida!");
        }
    }

    public void validarPosicaoDeDestino(Posicao origem, Posicao destino) {
        if ( !tab.peca(origem).podeMoverPara(destino) ) {
            throw new TabuleiroException("Posição de destino inválida!");
        }
    }

    private void mudarJogador() {
        if (JogadorAtual == Cor.Branca) {
            JogadorAtual = Cor.Preta;
        } else {
            JogadorAtual = Cor.Branca;
        }
    }

    private void colocarPecas() {
        tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c', 1).ToPosicao());
        tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('e', 1).ToPosicao());
        tab.colocarPeca(new Rei(tab, Cor.Branca), new PosicaoXadrez('d', 1).ToPosicao());
        tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c', 2).ToPosicao());
        tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('d', 2).ToPosicao());
        tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('e', 2).ToPosicao());

        tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('c', 8).ToPosicao());
        tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('e', 8).ToPosicao());
        tab.colocarPeca(new Rei(tab, Cor.Preta), new PosicaoXadrez('d', 8).ToPosicao());
    }
}

