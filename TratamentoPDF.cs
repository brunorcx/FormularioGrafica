using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Font = MigraDoc.DocumentObjectModel.Font;

namespace FormularioGrafica {

    internal class TratamentoPDF {
        private static List<string> listaString;
        private static List<string> listaPapelCor;

        public TratamentoPDF() {
        }

        public TratamentoPDF(List<string> listaString) {
            TratamentoPDF.listaString = listaString;
        }

        public TratamentoPDF(List<string> listaString, List<string> listaPapelCor) {
            TratamentoPDF.listaString = listaString;
            TratamentoPDF.listaPapelCor = listaPapelCor;
        }

        private static Document CreateDocument() {
            // Create a new MigraDoc document
            Document document = new Document();

            //Definir styles
            DefineStyles(document);

            // Add a section to the document
            Section section = document.AddSection();
            section.PageSetup.TopMargin = "0.5cm"; // Diminuir a margem do topo da página
            section.PageSetup.BottomMargin = "-0.5cm";
            //Inserir tabela
            SimpleTable(document);
            // Add a paragraph to the section
            Paragraph paragraph = section.AddParagraph();

            paragraph.Format.Font.Color = MigraDoc.DocumentObjectModel.Color.FromCmyk(100, 30, 20, 50);

            // Add some text to the paragraph
            //paragraph.AddFormattedText("Hello, World!", TextFormat.Bold);

            return document;
        }

        private static void DefineStyles(Document document) {
            // Get the predefined style Normal.
            Style style = document.Styles["Normal"];
            // Because all styles are derived from Normal, the next line changes the
            // font of the whole document. Or, more exactly, it changes the font of
            // all styles and paragraphs that do not redefine the font.
            style.Font.Name = "Times New Roman";

            // Heading1 to Heading9 are predefined styles with an outline level. An outline level
            // other than OutlineLevel.BodyText automatically creates the outline (or bookmarks)
            // in PDF.
            style = document.Styles["Heading1"];
            style.Font.Name = "Tahoma";
            style.Font.Size = 14;
            style.Font.Bold = true;
            style.Font.Color = Colors.DarkBlue;
            style.ParagraphFormat.PageBreakBefore = true;
            //style.ParagraphFormat.SpaceAfter = 6;
        }

