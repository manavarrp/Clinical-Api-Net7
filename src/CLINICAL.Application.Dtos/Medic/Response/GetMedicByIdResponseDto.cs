namespace CLINICAL.Application.Dtos.Medic.Response
{
    public class GetMedicByIdResponseDto
    {
        public int MedicId { get; set; }
        public string? Names { get; set; }
        public string? LastName { get; set; }
        public string? MotherMaidenName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? BirthDate { get; set; }
        public int DocumentTypesId { get; set; }
        public string? DocumentNumber { get; set; }
        public int SpecialityId { get; set; }
        public int State { get; set; }
        public DateTime? AuditCreateDate { get; set; }
    }
}
