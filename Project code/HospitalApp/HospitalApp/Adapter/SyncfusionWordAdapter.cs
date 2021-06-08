using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Syncfusion.DocIO.DLS;
using System;
using System.ComponentModel;
using System.Windows;

namespace HospitalApp.Adapter
{
    class SyncfusionWordAdapter : DocumentGeneratorInterface
    {
        public void CreateDocument(string text)
        {
            using (WordDocument document = new WordDocument())
            {
                //Adds a section and a paragraph to the document
                document.EnsureMinimal();
                //Appends text to the last paragraph of the document
                document.LastParagraph.AppendText(text);
                //Saves the Word document
                document.Save("Output.docx");
            }
        }
    }
}
