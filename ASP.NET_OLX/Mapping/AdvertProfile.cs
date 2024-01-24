using ASP.NET_OLX.Models;
using ASP.NET_OLX_DATABASE.Entities;
using AutoMapper;

namespace ASP.NET_OLX.Mappers
{
    public class AdvertProfile : Profile
    {
         public AdvertProfile() { CreateMap<AdvertModel, Advert>().ReverseMap(); }
    }
}
