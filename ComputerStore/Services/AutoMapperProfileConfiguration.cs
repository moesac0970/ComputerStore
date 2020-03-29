using AutoMapper;
using ComputerStore.Lib.Dto;
using ComputerStore.Lib.Models;
using ComputerStore.Lib.Models.Parts;
using ComputerStore.Lib.Models.PartTypes.Enumerations;
using System.Linq;

namespace ComputerStore.Api.Services
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration() : this("MyProfile")
        {

        }

        public AutoMapperProfileConfiguration(string profileName) : base(profileName)
        {
            CreateMap<PcPart, PcPartBasic>()
                .ForMember(
                dest => dest.Name,
                opts => opts.MapFrom(src => $"{src.Name}"))
                .ForMember(
                dest => dest.ImageNames,
                opts => opts.MapFrom(src => src.Images.Select(i => i.FileName).ToList()))
                .ForMember(
                dest => dest.Type,
                opts => opts.MapFrom(src => ((PartType)src.Type).ToString()))
                .ForMember(
                dest => dest.Hot,
                opts => opts.MapFrom(src => DtoServices.NewOrNah(src.CreationDate))
                ).ReverseMap();

            CreateMap<Cpu, Cpu>()
                .ForMember(
                dest => dest.PcPart,
                opts => opts.MapFrom(src => src.PcPart.Id)
                );


        }


    }
}
