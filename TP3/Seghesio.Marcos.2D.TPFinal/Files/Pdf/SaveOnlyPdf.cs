using Files.Xml;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files.Pdf
{
    public class SaveOnlyPdf : ISaveOnlyFile<string>
    {
        public bool Save(string file, string data)
        {
            return true;
        }
    }
}
