using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase estática encargada de guardar los métodos de extensión
    /// </summary>
    public static class MetodosExtension 
    {
        /// <summary>
        /// Metodo encargado de tomar un objeto del tipo Producto y devolver un objeto con referencias en memoria distintas, pero con los mismos valores en los atributos
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
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
