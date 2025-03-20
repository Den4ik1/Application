using Application.ViewModels;
using AutoMapper;
using DomeinService.Models;

namespace Application.Mappers
{
    public class ViewMapping : Profile
    {
        public ViewMapping()
        {
            CreateMap<TreeModel, TreeViewModel>().ReverseMap();
            CreateMap<JournalModel, SingleViewModel>().ReverseMap();
        }
    }
}
