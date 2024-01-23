using ASP.NET_OLX_DATABASE;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_OLX.Services.Interfaces
{
    public interface IAdvertRemover
    {
        Task RemoveAdvert(int id, OlxDBContext context, IWebHostEnvironment env, IConfiguration config);
    }
}
