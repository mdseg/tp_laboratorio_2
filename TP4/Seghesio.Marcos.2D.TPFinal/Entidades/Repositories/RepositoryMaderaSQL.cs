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

        public RepositoryMaderaSQL(string connectionString, string table)
        :base(connectionString,table)
        {
            this.table = table;
        }

        public override int Count()
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

                    command.CommandText = $"INSERT INTO [{table}] ([cantidad], [fechaIngreso], [estaLijada], [forma], [tipoMadera])" + "Values (@cantidad, @fechaIngreso, @estaLijada, @forma, @tipoMadera)";
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
                throw new Exception();
            }
        }

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

                command.CommandText = string.Format($"SELECT * FROM {table}");

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
                throw new Exception();
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

            command.CommandText = string.Format($"SELECT * FROM {table} WHERE id = @id");
            command.Parameters.AddWithValue("@id", entityId);
            SqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.Read() == false)
            {
                throw new Exception("Datos de insumo no encontrados");
            }
            ETipoMadera tipoMadera = (ETipoMadera)Enum.Parse(typeof(ETipoMadera), dataReader["tipoMadera"].ToString());
            EForma forma = (EForma)Enum.Parse(typeof(EForma), dataReader["forma"].ToString());
            madera = new Madera(tipoMadera, forma, Convert.ToInt32(dataReader["cantidad"]), Convert.ToDateTime(dataReader["fechaIngreso"]));

            
            madera.Id = Convert.ToInt32(dataReader["id"]);
            dataReader.Close();
            connection.Close();
            return madera;
        }

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
            catch(Exception e)
            {
                throw new Exception();
            }
            return id;
    
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

                command.CommandText = string.Format($"DELETE FROM {table} WHERE ID = @id");
                command.Parameters.AddWithValue("@id", entity.Id);
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

                    command.CommandText = $"UPDATE [{table}] SET cantidad = @cantidad, fechaIngreso = @fechaIngreso, estaLijada = @estaLijada, forma = @forma, tipoMadera = @tipoMadera WHERE Id = {entity.Id}";

                    command.Parameters.AddWithValue("@cantidad", entity.Cantidad);
                    command.Parameters.AddWithValue("@fechaIngreso", entity.FechaIngreso);
                    command.Parameters.AddWithValue("@estaLijada", entity.EstaLijada);
                    command.Parameters.AddWithValue("@forma", entity.Forma);
                    command.Parameters.AddWithValue("@tipoMadera", entity.TipoMadera);
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
