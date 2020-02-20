using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace FormularioGrafica {

    public partial class Pagina1 : UserControl {
        private DBConnect dB = new DBConnect();
        private DataTable tabela = new DataTable();
        private AutoCompleteStringCollection textCollection = new AutoCompleteStringCollection();
        private AutoCompleteStringCollection textCollection2 = new AutoCompleteStringCollection();
        private Bitmap memoryImage;

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
            textBoxCPF.Clear();
            tabela = dB.Select("%", "", ""); // Pelo CPF
            foreach (DataRow row in tabela.Rows) {
                textCollection.Add(row[0].ToString());
            }

            textBoxCPF.AutoCompleteCustomSource = textCollection;

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

        private void CaptureScreen() {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        }

        private void textBoxCliente_Enter(object sender, EventArgs e) {
        }

        private void printDocumentPagina1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e) {
            e.Graphics.DrawImage(memoryImage, 0, 0);
            e.Graphics.DrawString(textBoxCliente.Text, new Font("Arial", 40, FontStyle.Regular), Brushes.Red, 100, 100);
        }

        private void buttonImprimir_Click(object sender, EventArgs e) {
            CaptureScreen();
            //printPreviewDialogPagina1.ShowDialog();
            if (printDialogPagina1.ShowDialog() == DialogResult.OK) {
                printDocumentPagina1.Print();
            }
        }

        private void printDocumentPagina1_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e) {
            System.Threading.Thread.Sleep(2000);
            MessageBox.Show("Impresão finalizada.");
        }

        private void comboBoxServico_Leave(object sender, EventArgs e) {
            tabela = dB.Select(comboBoxServico.Text, "", "", "");
            if (comboBoxServico.Text != String.Empty && tabela.Rows.Count != 0) {
                textBoxTamanhoX.Text = tabela.Rows[0][2].ToString();
                textBoxTamanhoY.Text = tabela.Rows[0][3].ToString();
            }
        }

        private void textBoxCPF_Leave(object sender, EventArgs e) {
            tabela = dB.Select(textBoxCPF.Text, "", "");
            if (textBoxCPF.Text != String.Empty && tabela.Rows.Count != 0) {
                textBoxCliente.Text = tabela.Rows[0][1].ToString();
                textBoxTelefone.Text = tabela.Rows[0][2].ToString();
            }
        }
    }
}

//https://www.codeproject.com/Questions/1048064/Print-PDF-File-With-Code-In-Windows-Forms
//http://www.pdfsharp.com/PDFsharp/
//CPF nome telefone