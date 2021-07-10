using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class MetodosExtension 
    {
        public static Producto ClonarNuevoProducto(this Producto producto)
        {
            Producto output = null;
            if(producto is Torre)
            {

                output = new Torre((Madera)producto.MaderaPrincipal.Clone(), (Tela)producto.TelaProducto.Clone(), ((Torre)producto).Modelo, (Madera)((Torre)producto).MaderaColumna.Clone(),((Torre)producto).MetrosYute);
            }
            else
            {
                output = new Estante((Madera)producto.MaderaPrincipal.Clone(), (Tela)producto.TelaProducto.Clone(), ((Estante)producto).CantidadEstantes);
            }
            return output;
        }
    }
}
