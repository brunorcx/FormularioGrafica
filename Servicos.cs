using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormularioGrafica {

    internal class Servicos {
        private string Nome;
        private string Preco;
        private float TamanhoX;
        private float TamanhoY;

        public Servicos(string Nome, string Preco, float TamanhoX, float TamanhoY) {
            this.Nome = Nome;
            this.Preco = Preco;
            this.TamanhoX = TamanhoX;
            this.TamanhoY = TamanhoY;
        }
    }
}