using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class GenericInventario<T>
    {
        public List<T> listadoObjetos;

        public GenericInventario()
        {
            listadoObjetos = new List<T>();
        }

        public static bool operator ==(GenericInventario<T> inventario, T t)
        {
            bool output = false;
            if (inventario != null && t != null)
            {
                foreach (T objeto in inventario.listadoObjetos)
                {
                    if (objeto.Equals(t))
                    {
                        output = true;
                        break;
                    }
                }
            }
            return output;

        }
        



        public static bool operator !=(GenericInventario<T> inventario, T t)
        {
            bool output = false;
            if(inventario != t)
            {
                output = true;
            }
            return output;
        }

        public static bool operator +(GenericInventario<T> inventario, T t)
        {
            bool output = false;
            if(inventario != t)
            {
                inventario.listadoObjetos.Add(t);
                output = true;
            }
            return output;
        }
    }
}
