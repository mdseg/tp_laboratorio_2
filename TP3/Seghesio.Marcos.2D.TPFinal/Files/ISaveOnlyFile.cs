using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files.Xml
{
    /// <summary>
    /// Interfaz para solo guardar archivos
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISaveOnlyFile<T>
    {

        bool Save(string file, T data);
    }
}
