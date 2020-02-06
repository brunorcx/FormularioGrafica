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
        private const int largura = 724;
        private const int altura = 340;
        private Point localInicial = new Point(160, 0);

        public Form1() {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
        }

        private void label1_Click(object sender, EventArgs e) {
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e) {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
        }

        private void textBox2_TextChanged(object sender, EventArgs e) {
        }

        private void textBox3_TextChanged(object sender, EventArgs e) {
        }

        private void textBox4_TextChanged(object sender, EventArgs e) {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
        }

        private void textBox7_TextChanged(object sender, EventArgs e) {
        }

        private void textBox6_TextChanged(object sender, EventArgs e) {
        }

        private void textBox8_TextChanged(object sender, EventArgs e) {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) {
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e) {
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e) {
        }

        private void textBox5_TextChanged(object sender, EventArgs e) {
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e) {
        }

        private void Form1_Load(object sender, EventArgs e) {
            pagina11.Hide();
            pagina21.Hide();
            pagina31.Hide();
            pagina41.Hide();

            //Definir tamanho e largura
            pagina11.Width = largura;
            pagina11.Height = altura;
            pagina11.Location = localInicial;

            pagina21.Width = largura;
            pagina21.Height = altura;
            pagina21.Location = localInicial;

            pagina31.Width = largura;
            pagina31.Height = altura;
            pagina31.Location = localInicial;

            pagina41.Width = largura;
            pagina41.Height = altura;
            pagina41.Location = localInicial;
        }

        private void button1_Click(object sender, EventArgs e) {
            //panelSelect.Height = button1.Height;
            //panelSelect.Top = button1.Top;

            //Esconder userControls(páginas)
            pagina11.Show();
            pagina21.Hide();
            pagina31.Hide();
            pagina41.Hide();

        }

        private void button2_Click(object sender, EventArgs e) {
            //panelSelect.Height = button2.Height;
            //panelSelect.Top = button2.Top;

            //Esconder userControls(páginas)
            pagina11.Hide();
            pagina21.Show();
            pagina31.Hide();
            pagina41.Hide();
        }

        private void button3_Click(object sender, EventArgs e) {
            //panelSelect.Height = button3.Height;
            //panelSelect.Top = button3.Top;

            //Esconder userControls(páginas)
            pagina11.Hide();
            pagina21.Hide();
            pagina31.Show();
            pagina41.Hide();
        }

        private void button4_Click(object sender, EventArgs e) {
            //panelSelect.Height = button4.Height;
            //panelSelect.Top = button4.Top;

            //Esconder userControls(páginas)
            pagina11.Hide();
            pagina21.Hide();
            pagina31.Hide();
            pagina41.Show();
        }

        private void label15_Click(object sender, EventArgs e) {
        }

        private void pagina41_Load(object sender, EventArgs e) {
        }

        private void panel1_Paint(object sender, PaintEventArgs e) {
        }

        private void panel3_Paint(object sender, PaintEventArgs e) {
        }

        private void label12_Click(object sender, EventArgs e) {
        }

        private void panelSelect_Paint(object sender, PaintEventArgs e) {
        }

        private void panel2_Paint(object sender, PaintEventArgs e) {
        }

        private void pagina11_Load(object sender, EventArgs e) {
        }

        private void pagina21_Load(object sender, EventArgs e) {
        }

        private void pagina31_Load(object sender, EventArgs e) {
        }
    }
}

// Site ícones https://www.flaticon.com/free-icon/home_25694