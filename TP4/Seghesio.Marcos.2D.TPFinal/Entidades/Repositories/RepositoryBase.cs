using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T>
    {
        protected string connectionString;

        public RepositoryBase(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public abstract List<T> GetAll();

        public abstract T GetById(long entityId);

        public abstract void Create(T entity);

        public abstract void Update(T entity);

        public abstract void Remove(T entity);

        public abstract int GetMaxId();
    }
}
