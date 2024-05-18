using CLINICAL.Application.Dtos.Exam.Response;
using CLINICAL.Application.Interfaces.Interfaces;
using CLINICAL.Domain.Entities;
using CLINICAL.Persistences.Context;
using Dapper;
using System.Data;

namespace CLINICAL.Persistences.Repositories
{
    public class ExamRepository : GenericRepository<Exam>, IExamRepository
    {
        private readonly AppDbContext _appDbContext;

        public ExamRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<GetAllExamResponseDto>> GetAllExams(string storedProcedure)
        {
            using var connnection = _appDbContext.CreateConnection;

            var exams = await connnection.QueryAsync<GetAllExamResponseDto>(storedProcedure, commandType: CommandType.StoredProcedure);
            return exams;
        }
    }
}
