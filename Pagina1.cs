using System;
using System.Data;
using System.Windows.Forms;

namespace FormularioGrafica {

    public partial class Pagina1 : UserControl {
        private DBConnect dB = new DBConnect();
        private DataTable tabela = new DataTable();
        private AutoCompleteStringCollection textCollection = new AutoCompleteStringCollection();
        private AutoCompleteStringCollection textCollection2 = new AutoCompleteStringCollection();

        public Pagina1() {
            InitializeComponent();
            labelAtendente.Text = Login.login;
        }

        private void Pagina1_Load(object sender, EventArgs e) {
            ClienteAutoComplete();
            ServicoAutoComplete();
        }

        public AutoCompleteStringCollection ClienteAutoComplete() {
            textCollection.Clear();
            textBoxCliente.Clear();
            tabela = dB.Select("", "%", "");
            foreach (DataRow row in tabela.Rows) {
                textCollection.Add(row[1].ToString());
            }

            textBoxCliente.AutoCompleteCustomSource = textCollection;

            return textCollection;
        }

        public AutoCompleteStringCollection ServicoAutoComplete() {
            textCollection2.Clear();
            comboBoxServico.Items.Clear();
            tabela = dB.Select("%", "", "", "");
            foreach (DataRow row in tabela.Rows) {
                comboBoxServico.Items.Add(row[0].ToString());
            }
            comboBoxServico.AutoCompleteCustomSource = textCollection2;

            return textCollection2;
        }

        private void textBoxCliente_Enter(object sender, EventArgs e) {
        }
    }
}