using Entidades.Exceptions;
using Entidades.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Services
{
    /// <summary>
    /// Clase mediadora entre la clase de Fabrica y todas las operaciones vinculadas al CRUD de Producto
    /// </summary>
    public class ProductoService : ICRUDService<Producto>
    {
        private IRepository<Torre> torresRepo;
        private IRepository<Estante> estantesRepo;
        private IRepository<Madera> maderaRepo;
        private IRepository<Tela> telasRepo;


        /// <summary>
        /// Constructor que incializa la conexion a base de datos de todos los repositorios
        /// </summary>
        public ProductoService(string connectionStr)
        {
            this.torresRepo = new RepositoryTorreSQL(connectionStr,"Torre");
            this.estantesRepo = new RepositoryEstanteSQL(connectionStr,"Estante");
            this.maderaRepo = new RepositoryMaderaSQL(connectionStr, "MaderaProducto");
            this.telasRepo = new RepositoryTelaSQL(connectionStr, "TelaProducto");

        }
        /// <summary>
        /// Da de alta en el repositorio un Producto
        /// </summary>
        /// <param name="lista"></param>
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
   
            }
            catch (Exception e)
            {
                throw new SQLEntityException($"Error al persistir el objeto {producto.Mostrar()}");
            }
        }
        /// <summary>
        /// Da de alta en el repositorio un listado de Productos
        /// </summary>
        /// <param name="lista"></param>
        public void CreateEntity(List<Producto> listaProductos)
        {
            if (listaProductos != null && listaProductos.Count > 0)
            {
                foreach (Producto producto in listaProductos)
                {
                    this.CreateEntity(producto);
                }
         
            }
        }
        /// <summary>
        /// Obtiene el valor mas alto del campo Id
        /// </summary>
        /// <param name="tipoInsumo"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Elimina del repositorio un objeto del tipo Producto
        /// </summary>
        /// <param name="entity"></param>
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
       
            }
            catch (Exception e)
            {
                throw new SQLEntityException($"Error al persistir el objeto {producto.Mostrar()}");
            }
        }
        /// <summary>
        /// Obtiene dle repositorio un Producto filtrando por id
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Actualiza en el repositorio un Producto
        /// </summary>
        /// <param name="entity"></param>
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
        
            }
            catch (Exception e)
            {
                throw new SQLEntityException($"Error al actualizar el objeto {producto.Mostrar()}");
            }
        }
        /// <summary>
        /// Obtiene todos los productos del repositorio
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Obtiene todos los productos filtrando por estado
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Obtiene todos los productos de la linea de produccion
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Elimina todos los insumos del repositorio
        /// </summary>
        public void DeleteAll()
        {
            try
            {
                ((RepositoryTorreSQL)torresRepo).DeleteAll();
                ((RepositoryEstanteSQL)estantesRepo).DeleteAll();
                ((RepositoryMaderaSQL)maderaRepo).DeleteAll();
                ((RepositoryTelaSQL)telasRepo).DeleteAll();
    
            }
            catch(Exception e)
            {
                throw new SQLEntityException("Error al eliminar los productos cargados");
            }

        }

        

    }

    public enum ETipoProductoConsulta
    {
        Torre,
        Estante
    }
}
