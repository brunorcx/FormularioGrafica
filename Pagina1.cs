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
        private List<string> listaServico1 = new List<string>();
        private List<string> listaServico2 = new List<string>();
        private List<string> listaServico3 = new List<string>();
        private List<string> listaServico4 = new List<string>();
        private decimal somaServicoTotal;
        private int numServicos;
        private bool carregarValores;

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
            listaVenda.Add(checkBoxCAplicacao.Checked.ToString());      //5
            listaVenda.Add(checkBoxSAplicacao.Checked.ToString());      //6
            listaVenda.Add(checkBoxRAdesivo.Checked.ToString());        //7
            listaVenda.Add(checkBoxRPlaca.Checked.ToString());          //8
            //Adicionar Serviços
            if (comboBoxServico.Text == "")
                MessageBox.Show("Por favor, selecione um serviço.");
            else {
                if (listaServico1.Count == 0) {
                    listaServico1 = adicionaServico(listaServico1);
                }
                else if (listaServico2.Count == 0 && comboBoxServico.Text != listaServico1[0]) {
                    listaServico2 = adicionaServico(listaServico2);
                }
                else if (listaServico3.Count == 0 && comboBoxServico.Text != listaServico1[0] && comboBoxServico.Text != listaServico2[0]) {
                    listaServico3 = adicionaServico(listaServico3);
                }
                else if (listaServico4.Count == 0 && comboBoxServico.Text != listaServico1[0] && comboBoxServico.Text != listaServico2[0] && comboBoxServico.Text != listaServico3[0]) {
                    listaServico4 = adicionaServico(listaServico4);
                }

                listaVenda.AddRange(listaServico1);//9
                listaVenda.AddRange(listaServico2);//14
                listaVenda.AddRange(listaServico3);//19
                listaVenda.AddRange(listaServico4);//24

                //Salvar os preços
                decimal preco1;
                decimal preco2;
                decimal preco3;
                decimal preco4;

                //Try catchs para soma total ##############
                try {
                    preco1 = decimal.Parse(listaServico1[4]);
                }
                catch (Exception) {
                    preco1 = 0;
                }
                try {
                    preco2 = decimal.Parse(listaServico2[4]);
                }
                catch (Exception) {
                    preco2 = 0;
                }
                try {
                    preco3 = decimal.Parse(listaServico3[4]);
                }
                catch (Exception) {
                    preco3 = 0;
                }
                try {
                    preco4 = decimal.Parse(listaServico4[4]);
                }
                catch (Exception) {
                    preco4 = 0;
                }
                //Fim try catchs para soma total ##############

                somaServicoTotal = preco1 + preco2 + preco3 + preco4;

                listaVenda.Add(somaServicoTotal.ToString());
                labelSomaTotal.Text = "SomaTotal:R$ " + somaServicoTotal.ToString();

                pdf = new TratamentoPDF(listaVenda);//Se quiser imprimir o pdf vazio, basta não enviar uma lista
                pdf.salvarPDF();
            }
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
                labelSomaTotal.Text = "SomaTotal:R$ " + somaServicoTotal.ToString();
            }
        }

        private void buttonProxServico_Click(object sender, EventArgs e) {
            if (comboBoxServico.Text == "") {
                MessageBox.Show("Por favor, preencha o serviço " + (numServicos + 1).ToString());
            }
            else if (numServicos <= 3) {
                //Controle do próximo serviço
                numServicos = numeroServico(true);
                if (numServicos == 4)
                    numServicos = 3;
                else {
                    labelNumServico.Text = "Serviço: " + (numServicos + 1).ToString();
                    if (numServicos == 1) {
                        listaServico1 = adicionaServico(listaServico1);

                        if (listaServico2.Count != 0) {
                            carregaServico(listaServico2);
                            carregarValores = true;
                        }
                    }
                    else if (numServicos == 2) {
                        listaServico2 = adicionaServico(listaServico2);

                        if (listaServico3.Count != 0) {
                            carregaServico(listaServico3);
                            carregarValores = true;
                        }
                    }
                    else if (numServicos == 3) {
                        listaServico3 = adicionaServico(listaServico3);

                        if (listaServico4.Count != 0) {
                            carregaServico(listaServico4);
                            carregarValores = true;
                        }
                    }

                    //Resetar textos
                    if (!carregarValores) {
                        comboBoxServico.SelectedItem = null;
                        textBoxTamanhoX.ResetText();
                        textBoxTamanhoY.ResetText();
                        numericUpDownQuantidade.Value = 1;
                        labelTotal.Text = "Total:R$ 0";
                    }
                    //Salvar os preços
                    if (numServicos == 1)
                        somaServicoTotal = decimal.Parse(listaServico1[4]);
                    else if (numServicos == 2)
                        somaServicoTotal = decimal.Parse(listaServico1[4]) + decimal.Parse(listaServico2[4]);
                    else if (numServicos == 3)
                        somaServicoTotal = decimal.Parse(listaServico1[4]) + decimal.Parse(listaServico2[4]) + decimal.Parse(listaServico3[4]);

                    labelSomaTotal.Text = "SomaTotal:R$ " + somaServicoTotal.ToString();

                    carregarValores = false;
                }
            }

        }

        private void buttonAntServico_Click(object sender, EventArgs e) {
            numServicos = numeroServico(false);
            if (numServicos >= 0) {
                //Controle do serviço anterior
                labelNumServico.Text = "Serviço: " + (numServicos + 1).ToString();
                if (numServicos == 0) {
                    //Salvar lista 1
                    if (comboBoxServico.Text != "") {
                        listaServico2 = adicionaServico(listaServico2);
                    }
                    //Carregar os valores dos textboxes
                    carregaServico(listaServico1);
                }
                else if (numServicos == 1) {
                    //Salvar lista 2
                    if (comboBoxServico.Text != "") {
                        listaServico3 = adicionaServico(listaServico3);
                    }

                    carregaServico(listaServico2);
                }
                else if (numServicos == 2) {
                    //Salvar lista 3
                    if (comboBoxServico.Text != "") {
                        listaServico4 = adicionaServico(listaServico4);
                    }

                    carregaServico(listaServico3);
                }

                //Salvar os preços
                if (numServicos == 1)
                    somaServicoTotal = decimal.Parse(listaServico1[4]);
                else if (numServicos == 2)
                    somaServicoTotal = decimal.Parse(listaServico1[4]) + decimal.Parse(listaServico2[4]);
                else if (numServicos == 3)
                    somaServicoTotal = decimal.Parse(listaServico1[4]) + decimal.Parse(listaServico2[4]) + decimal.Parse(listaServico3[4]);

                labelSomaTotal.Text = "SomaTotal:R$ " + somaServicoTotal.ToString();
            }
            else
                numServicos = 0;
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
        private int numeroServico(bool aumentar) {
            if (numServicos <= 3 && aumentar)
                numServicos++;
            else if (numServicos >= 0 && !aumentar)
                numServicos--;

            return numServicos;
        }

        private List<string> adicionaServico(List<string> listaServico) {
            listaServico.Clear();

            listaServico.Add(comboBoxServico.Text);//10
            listaServico.Add(numericUpDownQuantidade.Value.ToString());//11
            listaServico.Add(textBoxTamanhoX.Text);//12
            listaServico.Add(textBoxTamanhoY.Text);//13
            listaServico.Add(somaServico.ToString());//14

            return listaServico;
        }

        private void carregaServico(List<string> listaServico) {
            comboBoxServico.Text = listaServico[0];
            numericUpDownQuantidade.Value = int.Parse(listaServico[1]);
            textBoxTamanhoX.Text = listaServico[2];
            textBoxTamanhoY.Text = listaServico[3];
            labelTotal.Text = "Total:R$ " + listaServico[4];
        }
    }
}

//https://www.codeproject.com/Questions/1048064/Print-PDF-File-With-Code-In-Windows-Forms
//http://www.pdfsharp.com/PDFsharp/
//https://docs.microsoft.com/en-us/dotnet/api/system.drawing.printing.printdocument?redirectedfrom=MSDN&view=netframework-4.8