using AutoMapper;
using NS.Application.Product.Queries;

namespace NS.Application.MapperProfiles;

public class MapperProfile : Profile 
{
    public MapperProfile()
    {
        CreateMap<Domain.Entities.Product.Product, ProductViewModel>().ReverseMap();
    }
}