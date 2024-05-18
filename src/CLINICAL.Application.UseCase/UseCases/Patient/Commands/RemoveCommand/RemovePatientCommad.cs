using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Patient.Commands.RemoveCommand
{
    public class RemovePatientCommad : IRequest<BaseReponse<bool>>
    { 
        public int PatientId { get; set; }  
    }
}
