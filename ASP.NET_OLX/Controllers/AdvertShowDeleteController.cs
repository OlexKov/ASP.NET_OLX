using ASP.NET_OLX.Controllers.ControllerInerfaces;
using ASP.NET_OLX_DATABASE;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_OLX.Controllers
{
	public class AdvertShowDeleteController: AdvertShowController, IAdvertDelete
	{
        public AdvertShowDeleteController(OlxDBContext context):base(context){}

		public  async Task<IActionResult> DeleteElement(int id, [FromServices] IWebHostEnvironment env, [FromServices] IConfiguration config)
		{
			var images = context.Images.Where(x => x.AdvertId == id);
			foreach (var image in images)
				System.IO.File.Delete(Path.Combine(env.WebRootPath, config["UserImgDir"] ?? string.Empty, Path.GetFileName(image.Url)));
			var advert = await context.Adverts.FindAsync(id) ?? new();
			context.Images.RemoveRange(images);
			context.Adverts.Remove(advert);
			await context.SaveChangesAsync();
			return RedirectToAction("Index");
		}
		
	}
}
