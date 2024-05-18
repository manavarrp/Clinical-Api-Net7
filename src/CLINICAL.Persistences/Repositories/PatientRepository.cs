using CLINICAL.Application.Dtos.Patient.Response;
using CLINICAL.Application.Interfaces.Interfaces;
using CLINICAL.Domain.Entities;
using CLINICAL.Persistences.Context;
using Dapper;
using System.Data;

namespace CLINICAL.Persistences.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        private readonly AppDbContext _appDbContext;

        public PatientRepository(AppDbContext appDbContext) : base(appDbContext) 
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<GetAllPatientResponseDto>> GetAllPatients(string storedProcedure)
        {
            using var connection = _appDbContext.CreateConnection;

            var patients = await connection.QueryAsync<GetAllPatientResponseDto>(storedProcedure, commandType: CommandType.StoredProcedure);
            return patients;



        }
    }
}
