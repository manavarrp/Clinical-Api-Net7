using CLINICAL.Application.Dtos.Medic.Response;
using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Medic.Queries.GetById
{
    public class GetByIdMedicQuery : IRequest<BaseReponse<GetMedicByIdResponseDto>>
    {
        public int MedicId { get; set; }
    }
}
