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
            labelNovosDados.Hide();
            labelNovoNome.Hide();
            labelNovoPreco.Hide();
            labelNovoTamanho.Hide();
            labelNovoX.Hide();
            textBoxNovoNome.Hide();
            textBoxNovoPreco.Hide();
            textBoxNTamanhoX.Hide();
            textBoxNTamanhoY.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
        }

        private void label1_Click(object sender, EventArgs e) {
        }

        private void buttonCadastrar_Click(object sender, EventArgs e) {
            labelNovosDados.Hide();
            labelNovoNome.Hide();
            labelNovoPreco.Hide();
            labelNovoTamanho.Hide();
            labelNovoX.Hide();
            textBoxNovoNome.Hide();
            textBoxNovoPreco.Hide();
            textBoxNTamanhoX.Hide();
            textBoxNTamanhoY.Hide();

            nome = textBoxNomeRegistro.Text.Trim();
            preco = textBoxPrecoRegistro.Text.Replace(',', '.').Replace(" ", string.Empty);// Aceitar vírgulas
            tamanhoX = textBoxTamanhoXRegistro.Text.Replace(',', '.').Replace(" ", string.Empty);// Aceitar vírgulas
            tamanhoY = textBoxTamanhoYRegistro.Text.Replace(',', '.').Replace(" ", string.Empty);// Aceitar vírgulas
            if (preco.Length == 0 || nome.Length == 0 || tamanhoX.Length == 0 || tamanhoY.Length == 0) // Verificar campos em branco
                MessageBox.Show("Por favor, preencha todos os campos.");
            else {
                //dB = new DBConnect();
                dB.Insert(nome, preco, tamanhoX, tamanhoY);
            }
            //List<string>[] list = new List<string>[2];
        }

        private void buttonRemover_Click(object sender, EventArgs e) {
            labelNovosDados.Hide();
            labelNovoNome.Hide();
            labelNovoPreco.Hide();
            labelNovoTamanho.Hide();
            labelNovoX.Hide();
            textBoxNovoNome.Hide();
            textBoxNovoPreco.Hide();
            textBoxNTamanhoX.Hide();
            textBoxNTamanhoY.Hide();

            nome = textBoxNomeRegistro.Text.Trim();
            preco = textBoxPrecoRegistro.Text.Replace(',', '.').Replace(" ", string.Empty);// Aceitar vírgulas
            tamanhoX = textBoxTamanhoXRegistro.Text.Replace(',', '.').Replace(" ", string.Empty);// Aceitar vírgulas
            tamanhoY = textBoxTamanhoYRegistro.Text.Replace(',', '.').Replace(" ", string.Empty);// Aceitar vírgulas
            if (preco.Length == 0 || nome.Length == 0 || tamanhoX.Length == 0 || tamanhoY.Length == 0) // Verificar campos em branco
                MessageBox.Show("Por favor, preencha todos os campos.");
            else {
                //dB = new DBConnect();
                dB.Delete(nome, preco, tamanhoX, tamanhoY);
            }
        }

        //Pesquisar
        private void buttonPesquisar_Click(object sender, EventArgs e) {
            labelNovosDados.Hide();
            labelNovoNome.Hide();
            labelNovoPreco.Hide();
            labelNovoTamanho.Hide();
            labelNovoX.Hide();
            textBoxNovoNome.Hide();
            textBoxNovoPreco.Hide();
            textBoxNTamanhoX.Hide();
            textBoxNTamanhoY.Hide();

            nome = textBoxNomeRegistro.Text.Trim();
            preco = textBoxPrecoRegistro.Text.Replace(',', '.').Replace(" ", string.Empty);// Aceitar vírgulas
            tamanhoX = textBoxTamanhoXRegistro.Text.Replace(',', '.').Replace(" ", string.Empty);// Aceitar vírgulas
            tamanhoY = textBoxTamanhoYRegistro.Text.Replace(',', '.').Replace(" ", string.Empty);// Aceitar vírgulas

            if (preco.Length == 0 && nome.Length == 0 && tamanhoX.Length == 0 && tamanhoY.Length == 0) // Verificar campos em branco
                MessageBox.Show("Por favor, preencha pelo menos um dos campos.");
            else {
                dataGridTabelaServicos.Show();

                tabela = dB.Select(nome, preco, tamanhoX, tamanhoY);
                dataGridTabelaServicos.DataSource = tabela;
            }
        }

        private void buttonAlterar_Click(object sender, EventArgs e) {
            dataGridTabelaServicos.Hide();

            labelNovosDados.Show();
            labelNovoNome.Show();
            labelNovoPreco.Show();
            labelNovoTamanho.Show();
            labelNovoX.Show();
            textBoxNovoNome.Show();
            textBoxNovoPreco.Show();
            textBoxNTamanhoX.Show();
            textBoxNTamanhoY.Show();

            List<string> dadosNovos = new List<string>();
            List<string> dadosAtuais = new List<string>();
            string novoNome;
            string novoPreco;
            string novoTamanhoX;
            string novoTamanhoY;

            nome = textBoxNomeRegistro.Text.Trim();
            preco = textBoxPrecoRegistro.Text.Replace(',', '.').Replace(" ", string.Empty);// Aceitar vírgulas
            tamanhoX = textBoxTamanhoXRegistro.Text.Replace(',', '.').Replace(" ", string.Empty);// Aceitar vírgulas
            tamanhoY = textBoxTamanhoYRegistro.Text.Replace(',', '.').Replace(" ", string.Empty);// Aceitar vírgulas
            //Novos valores
            novoNome = textBoxNovoNome.Text;
            novoPreco = textBoxNovoPreco.Text.Replace(',', '.').Replace(" ", string.Empty);// Aceitar vírgulas
            novoTamanhoX = textBoxNTamanhoX.Text.Replace(',', '.').Replace(" ", string.Empty);// Aceitar vírgulas
            novoTamanhoY = textBoxNTamanhoY.Text.Replace(',', '.').Replace(" ", string.Empty);// Aceitar vírgulas

            if (preco.Length == 0 || nome.Length == 0 || tamanhoX.Length == 0 || tamanhoY.Length == 0) // Verificar campos em branco
                MessageBox.Show("Por favor, preencha todos os campos iniciais da busca");
            else {
                if (novoPreco.Length == 0 && novoNome.Length == 0 && novoTamanhoX.Length == 0 && novoTamanhoY.Length == 0) // Verificar campos em branco
                    MessageBox.Show("Por favor, preencha pelo menos um campo a ser atualizado");
                else {
                    //Inserir dados atuais
                    dadosAtuais.Add(nome);
                    dadosAtuais.Add(preco);
                    dadosAtuais.Add(tamanhoX);
                    dadosAtuais.Add(tamanhoY);
                    //Inserir dados novos na arrayList
                    dadosNovos.Add(novoNome);
                    dadosNovos.Add(novoPreco);
                    dadosNovos.Add(novoTamanhoX);
                    dadosNovos.Add(novoTamanhoY);
                    //dar update
                    dB.Update(dadosAtuais, dadosNovos);

                    //Resetar os textos
                    textBoxNovoNome.ResetText();
                    textBoxNovoPreco.ResetText();
                    textBoxNTamanhoX.ResetText();
                    textBoxNTamanhoY.ResetText();
                }
            }
        }
    }
}