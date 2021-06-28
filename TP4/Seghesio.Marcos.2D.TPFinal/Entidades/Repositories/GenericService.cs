using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Repositories
{
    public class GenericService<T>
    {
        private RepositoryBase<T> repo;
    }
}
