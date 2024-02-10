using ApplicationCore.DTOs;
using System.Security.Claims;

namespace ApplicationCore.Services.Interfaces
{
	public interface IOrderService
	{
		Task<OrderDto> GetOrder(int orderId);
		Task<IEnumerable<OrderDto>> GetAllOrders();
		Task<IEnumerable<OrderDto>> GetUserOrders(ClaimsPrincipal user);
		Task CreateOrder(OrderDto orderDto);
	}
}
