using CLINICAL.Application.Dtos.Analysis.Response;
using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Queries.GetById
{
    public class GetAnalysisByIdQuery : IRequest<BaseReponse<GetAnalysisByIdResponseDto>>
    {
        public int AnalysisId {  get; set; }
    }
}
