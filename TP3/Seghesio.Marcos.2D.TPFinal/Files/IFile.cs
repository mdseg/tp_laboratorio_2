using Files.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    /// <summary>
    /// Interfaz genérica utilizada para leer y guardar un tipo de archivo
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IFile<T> : ISaveOnlyFile<T>
    {
        bool Read(string file, out T data);
    }
}
