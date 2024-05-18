using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Medic.Commands.UpdateCommand
{
    public class UpdateMedicCommand : IRequest<BaseReponse<bool>>
    {
        public int MedicId { get; set; }
        public string? Names { get; set; }
        public string? LastName { get; set; }
        public string? MotherMaidenName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public int DocumentTypesId { get; set; }
        public string? DocumentNumber { get; set; }
        public int SpecialityId { get; set; }
        public int State { get; set; }
    }
}
