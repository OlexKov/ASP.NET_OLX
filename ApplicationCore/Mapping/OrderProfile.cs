using ApplicationCore.DTOs;
using AutoMapper;
using DataAccess.Entities;
using Microsoft.Extensions.Configuration;

namespace ApplicationCore.Mapping
{
	public class OrderProfile : Profile
	{
		public OrderProfile(IMapper mapper﻿)
		{
			CreateMap<Order, OrderDto>().
				ForMember(x=>x.Advert,opt=>opt.MapFrom(x=>mapper.Map<OrderDto>(x)));

		}
	}
}
