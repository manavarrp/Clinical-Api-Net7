using AutoMapper;
using CLINICAL.Application.Dtos.Exam.Response;
using CLINICAL.Application.UseCase.UseCases.Exam.Commands.CreateCommand;
using CLINICAL.Application.UseCase.UseCases.Exam.Commands.UpdateCommand;
using CLINICAL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Application.UseCase.Mappgins
{
    internal class ExamMappingsProfile : Profile
    {
        public ExamMappingsProfile()
        {
            CreateMap<Exam, GetAllExamResponseDto>()
                .ReverseMap();

            CreateMap<Exam, GetExamByIdResponseDto>()
                .ReverseMap();

            CreateMap<CreateExamCommand, Exam>();

            CreateMap<UpdateExamCommand, Exam>();
        }
    }
}
