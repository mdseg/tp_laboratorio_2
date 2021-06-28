using Entidades.Exceptions;
using Entidades.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Services
{
    public class InsumoService
    {
        private IRepository<Madera> maderaRepo;
        private IRepository<Tela> telasRepo;
        private IRepository<InsumoAccesorio> accesorioRepo;

        public InsumoService(string connectionStr)
        {
            this.maderaRepo = new RepositoryMaderaSQL(connectionStr);
            this.telasRepo = new RepositoryTelaSQL(connectionStr);
            this.accesorioRepo = new RepositoryInsumoAccesorioSQL(connectionStr);
        }

        public void AltaInsumo(Insumo insumo)
        {
            try
            {
                if (insumo is Madera)
                {
                    maderaRepo.Create((Madera)insumo);
                }
                else if (insumo is Tela)
                {
                    telasRepo.Create((Tela)insumo);
                }
                else
                {
                    accesorioRepo.Create((InsumoAccesorio)insumo);
                }
            }
            catch(Exception e)
            {
                throw new CreateEntityException($"Error al persistir el objeto {insumo.Mostrar()}");
            }
        }

        public void EliminarInsumo(Insumo insumo)
        {
            try
            {
                if (insumo is Madera)
                {
                    maderaRepo.Remove((Madera)insumo);
                }
                else if (insumo is Tela)
                {
                    telasRepo.Remove((Tela)insumo);
                }
                else
                {
                    accesorioRepo.Remove((InsumoAccesorio)insumo);
                }
            }
            catch (Exception e)
            {
                throw new CreateEntityException($"Error al persistir el objeto {insumo.Mostrar()}");
            }
        }

    }
}
