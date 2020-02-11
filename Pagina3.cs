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

        private void buttonCadastrar_Click(object sender, EventArgs e) {
            string nome = textBoxNomeRegistro.Text;
            string preco = textBoxPrecoRegistro.Text.Replace(',', '.');// Aceitar vírgulas
            string tamanhoX = textBoxTamanhoXRegistro.Text.Replace(',', '.');// Aceitar vírgulas
            string tamanhoY = textBoxTamanhoYRegistro.Text.Replace(',', '.');// Aceitar vírgulas
            if (preco.Length == 0 || nome.Length == 0 || tamanhoX.Length == 0 || tamanhoY.Length == 0) // Verificar campos em branco
                MessageBox.Show("Por favor, preencha todos os campos.");
            else {
                dB = new DBConnect();
                dB.Insert(nome, preco, tamanhoX, tamanhoY);
            }
            //List<string>[] list = new List<string>[2];
        }

        private void buttonRemover_Click(object sender, EventArgs e) {
            string nome = textBoxNomeRegistro.Text;
            string preco = textBoxPrecoRegistro.Text.Replace(',', '.');// Aceitar vírgulas
            string tamanhoX = textBoxTamanhoXRegistro.Text.Replace(',', '.');// Aceitar vírgulas
            string tamanhoY = textBoxTamanhoYRegistro.Text.Replace(',', '.');// Aceitar vírgulas
            if (preco.Length == 0 || nome.Length == 0 || tamanhoX.Length == 0 || tamanhoY.Length == 0) // Verificar campos em branco
                MessageBox.Show("Por favor, preencha todos os campos.");
            else {
                dB = new DBConnect();
                dB.Delete(nome, preco, tamanhoX, tamanhoY);
            }
        }
    }
}