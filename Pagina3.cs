using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormularioGrafica {

    public partial class Pagina3 : UserControl {
        private DBConnect dB;

        public Pagina3() {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
        }

        private void label1_Click(object sender, EventArgs e) {
        }

        private void buttonRegistrar_Click(object sender, EventArgs e) {
            string nome = textBoxNomeRegistro.Text;
            string preco = textBoxPrecoRegistro.Text.Replace(',', '.');// Aceitar vírgulas
            string tamanhoX = textBoxTamanhoXRegistro.Text.Replace(',', '.');// Aceitar vírgulas
            string tamanhoY = textBoxTamanhoYRegistro.Text.Replace(',', '.');// Aceitar vírgulas

            dB = new DBConnect();
            dB.Insert("INSERT INTO servicos (Nome, Preco, TamanhoX, TamanhoY) " +
                "VALUES('" + nome + "','" + preco + "', '" + tamanhoX + "', '" + tamanhoY + "') ");

            //List<string>[] list = new List<string>[2];

        }
    }
}