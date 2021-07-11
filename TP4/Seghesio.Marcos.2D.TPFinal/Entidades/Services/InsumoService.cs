using Entidades.Exceptions;
using Entidades.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Services
{
    public delegate void InsumoModificado();

    public class InsumoService : ICRUDService<Insumo>
    {
        private IRepository<Madera> maderaRepo;
        private IRepository<Tela> telasRepo;
        private IRepository<InsumoAccesorio> accesorioRepo;
        public event InsumoModificado avisoInsumo;


        public InsumoService(string connectionStr)
        {
            this.maderaRepo = new RepositoryMaderaSQL(connectionStr,"Madera");
            this.telasRepo = new RepositoryTelaSQL(connectionStr,"Tela");
            this.accesorioRepo = new RepositoryInsumoAccesorioSQL(connectionStr,"InsumoAccesorio");

        }

        public void CreateEntity(List<Insumo> lista)
        {
            try
            {
                if (lista != null && lista.Count > 0)
                {
                    foreach (Insumo insumo in lista)
                    {
                        this.CreateEntity(insumo);
                    }
          
                }
            }
            catch (Exception e)
            {
                throw new SQLEntityException($"Error al persistir un listado de objetos");
            }
        }

        public void CreateEntity(Insumo entity)
        {
            bool insumoExistente = false;

            try
            {
                List<Insumo> bufferInsumos = this.GetAll();
                foreach(Insumo insumoBD in bufferInsumos)
                {
                    if(insumoBD == entity)
                    {
                        insumoBD.Cantidad += entity.Cantidad;
                        insumoBD.FechaIngreso = entity.FechaIngreso;

                        this.UpdateEntity(insumoBD);
                        insumoExistente = true;
                        break;
                    }
                }
                if(!insumoExistente)
                {
                    if (entity is Madera)
                    {
                        maderaRepo.Create((Madera)entity);
                    }
                    else if (entity is Tela)
                    {
                        telasRepo.Create((Tela)entity);
                    }
                    else
                    {
                        accesorioRepo.Create((InsumoAccesorio)entity);
                    }
                }
 

            }
            catch(Exception e)
            {
                throw new SQLEntityException($"Error al persistir el objeto {entity.Mostrar()}");
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

        public void DeleteEntity(Insumo entity)
        {
            try
            {
                if (entity is Madera)
                {
                    maderaRepo.Remove((Madera)entity);
                }
                else if (entity is Tela)
                {
                    telasRepo.Remove((Tela)entity);
                }
                else
                {
                    accesorioRepo.Remove((InsumoAccesorio)entity);
                }
             
            }
            catch (Exception e)
            {
                throw new SQLEntityException($"Error al persistir el objeto {entity.Mostrar()}");
            }
        }

        public Insumo GetEntityById(Insumo entity)
        {
            Insumo output = null;
            try
            {

                if (entity is Madera)
                {
                    output = maderaRepo.GetById(entity.Id);
                }
                else if (entity is Tela)
                {
                    output = telasRepo.GetById(entity.Id);
                }
                else
                {
                    output = accesorioRepo.GetById(entity.Id);
                }
            }
            catch(Exception e)
            {
                throw new SQLEntityException($"Error al obtener el objeto {entity.Mostrar()}");
            }
            return output;
        }

        public int GetCountByTipoInsumo(ETipoInsumo tipoInsumo)
        {
            int output = 0;
            try
            {
                switch (tipoInsumo)
                {
                    case ETipoInsumo.Madera:
                        output = ((RepositoryMaderaSQL)maderaRepo).Count();
                        break;
                    case ETipoInsumo.Tela:
                        output = ((RepositoryTelaSQL)telasRepo).Count();
                        break;
                    case ETipoInsumo.Barniz:
                        output = ((RepositoryInsumoAccesorioSQL)accesorioRepo).SumTipoInsumoAccesorio(ETipoAccesorio.Barniz);
                        break;
                    case ETipoInsumo.Pegamento:
                        output = ((RepositoryInsumoAccesorioSQL)accesorioRepo).SumTipoInsumoAccesorio(ETipoAccesorio.Pegamento);
                        break;
                    case ETipoInsumo.Tornillo:
                        output = ((RepositoryInsumoAccesorioSQL)accesorioRepo).SumTipoInsumoAccesorio(ETipoAccesorio.Tornillo);
                        break;
                    case ETipoInsumo.Yute:
                        output = ((RepositoryInsumoAccesorioSQL)accesorioRepo).SumTipoInsumoAccesorio(ETipoAccesorio.Yute);
                        break;
                }
            }
            
            catch (Exception e)
            {
                throw new SQLEntityException($"Error al obtener el conteo de insumos");
            }
            return output;
        }

        public void UpdateEntity(Insumo entity)
        {
            try
            {
                if (entity is Madera)
                {
                    maderaRepo.Update((Madera)entity);
                }
                else if (entity is Tela)
                {
                    telasRepo.Update((Tela)entity);
                }
                else
                {
                    accesorioRepo.Update((InsumoAccesorio)entity);
                }
        
            }
            catch (Exception e)
            {
                throw new SQLEntityException($"Error al actualizar el objeto {entity.Mostrar()}");
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

        public List<Insumo> GetAll(ETipoInsumo tipoInsumo)
        {
            List<Insumo> listadoInsumo = new List<Insumo>();
            try
            {
                switch(tipoInsumo)
                {
                    case ETipoInsumo.Madera:
                        listadoInsumo = Insumo.ToListInsumo(maderaRepo.GetAll());
                        break;
                    case ETipoInsumo.Tela:
                        listadoInsumo = Insumo.ToListInsumo(telasRepo.GetAll());
                        break;
                    case ETipoInsumo.Pegamento:
                        listadoInsumo.Add(((RepositoryInsumoAccesorioSQL)accesorioRepo).GetByTipoAccesorio(ETipoAccesorio.Pegamento));
                        break;
                    case ETipoInsumo.Barniz:
                        listadoInsumo.Add(((RepositoryInsumoAccesorioSQL)accesorioRepo).GetByTipoAccesorio(ETipoAccesorio.Barniz));
                        break;
                    case ETipoInsumo.Tornillo:
                        listadoInsumo.Add(((RepositoryInsumoAccesorioSQL)accesorioRepo).GetByTipoAccesorio(ETipoAccesorio.Tornillo));
                        break;
                    case ETipoInsumo.Yute:
                        listadoInsumo.Add(((RepositoryInsumoAccesorioSQL)accesorioRepo).GetByTipoAccesorio(ETipoAccesorio.Tornillo));
                        break;
                }
            }
            catch (Exception e)
            {
                throw new SQLEntityException("Error al recuperar el listado completo de Insumos");
            }

            return listadoInsumo;
        }

        public void DeleteAll()
        {
            try
            {
                ((RepositoryInsumoAccesorioSQL)accesorioRepo).DeleteAll();
                ((RepositoryMaderaSQL)maderaRepo).DeleteAll();
                ((RepositoryTelaSQL)telasRepo).DeleteAll();
     
            } catch (Exception e)
            {
                throw new SQLEntityException("Error al eliminar el listado completo de Insumos");
            }

        }


    }

    public enum ETipoInsumoConsulta
    {
        Madera,
        Tela,
        InsumoAccesorio
    }
}
