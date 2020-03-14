using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormularioGrafica {

    public partial class Form1 : Form {
        private string icons_path = "";

        public Form1() {
            InitializeComponent();
            icons_path = Application.ExecutablePath;
        }

        private void Form1_Load(object sender, EventArgs e) {
            pagina11.Show();
            pagina21.Hide();
            pagina31.Hide();
            pagina41.Hide();

            //Troca a cor dos icones
            button1.Image = Properties.Resources.online_store_30px_ligth;
            button2.Image = Properties.Resources.user_account_30px_dark;
            button3.Image = Properties.Resources.clipboard_30px_dark;
            //button3.Image = Properties.Resources.clipboard_30px_white;

            WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e) {
            //panelSelect.Height = button1.Height;
            //panelSelect.Top = button1.Top;

            //Atulizar autocomplete
            if (!pagina11.Visible) {
                pagina11.ClienteAutoComplete();
                pagina11.ServicoAutoComplete();
            }
            //Esconder userControls(páginas)
            pagina11.Show();
            pagina21.Hide();
            pagina31.Hide();
            pagina41.Hide();

            //Troca a cor dos icones
            button1.Image = Properties.Resources.online_store_30px_ligth;
            button2.Image = Properties.Resources.user_account_30px_dark;
            button3.Image = Properties.Resources.clipboard_30px_dark;
            //button3.Image = Properties.Resources.clipboard_30px_white;
            //Mostrar borda
            button1.FlatAppearance.BorderSize = 1;
            button2.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.BorderSize = 0;
        }

        private void button2_Click(object sender, EventArgs e) {
            //panelSelect.Height = button2.Height;
            //panelSelect.Top = button2.Top;

            //Esconder userControls(páginas)
            pagina11.Hide();
            pagina21.Show();
            pagina31.Hide();
            pagina41.Hide();

            //Troca a cor dos icones
            button1.Image = Properties.Resources.online_store_30px_dark;
            button2.Image = Properties.Resources.user_account_30px_ligth;
            button3.Image = Properties.Resources.clipboard_30px_dark;
            //button3.Image = Properties.Resources.clipboard_30px_white;
            //Mostrar borda
            button1.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.BorderSize = 1;
            button3.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.BorderSize = 0;
        }

        private void button3_Click(object sender, EventArgs e) {
            //panelSelect.Height = button3.Height;
            //panelSelect.Top = button3.Top;

            //Esconder userControls(páginas)
            pagina11.Hide();
            pagina21.Hide();
            pagina31.Show();
            pagina41.Hide();

            //Troca a cor dos icones
            button1.Image = Properties.Resources.online_store_30px_dark;
            button2.Image = Properties.Resources.user_account_30px_dark;
            button3.Image = Properties.Resources.clipboard_30px_ligth;
            //button3.Image = Properties.Resources.clipboard_30px_white;

            //Mostrar borda
            button1.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.BorderSize = 1;
            button4.FlatAppearance.BorderSize = 0;
        }

        private void button4_Click(object sender, EventArgs e) {
            //panelSelect.Height = button4.Height;
            //panelSelect.Top = button4.Top;

            //Esconder userControls(páginas)
            pagina11.Hide();
            pagina21.Hide();
            pagina31.Hide();
            pagina41.Show();

            //Troca a cor dos icones
            button1.Image = Properties.Resources.online_store_30px_dark;
            button2.Image = Properties.Resources.user_account_30px_dark;
            button3.Image = Properties.Resources.clipboard_30px_dark;
            //button3.Image = Properties.Resources.clipboard_30px_white;

            //Mostrar borda
            button1.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.BorderSize = 1;
        }

        private void buttonMinimizar_Click(object sender, EventArgs e) {
            WindowState = FormWindowState.Minimized;
        }

        private void buttonFechar_Click(object sender, EventArgs e) {
            Application.Exit();
        }
    }
}

// Site ícones https://www.flaticon.com/free-icon/home_25694
//Conectar com o banco https://www.guru99.com/c-sharp-access-database.html
// this.close() fechar a windows form