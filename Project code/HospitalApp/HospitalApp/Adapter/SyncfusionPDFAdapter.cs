using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows;

namespace HospitalApp.Adapter
{
    class SyncfusionPdfAdapter : DocumentGeneratorInterface
    {
        public SyncfusionPdfAdapter()
        {
        }

        public void CreateDocument(string text)
        {
            using (PdfDocument document = new PdfDocument())
            {
                //Add a page to the document
                PdfPage page = document.Pages.Add();

                //Create PDF graphics for a page
                PdfGraphics graphics = page.Graphics;

                //Set the standard font
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

                //Draw the text
                graphics.DrawString(text, font, PdfBrushes.Black, new PointF(0, 0));

                //Save the document
                document.Save("Output.pdf");
            }
        }
    }
}
