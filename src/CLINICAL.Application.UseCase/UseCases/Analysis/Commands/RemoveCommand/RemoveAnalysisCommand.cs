using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Commands.RemoveCommand
{
    public class RemoveAnalysisCommand : IRequest<BaseReponse<bool>>
    {
        public int AnalysisId { get; set; }
    }
}
