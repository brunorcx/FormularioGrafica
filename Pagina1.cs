using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
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
        private TratamentoPDF pdf;
        private decimal somaServico;
        private List<string> listaServico1;
        private List<string> listaServico2;
        private List<string> listaServico3;
        private decimal somaServicoTotal;

        public Pagina1() {
            InitializeComponent();
            labelAtendente.Text = Login.login;
            comboBoxDimensoes.Text = "cm";
            numericUpDownQuantidade.Value = 1;
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

        private decimal somaTotal() {
            decimal areaBase;
            decimal areaAtual;
            decimal dif;
            decimal total;

            tabela = dB.Select(comboBoxServico.Text, "", "", "");

            areaBase = decimal.Parse(tabela.Rows[0][2].ToString()) * decimal.Parse(tabela.Rows[0][3].ToString());
            areaAtual = decimal.Parse(textBoxTamanhoX.Text) * decimal.Parse(textBoxTamanhoY.Text);
            dif = (areaAtual * 100) / areaBase;
            total = decimal.Parse(tabela.Rows[0][1].ToString()) * (dif / 100) * numericUpDownQuantidade.Value;
            return total;
        }

        private void buttonImprimir_Click(object sender, EventArgs e) {
            List<string> listaVenda = new List<string>();
            listaVenda.Add(dateTimePickerEntrada.Value.ToString());     //0
            listaVenda.Add(dateTimePickerEntrega.Value.ToString());     //1
            listaVenda.Add(textBoxCliente.Text);                        //2
            listaVenda.Add(textBoxCPF.Text);                            //3
            listaVenda.Add(textBoxTelefone.Text);                       //4
            listaVenda.Add(comboBoxServico.Text);                       //5
            listaVenda.Add(checkBoxCAplicacao.Checked.ToString());      //6
            listaVenda.Add(checkBoxSAplicacao.Checked.ToString());      //7
            listaVenda.Add(checkBoxRAdesivo.Checked.ToString());        //8
            listaVenda.Add(checkBoxRPlaca.Checked.ToString());          //9
            listaVenda.Add(labelTotal.Text);                            //10
            listaVenda.Add(textBoxTamanhoX.Text);                       //11
            listaVenda.Add(textBoxTamanhoY.Text);                       //12
            listaVenda.Add(numericUpDownQuantidade.Value.ToString());   //13
            listaVenda.Add(somaServico.ToString());                     //14

            if (listaServico1 != null) {
                //Adiciona lista Servico1
                listaVenda.AddRange(listaServico1);
                if (listaServico2 != null) {
                    listaVenda.AddRange(listaServico2);
                    if (listaServico3 != null) {
                        listaVenda.AddRange(listaServico3);
                    }
                }
            }
            //Salvar os preços
            somaServicoTotal += somaServico;
            listaVenda.Add(somaServicoTotal.ToString());

            pdf = new TratamentoPDF(listaVenda);//Se quiser imprimir o pdf vazio, basta não enviar uma lista
            pdf.salvarPDF();

            //imprimirPDF();

            //CaptureScreen();
            ////printPreviewDialogPagina1.ShowDialog();
            //if (printDialogPagina1.ShowDialog() == DialogResult.OK) {
            //    printDocumentPagina1.Print();
            //}
        }

        private void textBoxCPF_Leave(object sender, EventArgs e) {
            tabela = dB.Select(textBoxCPF.Text, "", "");
            if (textBoxCPF.Text != String.Empty && tabela.Rows.Count != 0) {
                textBoxCliente.Text = tabela.Rows[0][1].ToString();
                textBoxTelefone.Text = tabela.Rows[0][2].ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
        }

        private void label18_Click(object sender, EventArgs e) {
        }

        private void comboBoxCor_Leave(object sender, EventArgs e) {
            if (comboBoxServico.Text != "") {
                somaServico = somaTotal();
                labelTotal.Text = "Total:R$ " + somaServico.ToString();
            }
        }

        private void numericUpDownQuantidade_ValueChanged(object sender, EventArgs e) {
            if (comboBoxServico.Text != "") {
                somaServico = somaTotal();
                labelTotal.Text = "Total:R$ " + somaServico.ToString();
            }
        }

        private void comboBoxServico_TextChanged(object sender, EventArgs e) {
            tabela = dB.Select(comboBoxServico.Text, "", "", "");
            if (comboBoxServico.Text != String.Empty && tabela.Rows.Count != 0) {
                textBoxTamanhoX.Text = tabela.Rows[0][2].ToString();
                textBoxTamanhoY.Text = tabela.Rows[0][3].ToString();
            }
            if (comboBoxServico.Text != "") {
                somaServico = somaTotal();
                labelTotal.Text = "Total:R$ " + somaServico.ToString();
                labelSomaTotal.Text = "Soma Total:R$ " + somaServicoTotal.ToString();
            }
        }

        private void buttonServico2_Click(object sender, EventArgs e) {
            if (comboBoxServico.Text != "") {
                listaServico1 = new List<string>();
                //Adicionar a listade serviços
                listaServico1.Add(comboBoxServico.Text);//15
                listaServico1.Add(numericUpDownQuantidade.Value.ToString());//16
                listaServico1.Add(textBoxTamanhoX.Text);//17
                listaServico1.Add(textBoxTamanhoY.Text);//18
                listaServico1.Add(somaServico.ToString());//19
                //Resetar textos
                comboBoxServico.SelectedItem = null;
                textBoxTamanhoX.ResetText();
                textBoxTamanhoY.ResetText();
                numericUpDownQuantidade.Value = 1;
                labelTotal.ResetText();
                //Salvar os preços
                somaServicoTotal += somaServico;

                labelSomaTotal.Text = "Soma Total:R$ " + somaServicoTotal.ToString();
                MessageBox.Show("Primeiro serviço salvo com sucesso!");
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
        }

        private void buttonServico3_Click(object sender, EventArgs e) {
            if (comboBoxServico.Text != "") {
                if (listaServico1 == null) {
                    MessageBox.Show("Por favor, preencha o serviço 2.");
                }
                else {
                    listaServico2 = new List<string>();
                    //Adicionar a listade serviços
                    listaServico2.Add(comboBoxServico.Text);//20
                    listaServico2.Add(numericUpDownQuantidade.Value.ToString());//21
                    listaServico2.Add(textBoxTamanhoX.Text);//22
                    listaServico2.Add(textBoxTamanhoY.Text);//23
                    listaServico2.Add(somaServico.ToString());//24
                    //Resetar textos
                    comboBoxServico.SelectedItem = null;
                    textBoxTamanhoX.ResetText();
                    textBoxTamanhoY.ResetText();
                    numericUpDownQuantidade.Value = 1;
                    labelTotal.ResetText();
                    //Salvar os preços
                    somaServicoTotal += somaServico;

                    labelSomaTotal.Text = "Soma Total:R$ " + somaServicoTotal.ToString();
                    MessageBox.Show("Segundo serviço salvo com sucesso!");

                }
            }
        }

        private void buttonServico4_Click(object sender, EventArgs e) {
            if (comboBoxServico.Text != "") {
                if (listaServico2 == null) {
                    MessageBox.Show("Por favor, preencha o serviço 3.");
                }
                else {
                    listaServico3 = new List<string>();
                    //Adicionar a listade serviços
                    listaServico3.Add(comboBoxServico.Text);//25
                    listaServico3.Add(numericUpDownQuantidade.Value.ToString());//26
                    listaServico3.Add(textBoxTamanhoX.Text);//27
                    listaServico3.Add(textBoxTamanhoY.Text);//28
                    listaServico3.Add(somaServico.ToString());//29
                    //Resetar textos
                    comboBoxServico.SelectedItem = null;
                    textBoxTamanhoX.ResetText();
                    textBoxTamanhoY.ResetText();
                    numericUpDownQuantidade.Value = 1;
                    labelTotal.ResetText();
                    //Salvar os preços
                    somaServicoTotal += somaServico;

                    labelSomaTotal.Text = "Soma Total:R$ " + somaServicoTotal.ToString();
                    MessageBox.Show("Terceiro serviço salvo com sucesso!");

                }
            }
        }

        private void dateTimePickerEntrada_ValueChanged(object sender, EventArgs e) {
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