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
            paragraph.AddFormattedText("Hello, World!", TextFormat.Bold);

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
            Column column = table.AddColumn(Unit.FromCentimeter(15));//Primeira coluna
            //column.Format.Alignment = ParagraphAlignment.Center;
            table.AddColumn(Unit.FromCentimeter(5));//Segunda coluna
            //Arrastar tabela
            table.Rows.LeftIndent = "-2cm";
            table.Rows.Height = 35;

            //table.Format.SpaceBefore = "-4cm";
            //Colocar uma border branca e usar row vermelha para completar a linha
            //Linha 0
            Row row = table.AddRow();
            Cell cell = row.Cells[0];

            cell.AddParagraph("ENTRADA:\t\t\tENTREGA:\t\t\tHORA:"); //113 caracteres
            cell.VerticalAlignment = VerticalAlignment.Bottom;
            cell = row.Cells[1];
            cell.AddParagraph("texto 0");
            //Linha 1
            row = table.AddRow();
            cell = row.Cells[0];
            cell.AddParagraph("CLIENTE:");
            cell.VerticalAlignment = VerticalAlignment.Bottom;
            row.Cells[0].MergeRight = 1;
            //cell = row.Cells[1];
            //cell.AddParagraph("texto 1");
            //Linha 2
            row = table.AddRow();
            cell = row.Cells[0];
            cell.AddParagraph("2");
            cell = row.Cells[1];
            cell.AddParagraph("texto 2");
            //Linha 3
            row = table.AddRow();
            cell = row.Cells[0];
            cell.AddParagraph("3");
            row.Cells[0].MergeRight = 1;
            //Linha 4
            row = table.AddRow();
            row.Shading.Color = Colors.Crimson;
            cell = row.Cells[0];
            cell.AddParagraph("4");
            cell = row.Cells[1];
            cell.AddParagraph("texto 4");
            //Linha 5
            row = table.AddRow();
            cell = row.Cells[0];
            cell.AddParagraph("5");
            cell = row.Cells[1];
            cell.AddParagraph("texto 5");
            //Linha 6
            row = table.AddRow();
            cell = row.Cells[0];
            cell.AddParagraph("6");
            cell = row.Cells[1];
            cell.AddParagraph("texto 6");

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