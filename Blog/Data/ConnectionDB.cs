using Microsoft.Data.SqlClient;

namespace Blog.API.Data
{
    public class ConnectionDB
    {
        private readonly string _connectionString;
        public ConnectionDB(IConfiguration configuration)   // injetando a configuração do appsettings.json
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection"); // pegando a string de conexão
        }
        public SqlConnection GetConnection()        // método para obter a conexão
        {
            return new SqlConnection(_connectionString);    // retornando a conexão
        }
    }
}
