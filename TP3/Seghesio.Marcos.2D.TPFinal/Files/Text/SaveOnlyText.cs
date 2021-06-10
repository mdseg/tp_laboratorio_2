using Files.Xml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files.Text
{
    public class TxtLogger : ISaveOnlyFile<string>
    {
        public bool Save(string file, string data)
        {
            bool output = false;
            
            try
            {
                using (StreamWriter sw = new StreamWriter(file, true))
                {
                    sw.WriteLine(data.ToString());
                    sw.Close();
                    output = true;
                }
            }
            catch(Exception e)
            {
                throw new DirectoryNotFoundException();
            }
            

            
            return output;
        }
    }
}
