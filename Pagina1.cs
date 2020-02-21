using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PdfSharp.Pdf;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace FormularioGrafica {

    public partial class Pagina1 : UserControl {
        private DBConnect dB = new DBConnect();
        private DataTable tabela = new DataTable();
        private AutoCompleteStringCollection textCollection = new AutoCompleteStringCollection();
        private AutoCompleteStringCollection textCollection2 = new AutoCompleteStringCollection();
        private TratamentoPDF pdf = new TratamentoPDF();

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

        private void buttonImprimir_Click(object sender, EventArgs e) {
            pdf.salvarPDF();
            //imprimirPDF();

            //CaptureScreen();
            ////printPreviewDialogPagina1.ShowDialog();
            //if (printDialogPagina1.ShowDialog() == DialogResult.OK) {
            //    printDocumentPagina1.Print();
            //}
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

        //private void imprimirPDF() {
        //    ProcessStartInfo startInfo = new ProcessStartInfo();
        //    startInfo.FileName = "SumatraPDF.exe";
        //    string args = string.Format("-print-to-default \"{0}\" -exit-when-done", "HelloWorld.pdf");
        //    startInfo.Arguments = args;
        //    startInfo.CreateNoWindow = true;
        //    startInfo.ErrorDialog = false;
        //    startInfo.UseShellExecute = false;
        //    Process process = Process.Start(startInfo);
        //    MessageBox.Show("Start Print.");
        //    //process.Exited += process_Exited;
        //    while (!process.HasExited) {
        //        MessageBox.Show("Wait 1 Sec.");
        //        process.WaitForExit(1000);
        //    }
        //    MessageBox.Show("Print Finish.");
        //} Para adicionar o sumatra arrastar no FomularioGrafica(verde) e mudar para sempre output

    }
}

//https://www.codeproject.com/Questions/1048064/Print-PDF-File-With-Code-In-Windows-Forms
//http://www.pdfsharp.com/PDFsharp/
//https://docs.microsoft.com/en-us/dotnet/api/system.drawing.printing.printdocument?redirectedfrom=MSDN&view=netframework-4.8