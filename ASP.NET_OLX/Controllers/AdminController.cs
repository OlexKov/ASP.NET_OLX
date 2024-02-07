using ApplicationCore.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace ASP.NET_OLX.Controllers
{
    [Authorize]
   // [Authorize(Roles = "Admin")]
    public class AdminController : BaseController
	{
        public AdminController(IAdvertService advertService) :base(advertService){ }

        public async Task<IActionResult> Index() => View(await advertService.GetAllAdverts());
                    
        public async Task<IActionResult> ShowPartialView(int id)
        {
            var advert = await advertService.GetAdvert(id);
            ViewBag.Images = await advertService.GetAdvertImages(id);
            return PartialView("_ShowPartialView", advert);
        }

        public async Task<IActionResult> DeleteElement(int id)
        {
            await advertService.RemoveAdvert(id);
            return RedirectToAction("Index");
        }
    }
}
