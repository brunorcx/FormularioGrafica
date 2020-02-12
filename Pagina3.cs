using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace FormularioGrafica {

    public partial class Pagina3 : UserControl {
        private DataTable tabela = new DataTable();
        private string nome;
        private string preco;
        private string tamanhoX;
        private string tamanhoY;

        private DBConnect dB = new DBConnect();

        public Pagina3() {
            InitializeComponent();
            dataGridTabelaServicos.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
        }

        private void label1_Click(object sender, EventArgs e) {
        }

        private void buttonCadastrar_Click(object sender, EventArgs e) {
            nome = textBoxNomeRegistro.Text;
            preco = textBoxPrecoRegistro.Text.Replace(',', '.');// Aceitar vírgulas
            tamanhoX = textBoxTamanhoXRegistro.Text.Replace(',', '.');// Aceitar vírgulas
            tamanhoY = textBoxTamanhoYRegistro.Text.Replace(',', '.');// Aceitar vírgulas
            if (preco.Length == 0 || nome.Length == 0 || tamanhoX.Length == 0 || tamanhoY.Length == 0) // Verificar campos em branco
                MessageBox.Show("Por favor, preencha todos os campos.");
            else {
                //dB = new DBConnect();
                dB.Insert(nome, preco, tamanhoX, tamanhoY);
            }
            //List<string>[] list = new List<string>[2];
        }

        private void buttonRemover_Click(object sender, EventArgs e) {
            nome = textBoxNomeRegistro.Text;
            preco = textBoxPrecoRegistro.Text.Replace(',', '.');// Aceitar vírgulas
            tamanhoX = textBoxTamanhoXRegistro.Text.Replace(',', '.');// Aceitar vírgulas
            tamanhoY = textBoxTamanhoYRegistro.Text.Replace(',', '.');// Aceitar vírgulas
            if (preco.Length == 0 || nome.Length == 0 || tamanhoX.Length == 0 || tamanhoY.Length == 0) // Verificar campos em branco
                MessageBox.Show("Por favor, preencha todos os campos.");
            else {
                //dB = new DBConnect();
                dB.Delete(nome, preco, tamanhoX, tamanhoY);
            }
        }

        private void buttonPesquisar_Click(object sender, EventArgs e) {
            dataGridTabelaServicos.Show();
            nome = textBoxNomeRegistro.Text;
            preco = textBoxPrecoRegistro.Text.Replace(',', '.');// Aceitar vírgulas
            tamanhoX = textBoxTamanhoXRegistro.Text.Replace(',', '.');// Aceitar vírgulas
            tamanhoY = textBoxTamanhoYRegistro.Text.Replace(',', '.');// Aceitar vírgulas
            if (preco.Length == 0 && nome.Length == 0 && tamanhoX.Length == 0 && tamanhoY.Length == 0) // Verificar campos em branco
                MessageBox.Show("Por favor, preencha pelo menos um dos campos.");
            else {
                tabela = dB.Select(nome, preco, tamanhoX, tamanhoY);
                dataGridTabelaServicos.DataSource = tabela;
            }
        }
    }
}