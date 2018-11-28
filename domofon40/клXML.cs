using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace domofon40
{
    class клXML
    {

        public static void ChangeTextInCell(Table table, int строка, int ячейка, string txt)
        {
            // Use the file name and path passed in as an argument to 
            // open an existing document.            
            //using (WordprocessingDocument doc =
            //    WordprocessingDocument.Open(filepath, true))
            //{
            // Find the first table in the document.
            //Table table =
            //    doc.MainDocumentPart.Document.Body.Elements<Table>().First();

            // Find the second row in the table.
            if (table.Elements<TableRow>().Count() > строка )
            {
                TableRow row = table.Elements<TableRow>().ElementAt(строка);

                if (row.Elements<TableCell>().Count() > ячейка )
                {

                    // Find the third cell in the row.
                    TableCell cell = row.Elements<TableCell>().ElementAt(ячейка);

                    // Find the first paragraph in the table cell.
                    Paragraph p = cell.Elements<Paragraph>().First();
                 //   свойствоПараграфа(p);

                    Run r;
                    Text t;
                    if (p.Elements<Run>().Count() > 0)
                    {
                        // Find the first run in the paragraph.
                        r = p.Elements<Run>().First();
                        t = r.Elements<Text>().First();


                        // Set the text for the run.
                    }
                    else
                    {
                        r = p.AppendChild<Run>(new Run());
                        t = r.AppendChild<Text>(new Text());
                    }

                    t.Text = txt;

                }
                else
                {
                    MessageBox.Show("Нет ячейки "+ ячейка.ToString());
                }
            }
            else
            {
                MessageBox.Show("Нет строки "+ строка.ToString());
            }
        }
        public static void  свойствоПараграфа(Paragraph par)
        {
            if (par.Elements<ParagraphProperties>().Count() == 0)
            {

                par.AppendChild<ParagraphProperties>(new ParagraphProperties());
            }

            ParagraphProperties pPr = par.Elements<ParagraphProperties>().First();
           ParagraphStyleId pSt= pPr.ParagraphStyleId = new ParagraphStyleId();
           
           pSt.Val = "Заголовок 1" ;
            
            

        }

        public static void просмотрWord( string tempFile)
        {
            var template2 = new System.IO.FileInfo(tempFile);
            if (template2.Exists)
            {
              //  template2.IsReadOnly = true; не действует 
                try
                {
                    System.Diagnostics.Process.Start(tempFile);
                }
                catch
                {
                    MessageBox.Show("Невозможно открыть файл Word...");
                    return;
                }
              //  template2.OpenRead();
             //   Word.Application oWord = new Word.Application();
             //   Word.Document o = oWord.Documents.Open(tempFile);
             ////  Word.Document o = oWord.Documents.
             //   oWord.Visible = true;
            }
            else
            {
                MessageBox.Show("Нет файла " + tempFile.ToString());
            
            }

          //if (!System.IO.File.Exists(tempFile))
          //  {
          //      MessageBox.Show("Нет файла " + tempFile.ToString());
          //      return;
          //  }

          //System.Diagnostics.Process.Start(tempFile);
         // string команда = "'tempFile' /n";
          //System.Diagnostics.Process.Start(@"c:\sharp10\domofon10\domofon10\bin\Debug\temp\temp.docx /n" );
      //      Word.Application oWord = new Word.Application();
      //  //    oWord.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;
      //      //Word.Document o = oWord.Documents.Open(tempFile);
      //     Word.Document o = oWord.Documents.Open(tempFile, Type.Missing, true);
            
      //  //    Word.Document o = oWord.Documents.Open(FileName: tempFile, ReadOnly: true);
      ////      o.Application.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;
      //      oWord.Visible = true;
        }
       


    }
}
