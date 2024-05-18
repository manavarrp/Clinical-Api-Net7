using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Medic.Commands.DeleteCommand
{
    public class DeleteMedicCommand : IRequest<BaseReponse<bool>>
    {
        public int MedicId { get; set; }    
    }
}
