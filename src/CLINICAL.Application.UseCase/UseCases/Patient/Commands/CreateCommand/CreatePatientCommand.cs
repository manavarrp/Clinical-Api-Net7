using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Patient.Commands.CreateCommand
{
    public class CreatePatientCommand : IRequest<BaseReponse<bool>>
    {
        public string? Names { get; set; }
        public string? LastName {  get; set; }
        public string? MotherMaidenName {  get; set; }
        public int DocumentTypesId {  get; set; }
        public string? DocumentNumber {  get; set; }
        public string? Phone {  get; set; }
        public int TypeAgesId {  get; set; }
        public int Age {  get; set; }
        public int GendersId {  get; set; }
    }
}
