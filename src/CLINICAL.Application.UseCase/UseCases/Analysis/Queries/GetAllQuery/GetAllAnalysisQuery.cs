using CLINICAL.Application.Dtos.Analysis.Response;
using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Queries.GetAllQuery
{
    public class GetAllAnalysisQuery : IRequest<BasePaginationResponse<IEnumerable<GetALLAnalysisResponseDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
