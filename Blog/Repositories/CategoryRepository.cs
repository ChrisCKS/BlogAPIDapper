using Blog.API.Data;
using Blog.API.Models;
using Blog.API.Models.DTOs;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.API.Repositories
{
    //Camada de acesso ao banco
    //Consulta e altera o banco de dados
    public class CategoryRepository
    {
        private readonly SqlConnection _connection;

        //O Controller -> Service -> Repository injetam o ConnectionDB
        //O repository chama GetConnection() e pega a SqlConnection
       // Essa conexão é usada para executar comandos SQL
        public CategoryRepository(ConnectionDB connection) 
        {
            _connection = connection.GetConnection();
        }

        //Retorna uma lista de CategoryResponseDTO, que é usada para responder ao usuário
        public async Task<List<CategoryResponseDTO>> GetAllCategoriesAsync()
        {
          var sql = "SELECT Name , Slug  FROM Category"; 
               
          return (await _connection.QueryAsync<CategoryResponseDTO>(sql)).ToList();
            //QueryAsync<>()-> roda a query e mapeia cada linha para um objeto do tipo CategoryResponseDTO
        }


        public async Task CreateCategoryAsync(Category category)
        {
          var sql = "INSERT INTO Category (Name, Slug) VALUES (@Name, @Slug)";  
            
          await _connection.ExecuteAsync(sql, new {category.Name, category.Slug });
            //subs @Name por category.Name e Slug por category.Slug
            //esse objeto anonimo cria automaticamente os parametros
        }

        //buscando a categoria pelo Id
        public async Task<CategoryResponseDTO> GetCategoryIdAsync(int id)
        {
            var sql = "SELECT Name, Slug FROM  Category WHERE Id = @Id";

            return await _connection.QueryFirstOrDefaultAsync<CategoryResponseDTO>(sql, new {id});
        }

        public async Task UpdateCategoryAsync(int id, Category category) 
        {
            var sql = @"UPDATE Category SET Name = @Name, Slug = @Slug WHERE Id = @Id";

            await _connection.ExecuteAsync(sql, new { Id = id, category.Name, category.Slug});
        }

        public async Task DeleteCategoryAsync(int id) 
        {
            var sql = "DELETE FROM Category WHERE Id = @Id";

            await _connection.ExecuteAsync(sql, new {Id = id});
        }
    }
}


//USANDO ADO.NET

/*var reader = await _connection.ExecuteReaderAsync(sql);

while (reader.Read())
{
    var category = new Category(
        reader["Name"].ToString(),
        reader["Slug"].ToString()
    );
    categories.Add(category);
}*/
