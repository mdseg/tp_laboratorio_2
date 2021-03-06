using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Torre;

namespace Entidades.Repositories
{    /// <summary>
     /// Clase derivada que recibe la clase Torre como parámetro
     /// </summary>
    public class RepositoryTorreSQL : RepositoryBase<Torre>
    {
        private RepositoryBase<Madera> maderasRepo;
        private RepositoryBase<Tela> telasRepo;

        /// <summary>
        /// Unico contructor con parametros que configura la conexion y la tabla de referencia inicializando los repositorios necesarios
        /// </summary>
        /// <param name="connectionStr"></param>
        /// <param name="table"></param>
        public RepositoryTorreSQL(string connectionStr,string table)
        : base(connectionStr,table)
        {
            this.maderasRepo = new RepositoryMaderaSQL(connectionStr,"MaderaProducto");
            this.telasRepo = new RepositoryTelaSQL(connectionStr, "TelaProducto");
        }

        public override void Create(Torre entity)
        {
            int columnasAfectadas = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    Madera bufferMaderaPrincipal = entity.MaderaPrincipal;
                    Madera bufferMaderaColumna = entity.MaderaColumna;
                    Tela bufferTelaPrincipal = entity.TelaProducto;


                    maderasRepo.Create(bufferMaderaPrincipal);
                    bufferMaderaPrincipal = maderasRepo.GetById(maderasRepo.GetMaxId());
                    maderasRepo.Create(bufferMaderaColumna);
                    bufferMaderaColumna = maderasRepo.GetById(maderasRepo.GetMaxId());
                    telasRepo.Create(bufferTelaPrincipal);
                    bufferTelaPrincipal = telasRepo.GetById(telasRepo.GetMaxId());

                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;

                    command.CommandText = $"INSERT INTO [{table}] ([estadoProducto], [idMaderaPrincipal], [idTelaProducto], [idMaderaColumna], [metrosYute], [modelo], [yuteInstalado])" + "Values (@estadoProducto, @idMaderaPrincipal, @idTelaProducto, @idMaderaColumna, @metrosYute, @modelo, @YuteInstalado)";
                    command.Parameters.AddWithValue("@estadoProducto", entity.EstadoProducto);
                    command.Parameters.AddWithValue("@idMaderaPrincipal", bufferMaderaPrincipal.Id);
                    command.Parameters.AddWithValue("@idTelaProducto", bufferTelaPrincipal.Id);
                    command.Parameters.AddWithValue("@idMaderaColumna", bufferMaderaColumna.Id);
                    command.Parameters.AddWithValue("@metrosYute", entity.MetrosYute);
                    command.Parameters.AddWithValue("@modelo", entity.Modelo);
                    command.Parameters.AddWithValue("@yuteInstalado", entity.YuteInstalado);
                    columnasAfectadas = command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }
        /// <summary>
        /// Obtiene todos los registros de la tabla Torre
        /// </summary>
        /// <returns></returns>
        public override List<Torre> GetAll()
        {
            List<Torre> torres = new List<Torre>();

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
                    Torre torre = new Torre();
                    torre.Id = Convert.ToInt32(dataReader["id"]);
                    torre.EstadoProducto = (EEstado)Enum.Parse(typeof(EEstado), dataReader["estadoProducto"].ToString());
                    torre.MaderaPrincipal = maderasRepo.GetById(Convert.ToInt32(dataReader["idMaderaPrincipal"]));
                    torre.TelaProducto = telasRepo.GetById(Convert.ToInt32(dataReader["idTelaProducto"]));
                    Madera madera = maderasRepo.GetById(Convert.ToInt32(dataReader["idMaderaColumna"]));
                    torre.MaderaColumna = madera;
                    torre.MetrosYute = Convert.ToInt32(dataReader["metrosYute"]);
                    torre.Modelo = (EModeloTorre)Enum.Parse(typeof(EModeloTorre), dataReader["modelo"].ToString());
                    torre.YuteInstalado = Convert.ToBoolean(dataReader["yuteInstalado"]);
                    torres.Add(torre);
                }
                dataReader.Close();
                connection.Close();

            }
            catch (Exception e)
            {
                throw new Exception();
            }
            return torres;
        }
        /// <summary>
        /// Obtiene un registro del tipo Torre filtrando por Id
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public override Torre GetById(long entityId)
        {
            Torre torre = new Torre();
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
                throw new Exception("Datos de la torre no encontrados");
            }

            torre.Id = Convert.ToInt32(dataReader["id"]);
            torre.EstadoProducto = (EEstado)Enum.Parse(typeof(EEstado), dataReader["estadoProducto"].ToString());
            torre.MaderaPrincipal = maderasRepo.GetById(Convert.ToInt32(dataReader["idMaderaPrincipal"]));
            torre.TelaProducto = telasRepo.GetById(Convert.ToInt32(dataReader["idTelaProducto"]));
            torre.MaderaColumna = maderasRepo.GetById(Convert.ToInt32(dataReader["idMaderaColumna"]));
            torre.MetrosYute = Convert.ToInt32(dataReader["metrosYute"]);
            torre.Modelo = (EModeloTorre)Enum.Parse(typeof(EModeloTorre), dataReader["modelo"].ToString());
            torre.YuteInstalado = Convert.ToBoolean(dataReader["yuteInstalado"]);
            dataReader.Close();
            connection.Close();
            return torre;
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
                    throw new Exception("Datos de la torre no encontrados");
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
        public override void Remove(Torre entity)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;

                maderasRepo.Remove(maderasRepo.GetById(entity.MaderaPrincipal.Id));
                maderasRepo.Remove(maderasRepo.GetById(entity.MaderaColumna.Id));
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
        public override void Update(Torre entity)
        {
            int columnasAfectadas = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    maderasRepo.Update(entity.MaderaPrincipal);
                    maderasRepo.Update(entity.MaderaColumna);
                    telasRepo.Update(entity.TelaProducto);


                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;



                    command.CommandText = $"UPDATE [{table}] SET estadoProducto = @estadoProducto, idMaderaPrincipal = @idMaderaPrincipal, idTelaProducto = @idTelaProducto, idMaderaColumna = @idMaderaColumna, metrosYute = @metrosYute, modelo = @modelo, yuteInstalado = @yuteInstalado WHERE Id = @id";
                    command.Parameters.AddWithValue("@estadoProducto", entity.EstadoProducto);
                    command.Parameters.AddWithValue("@idMaderaPrincipal", entity.MaderaPrincipal.Id);
                    command.Parameters.AddWithValue("@idTelaProducto", entity.TelaProducto.Id);
                    command.Parameters.AddWithValue("@idMaderaColumna", entity.MaderaColumna.Id);
                    command.Parameters.AddWithValue("@metrosYute", entity.MetrosYute);
                    command.Parameters.AddWithValue("@modelo", entity.Modelo);
                    command.Parameters.AddWithValue("@yuteInstalado", entity.YuteInstalado);
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
        /// Obtiene todos los registros que no esten en estado "Completo" o "Despachado"
        /// </summary>
        /// <returns></returns>
        public List<Torre> GetAllByEstadoNotInCompletoAndDespachado()
        {
            List<Torre> torres = new List<Torre>();

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);



                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;

                command.CommandText = string.Format($"SELECT * FROM {table} WHERE NOT [estadoProducto] BETWEEN 5 AND 6"); ;
                
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read() != false)
                {
                    Torre torre = new Torre();
                    torre.Id = Convert.ToInt32(dataReader["id"]);
                    torre.EstadoProducto = (EEstado)Enum.Parse(typeof(EEstado), dataReader["estadoProducto"].ToString());
                    torre.MaderaPrincipal = maderasRepo.GetById(Convert.ToInt32(dataReader["idMaderaPrincipal"]));
                    torre.TelaProducto = telasRepo.GetById(Convert.ToInt32(dataReader["idTelaProducto"]));
                    torre.MaderaColumna = maderasRepo.GetById(Convert.ToInt32(dataReader["idMaderaColumna"]));
                    torre.MetrosYute = Convert.ToInt32(dataReader["metrosYute"]);
                    torre.Modelo = (EModeloTorre)Enum.Parse(typeof(EModeloTorre), dataReader["modelo"].ToString());
                    torre.YuteInstalado = Convert.ToBoolean(dataReader["yuteInstalado"]);
                    torres.Add(torre);
                }
                dataReader.Close();
                connection.Close();

            }
            catch (Exception e)
            {
                throw new Exception();
            }
            return torres;
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

            }
        }
        /// <summary>
        /// Obtiene todos los registros de un Estado específico
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        public List<Torre> GetAllByEstado(EEstado estado)
        {
            List<Torre> torres = new List<Torre>();

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);



                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;

                command.CommandText = string.Format($"SELECT * FROM {table} WHERE estadoProducto = @estadoProducto");
                command.Parameters.AddWithValue("@estadoProducto", Convert.ToInt32(estado));

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read() != false)
                {
                    Torre torre = new Torre();
                    torre.Id = Convert.ToInt32(dataReader["id"]);
                    torre.EstadoProducto = (EEstado)Enum.Parse(typeof(EEstado), dataReader["estadoProducto"].ToString());
                    torre.MaderaPrincipal = maderasRepo.GetById(Convert.ToInt32(dataReader["idMaderaPrincipal"]));
                    torre.TelaProducto = telasRepo.GetById(Convert.ToInt32(dataReader["idTelaProducto"]));
                    torre.MaderaColumna = maderasRepo.GetById(Convert.ToInt32(dataReader["idMaderaColumna"]));
                    torre.MetrosYute = Convert.ToInt32(dataReader["metrosYute"]);
                    torre.Modelo = (EModeloTorre)Enum.Parse(typeof(EModeloTorre), dataReader["modelo"].ToString());
                    torre.YuteInstalado = Convert.ToBoolean(dataReader["yuteInstalado"]);
                    torres.Add(torre);
                }
                dataReader.Close();
                connection.Close();

            }
            catch (Exception e)
            {
                throw new Exception();
            }
            return torres;
        }


    }
}
