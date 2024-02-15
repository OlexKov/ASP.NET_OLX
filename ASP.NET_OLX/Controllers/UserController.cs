using ApplicationCore.DTOs;
using ApplicationCore.Models;
using ApplicationCore.Services.Interfaces;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace ASP.NET_OLX.Controllers
{
    [Authorize(Roles = "User")]
    public class UserController : BaseController
	{
        [NonAction]
		private async Task setDataToBag()
        {
            ViewBag.Categories = new SelectList(await advertService.GetAllCategories(), nameof(CategoryDto.Id), nameof(CategoryDto.Name));
            ViewBag.Cities = new SelectList(await advertService.GetAllCities(), nameof(City.Id), nameof(City.Name));
        }

		public UserController( IAdvertService advertService) :base(advertService){ }

        public async Task RemoveImage(string url) => await advertService.RemoveImage(url);
     
        public async Task<IActionResult> ShowAdvert(int id)
        {
            var advert = await advertService.GetAdvert(id);
            ViewBag.Images = (await advertService.GetAdvertImages(id)).ToArray();
            return View(advert);
        }

        public async Task<IActionResult> DeleteElement(int id)
        {
            await advertService.RemoveAdvert(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AddAdvert(int id)
        {
            await setDataToBag();
            if (id != 0)
            {
                var advert = await advertService.GetAdvertModel(id);
                if (advert == null) return NotFound();
                return View(advert);
            }
			return View();
        }

        public async Task<IActionResult> Index([FromServices]UserManager<User> userManager)
        {
            var currentUser = await userManager.FindByNameAsync(User.Identity.Name);

			return View(await advertService.GetUserAdverts(currentUser.Id));
        }
       
        [HttpPost]
        public async Task<IActionResult> Create(AdvertModel advertModel)
        {
            if (!ModelState.IsValid)
            {
                advertModel.ImagesUrls = (await advertService.GetAdvertImages(advertModel.Id)).Select(x=>x.Name);
                await setDataToBag();
				return View("AddAdvert", advertModel);
            }

            await  advertService.CreateAdvert(advertModel);
			
            return RedirectToAction("Index");
        }
    }
}
