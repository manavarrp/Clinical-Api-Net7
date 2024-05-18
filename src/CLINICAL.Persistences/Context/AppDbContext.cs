using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace CLINICAL.Persistences.Context
{
    public class AppDbContext 
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("ClinicalConnection")!;
        }

        public IDbConnection CreateConnection => new SqlConnection(_connectionString);
    }
}
