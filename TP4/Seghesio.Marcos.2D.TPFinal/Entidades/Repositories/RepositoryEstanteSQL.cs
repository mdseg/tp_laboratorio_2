using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Repositories
{
    /// <summary>
    /// Clase derivada que recibe la clase Estante como parámetro
    /// </summary>
    public class RepositoryEstanteSQL : RepositoryBase<Estante>
    {
        private RepositoryBase<Madera> maderasRepo;
        private RepositoryBase<Tela> telasRepo;

        /// <summary>
        /// Unico contructor con parametros que configura la conexion y la tabla de referencia inicializando los repositorios necesarios
        /// </summary>
        /// <param name="connectionStr"></param>
        /// <param name="table"></param>
        public RepositoryEstanteSQL(string connectionStr,string table)
        : base(connectionStr,table)
        {
            this.maderasRepo = new RepositoryMaderaSQL(connectionStr, "MaderaProducto");
            this.telasRepo = new RepositoryTelaSQL(connectionStr, "TelaProducto");
        }

        /// <summary>
        /// Inserta en la BD un Producto del tipo Estante
        /// </summary>
        /// <param name="entity"></param>
        public override void Create(Estante entity)
        {

            int columnasAfectadas = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    Madera bufferMaderaPrincipal = entity.MaderaPrincipal;
                    Tela bufferTelaPrincipal = entity.TelaProducto;

                    maderasRepo.Create(bufferMaderaPrincipal);
                    telasRepo.Create(bufferTelaPrincipal);

                    bufferMaderaPrincipal = maderasRepo.GetById(maderasRepo.GetMaxId());
                    bufferTelaPrincipal = telasRepo.GetById(telasRepo.GetMaxId());

                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;

                    command.CommandText = $"INSERT INTO [{table}] ([estadoProducto], [idMaderaProducto], [idTelaProducto], [cantidadEstantes])" + "Values (@estadoProducto, @idMaderaProducto, @idTelaProducto, @cantidadEstantes)";
                    command.Parameters.AddWithValue("@estadoProducto", entity.EstadoProducto);
                    command.Parameters.AddWithValue("@idMaderaProducto", bufferMaderaPrincipal.Id);
                    command.Parameters.AddWithValue("@idTelaProducto", bufferTelaPrincipal.Id);
                    command.Parameters.AddWithValue("@cantidadEstantes", entity.CantidadEstantes);
                    columnasAfectadas = command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Elimina todos los registros de la tabla de Estante
        /// </summary>
        public override void DeleteAll()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;

                command.CommandText = string.Format($"DELETE FROM {table}");

                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }
        /// <summary>
        /// Obtiene todos los registros de la tabla Estante
        /// </summary>
        /// <returns></returns>
        public override List<Estante> GetAll()
        {
            List<Estante> estantes = new List<Estante>();

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);



                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;

                command.CommandText = string.Format($"SELECT * FROM {table}");

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read() != false)
                {
                    Estante estante = new Estante();
                    estante.Id = Convert.ToInt32(dataReader["id"]);
                    estante.EstadoProducto = (EEstado)Enum.Parse(typeof(EEstado), dataReader["estadoProducto"].ToString());
                    estante.MaderaPrincipal = maderasRepo.GetById(Convert.ToInt32(dataReader["idMaderaProducto"]));
                    estante.TelaProducto = telasRepo.GetById(Convert.ToInt32(dataReader["idTelaProducto"]));
                    estante.CantidadEstantes = Convert.ToInt32(dataReader["cantidadEstantes"]);
                    estantes.Add(estante);
                }
                dataReader.Close();
                connection.Close();

            }
            catch (Exception e)
            {
                throw new Exception();
            }
            return estantes;
        }
        /// <summary>
        /// Obtiene todos los registros de un Estado específico
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        public List<Estante> GetAllByEstado(EEstado estado)
        {
            List<Estante> estantes = new List<Estante>();

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);



                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;

                int numero = Convert.ToInt32(estado);

                command.CommandText = string.Format($"SELECT * FROM {table} WHERE [estadoProducto] = @numero");
                command.Parameters.AddWithValue("@numero", numero);


                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read() != false)
                {
                    Estante estante = new Estante();
                    estante.Id = Convert.ToInt32(dataReader["id"]);
                    estante.EstadoProducto = (EEstado)Enum.Parse(typeof(EEstado), dataReader["estadoProducto"].ToString());
                    estante.MaderaPrincipal = maderasRepo.GetById(Convert.ToInt32(dataReader["idMaderaProducto"]));
                    estante.TelaProducto = telasRepo.GetById(Convert.ToInt32(dataReader["idTelaProducto"]));
                    estante.CantidadEstantes = Convert.ToInt32(dataReader["cantidadEstantes"]);
                    estantes.Add(estante);
                }
                dataReader.Close();
                connection.Close();

            }
            catch (Exception e)
            {
                throw new Exception();
            }
            return estantes;
        }
        /// <summary>
        /// Obtiene todos los registros que no esten en estado "Completo" o "Despachado"
        /// </summary>
        /// <returns></returns>
        public List<Estante> GetAllByEstadoNotInCompletoAndDespachado()
        {
            List<Estante> estantes = new List<Estante>();

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);



                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;


                command.CommandText = string.Format($"SELECT * FROM {table} WHERE NOT [estadoProducto] BETWEEN 5 AND 6");

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read() != false)
                {
                    Estante estante = new Estante();
                    estante.Id = Convert.ToInt32(dataReader["id"]);
                    estante.EstadoProducto = (EEstado)Enum.Parse(typeof(EEstado), dataReader["estadoProducto"].ToString());
                    estante.MaderaPrincipal = maderasRepo.GetById(Convert.ToInt32(dataReader["idMaderaProducto"]));
                    estante.TelaProducto = telasRepo.GetById(Convert.ToInt32(dataReader["idTelaProducto"]));
                    estante.CantidadEstantes = Convert.ToInt32(dataReader["cantidadEstantes"]);
                    estantes.Add(estante);
                }
                dataReader.Close();
                connection.Close();

            }
            catch (Exception e)
            {
                throw new Exception();
            }
            return estantes;
        }
        /// <summary>
        /// Obtiene un registro del tipo Estante filtrando por Id
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public override Estante GetById(long entityId)
        {
            Estante estante = new Estante();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;

            command.CommandText = string.Format($"SELECT * FROM {table} WHERE id = @numero");
            command.Parameters.AddWithValue("@numero", entityId);
            SqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.Read() == false)
            {
                throw new Exception("Datos de estante no encontrados");
            }
 
            estante.Id = Convert.ToInt32(dataReader["id"]);
            estante.EstadoProducto = (EEstado)Enum.Parse(typeof(EEstado), dataReader["estadoProducto"].ToString());
            estante.MaderaPrincipal = maderasRepo.GetById(Convert.ToInt32(dataReader["idMaderaProducto"]));
            estante.TelaProducto = telasRepo.GetById(Convert.ToInt32(dataReader["idTelaProducto"]));
            estante.CantidadEstantes = Convert.ToInt32(dataReader["cantidadEstantes"]);
            dataReader.Close();
            connection.Close();
            return estante;
        }
        /// <summary>
        /// Obtiene el mayor id presente en la tabla
        /// </summary>
        /// <returns></returns>
        public override int GetMaxId()
        {
            int id = 0;
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;
                command.CommandText = string.Format($"SELECT MAX(id) AS id FROM {table};");
                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read() == false)
                {
                    throw new Exception("Datos del estante no encontrados");
                }
                else
                {
                    id = Convert.ToInt32(dataReader["id"]);
                }
            }
            catch (Exception e)
            {
                throw new Exception();
            }
            return id;

        }
        /// <summary>
        /// elimina un registro de la tabla
        /// </summary>
        /// <param name="entity"></param>
        public override void Remove(Estante entity)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;

                maderasRepo.Remove(maderasRepo.GetById(entity.MaderaPrincipal.Id));
                telasRepo.Remove(telasRepo.GetById(entity.TelaProducto.Id));

                command.CommandText = string.Format($"DELETE FROM {table} WHERE ID = @id");
                command.Parameters.AddWithValue("@id", entity.Id);
                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }
        /// <summary>
        /// Actualiza un registro de la BD recibiendo un objeto
        /// </summary>
        /// <param name="entity"></param>
        public override void Update(Estante entity)
        {
            int columnasAfectadas = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    maderasRepo.Update(entity.MaderaPrincipal);
                    telasRepo.Update(entity.TelaProducto);

                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;


                    command.CommandText = $"UPDATE [{table}] SET estadoProducto = @estadoProducto, idMaderaProducto = @idMaderaProducto, idTelaProducto = @idTelaProducto, cantidadEstantes = @cantidadEstantes WHERE Id = @id";
                    command.Parameters.AddWithValue("@estadoProducto", entity.EstadoProducto);
                    command.Parameters.AddWithValue("@idMaderaProducto", entity.MaderaPrincipal.Id);
                    command.Parameters.AddWithValue("@idTelaProducto", entity.TelaProducto.Id);
                    command.Parameters.AddWithValue("@cantidadEstantes", entity.CantidadEstantes);
                    command.Parameters.AddWithValue("@id", entity.Id);
                    columnasAfectadas = command.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }


    }
}
