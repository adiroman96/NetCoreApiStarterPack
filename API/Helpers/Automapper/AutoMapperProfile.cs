using API.Dtos.MedicalInformation;
using AutoMapper;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers.Automapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // mapparea automata a tuturor proprietatiilor lui MedInfo in DTO, acolo unde numele si tipul proprietatilor se potrivesc
            CreateMap<MedicalInformation, MedicalInformationDto>();

            // mapparea automata a tuturor proprietatiilor lui DTO in MedInfo, acolo unde numele si tipul proprietatilor se potrivesc
            // Conditie:: se mappeaza doar daca proprietatea sursa != null
            CreateMap<MedicalInformationDto, MedicalInformation>()
               .ForAllMembers(opts => opts.Condition(
                   (src, dest, srcMember) => srcMember != null
                   ));
        }
    }
}
