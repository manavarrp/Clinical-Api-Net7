using AutoMapper;
using CLINICAL.Application.Dtos.Medic.Response;
using CLINICAL.Application.UseCase.UseCases.Medic.Commands.CreateCommand;
using CLINICAL.Application.UseCase.UseCases.Medic.Commands.UpdateCommand;
using CLINICAL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Application.UseCase.Mappgins
{
    public class MedicMappingsProfile : Profile
    {
        public MedicMappingsProfile()
        {
            CreateMap<Medic, GetAllMedicResponseDto>()
                .ReverseMap();

            CreateMap<Medic, GetMedicByIdResponseDto>()
                .ReverseMap();

            CreateMap<CreateMedicCommand, Medic>();

            CreateMap<UpdateMedicCommand, Medic>();
        }
    }
}
