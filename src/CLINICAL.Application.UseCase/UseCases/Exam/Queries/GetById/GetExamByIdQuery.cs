using CLINICAL.Application.Dtos.Exam.Response;
using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Exam.Queries.GetById
{
    public class GetExamByIdQuery : IRequest< BaseReponse<GetExamByIdResponseDto>>
    {
        public int ExamId { get; set; }
    }
}
