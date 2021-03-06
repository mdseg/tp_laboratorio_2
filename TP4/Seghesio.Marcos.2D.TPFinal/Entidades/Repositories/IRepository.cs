using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Repositories
{
    /// <summary>
    /// Interfaz genérica que indica los métodos mínimimos de interacción con la BD
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        List<T> GetAll();

        T GetById(long entityId);

        void Create(T entity);

        void Update(T entity);

        void Remove(T entity);

        int GetMaxId();

    }
}
