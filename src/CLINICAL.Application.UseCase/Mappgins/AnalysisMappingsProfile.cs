using AutoMapper;
using CLINICAL.Application.Dtos.Analysis.Response;
using CLINICAL.Application.UseCase.UseCases.Analysis.Commands.ChangeStateCommand;
using CLINICAL.Application.UseCase.UseCases.Analysis.Commands.CreateCommand;
using CLINICAL.Application.UseCase.UseCases.Analysis.Commands.EditCommand;
using CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.Mappgins
{
    internal class AnalysisMappingsProfile : Profile
    {
        public AnalysisMappingsProfile()
        {
            CreateMap<Analysis, GetALLAnalysisResponseDto>()
                .ForMember(x => x.StateAnalysis, x => x.MapFrom(y => y.State == 1 ? "Activo" : "Inactivo"))
                .ReverseMap();

            CreateMap<Analysis, GetAnalysisByIdResponseDto>()
                .ReverseMap();

            CreateMap<CreateAnalysisCommand, Analysis>();

            CreateMap<EditAnalysisCommand, Analysis>();

            CreateMap<ChangeStateAnalysisCommand, Analysis>();
        }
    }
}
