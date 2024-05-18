using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Commands.EditCommand
{
    public class EditAnalysisCommand : IRequest<BaseReponse<bool>>
    {
        public int AnalysisId { get; set; }
        public string? Name { get; set; }
        public int State { get; set; }
    }
}
