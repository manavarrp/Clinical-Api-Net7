namespace CLINICAL.Application.Dtos.Patient.Response
{
    public class GetPatientByIdResponseDto
    {
        public int PatientId { get; set; }
        public string? Names { get; set; }
        public string? LastName { get; set; }
        public string? MotherMaidenName { get; set; }
        public int DocumentTypesId { get; set; }
        public string? DocumentNumber { get; set; }
        public string? Phone { get; set; }
        public int TypeAgesId { get; set; }
        public string? Age { get; set; }
        public int GendersId { get; set; }
    }
}
