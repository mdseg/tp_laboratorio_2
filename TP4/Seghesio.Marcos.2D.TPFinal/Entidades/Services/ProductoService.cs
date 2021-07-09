using Entidades.Exceptions;
using Entidades.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Services
{
    public delegate void ProductoModificado();

    public class ProductoService
    {
        private IRepository<Torre> torresRepo;
        private IRepository<Estante> estantesRepo;
        private IRepository<Madera> maderaRepo;
        private IRepository<Tela> telasRepo;

        public event ProductoModificado avisoProducto;
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

        public ProductoService(string connectionStr)
        {
            this.torresRepo = new RepositoryTorreSQL(connectionStr,"Torre");
            this.estantesRepo = new RepositoryEstanteSQL(connectionStr,"Estante");
            this.maderaRepo = new RepositoryMaderaSQL(connectionStr, "MaderaProducto");
            this.telasRepo = new RepositoryTelaSQL(connectionStr, "TelaProducto");
            this.LanzarEvento = true;
        }

        public void CreateEntity(Producto producto)
        {
            try
            {
                if (producto is Torre)
                {
                    torresRepo.Create((Torre)producto);
                }               
                else
                {
                    estantesRepo.Create((Estante)producto);
                }
                EmitirEvento();
            }
            catch (Exception e)
            {
                throw new SQLEntityException($"Error al persistir el objeto {producto.Mostrar()}");
            }
        }

        public void CreateEntity(List<Producto> listaProductos)
        {
            if (listaProductos != null && listaProductos.Count > 0)
            {
                foreach (Producto producto in listaProductos)
                {
                    this.CreateEntity(producto);
                }
                EmitirEvento();
            }
        }

        public int GetMaxIdEntity(ETipoProductoConsulta tipoInsumo)
        {
            int output = 0;
            try
            {
                if(tipoInsumo == ETipoProductoConsulta.Torre)
                {
                    output = torresRepo.GetMaxId();
                }
                else
                {
                    output = estantesRepo.GetMaxId();
                }
            }
            catch (Exception e)
            {
                throw new SQLEntityException($"Error al realizar al consulta");
            }
            return output;
        }

        public void DeleteEntity(Producto producto)
        {
            try
            {
                if (producto is Torre)
                {
                    torresRepo.Remove((Torre)producto);
                }
                else
                {
                    estantesRepo.Create((Estante)producto);
                }
                EmitirEvento();
            }
            catch (Exception e)
            {
                throw new SQLEntityException($"Error al persistir el objeto {producto.Mostrar()}");
            }
        }

        public Producto GetEntityById(Producto producto)
        {
            Producto output = null;
            if (producto is Torre)
            {
                output = torresRepo.GetById(producto.Id);
            }
            else
            {
                output = estantesRepo.GetById(producto.Id);
            }
            return output;
        }

        public void UpdateEntity(Producto producto)
        {
            try
            {
                if (producto is Torre)
                {
                    torresRepo.Update((Torre)producto);
                }
                else
                {
                    estantesRepo.Update((Estante)producto);
                }
                EmitirEvento();
            }
            catch (Exception e)
            {
                throw new SQLEntityException($"Error al actualizar el objeto {producto.Mostrar()}");
            }
        }

        public List<Producto> GetAll()
        {
            List<Producto> listadoProducto = new List<Producto>();
            try
            {
                List<Producto> bufferTorres = Producto.ToListProducto(torresRepo.GetAll());
                List<Producto> bufferEstantes = Producto.ToListProducto(estantesRepo.GetAll());

                Producto.ConcatenarProductos(listadoProducto, bufferTorres);
                Producto.ConcatenarProductos(listadoProducto, bufferEstantes);

            }
            catch (Exception e)
            {
                throw new SQLEntityException("Error al recuperar el listado completo de Productos");
            }

            return listadoProducto;
        }

        public List<Producto> GetAllByEstado(EEstado estado)
        {
            List<Producto> listadoProducto = new List<Producto>();
            try
            {

                List<Producto> bufferTorres = Producto.ToListProducto(((RepositoryTorreSQL)torresRepo).GetAllByEstado(estado));
                List<Producto> bufferEstantes = Producto.ToListProducto(((RepositoryEstanteSQL)estantesRepo).GetAllByEstado(estado));

                Producto.ConcatenarProductos(listadoProducto, bufferTorres);
                Producto.ConcatenarProductos(listadoProducto, bufferEstantes);

            }
            catch (Exception e)
            {
                throw new SQLEntityException("Error al recuperar el listado completo de Productos");
            }

            return listadoProducto;
        }

        public List<Producto> GetAllProductosByEstado(EEstado estado)
        {
            List<Producto> listadoProducto = new List<Producto>();
            try
            {

                List<Producto> bufferTorres = Producto.ToListProducto(((RepositoryTorreSQL)torresRepo).GetAllByEstado(estado));
                List<Producto> bufferEstantes = Producto.ToListProducto(((RepositoryEstanteSQL)estantesRepo).GetAllByEstado(estado));

                Producto.ConcatenarProductos(listadoProducto, bufferTorres);
                Producto.ConcatenarProductos(listadoProducto, bufferEstantes);

            }
            catch (Exception e)
            {
                throw new SQLEntityException("Error al recuperar el listado completo de Productos");
            }

            return listadoProducto;
        }

        public List<Producto> GetAllProductosLineaProduccion()
        {
            List<Producto> listadoProducto = new List<Producto>();
            try
            {

                List<Producto> bufferTorres = Producto.ToListProducto(((RepositoryTorreSQL)torresRepo).GetAllByEstadoNotInCompletoAndDespachado());
                List<Producto> bufferEstantes = Producto.ToListProducto(((RepositoryEstanteSQL)estantesRepo).GetAllByEstadoNotInCompletoAndDespachado());

                Producto.ConcatenarProductos(listadoProducto, bufferTorres);
                Producto.ConcatenarProductos(listadoProducto, bufferEstantes);

            }
            catch (Exception e)
            {
                throw new SQLEntityException("Error al recuperar el listado completo de Productos terminados");
            }

            return listadoProducto;
        }

        public void DeleteAll()
        {
            try
            {
                ((RepositoryTorreSQL)torresRepo).DeleteAll();
                ((RepositoryEstanteSQL)estantesRepo).DeleteAll();
                ((RepositoryMaderaSQL)maderaRepo).DeleteAll();
                ((RepositoryTelaSQL)telasRepo).DeleteAll();
                EmitirEvento();
            }
            catch(Exception e)
            {
                throw new SQLEntityException("Error al eliminar los productos cargados");
            }

        }

        public void EmitirEvento()
        {
            if(LanzarEvento)
            {
                try
                {
                    this.avisoProducto.Invoke();
                }
                catch (Exception e)
                {

                }
            }
        }

    }

    public enum ETipoProductoConsulta
    {
        Torre,
        Estante
    }
}
