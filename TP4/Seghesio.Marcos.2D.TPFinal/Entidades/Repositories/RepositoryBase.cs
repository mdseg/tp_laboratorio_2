using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T>
    {
        protected string connectionString;
        protected string table;

        public RepositoryBase(string connectionString, string table)
        {
            this.connectionString = connectionString;
            this.table = table;
        }

        public abstract List<T> GetAll();

        public abstract T GetById(long entityId);

        public abstract void Create(T entity);

        public abstract void Update(T entity);

        public abstract void Remove(T entity);

        

        public abstract int Count();

        public abstract int GetMaxId();

        public abstract void DeleteAll();
    }
}
