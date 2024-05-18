using CLINICAL.Application.Dtos.Exam.Response;
using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.TakeExam.Queries.GetAllQuery
{
    public class GetAllTakeExamQuery : IRequest<BasePaginationResponse<IEnumerable<GetAllExamResponseDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
