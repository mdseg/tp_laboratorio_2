using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Repositories
{
    public class RepositoryMadera
    {
        private RepositoryMaderaSQL maderaDAO;

        public RepositoryMadera(string connectionString)
        {
            this.maderaDAO = new RepositoryMaderaSQL(connectionString);
        }

        public bool Create(Madera entity)
        {
            bool output = false;
            try
            {
                maderaDAO.Create(entity);
                output = true;
            }
            catch (Exception e)
            {

            }
            return output;
        }

        public List<Madera> GetAll()
        {
            List<Madera> output = maderaDAO.GetAll();
            return output;
        }

        public Madera GetById(long entityId)
        {
            throw new NotImplementedException();
        }

        public void Remove(Madera entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Madera entity)
        {
            throw new NotImplementedException();
        }
    }
}
