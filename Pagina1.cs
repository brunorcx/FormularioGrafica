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

            if (listaServico1.Count != 0) {
                //Adiciona lista Servico1
                listaVenda.AddRange(listaServico1);
                if (listaServico2.Count != 0) {
                    listaVenda.AddRange(listaServico2);
                    if (listaServico3.Count != 0) {
                        listaVenda.AddRange(listaServico3);
                        if (listaServico4.Count != 0) {
                            listaVenda[5] = listaServico4[0];
                            listaVenda[13] = listaServico4[1];
                            listaVenda[11] = listaServico4[2];
                            listaVenda[12] = listaServico4[3];
                            listaVenda[14] = listaServico4[4];
                        }
                    }
                }
            }
            //Salvar os preços
            if (numServicos == 1)
                somaServicoTotal = decimal.Parse(listaServico1[4]);
            else if (numServicos == 2)
                somaServicoTotal = decimal.Parse(listaServico1[4]) + decimal.Parse(listaServico2[4]);
            else if (numServicos == 3)
                somaServicoTotal = decimal.Parse(listaServico1[4]) + decimal.Parse(listaServico2[4]) + decimal.Parse(listaServico3[4]);

            somaServicoTotal += somaServico;
            listaVenda.Add(somaServicoTotal.ToString());
            //VERIFICAR ERRO DE SOMA QUANDO IMPRIMIR VÁRIAS VEZES
            labelSomaTotal.Text = "SomaTotal:R$ " + somaServicoTotal.ToString();

            pdf = new TratamentoPDF(listaVenda);//Se quiser imprimir o pdf vazio, basta não enviar uma lista
            pdf.salvarPDF();

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
                labelNumServico.Text = "Serviço: " + (numServicos + 1).ToString();
                if (numServicos == 1) {
                    listaServico1.Clear();

                    //Adicionar a listade serviços
                    listaServico1.Add(comboBoxServico.Text);//15
                    listaServico1.Add(numericUpDownQuantidade.Value.ToString());//16
                    listaServico1.Add(textBoxTamanhoX.Text);//17
                    listaServico1.Add(textBoxTamanhoY.Text);//18
                    listaServico1.Add(somaServico.ToString());//19

                    if (listaServico2.Count != 0) {
                        comboBoxServico.Text = listaServico2[0];
                        numericUpDownQuantidade.Value = int.Parse(listaServico2[1]);
                        textBoxTamanhoX.Text = listaServico2[2];
                        textBoxTamanhoY.Text = listaServico2[3];
                        labelTotal.Text = listaServico2[4];
                        carregarValores = true;
                    }

                }
                else if (numServicos == 2) {
                    listaServico2.Clear();

                    //Adicionar a listade serviços
                    listaServico2.Add(comboBoxServico.Text);//20
                    listaServico2.Add(numericUpDownQuantidade.Value.ToString());//21
                    listaServico2.Add(textBoxTamanhoX.Text);//22
                    listaServico2.Add(textBoxTamanhoY.Text);//23
                    listaServico2.Add(somaServico.ToString());//24

                    if (listaServico3.Count != 0) {
                        comboBoxServico.Text = listaServico3[0];
                        numericUpDownQuantidade.Value = int.Parse(listaServico3[1]);
                        textBoxTamanhoX.Text = listaServico3[2];
                        textBoxTamanhoY.Text = listaServico3[3];
                        labelTotal.Text = "Total:R$ " + listaServico3[4];
                        carregarValores = true;
                    }

                }
                else if (numServicos == 3) {
                    listaServico3.Clear();

                    //Adicionar a listade serviços
                    listaServico3.Add(comboBoxServico.Text);//25
                    listaServico3.Add(numericUpDownQuantidade.Value.ToString());//26
                    listaServico3.Add(textBoxTamanhoX.Text);//27
                    listaServico3.Add(textBoxTamanhoY.Text);//28
                    listaServico3.Add(somaServico.ToString());//29

                    if (listaServico4.Count != 0) {
                        comboBoxServico.Text = listaServico4[0];
                        numericUpDownQuantidade.Value = int.Parse(listaServico4[1]);
                        textBoxTamanhoX.Text = listaServico4[2];
                        textBoxTamanhoY.Text = listaServico4[3];
                        labelTotal.Text = "Total:R$ " + listaServico4[4];
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
            else
                numServicos = 3;

        }

        private void buttonAntServico_Click(object sender, EventArgs e) {
            numServicos = numeroServico(false);
            if (numServicos >= 0) {
                //Controle do serviço anterior
                labelNumServico.Text = "Serviço: " + (numServicos + 1).ToString();
                if (numServicos == 0) {
                    //Salvar lista 1
                    if (comboBoxServico.Text != "") {
                        listaServico2[0] = comboBoxServico.Text;
                        listaServico2[1] = numericUpDownQuantidade.Value.ToString();
                        listaServico2[2] = textBoxTamanhoX.Text;
                        listaServico2[3] = textBoxTamanhoY.Text;
                        listaServico2[4] = labelTotal.Text;
                    }
                    comboBoxServico.Text = listaServico1[0];
                    numericUpDownQuantidade.Value = int.Parse(listaServico1[1]);
                    textBoxTamanhoX.Text = listaServico1[2];
                    textBoxTamanhoY.Text = listaServico1[3];
                    labelTotal.Text = "Total:R$ " + listaServico1[4];
                }
                else if (numServicos == 1) {
                    //Salvar lista 2
                    if (comboBoxServico.Text != "") {
                        listaServico3[0] = comboBoxServico.Text;
                        listaServico3[1] = numericUpDownQuantidade.Value.ToString();
                        listaServico3[2] = textBoxTamanhoX.Text;
                        listaServico3[3] = textBoxTamanhoY.Text;
                        listaServico3[4] = labelTotal.Text;
                    }

                    comboBoxServico.Text = listaServico2[0];
                    numericUpDownQuantidade.Value = int.Parse(listaServico2[1]);
                    textBoxTamanhoX.Text = listaServico2[2];
                    textBoxTamanhoY.Text = listaServico2[3];
                    labelTotal.Text = "Total:R$ " + listaServico2[4];
                }
                else if (numServicos == 2) {
                    //Salvar lista 3
                    if (comboBoxServico.Text != "") {
                        listaServico4.Clear();
                        listaServico4.Add(comboBoxServico.Text);
                        listaServico4.Add(numericUpDownQuantidade.Value.ToString());
                        listaServico4.Add(textBoxTamanhoX.Text);
                        listaServico4.Add(textBoxTamanhoY.Text);
                        listaServico4.Add(somaServico.ToString());
                    }
                    comboBoxServico.Text = listaServico3[0];
                    numericUpDownQuantidade.Value = int.Parse(listaServico3[1]);
                    textBoxTamanhoX.Text = listaServico3[2];
                    textBoxTamanhoY.Text = listaServico3[3];
                    labelTotal.Text = "Total:R$ " + listaServico3[4];

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

    }
}

//https://www.codeproject.com/Questions/1048064/Print-PDF-File-With-Code-In-Windows-Forms
//http://www.pdfsharp.com/PDFsharp/
//https://docs.microsoft.com/en-us/dotnet/api/system.drawing.printing.printdocument?redirectedfrom=MSDN&view=netframework-4.8