namespace CLINICAL.Application.Dtos.TakeExam.response
{
    public class GetTakeExamByIdResponseDto
    {
        public int TakeExamId { get; set; }
        public int PatientId { get; set; }
        public int MedicId { get; set; }
        public IEnumerable<GetTakeExamDetailByTakeExamIdResponseDto>? TakeExamDetails { get; set; }
    }
}
