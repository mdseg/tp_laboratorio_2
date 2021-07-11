using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase abstracta que dota a las derivadas de un campo de id
    /// </summary>
    public abstract class Entity
    {
        private long id;

        public long Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }
    }
}
