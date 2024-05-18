using CLINICAL.Application.Dtos.Exam.Response;
using CLINICAL.Domain.Entities;

namespace CLINICAL.Application.Interfaces.Interfaces
{
    public interface IExamRepository : IGenericRepository<Exam>
    {
        Task<IEnumerable<GetAllExamResponseDto>> GetAllExams(string storedProcedure);
    }
}