        private static void SimpleTable(Document document) {
            //document.LastSection.AddParagraph("Simple Tables", "Heading2");

            Table table = new Table();
            table.Borders.Width = 0.75;
            table.Borders.Color = Colors.DarkRed;
            Column column = table.AddColumn(Unit.FromCentimeter(2));//Primeira coluna
            //column.Format.Alignment = ParagraphAlignment.Center;
            table.AddColumn(Unit.FromCentimeter(2));//Segunda coluna
            table.AddColumn(Unit.FromCentimeter(2));//Terceira coluna
            table.AddColumn(Unit.FromCentimeter(2));//Quarta coluna
            table.AddColumn(Unit.FromCentimeter(2));//Quinta coluna
            table.AddColumn(Unit.FromCentimeter(2));//Sexta coluna
            table.AddColumn(Unit.FromCentimeter(2));//Sétima coluna
            table.AddColumn(Unit.FromCentimeter(2));//Oitava coluna
            table.AddColumn(Unit.FromCentimeter(2));//Nona coluna
            table.AddColumn(Unit.FromCentimeter(2));//Decima coluna
            //Arrastar tabela
            table.Rows.LeftIndent = "-2cm";
            table.Rows.Height = 90;
            table.Format.Font.Size = 14;
            table.Format.Font.Color = Colors.DarkRed;

            //table.Format.SpaceBefore = "-4cm";
            //Colocar uma border branca e usar row vermelha para completar a linha
            //Linha 0

            Row row = table.AddRow();
            row.Height = 70;

            Cell cell = row.Cells[0];
            cell.AddImage("../../Resources/imagens/CabecalhoForbras.png");
            cell.AddParagraph("ENTRADA: " + listaString[0] + "\t\tENTREGA: " + listaString[1]); //113 caracteres
            cell.VerticalAlignment = VerticalAlignment.Bottom;
            cell = row.Cells[9];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.VerticalAlignment = VerticalAlignment.Top;
            cell.AddParagraph("PEDIDO");
            cell.AddParagraph("\n000100");
            row.Cells[0].MergeRight = 8;
            //Linha 1
            row = table.AddRow();
            row.Height = 60;

            //row.Borders.Color = Colors.White;
            cell = row.Cells[0];
            cell.AddParagraph("CLIENTE: " + listaString[2]).Format.SpaceAfter = 5;
            cell.Format.Borders.Bottom.Width = 0.75;
            //cell.Format.Borders.Width = 4;
            cell.Format.Borders.DistanceFromLeft = -60.0;
            cell.Format.Borders.DistanceFromRight = 4;
            //cell.Format.Borders.DistanceFromRight = -515.0;
            cell.Format.Borders.Bottom.Color = Colors.DarkRed;
            cell.AddParagraph("CNPJ: " + listaString[3] + "\t\tFONE: " + listaString[4]).Format.Borders.Bottom.Color = Colors.White;
            cell.VerticalAlignment = VerticalAlignment.Bottom;
            row.Cells[0].MergeRight = 9;

            //Linha 2
            row = table.AddRow();
            row.Borders.Right.Clear();
            row.Height = 296;
            cell = row.Cells[0];
            //COLOCAR QUANTIDADE EM OUTRA COLUNA
            //VERIFICAR O LIMITE DO NOME DO SERVIÇO E MUDAR MAXIUM LENGTH NO TEXTBOX
            //Serviço 1
            cell.AddParagraph("SERVIÇO: " + listaString[9]).Format.Font.Bold = true;
            row.Cells[7].AddParagraph("QUANTIDADE:" + listaString[10]).Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("Vias\t1º\t2º\t3º\t4º\tTAMANHO:" + listaString[11] + "x" + listaString[12]);
            row.Cells[8].AddParagraph("\tR$" + listaString[13] + "\n\n\n");
            cell.AddParagraph("PAPEL:" + listaPapelCor[0] + "\t\t\t\tCOR:" + listaPapelCor[1]);
            if (listaString.Count > 15) {  //Serviço 2
                row.Cells[0].AddParagraph("\n\nSERVIÇO: " + listaString[14]).Format.Font.Bold = true;
                row.Cells[7].AddParagraph("\n\n\n\nQUANTIDADE:" + listaString[15]).Format.Alignment = ParagraphAlignment.Center;
                row.Cells[0].AddParagraph("Vias\t1º\t2º\t3º\t4º\tTAMANHO:" + listaString[16] + "x" + listaString[17]);
                row.Cells[8].AddParagraph("\n\n\tR$" + listaString[18] + "\n\n\n");
                row.Cells[0].AddParagraph("PAPEL:" + listaPapelCor[2] + "\t\t\t\tCOR:" + listaPapelCor[3]);

                if (listaString.Count > 20) {//Serviço 3
                    row.Cells[0].AddParagraph("\n\nSERVIÇO: " + listaString[19]).Format.Font.Bold = true;
                    row.Cells[7].AddParagraph("\n\n\n\nQUANTIDADE:" + listaString[20]).Format.Alignment = ParagraphAlignment.Center;
                    row.Cells[0].AddParagraph("Vias\t1º\t2º\t3º\t4º\tTAMANHO:" + listaString[21] + "x" + listaString[22]);
                    row.Cells[8].AddParagraph("\n\n\tR$" + listaString[23] + "\n\n\n");
                    row.Cells[0].AddParagraph("PAPEL:" + listaPapelCor[4] + "\t\t\t\tCOR:" + listaPapelCor[5]);
                }
                if (listaString.Count > 25) {//Serviço 4
                    row.Cells[0].AddParagraph("\n\nSERVIÇO: " + listaString[24]).Format.Font.Bold = true;
                    row.Cells[7].AddParagraph("\n\n\n\nQUANTIDADE:" + listaString[25]).Format.Alignment = ParagraphAlignment.Center;
                    row.Cells[0].AddParagraph("Vias\t1º\t2º\t3º\t4º\tTAMANHO:" + listaString[26] + "x" + listaString[27]);
                    row.Cells[8].AddParagraph("\n\n\tR$" + listaString[28]);
                    row.Cells[0].AddParagraph("PAPEL:" + listaPapelCor[6] + "\t\t\t\tCOR:" + listaPapelCor[7]);
                }
            }

            row.Cells[0].MergeRight = 6;
            row.Cells[8].MergeRight = 1;
            row.Cells[9].Borders.Right.Color = Colors.DarkRed;

            //Linha 3
            row = table.AddRow();
            row.Height = 60;
            cell = row.Cells[0];
            Paragraph paragraph = new Paragraph();
            FormattedText caixaTrue = new FormattedText();
            FormattedText caixaFalse = new FormattedText();
            caixaTrue.AddFormattedText(true ? "\u00fe" : "\u00A8", new Font("Wingdings", 14));
            caixaFalse.AddFormattedText(false ? "\u00fe" : "\u00A8", new Font("Wingdings", 14));

            if (listaString[5] == "True")
                paragraph.Add(caixaTrue);
            else
                paragraph.Add(caixaFalse);
            paragraph.AddText("COM APLICAÇÂO\t\t");
            //------------------------------------
            if (listaString[6] == "True")
                paragraph.Add(caixaTrue.Clone());
            else
                paragraph.Add(caixaFalse.Clone());
            paragraph.AddText("SEM APLICAÇÃO");
            //------------------------------------
            cell.Add(paragraph);
            //Adicionar paragráfo 2
            paragraph = new Paragraph();
            if (listaString[7] == "True")
                paragraph.Add(caixaTrue.Clone());
            else
                paragraph.Add(caixaFalse.Clone());
            paragraph.AddText("RETIRADA ADESIVO\t");
            //------------------------------------
            if (listaString[8] == "True")
                paragraph.Add(caixaTrue.Clone());
            else
                paragraph.Add(caixaFalse.Clone());
            paragraph.AddText("RETIRADA PLACA");
            //------------------------------------
            cell.Add(paragraph);
            paragraph = new Paragraph();
            paragraph.AddText("\nOBS:");
            paragraph.Format.SpaceAfter = 5;
            paragraph.Format.Borders.Bottom.Width = 0.75;
            paragraph.Format.Borders.DistanceFromLeft = -28.0;
            paragraph.Format.Borders.DistanceFromRight = 1;
            paragraph.Format.Borders.Bottom.Color = Colors.DarkRed;
            cell.Add(paragraph);
            cell = row.Cells[8];
            cell.AddParagraph("\nTOTAL: R$" + listaString[listaString.Count - 1].ToUpper()).Format.Alignment = ParagraphAlignment.Center;
            row.Cells[0].MergeRight = 7;
            row.Cells[8].MergeRight = 1;

            //Linha 4
            row = table.AddRow();
            row.Shading.Color = Colors.Crimson;
            row.Borders.Bottom.Clear();
            cell = row.Cells[0];
            cell.Format.Font.Color = Colors.White;
            cell.Format.Font.Name = "Arial";
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.VerticalAlignment = VerticalAlignment.Center;
            cell.AddParagraph().AddFormattedText("OBS: É NECESSÁRIA A APRESENTAÇÃO DESTE PARA O RECEBIMENTO DO MATERIAL.", TextFormat.Bold);
            cell.AddParagraph("O CLIENTE ASSUME A RESPONSABILIDADE DO PEDIDO APÓS A CONFIRMAÇÃO DO MODELO, E PAGAMENTO " +
                "SOB O VALOR ASSINADO APÓS A CONFIRMAÇÃO. NÃO TRABALHAMOS COM PROVA DE COR, POR ISSO PODEM OCORRER VARIAÇÕES MÍNIMAS " +
                "DE COR DURANTE O PROCESSO DE IMPRESSÃO.").Format.Font.Size = 10;
            row.Cells[0].MergeRight = 9;

            //Linha 5
            row = table.AddRow();
            row.Borders.Top.Clear();
            row.Borders.Right.Clear();
            cell = row.Cells[0];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.VerticalAlignment = VerticalAlignment.Bottom;
            cell.AddParagraph("_________________________________");
            cell.AddParagraph("FORBRÁS");
            row.Cells[0].MergeRight = 4;
            row.Cells[5].MergeRight = 4;
            row.Cells[9].Borders.Right.Color = Colors.DarkRed;

            cell = row.Cells[5];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.VerticalAlignment = VerticalAlignment.Bottom;
            cell.AddParagraph("_________________________________");
            cell.AddParagraph("CLIENTE");

            //Linha 6
            row = table.AddRow();
            row.Shading.Color = Colors.Crimson;
            row.Format.Font.Bold = true;
            row.Format.Font.Color = Colors.White;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.VerticalAlignment = VerticalAlignment.Top;
            row.Borders.Bottom.Clear();
            cell = row.Cells[0];
            //cell.Format.Shading.Color = Colors.Crimson;
            cell.AddParagraph("ENTRADA");
            cell = row.Cells[5];
            cell.AddParagraph("RESTANTE");
            row.Cells[0].MergeRight = 4;
            row.Cells[5].MergeRight = 4;
            row.Height = 20;

            //Linha 7
            row = table.AddRow();
            //row.Format.Font.Color = Colors.DarkRed;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.VerticalAlignment = VerticalAlignment.Top;
            row.Borders.Top.Clear();
            cell = row.Cells[0];
            cell.AddParagraph("R$ 50,00").Format.Font.Size = 20; // TODO Colocar uma variavel para indicar  entrada e restante
            cell.AddParagraph("\n\n\n" + listaString[0]).Format.Font.Size = 20;

            cell = row.Cells[5];
            cell.AddParagraph("R$ 50,00").Format.Font.Size = 20;
            cell.AddParagraph("\n\n\n" + listaString[1]).Format.Font.Size = 20;
            row.Cells[0].MergeRight = 4;
            row.Cells[5].MergeRight = 4;
            //table.SetEdge(0, 0, 2, 3, Edge.Box, BorderStyle.Single, 1.5, Colors.DarkRed);
            //table.LeftPadding = 60;

            document.LastSection.Add(table);
        }

