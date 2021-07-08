using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Repositories
{
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
