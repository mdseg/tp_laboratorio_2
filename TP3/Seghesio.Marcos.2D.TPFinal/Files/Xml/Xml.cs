using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Files.Xml
{
    public class Xml<T> : IFile<T>
    {
        public bool Read(string file, out T data)
        {
            bool output = false;
            try
            {
                XmlSerializer newXml = new XmlSerializer(typeof(T));
                using (XmlTextReader newTR = new XmlTextReader(file))
                {
                    data = (T)newXml.Deserialize(newTR);
                    output = true;
                }
            }
            catch (Exception e)
            {
                throw new Exception();
            }
            return output;
        }

        public bool Save(string file, T data)
        {
            bool output = false;
            try
            {
                using (XmlTextWriter auxFile = new XmlTextWriter(file, Encoding.UTF8))
                {
                    XmlSerializer auxWritter = new XmlSerializer(typeof(T));
                    auxWritter.Serialize(auxFile, data);
                }
            }
            catch (Exception e)
            {
                throw new Exception();
            }
            return output;
        }
    }
}
