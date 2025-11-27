using Blog.API.Data;
using Blog.API.Models;
using Blog.API.Models.DTOs;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.API.Repositories
{
    public class RoleRepository
    {
        private readonly SqlConnection _connection;

        public RoleRepository(ConnectionDB connection)
        {
            _connection = connection.GetConnection();
        }

        public async Task<List<RoleResponseDTO>> GetAllRolesAsync()
        {
            var sql = "SELECT Name , Slug  FROM Role";

            return (await _connection.QueryAsync<RoleResponseDTO>(sql)).ToList();
        }

        public async Task CreateRoleAsync(Role role)
        {
            var sql = "INSERT INTO Role (Name, Slug) VALUES (@Name, @Slug)";

            await _connection.ExecuteAsync(sql, new { role.Name, role.Slug });
        }

        public async Task<RoleResponseDTO> GetRoleIdAsync(int id)
        {
            var sql = "SELECT Name, Slug FROM Role WHERE Id = @Id";

            return await _connection.QueryFirstOrDefaultAsync<RoleResponseDTO> (sql, new { id });
        }

        public async Task UpdateRoleAsync(int id, Role role)
        {
            var sql = @"UPDATE Role SET Name = @Name, Slug = @Slug WHERE Id = @Id";

            await _connection.ExecuteAsync(sql, new { Id = id, role.Name, role.Slug });
        }

        public async Task DeleteRoleAsync(int id)
        {
            var sql = "DELETE FROM Role WHERE Id = @Id";

            await _connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
