using ApplicationCore.Services.Interfaces;
using ASP.NET_OLX_DATABASE;
using DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ApplicationCore.Services
{
	public class AdvertRemover : IAdvertRemover
	{
		public async Task RemoveAdvert(int id, OlxDBContext context, IWebHostEnvironment env, IConfiguration config)
		{
			var images = context.Images.Where(x => x.AdvertId == id);
			foreach (var image in images)
				File.Delete(Path.Combine(env.WebRootPath, config["UserImgDir"] ?? string.Empty, Path.GetFileName(image.Url)));
			var advert = await context.Adverts.FindAsync(id) ?? new();
			context.Images.RemoveRange(images);
			context.Adverts.Remove(advert);
			await context.SaveChangesAsync();
		}
	}
}
