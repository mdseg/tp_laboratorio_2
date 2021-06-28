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
    /// Incluye conceptos de la clase 17 Generics, 18 Interfaces y 19 Archivos
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IFile<T>
    {
        bool Read(string file, out T data);

        bool Save(string file, T data);
    }
}
