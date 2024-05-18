using CLINICAL.Application.Dtos.TakeExam.response;
using CLINICAL.Application.Interfaces.Interfaces;
using CLINICAL.Domain.Entities;
using CLINICAL.Persistences.Context;
using Dapper;
using System.Data;

namespace CLINICAL.Persistences.Repositories
{
    public class TakeExamRepository : GenericRepository<TakeExam>, ITakeExamRepository
    {
        private readonly AppDbContext _context;

        public TakeExamRepository(AppDbContext context): base(context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllTakeExamResponseDto>> GetAllTakeExamList(string storedProcedure, object parameter)
        {
            using var connection = _context.CreateConnection;
            var objParam = new DynamicParameters(parameter);
            var takExams = await connection.QueryAsync<GetAllTakeExamResponseDto>(storedProcedure, param: objParam, commandType: CommandType.StoredProcedure);
            return takExams;
        }

        public async Task<TakeExam> TakeExamById(int takeExamId)
        {
            var connection = _context.CreateConnection;
            var sql = @"SELECT TakeExamId, PatientId, MedicId FROM TakeExam WHERE TakeExamId= @TakeExamId";
            var parameters = new DynamicParameters();
            parameters.Add("TakeExamId", takeExamId);
            
            var takeExam = await connection.QuerySingleOrDefaultAsync<TakeExam>(sql, param: parameters);
            return takeExam!;
        }

        public async Task<IEnumerable<TakeExamDetail>> TakeExamDetailByTakeExamId(int takeExamId)
        {
            var connection = _context.CreateConnection;
            var sql = @"SELECT TakeExamDetailId, TakeExamId, ExamId, AnalysisId FROM TakeExamDetail WHERE TakeExamId= @TakeExamId";
            var parameters = new DynamicParameters();
            parameters.Add("TakeExamId", takeExamId);

            var takeExamDetail = await connection.QueryAsync<TakeExamDetail>(sql, param: parameters);
            return takeExamDetail;
        }
    }
}
