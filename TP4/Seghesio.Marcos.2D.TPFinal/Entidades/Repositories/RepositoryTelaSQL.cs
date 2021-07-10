using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Repositories
{
     /// <summary>
     /// Clase derivada que recibe la clase Torre como parámetro
     /// </summary>
    public class RepositoryTelaSQL : RepositoryBase<Tela>
    {
        // <summary>
        /// Unico contructor con parametros que configura la conexion y la tabla de referencia
        /// </summary>
        /// <param name="connectionStr"></param>
        /// <param name="table"></param>
        public RepositoryTelaSQL(string connectionString, string table)
        :base(connectionString,table)
        {
        }
        /// <summary>
        /// Insera en la BD un registro del tipo Tela
        /// </summary>
        /// <param name="entity"></param>
        public override void Create(Tela entity)
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

                    command.CommandText = $"INSERT INTO [{table}] ([cantidad], [fechaIngreso], [color], [tipoTela])" + "Values (@cantidad, @fechaIngreso, @color, @tipoTela)";
                    command.Parameters.AddWithValue("@cantidad", entity.Cantidad);
                    command.Parameters.AddWithValue("@fechaIngreso", entity.FechaIngreso);
                    command.Parameters.AddWithValue("@color", entity.Color);
                    command.Parameters.AddWithValue("@tipoTela", entity.TipoTela);
                    columnasAfectadas = command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        
        
        }
        /// <summary>
        /// Devuelve la cantidad de registros presente en la tabla
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

                    command.CommandText = $"SELECT COUNT(*) AS cuenta FROM {table};";

                    SqlDataReader dataReader = command.ExecuteReader();

                    if (dataReader.Read() == false)
                    {
                        throw new Exception("Customer no encontrada");
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
        /// Obtiene el maximo id presente en la tabla
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
        /// Obtiene todos los registros de la tabla
        /// </summary>
        /// <returns></returns>
        public override List<Tela> GetAll()
        {
            List<Tela> telas = new List<Tela>();

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
                    ETipoTela tipoTela = (ETipoTela)Enum.Parse(typeof(ETipoTela), dataReader["tipoTela"].ToString());
                    EColor color = (EColor)Enum.Parse(typeof(EColor), dataReader["color"].ToString());
                    Tela tela = new Tela(color, tipoTela, Convert.ToInt32(dataReader["cantidad"]), Convert.ToDateTime(dataReader["fechaIngreso"]));
                    tela.Id = Convert.ToInt32(dataReader["id"]);
                    telas.Add(tela);
                }
                dataReader.Close();
                connection.Close();

            }
            catch (Exception e)
            {
                throw new Exception();
            }
            return telas;
        }
        /// <summary>
        /// Obtiene un elemento del tipo Tela filtrando por Id
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public override Tela GetById(long entityId)
        {
            Tela tela = null;

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
            ETipoTela tipoTela = (ETipoTela)Enum.Parse(typeof(ETipoTela), dataReader["tipoTela"].ToString());
            EColor color = (EColor)Enum.Parse(typeof(EColor), dataReader["color"].ToString());
            tela = new Tela(color, tipoTela, Convert.ToInt32(dataReader["cantidad"]), Convert.ToDateTime(dataReader["fechaIngreso"]));

            
            tela.Id = Convert.ToInt32(dataReader["id"]);
            dataReader.Close();
            connection.Close();
            return tela;
        }
        /// <summary>
        /// Elimina un registro de la tabla
        /// </summary>
        /// <param name="entity"></param>
        public override void Remove(Tela entity)
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
        /// Actualiza un registro de la tabla
        /// </summary>
        /// <param name="entity"></param>
        public override void Update(Tela entity)
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

                    command.CommandText = $"UPDATE [{table}] SET cantidad = @cantidad, fechaIngreso = @fechaIngreso, color = @color, tipoTela = @tipoTela WHERE Id = @id";

                    command.Parameters.AddWithValue("@cantidad", entity.Cantidad);
                    command.Parameters.AddWithValue("@fechaIngreso", entity.FechaIngreso);
                    command.Parameters.AddWithValue("@color", entity.Color);
                    command.Parameters.AddWithValue("@tipoTela", entity.TipoTela);
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
