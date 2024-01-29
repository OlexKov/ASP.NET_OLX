using ASP.NET_OLX_DATABASE;
using DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ApplicationCore.Services.Interfaces
{
	public interface IAdvertRemover
	{
		Task RemoveAdvert(int id, OlxDBContext context, IWebHostEnvironment env, IConfiguration config);
	}
}
