using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Repositories
{
    public class RepositoryTelaSQL : RepositoryBase<Tela>
    {

        public RepositoryTelaSQL(string connectionString)
        :base(connectionString)
        {

        }

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

                    command.CommandText = "INSERT INTO [Tela] ([cantidad], [fechaIngreso], [color], [tipoTela])" + "Values (@cantidad, @fechaIngreso, @color, @tipoTela)";
                    command.Parameters.AddWithValue("@cantidad", entity.Cantidad);
                    command.Parameters.AddWithValue("@fechaIngreso", entity.FechaIngreso);
                    command.Parameters.AddWithValue("@color", entity.Color);
                    command.Parameters.AddWithValue("@tipoTela", entity.TipoTela);
                    columnasAfectadas = command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {

            }
        }

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

                command.CommandText = string.Format("SELECT * FROM Tela");

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

            }
            return telas;
        }

        public override Tela GetById(long entityId)
        {
            Tela tela = null;

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;

            command.CommandText = string.Format($"SELECT * FROM Tela WHERE id = {entityId}");

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

        public override void Remove(Tela entity)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;

                command.CommandText = string.Format($"DELETE FROM Tela WHERE ID = {entity.Id}");

                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception e)
            {

            }

        }

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

                    command.CommandText = $"UPDATE [Tela] SET cantidad = @cantidad, fechaIngreso = @fechaIngreso, color = @color, tipoTela = @tipoTela WHERE Id = {entity.Id}";

                    command.Parameters.AddWithValue("@cantidad", entity.Cantidad);
                    command.Parameters.AddWithValue("@fechaIngreso", entity.FechaIngreso);
                    command.Parameters.AddWithValue("@color", entity.Color);
                    command.Parameters.AddWithValue("@tipoTela", entity.TipoTela);

                    columnasAfectadas = command.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {

            }
        }
    }
}
