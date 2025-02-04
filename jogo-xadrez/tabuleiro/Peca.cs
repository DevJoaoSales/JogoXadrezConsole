﻿
using tabuleiro;

namespace tabuleiro {
        abstract class Peca {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qteMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        public Peca( Tabuleiro tab, Cor cor ) { 
            this.posicao = null;
            this.tab = tab;
            this.cor = cor;
            this.qteMovimentos = 0;
        }

        public void IncrementarQtdMovimentos() {
            this.qteMovimentos++;
        }
        public void DecrementarQtdMovimentos() {
            this.qteMovimentos--;
        }

        public bool existeMovimentosPossiveis() {
            bool[,] mat = movimentosPossiveis(); 
            for (var i=0;i<tab.linhas;i++) {
                for (var j = 0; j < tab.colunas; j++){
                    if (mat[i,j]) {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool movimentoPossivel(Posicao pos) {
            return movimentosPossiveis()[pos.linha, pos.coluna];
        }

        public abstract bool[,] movimentosPossiveis();
    }
}
