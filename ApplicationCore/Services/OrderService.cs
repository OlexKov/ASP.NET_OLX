using ApplicationCore.DTOs;
using ApplicationCore.Services.Interfaces;
using AutoMapper;
using DataAccess;
using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections.Generic;
using System.Security.Claims;

namespace ApplicationCore.Services
{
	internal class OrderService : IOrderService
	{
		private readonly OlxDBContext context;
		private readonly UserManager<User> userManager;
		private readonly IMapper mapper;
		private readonly IIncludableQueryable<Order, Advert> orders;
		public OrderService(IMapper mapper,OlxDBContext context,UserManager<User> userManager)
        {
			this.mapper = mapper;
			this.context = context;
			this.userManager = userManager;
			orders = context.Orders.Include(x => x.User).Include(x => x.Advert);
		}

		public async Task CreateOrder(OrderDto orderDto)
		{
			var order = mapper.Map<Order>(orderDto);
			await context.Orders.AddAsync(order);
			await context.SaveChangesAsync();
		}

		public async Task<IEnumerable<OrderDto>> GetAllOrders() => mapper.Map <IEnumerable<OrderDto>>(await orders.ToArrayAsync());
		

		public async Task<OrderDto> GetOrder(int orderId) => mapper.Map<OrderDto>(await orders.FirstOrDefaultAsync(x => x.Id == orderId));


		public async Task<IEnumerable<OrderDto>> GetUserOrders(ClaimsPrincipal user)
		{
		   string? userId = (await userManager.GetUserAsync(user))?.Id;
		   return mapper.Map<IEnumerable<OrderDto>>(await orders.Where(x=>x.UserId == userId).ToArrayAsync());
		}
		
	}
}
