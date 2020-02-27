using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormularioGrafica {

    internal class TratamentoPDF {

        private static Document CreateDocument() {
            // Create a new MigraDoc document
            Document document = new Document();

            //Definir styles
            DefineStyles(document);

            // Add a section to the document
            Section section = document.AddSection();
            section.PageSetup.TopMargin = "0.5cm"; // Diminuir a margem do topo da página
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
            table.Rows.Height = 35;

            //table.Format.SpaceBefore = "-4cm";
            //Colocar uma border branca e usar row vermelha para completar a linha
            //Linha 0
            Row row = table.AddRow();
            Cell cell = row.Cells[0];

            cell.AddParagraph("ENTRADA:\t\t\t\t\tENTREGA:"); //113 caracteres
            cell.VerticalAlignment = VerticalAlignment.Bottom;
            cell = row.Cells[9];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.VerticalAlignment = VerticalAlignment.Center;
            cell.AddParagraph("ATENDENTE \n Nº 0001");
            row.Cells[0].MergeRight = 8;
            //Linha 1
            row = table.AddRow();
            //row.Borders.Color = Colors.White;
            cell = row.Cells[0];
            cell.AddParagraph("CLIENTE:   CPF").Format.SpaceAfter = 5;
            cell.Format.Borders.Bottom.Width = 0.75;
            //cell.Format.Borders.Width = 4;
            cell.Format.Borders.DistanceFromLeft = -43.0;
            cell.Format.Borders.DistanceFromRight = 4;
            //cell.Format.Borders.DistanceFromRight = -515.0;
            cell.Format.Borders.Bottom.Color = Colors.DarkRed;
            cell.AddParagraph("CNPJ:\t\t\t\tFONE:").Format.Borders.Bottom.Color = Colors.White;
            cell.VerticalAlignment = VerticalAlignment.Bottom;
            row.Cells[0].MergeRight = 9;

            //cell = row.Cells[1];
            //cell.AddParagraph("texto 1");
            //Linha 2
            row = table.AddRow();
            cell = row.Cells[0];
            cell.AddParagraph("Serviço:");
            cell = row.Cells[9];
            cell.AddParagraph("Valor R$").Format.Alignment = ParagraphAlignment.Center;
            cell.AddParagraph("100,00").Format.Alignment = ParagraphAlignment.Center;
            row.Cells[0].MergeRight = 8;
            //Linha 3
            row = table.AddRow();
            cell = row.Cells[0];
            Paragraph paragraph = new Paragraph();
            FormattedText caixaTrue = new FormattedText();
            FormattedText caixaFalse = new FormattedText();
            caixaTrue.AddFormattedText(true ? "\u00fe" : "\u00A8", new Font("Wingdings", 10));
            caixaFalse.AddFormattedText(false ? "\u00fe" : "\u00A8", new Font("Wingdings", 10));
            paragraph.Add(caixaTrue);
            paragraph.AddText("COM APLICAÇÂO\t\t");
            paragraph.Add(caixaTrue.Clone());
            paragraph.AddText("SEM APLICAÇÃO");
            cell.Add(paragraph);
            //Adicionar paragráfo 2
            paragraph = new Paragraph();
            paragraph.Add(caixaFalse.Clone());
            paragraph.AddText("RETIRADA ADESIVO\t\t");
            paragraph.Add(caixaFalse.Clone());
            paragraph.AddText("RETIRADA PLACA");

            cell.Add(paragraph);

            paragraph = new Paragraph();
            paragraph.AddText("OBS:");
            paragraph.Format.SpaceAfter = 5;
            paragraph.Format.Borders.Bottom.Width = 0.75;
            paragraph.Format.Borders.DistanceFromLeft = -20.0;
            paragraph.Format.Borders.DistanceFromRight = 4;
            paragraph.Format.Borders.Bottom.Color = Colors.DarkRed;
            cell.Add(paragraph);

            cell = row.Cells[9];
            cell.AddParagraph("TOTAL:").Format.Font.Size = 11;
            row.Cells[0].MergeRight = 8;
            //Linha 4
            row = table.AddRow();
            row.Shading.Color = Colors.Crimson;
            row.Borders.Bottom.Clear();
            cell = row.Cells[0];
            cell.Format.Font.Color = Colors.White;
            cell.Format.Font.Name = "Arial";
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.VerticalAlignment = VerticalAlignment.Center;
            cell.AddParagraph().AddFormattedText("OBS: É NECESSÁRIO A APREENTAÇÃO DESTE PARA O RECEBIMENTO DO MATERIAL.", TextFormat.Bold);
            cell.AddParagraph("O CLIENTE ASSUME A RESPONSABILIDADE DO PEDIDO APÓS A CONFIRMAÇÃO DO MODELO, E PAGAMENTO " +
                "SOB O VALOR ASSINADO, APOS A CONFIRMAÇÃO. NÃO TRABALHAMOS COM PROVA DE COR, POR ISSO PODEM OCORRER VARIAÇÕES MÍNIMAS" +
                "DE COR DURANTE O PROCESSO DE IMPRESSÃO.").Format.Font.Size = 7;
            row.Cells[0].MergeRight = 9;

            //Linha 5
            row = table.AddRow();
            row.Borders.Top.Clear();
            cell = row.Cells[0];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.VerticalAlignment = VerticalAlignment.Bottom;
            cell.AddParagraph("_________________________________").Format.Font.Color = Colors.DarkRed;
            cell.AddParagraph("CLIENTE");
            row.Cells[0].MergeRight = 9;

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

            //Linha 7
            row = table.AddRow();
            //row.Format.Font.Color = Colors.DarkRed;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.VerticalAlignment = VerticalAlignment.Top;
            row.Borders.Top.Clear();
            cell = row.Cells[0];
            cell.AddParagraph("R$ 50,00"); // TODO Colocar uma variavel para indicar  entrada e restante
            cell = row.Cells[5];
            cell.AddParagraph("R$ 50,00");
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