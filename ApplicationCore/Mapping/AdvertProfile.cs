using ApplicationCore.Models;
using AutoMapper;
using DataAccess.Entities;

namespace ApplicationCore.Mapping
{
	public class AdvertProfile : Profile
	{
		public AdvertProfile() { CreateMap<AdvertModel, Advert>().ReverseMap(); }
	}
}
