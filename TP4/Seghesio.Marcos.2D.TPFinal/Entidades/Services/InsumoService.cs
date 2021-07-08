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
            this.maderaRepo = new RepositoryMaderaSQL(connectionStr,"Madera");
            this.telasRepo = new RepositoryTelaSQL(connectionStr,"Tela");
            this.accesorioRepo = new RepositoryInsumoAccesorioSQL(connectionStr);
        }

        public void CreateEntity(Insumo insumo)
        {
            bool insumoExistente = false;

            try
            {
                List<Insumo> bufferInsumos = this.GetAll();
                foreach(Insumo insumoBD in bufferInsumos)
                {
                    if(insumoBD == insumo)
                    {
                        insumoBD.Cantidad += insumo.Cantidad;
                        insumoBD.FechaIngreso = insumo.FechaIngreso;

                        this.UpdateEntity(insumoBD);
                        insumoExistente = true;
                    }
                }
                if(!insumoExistente)
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
                
            }
            catch(Exception e)
            {
                throw new SQLEntityException($"Error al persistir el objeto {insumo.Mostrar()}");
            }
        }

        public int GetMaxIdEntity(ETipoInsumoConsulta tipoInsumo)
        {
            int output = 0;
            try
            {
                switch(tipoInsumo)
                {
                    case ETipoInsumoConsulta.Madera:
                        output = maderaRepo.GetMaxId();
                        break;
                    case ETipoInsumoConsulta.Tela:
                        output = telasRepo.GetMaxId();
                        break;
                    case ETipoInsumoConsulta.InsumoAccesorio:
                        output = accesorioRepo.GetMaxId();
                        break;
                }
            }
            catch (Exception e)
            {
                throw new SQLEntityException($"Error al realizar al consulta");
            }
            return output;
        }

        public void DeleteEntity(Insumo insumo)
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
                throw new SQLEntityException($"Error al persistir el objeto {insumo.Mostrar()}");
            }
        }

        public Insumo GetEntityById(Insumo insumo)
        {
            Insumo output = null;
            if (insumo is Madera)
            {
                output = maderaRepo.GetById(insumo.Id);
            }
            else if (insumo is Tela)
            {
                output = telasRepo.GetById(insumo.Id);
            }
            else
            {
                output = accesorioRepo.GetById(insumo.Id);
            }
            return output;
        }

        public void UpdateEntity(Insumo insumo)
        {
            try
            {
                if (insumo is Madera)
                {
                    maderaRepo.Update((Madera)insumo);
                }
                else if (insumo is Tela)
                {
                    telasRepo.Update((Tela)insumo);
                }
                else
                {
                    accesorioRepo.Update((InsumoAccesorio)insumo);
                }
            }
            catch (Exception e)
            {
                throw new SQLEntityException($"Error al actualizar el objeto {insumo.Mostrar()}");
            }
        }

        public List<Insumo> GetAll()
        {
            List<Insumo> listadoInsumo = new List<Insumo>();
            try
            {
                List<Insumo> bufferMadera = Insumo.ToListInsumo(maderaRepo.GetAll());
                List<Insumo> bufferTelas = Insumo.ToListInsumo(telasRepo.GetAll());
                List<Insumo> bufferAccesorios = Insumo.ToListInsumo(accesorioRepo.GetAll());

                Insumo.ConcatenarInsumos(listadoInsumo, bufferMadera);
                Insumo.ConcatenarInsumos(listadoInsumo, bufferTelas);
                Insumo.ConcatenarInsumos(listadoInsumo, bufferAccesorios);
            }
            catch(Exception e)
            {
                throw new SQLEntityException("Error al recuperar el listado completo de Insumos");
            }

            return listadoInsumo;
        }

        private void EliminarInsumosDuplicados()
        {
            
        }

    }

    public enum ETipoInsumoConsulta
    {
        Madera,
        Tela,
        InsumoAccesorio
    }
}
