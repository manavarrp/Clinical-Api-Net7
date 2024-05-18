using CLINICAL.Application.Dtos.TakeExam.response;
using CLINICAL.Domain.Entities;

namespace CLINICAL.Application.Interfaces.Interfaces
{
    public interface ITakeExamRepository : IGenericRepository<TakeExam>
    {
        Task<IEnumerable<GetAllTakeExamResponseDto>> GetAllTakeExamList(string storedProcedure, object parameter);
        Task<TakeExam> TakeExamById(int takeExamId);
        Task<IEnumerable<TakeExamDetail>> TakeExamDetailByTakeExamId(int  takeExamId);

    }
}
