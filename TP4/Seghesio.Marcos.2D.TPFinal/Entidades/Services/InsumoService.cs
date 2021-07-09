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

    public class InsumoService
    {
        private IRepository<Madera> maderaRepo;
        private IRepository<Tela> telasRepo;
        private IRepository<InsumoAccesorio> accesorioRepo;
        public event InsumoModificado avisoInsumo;
        bool lanzarEvento;

        public bool LanzarEvento
        {
            get
            {
                return this.lanzarEvento;
            }
            set
            {
                this.lanzarEvento = value;
            }
        }

        public InsumoService(string connectionStr)
        {
            this.maderaRepo = new RepositoryMaderaSQL(connectionStr,"Madera");
            this.telasRepo = new RepositoryTelaSQL(connectionStr,"Tela");
            this.accesorioRepo = new RepositoryInsumoAccesorioSQL(connectionStr,"InsumoAccesorio");
            this.LanzarEvento = true;
        }

        public void CreateEntity(List<Insumo> listaInsumos)
        {
            try
            {
                if (listaInsumos != null && listaInsumos.Count > 0)
                {
                    foreach (Insumo insumo in listaInsumos)
                    {
                        this.CreateEntity(insumo);
                    }
                    EmitirEvento();
                }
            }
            catch (Exception e)
            {
                throw new SQLEntityException($"Error al persistir un listado de objetos");
            }
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
                        break;
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
                EmitirEvento();

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
                EmitirEvento();
            }
            catch (Exception e)
            {
                throw new SQLEntityException($"Error al persistir el objeto {insumo.Mostrar()}");
            }
        }

        public Insumo GetEntityById(Insumo insumo)
        {
            Insumo output = null;
            try
            {

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
            }
            catch(Exception e)
            {
                throw new SQLEntityException($"Error al obtener el objeto {insumo.Mostrar()}");
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
                        output = maderaRepo.Count();
                        break;
                    case ETipoInsumo.Tela:
                        output = telasRepo.Count();
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
                EmitirEvento();
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
                EmitirEvento();
            } catch (Exception e)
            {
                throw new SQLEntityException("Error al eliminar el listado completo de Insumos");
            }

        }

        public void EmitirEvento()
        {
            if (LanzarEvento)
            {
                try
                {
                    this.avisoInsumo.Invoke();
                }
                catch (Exception e)
                {

                }
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
