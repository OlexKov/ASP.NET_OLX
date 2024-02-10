using ApplicationCore.DTOs;
using ApplicationCore.Models;
using AutoMapper;
using DataAccess.Entities;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography.X509Certificates;

namespace ApplicationCore.Mapping
{
	public class AdvertProfile : Profile
	{
		public AdvertProfile(IConfiguration Configuration﻿) 
		{
			CreateMap<AdvertModel, Advert>();
			CreateMap<Advert, AdvertModel>()
				.ForMember(x => x.ImagesUrls, opt => opt.MapFrom(src => src.Images.Select(x => $"/{Configuration["UserImgDir"]}/{x.Name}")));
			CreateMap<Advert, AdvertDto>()
				.ForMember(x => x.FirstImage, opt => opt.MapFrom(src => src.Images.Count() > 0 ? $"/{Configuration["UserImgDir"]}/{src.Images.ElementAt(0).Name}" : string.Empty))
				.ForMember(x => x.SellerName, opt => opt.MapFrom(x => x.User.Name))
			    .ForMember(x => x.SellerPhone, opt => opt.MapFrom(x => String.IsNullOrEmpty(x.User.PhoneNumber) ? "Телефон відсутній" : x.User.PhoneNumber))
			    .ForMember(x => x.SellerEmail, opt => opt.MapFrom(x => x.User.Email))
			    .ForMember(x => x.SellerSurname, opt => opt.MapFrom(x => x.User.Surname));
			CreateMap<AdvertDto, Advert>()
				.ForMember(x => x.Category, opts => opts.Ignore())
				.ForMember(x => x.City, opts => opts.Ignore())
				.ForPath(x => x.User.Name, opts => opts.MapFrom(x => x.SellerName))
				//.ForPath(x => x.User.PhoneNumber, opts => opts.MapFrom(x => x.SellerPhone))
				.ForPath(x => x.User.Email, opts => opts.MapFrom(x => x.SellerEmail))
				.ForPath(x => x.User.Surname, opts => opts.MapFrom(x => x.SellerSurname));
			CreateMap<BaseEntity, BaseEntityDto>().ReverseMap();
			CreateMap<Category, CategoryDto>().ReverseMap();
			CreateMap<City, CityDto>().ReverseMap();
			CreateMap<Image, ImageDto>()
				.ForMember(x=>x.Name,opt=>opt.MapFrom(x=> $"/{Configuration["UserImgDir"]}/{x.Name}"));
            CreateMap<ImageDto, Image>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => Path.GetFileName(x.Name)));
        }
	}
}
