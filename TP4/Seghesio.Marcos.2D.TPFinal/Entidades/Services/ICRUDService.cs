using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Services
{
    /// <summary>
    /// Interfaz genérica que establece los métodos minimos con los que cuenta el servicio encargado de mediar entre la fábrica y la conexion de base de datos
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICRUDService<T>
    {

        void CreateEntity(List<T> lista);

        void CreateEntity(T entity);

        void DeleteEntity(T entity);

        T GetEntityById(T entity);

        void UpdateEntity(T entity);

        List<T> GetAll();

        void DeleteAll();
    }
}
