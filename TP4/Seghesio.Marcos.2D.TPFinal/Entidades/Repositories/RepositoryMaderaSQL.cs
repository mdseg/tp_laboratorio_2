using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Repositories
{
    public class RepositoryMaderaSQL : RepositoryBase<Madera>
    {

        public RepositoryMaderaSQL(string connectionString)
        :base(connectionString)
        {

        }

        public override void Create(Madera entity)
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

                    command.CommandText = "INSERT INTO [Madera] ([cantidad], [fechaIngreso], [estaLijada], [forma], [tipoMadera])" + "Values (@cantidad, @fechaIngreso, @estaLijada, @forma, @tipoMadera)";
                    command.Parameters.AddWithValue("@cantidad", entity.Cantidad);
                    command.Parameters.AddWithValue("@fechaIngreso", entity.FechaIngreso);
                    command.Parameters.AddWithValue("@estaLijada", entity.EstaLijada);
                    command.Parameters.AddWithValue("@forma", entity.Forma);
                    command.Parameters.AddWithValue("@tipoMadera", entity.TipoMadera);

                    columnasAfectadas = command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {

            }
        }

        public override List<Madera> GetAll()
        {
            List<Madera> maderas = new List<Madera>();

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);



                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;

                command.CommandText = string.Format("SELECT * FROM Madera");

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read() != false)
                {
                    ETipoMadera tipoMadera = (ETipoMadera)Enum.Parse(typeof(ETipoMadera), dataReader["tipoMadera"].ToString());
                    EForma forma = (EForma)Enum.Parse(typeof(EForma), dataReader["forma"].ToString());
                    Madera madera = new Madera(tipoMadera, forma, Convert.ToInt32(dataReader["cantidad"]), Convert.ToDateTime(dataReader["fechaIngreso"]));
                    madera.Id = Convert.ToInt32(dataReader["id"]);
                    maderas.Add(madera);
                }
                dataReader.Close();
                connection.Close();

            }
            catch (Exception e)
            {

            }
            return maderas;
        }

        public override Madera GetById(long entityId)
        {
            Madera madera = null;

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;

            command.CommandText = string.Format($"SELECT * FROM Madera WHERE id = {entityId}");

            SqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.Read() == false)
            {
                throw new Exception("Customer no encontrada");
            }
            ETipoMadera tipoMadera = (ETipoMadera)Enum.Parse(typeof(ETipoMadera), dataReader["tipoMadera"].ToString());
            EForma forma = (EForma)Enum.Parse(typeof(EForma), dataReader["forma"].ToString());
            madera = new Madera(tipoMadera, forma, Convert.ToInt32(dataReader["cantidad"]), Convert.ToDateTime(dataReader["fechaIngreso"]));

            
            madera.Id = Convert.ToInt32(dataReader["id"]);
            dataReader.Close();
            connection.Close();
            return madera;
        }

        public override void Remove(Madera entity)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;

                command.CommandText = string.Format($"DELETE FROM Madera WHERE ID = {entity.Id}");

                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception e)
            {

            }

        }

        public override void Update(Madera entity)
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

                    command.CommandText = $"UPDATE [Madera] SET cantidad = @cantidad, fechaIngreso = @fechaIngreso, estaLijada = @estaLijada, forma = @forma, tipoMadera = @tipoMadera WHERE Id = {entity.Id}";

                    command.Parameters.AddWithValue("@cantidad", entity.Cantidad);
                    command.Parameters.AddWithValue("@fechaIngreso", entity.FechaIngreso);
                    command.Parameters.AddWithValue("@estaLijada", entity.EstaLijada);
                    command.Parameters.AddWithValue("@forma", entity.Forma);
                    command.Parameters.AddWithValue("@tipoMadera", entity.TipoMadera);

                    columnasAfectadas = command.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {

            }
        }
    }
}
