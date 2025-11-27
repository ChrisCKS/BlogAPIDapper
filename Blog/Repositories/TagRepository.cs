using Blog.API.Data;
using Blog.API.Models;
using Blog.API.Models.DTOs;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.API.Repositories
{
    public class TagRepository
    {
        private readonly SqlConnection _connection;

        public TagRepository(ConnectionDB connection)
        {
            _connection = connection.GetConnection();
        }

        public async Task<List<TagResponseDTO>> GetAllTagsAsync()
        {
            var sql = "SELECT Name , Slug  FROM Tag";

            return (await _connection.QueryAsync<TagResponseDTO>(sql)).ToList();
        }

        public async Task CreateTagAsync(Tag tag)
        {
            var sql = "INSERT INTO Tag (Name, Slug) VALUES (@Name, @Slug)";

            await _connection.ExecuteAsync(sql, new { tag.Name, tag.Slug });
        }

        public async Task<TagResponseDTO> GetTagIdAsync(int id)
        {
            var sql = "SELECT Name, Slug FROM Tag WHERE Id = @Id";

            return await _connection.QueryFirstOrDefaultAsync<TagResponseDTO>(sql, new { id });
        }

        public async Task UpdateTagAsync(int id, Tag tag)
        {
            var sql = @"UPDATE Tag SET Name = @Name, Slug = @Slug WHERE Id = @Id";

            await _connection.ExecuteAsync(sql, new { Id = id, tag.Name, tag.Slug });
        }

        public async Task DeleteTagAsync(int id)
        {
            var sql = "DELETE FROM Tag WHERE Id = @Id";

            await _connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
