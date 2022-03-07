using AutoMapper;
using Domain.Entities;

namespace API.Mappers;

public class MoviesProfile : Profile
{
    public MoviesProfile()
    {
        CreateMap<MovieMagic, Movie>()
            .ForMember(d => d.ImageUrl, o =>
                o.MapFrom(s => s.Image.Url ))
            .ForMember(d => d.Id , o => o.MapFrom(s => IdNormalize(s.Id)))
            ;
    }


    private static string IdNormalize(string id)
    {
        return id.Replace("/title/", "").Replace("/","");
    }
}
