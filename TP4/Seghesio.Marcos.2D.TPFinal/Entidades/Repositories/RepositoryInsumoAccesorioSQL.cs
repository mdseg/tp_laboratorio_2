using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Repositories
{
     /// <summary>
     /// Clase derivada que recibe la clase InsumoAccesorio como parámetro
     /// </summary>
    public class RepositoryInsumoAccesorioSQL : RepositoryBase<InsumoAccesorio>
    {

        /// <summary>
        /// Unico contructor con parametros que configura la conexion y la tabla de referencia
        /// <param name="connectionStr"></param>
        /// <param name="table"></param>
        public RepositoryInsumoAccesorioSQL(string connectionString,string table)
        :base(connectionString,table)
        {

        }

        /// <summary>
        /// Inserta en la BD un Producto del tipo InsumoAccesorio
        /// </summary>
        /// <param name="entity"></param>
        public override void Create(InsumoAccesorio entity)
        {
            int columnasAfectadas = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    
                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;

                    command.CommandText = $"INSERT INTO [{table}] ([cantidad], [fechaIngreso], [tipoAccesorio])" + "Values (@cantidad, @fechaIngreso, @tipoAccesorio)";
                    command.Parameters.AddWithValue("@cantidad", entity.Cantidad);
                    command.Parameters.AddWithValue("@fechaIngreso", entity.FechaIngreso);
                    command.Parameters.AddWithValue("@tipoAccesorio", entity.TipoAccesorio);
                    columnasAfectadas = command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw new Exception();
            }
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
                    throw new Exception("Datos de insumo no encontrados");
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
        /// Obtiene todos los registros de la tabla Estante
        /// </summary>
        /// <returns></returns>
        public override List<InsumoAccesorio> GetAll()
        {
            List<InsumoAccesorio> insumoAccesorios = new List<InsumoAccesorio>();

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
                    ETipoAccesorio tipoAccesorio = (ETipoAccesorio)Enum.Parse(typeof(ETipoAccesorio), dataReader["tipoAccesorio"].ToString());
                    InsumoAccesorio insumoAccesorio = new InsumoAccesorio(tipoAccesorio, Convert.ToInt32(dataReader["cantidad"]), Convert.ToDateTime(dataReader["fechaIngreso"]));
                    insumoAccesorio.Id = Convert.ToInt32(dataReader["id"]);
                    insumoAccesorios.Add(insumoAccesorio);
                }
                dataReader.Close();
                connection.Close();

            }
            catch (Exception e)
            {
                throw new Exception();
            }
            return insumoAccesorios;
        }
        /// <summary>
        /// Obtiene un elemento del tipo InsumoAcceosrio filtrando por id
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public override InsumoAccesorio GetById(long entityId)
        {
            InsumoAccesorio insumoAccesorio = null;

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;

            command.CommandText = string.Format($"SELECT * FROM {table} WHERE id = @id");
            command.Parameters.AddWithValue("@id", entityId);

            SqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.Read() == false)
            {
                throw new Exception("Customer no encontrada");
            }
            ETipoAccesorio tipoAccesorio = (ETipoAccesorio)Enum.Parse(typeof(ETipoAccesorio), dataReader["tipoAccesorio"].ToString());
            insumoAccesorio = new InsumoAccesorio(tipoAccesorio, Convert.ToInt32(dataReader["cantidad"]), Convert.ToDateTime(dataReader["fechaIngreso"]));
            insumoAccesorio.Id = Convert.ToInt32(dataReader["id"]);

            dataReader.Close();
            connection.Close();
            return insumoAccesorio;
        }
        /// <summary>
        /// Elimina de la BD un registro
        /// </summary>
        /// <param name="entity"></param>
        public override void Remove(InsumoAccesorio entity)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;

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
        /// Actualiza un registro de la BD
        /// </summary>
        /// <param name="entity"></param>
        public override void Update(InsumoAccesorio entity)
        {
            int columnasAfectadas = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;

                    command.CommandText = $"UPDATE [InsumoAccesorio] SET cantidad = @cantidad, fechaIngreso = @fechaIngreso, tipoAccesorio = @tipoAccesorio WHERE Id = @id";

                    command.Parameters.AddWithValue("@cantidad", entity.Cantidad);
                    command.Parameters.AddWithValue("@fechaIngreso", entity.FechaIngreso);
                    command.Parameters.AddWithValue("@tipoAccesorio", entity.TipoAccesorio);
                    command.Parameters.AddWithValue("@id", entity.Id);

                    columnasAfectadas = command.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }
        /// <summary>
        /// Devuelve la cantidad de registros de la tabla
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            int output = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;

                    command.CommandText = $"SELECT COUNT(*) AS cuenta FROM InsumoAccesorio;";

                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read() == false)
                    {
                        throw new Exception("Error");
                    }
                    output = Convert.ToInt32(dataReader["cuenta"]);




                }
            }
            catch (Exception e)
            {
                throw new Exception();
            }
            return output;
        }
        /// <summary>
        /// Elimina todos los elementos de la tabla
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

                command.CommandText = string.Format($"DELETE FROM InsumoAccesorio");

                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }
        /// <summary>
        /// Suma todos los registros de un tipo específico recibido por parámetro
        /// </summary>
        /// <param name="tipoAccesorio"></param>
        /// <returns></returns>
        public int SumTipoInsumoAccesorio(ETipoAccesorio tipoAccesorio)
        {
            int output = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;

                    command.CommandText = $"SELECT COALESCE(SUM(cantidad),0) AS cuenta FROM InsumoAccesorio WHERE tipoAccesorio = @numero;";
                    command.Parameters.AddWithValue("@numero", Convert.ToInt32(tipoAccesorio));

                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read() == false)
                    {
                        throw new Exception("Error");
                    }
                    output = Convert.ToInt32(dataReader["cuenta"]);

                }
            }
            catch (Exception e)
            {
                throw new Exception();
            }
            return output;

        }
        /// <summary>
        /// Recibe un registro de la tabla filtrando por tipoDeAccesosrio
        /// </summary>
        /// <param name="tipoAccesorioInput"></param>
        /// <returns></returns>
        public InsumoAccesorio GetByTipoAccesorio(ETipoAccesorio tipoAccesorioInput)
        {
            InsumoAccesorio insumoAccesorio = null;

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;

            command.CommandText = string.Format($"SELECT * FROM InsumoAccesorio WHERE tipoAccesorio = @numero");
            command.Parameters.AddWithValue("@numero", Convert.ToInt32(tipoAccesorioInput));
            SqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.Read() == false)
            {
                throw new Exception("Insumo no encontrado");
            }
            ETipoAccesorio tipoAccesorio = (ETipoAccesorio)Enum.Parse(typeof(ETipoAccesorio), dataReader["tipoAccesorio"].ToString());
            insumoAccesorio = new InsumoAccesorio(tipoAccesorio, Convert.ToInt32(dataReader["cantidad"]), Convert.ToDateTime(dataReader["fechaIngreso"]));
            insumoAccesorio.Id = Convert.ToInt32(dataReader["id"]);

            dataReader.Close();
            connection.Close();
            return insumoAccesorio;
        }
    }
}
