using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Commands.CreateCommand
{
    public class CreateAnalysisCommand : IRequest<BaseReponse<bool>>
    {
        public string? Name { get; set; }
    }
}
