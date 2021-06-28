using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Repositories
{
    public class RepositoryInsumoAccesorioSQL : RepositoryBase<InsumoAccesorio>
    {

        public RepositoryInsumoAccesorioSQL(string connectionString)
        :base(connectionString)
        {

        }

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

                    command.CommandText = "INSERT INTO [InsumoAccesorio] ([cantidad], [fechaIngreso], [tipoAccesorio])" + "Values (@cantidad, @fechaIngreso, @tipoAccesorio)";
                    command.Parameters.AddWithValue("@cantidad", entity.Cantidad);
                    command.Parameters.AddWithValue("@fechaIngreso", entity.FechaIngreso);
                    command.Parameters.AddWithValue("@tipoAccesorio", entity.TipoAccesorio);
                    columnasAfectadas = command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {

            }
        }

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

                command.CommandText = string.Format("SELECT * FROM InsumoAccesorio");

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

            }
            return insumoAccesorios;
        }

        public override InsumoAccesorio GetById(long entityId)
        {
            InsumoAccesorio insumoAccesorio = null;

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;

            command.CommandText = string.Format($"SELECT * FROM InsumoAccesorio WHERE id = {entityId}");

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

        public override void Remove(InsumoAccesorio entity)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;

                command.CommandText = string.Format($"DELETE FROM InsumoAccesorio WHERE ID = {entity.Id}");

                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception e)
            {

            }

        }

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

                    command.CommandText = $"UPDATE [InsumoAccesorio] SET cantidad = @cantidad, fechaIngreso = @fechaIngreso, tipoAccesorio = @tipoAccesorio WHERE Id = {entity.Id}";

                    command.Parameters.AddWithValue("@cantidad", entity.Cantidad);
                    command.Parameters.AddWithValue("@fechaIngreso", entity.FechaIngreso);
                    command.Parameters.AddWithValue("@tipoAccesorio", entity.TipoAccesorio);

                    columnasAfectadas = command.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {

            }
        }
    }
}
