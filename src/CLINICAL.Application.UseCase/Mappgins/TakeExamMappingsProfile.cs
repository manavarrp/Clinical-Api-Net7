using AutoMapper;
using CLINICAL.Application.Dtos.TakeExam.response;
using CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.Mappgins
{
    public class TakeExamMappingsProfile : Profile
    {
        public TakeExamMappingsProfile()
        {
            CreateMap<TakeExam, GetTakeExamByIdResponseDto>()
                .ReverseMap();

           CreateMap<TakeExamDetail, GetTakeExamDetailByTakeExamIdResponseDto>()
                .ReverseMap();
            
        }
    }
}
