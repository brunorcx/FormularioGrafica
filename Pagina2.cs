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

    public partial class Pagina2 : UserControl {
        private string nome;
        private string CPF;
        private string telefone;

        private DBConnect dB = new DBConnect();
        private DataTable tabela = new DataTable();

        public Pagina2() {
            InitializeComponent();
            dataGridTabelaClientes.Hide();
            labelNovosDados.Hide();
            labelNovoNome.Hide();
            labelNovoCPF.Hide();
            labelNovoTelefone.Hide();
            textBoxNovoCPF.Hide();
            textBoxNovoNome.Hide();
            textBoxNovoTelefone.Hide();
        }

        private void buttonCadastrar_Click(object sender, EventArgs e) {
            labelNovosDados.Hide();
            labelNovoNome.Hide();
            labelNovoCPF.Hide();
            labelNovoTelefone.Hide();
            textBoxNovoCPF.Hide();
            textBoxNovoNome.Hide();
            textBoxNovoTelefone.Hide();

            nome = textBoxNome.Text.Trim();
            CPF = textBoxCPF.Text.Replace(" ", string.Empty);
            telefone = textBoxTelefone.Text.Replace(" ", string.Empty);
            // Remover espaços em branco no começo e no final da palavra usar Trim()

            if (nome.Length == 0 || CPF.Length == 0) // Verificar campos em branco
                MessageBox.Show("Por favor, preencha os campos de Nome e CPF.");
            else {
                //dB = new DBConnect();
                dB.Insert(CPF, nome, telefone);
            }
        }

        private void buttonPesquisar_Click(object sender, EventArgs e) {
            labelNovosDados.Hide();
            labelNovoNome.Hide();
            labelNovoCPF.Hide();
            labelNovoTelefone.Hide();
            textBoxNovoCPF.Hide();
            textBoxNovoNome.Hide();
            textBoxNovoTelefone.Hide();

            nome = textBoxNome.Text.Trim();
            CPF = textBoxCPF.Text.Replace(" ", string.Empty);
            telefone = textBoxTelefone.Text.Replace(" ", string.Empty);

            if (CPF.Length == 0 && nome.Length == 0 && telefone.Length == 0) // Verificar campos em branco
                MessageBox.Show("Por favor, preencha pelo menos um dos campos.");
            else {
                dataGridTabelaClientes.Show();

                tabela = dB.Select(CPF, nome, telefone);
                dataGridTabelaClientes.DataSource = tabela;
            }
        }

        private void buttonRemover_Click(object sender, EventArgs e) {
            labelNovosDados.Hide();
            labelNovoNome.Hide();
            labelNovoCPF.Hide();
            labelNovoTelefone.Hide();
            textBoxNovoCPF.Hide();
            textBoxNovoNome.Hide();
            textBoxNovoTelefone.Hide();

            nome = textBoxNome.Text.Trim();
            CPF = textBoxCPF.Text.Replace(" ", string.Empty);
            telefone = textBoxTelefone.Text.Replace(" ", string.Empty);

            if (nome.Length == 0 || CPF.Length == 0) // Verificar campos em branco
                MessageBox.Show("Por favor, preencha os campos de Nome e CPF.");
            else {
                //dB = new DBConnect();
                dB.Delete(CPF, nome, telefone);
            }
        }

        private void buttonAlterar_Click(object sender, EventArgs e) {
            dataGridTabelaClientes.Hide();

            labelNovosDados.Show();
            labelNovoNome.Show();
            labelNovoCPF.Show();
            labelNovoTelefone.Show();
            textBoxNovoCPF.Show();
            textBoxNovoNome.Show();
            textBoxNovoTelefone.Show();

            string novoNome;
            string novoCPF;
            string novoTelefone;

            nome = textBoxNome.Text.Trim();
            CPF = textBoxCPF.Text.Replace(" ", string.Empty);// Aceitar vírgulas
            telefone = textBoxTelefone.Text.Replace(" ", string.Empty);// Aceitar vírgulas

            //Novos valores

            novoNome = textBoxNovoNome.Text;
            novoCPF = textBoxNovoCPF.Text.Replace(" ", string.Empty);// Aceitar vírgulas
            novoTelefone = textBoxNovoTelefone.Text.Replace(" ", string.Empty);// Aceitar vírgulas

            if (nome.Length == 0 || CPF.Length == 0 || telefone.Length == 0) // Verificar campos em branco
                MessageBox.Show("Por favor, preencha todos os campos iniciais da busca");
            else {
                if (novoNome.Length == 0 && novoCPF.Length == 0 && novoTelefone.Length == 0) // Verificar campos em branco
                    MessageBox.Show("Por favor, preencha pelo menos um campo a ser atualizado");
                else {
                    //dar update
                    dB.Update(nome, CPF, telefone, novoNome, novoCPF, novoTelefone);

                    //Resetar os textos
                    textBoxNovoNome.ResetText();
                    textBoxNovoCPF.ResetText();
                    textBoxTelefone.ResetText();
                }
            }
        }
    }
}