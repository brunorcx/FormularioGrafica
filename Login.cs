using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormularioGrafica {

    public partial class Login : Form {
        private string login;
        private string senha;

        public Login() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            DBConnect dB = new DBConnect();
            List<string>[] list = new List<string>[2];

            list = dB.Select("SELECT Nome,Senha FROM funcionarios WHERE (Nome =\'" + login + "\') AND (Senha =\'" + senha + "\')");
            if (list[0].Count() == 0) {
                MessageBox.Show("Login ou Senha incorretos");
            }
            else {
                this.Hide();
                Form1 form = new Form1();
                form.Show();
            }
            //foreach (var el in list) {
            //    buscaLogin = el[0];
            //}
            //dB.Insert("INSERT INTO funcionarios (CPF, Nome,Senha) VALUES(04548965149, 'Mario', 'minhaSenha')");
        }

        private void Usuario_Enter(object sender, EventArgs e) {
            if (textBoxUsuario.Text == "Usuário") {
                textBoxUsuario.Text = "";
                textBoxUsuario.ForeColor = Color.FromArgb(62, 120, 138);
            }
        }

        private void Usuario_Leave(object sender, EventArgs e) {
            if (textBoxUsuario.Text == "") {
                textBoxUsuario.Text = "Usuário";
                textBoxUsuario.ForeColor = SystemColors.InactiveCaption;
            }
            login = textBoxUsuario.Text;
        }

        private void Senha_Enter(object sender, EventArgs e) {
            if (textBoxSenha.Text == "Senha") {
                textBoxSenha.Text = "";
                textBoxSenha.ForeColor = Color.FromArgb(62, 120, 138);
            }
        }

        private void Senha_Leave(object sender, EventArgs e) {
            if (textBoxSenha.Text == "") {
                textBoxSenha.Text = "Senha";
                textBoxSenha.ForeColor = SystemColors.InactiveCaption;
            }
            senha = textBoxSenha.Text;
        }

        private void Senha_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                senha = textBoxSenha.Text;
                button_Login.PerformClick();
            }

        }

        private void textBoxUsuario_TextChanged(object sender, EventArgs e) {
        }
    }
}