        public void salvarPDF() {
            // Create a MigraDoc document
            Document document = CreateDocument();
            document.UseCmykColor = true;

            // ===== Unicode encoding and font program embedding in MigraDoc is demonstrated here =====

            // A flag indicating whether to create a Unicode PDF or a WinAnsi PDF file.
            // This setting applies to all fonts used in the PDF document.
            // This setting has no effect on the RTF renderer.
            const bool unicode = false;

            // An enum indicating whether to embed fonts or not.
            // This setting applies to all font programs used in the document.
            // This setting has no effect on the RTF renderer.
            // (The term 'font program' is used by Adobe for a file containing a font. Technically a 'font file'
            // is a collection of small programs and each program renders the glyph of a character when executed.
            // Using a font in PDFsharp may lead to the embedding of one or more font programms, because each outline
            // (regular, bold, italic, bold+italic, ...) has its own fontprogram)
            const PdfFontEmbedding embedding = PdfFontEmbedding.Always;

            // ========================================================================================

            // Create a renderer for the MigraDoc document.
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(unicode, embedding);

            // Associate the MigraDoc document with a renderer
            pdfRenderer.Document = document;

            // Layout and render document to PDF
            pdfRenderer.RenderDocument();

            // Save the document...
            const string filename = "HelloWorld.pdf";
            pdfRenderer.PdfDocument.Save(filename);
            // ...and start a viewer.
            Process.Start(filename);
        }
    }
}

//http://www.pdfsharp.net/wiki/HelloMigraDoc-sample.ashx