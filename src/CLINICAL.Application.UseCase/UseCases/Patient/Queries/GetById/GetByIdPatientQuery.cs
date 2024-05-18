using CLINICAL.Application.Dtos.Patient.Response;
using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Patient.Queries.GetById
{
    public class GetByIdPatientQuery : IRequest<BaseReponse<GetPatientByIdResponseDto>>
    {
        public int PatientId { get; set; }
    }
}
