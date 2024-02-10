using ApplicationCore.DTOs;
using AutoMapper;
using DataAccess.Entities;

namespace ApplicationCore.Mapping
{
	public class OrderProfile : Profile
	{
		public OrderProfile()
		{
			CreateMap<Order, OrderDto>().ReverseMap();
		}
	}
}
