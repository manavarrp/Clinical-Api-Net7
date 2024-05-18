using AutoMapper;
using CLINICAL.Application.Dtos.Patient.Response;
using CLINICAL.Application.UseCase.UseCases.Patient.Commands.CreateCommand;
using CLINICAL.Application.UseCase.UseCases.Patient.Commands.UpdateCommand;
using CLINICAL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Application.UseCase.Mappgins
{
    public class PatientMappingsProfile : Profile
    {
        public PatientMappingsProfile()
        {
            CreateMap<Patient, GetAllPatientResponseDto>()
                .ForMember(x => x.StatePatient, x => x.MapFrom(y => y.State == 1 ? "Activo" : "Inactivo"))
                 .ForMember(dest => dest.Surnames, opt => opt.MapFrom(src => (src.LastName!.Trim() ?? "") + " " + (src.MotherMaidenName!.Trim() ?? "")))
                .ForMember(x => x.Gender, x => x.MapFrom(y => y.GendersId))
                .ReverseMap();

            CreateMap<Patient, GetPatientByIdResponseDto>()
                .ReverseMap();

            CreateMap<CreatePatientCommand, Patient>();

            CreateMap<UpdatePatientCommand, Patient>();
        }
    }
}
