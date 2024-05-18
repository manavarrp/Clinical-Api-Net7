using CLINICAL.Application.Dtos.Medic.Response;
using CLINICAL.Application.Interfaces.Interfaces;
using CLINICAL.Domain.Entities;
using CLINICAL.Persistences.Context;
using Dapper;
using System.Data;

namespace CLINICAL.Persistences.Repositories
{
    public class MedicRepository : GenericRepository<Medic>, IMedicRepository
    {
        private readonly AppDbContext _appDbContext;

        public MedicRepository(AppDbContext appDbContext) : base(appDbContext) 
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<GetAllMedicResponseDto>> GetAllMedicList(string storedProcedure)
        {
            using var connection = _appDbContext.CreateConnection;
            var medics = await connection.QueryAsync<GetAllMedicResponseDto>(storedProcedure, commandType: CommandType.StoredProcedure);

            return medics;

        }
    }
}
