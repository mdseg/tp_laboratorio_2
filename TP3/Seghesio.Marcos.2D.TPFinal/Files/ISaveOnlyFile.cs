using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files.Xml
{
    public interface ISaveOnlyFile<T>
    {
        bool Save(string file, T data);
    }
}
