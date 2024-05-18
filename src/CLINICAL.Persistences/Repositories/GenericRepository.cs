using CLINICAL.Application.Interfaces.Interfaces;
using CLINICAL.Persistences.Context;
using Dapper;
using System.Data;

namespace CLINICAL.Persistences.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync(string storedProcedure)
        {
            using var connection = _context.CreateConnection;
            return await connection.QueryAsync<T>(storedProcedure, commandType: CommandType.StoredProcedure);
        }

        public async Task<T> GetByIdAsync(string storedProcedure, object parameter)
        {
            using var connection = _context.CreateConnection;
            var objParam = new DynamicParameters(parameter);
            var response = await connection.QuerySingleOrDefaultAsync<T>(storedProcedure, param: objParam, commandType: CommandType.StoredProcedure);
            return response!;
        }


        public async Task<bool> ExecAsync(string storedProcedure, object parameters)
        {
            using var connection = _context.CreateConnection;
            var objParam = new DynamicParameters(parameters);
            var recordsAffected = await connection.ExecuteAsync(storedProcedure, param: objParam, commandType: CommandType.StoredProcedure);
            return recordsAffected > 0;
        }

        public async Task<IEnumerable<T>> GetAllWithPaginationAsync(string storedProcedure, object parameter)
        {
            using var connection = _context.CreateConnection;
            var objParam = new DynamicParameters(parameter);
            return await connection.QueryAsync<T>(storedProcedure, param: objParam, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> CountAsync(string tableName)
        {
            using var connection = _context.CreateConnection;
            var query = $"SELECT COUNT(1) FROM {tableName}";

            var count = await connection.ExecuteScalarAsync<int>(query);
            return count;
        }
    }
}
