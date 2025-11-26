using Blog.API.Data;
using Blog.API.Models;
using Blog.API.Models.DTOs;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace Blog.API.Repositories
{
    public class CategoryRepository
    {
        private readonly SqlConnection _connection;

        public CategoryRepository(ConnectionDB connection) 
        {
            _connection = connection.GetConnection();
        }

            public async Task<List<CategoryResponseDTO>> GetAllCategoriesAsync()
            {
            var sql = "SELECT Name , Slug  FROM Category";
            
               //await _connection.OpenAsync();

                //var categories = (await _connection.QueryAsync<CategoryResponseDTO>(sql)).ToList();

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
                 return (await _connection.QueryAsync<CategoryResponseDTO>(sql)).ToList();
            
            }

        public async Task CreateCategoryAsync(Category category)
        {
            var sql = "INSERT INTO Category (Name, Slug) VALUES (@Name, @Slug)";  
            
                //await _connection.OpenAsync();
                await _connection.ExecuteAsync(sql, new {category.Name, category.Slug });
        }
    }
}
