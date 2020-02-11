using System;
using System.Windows.Forms;

namespace FormularioGrafica {

    public partial class Pagina1 : UserControl {

        public Pagina1() {
            InitializeComponent();
            labelAtendente.Text = Login.login;
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
        }

    }
}