using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Services
{
    public interface ICRUDService<T>
    {
        bool LanzarEvento
        {
            get;
            set;
        }

        void CrearEntity(List<T> lista);

        void CrearEntity(T entity);

        void DeleteEntity(T entity);

        T GetEntityById(T entity);

        void UpdateEntity(T entity);

        List<T> GetAll();

        void DeleteAll();
    }
}
