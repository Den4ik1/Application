using AutoMapper;
using DomeinService.Models;
using Infrastructyre.DataModels;

namespace DomeinService.Mappers
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TreeDataModel, TreeModel>().ReverseMap();

            CreateMap<ExceptionModel, JornalExeptionDataModel>()
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Message))
                .ReverseMap();

            CreateMap<RangeFilterModel, JournalFilterDataModel>();

            CreateMap<JornalExeptionDataModel, JournalModel>();
        }
    }
}
