using CLINICAL.Application.Dtos.TakeExam.response;
using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.TakeExam.Queries.GetById
{
    public class GetByIdTakeExamQuery : IRequest<BaseReponse<GetTakeExamByIdResponseDto>>
    {
        public int TakeExamId { get; set; } 
    }
}
