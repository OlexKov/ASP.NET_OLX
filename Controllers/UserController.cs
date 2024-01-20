using ASP.NET_OLX.Models;
using ASP.NET_OLX.Models.Data;
using ASP.NET_OLX.Models.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Diagnostics;

namespace ASP.NET_OLX.Controllers
{
    public class UserController : Controller
    {
        private readonly OlxDBContext context;

        private const string imageDirPath = "UsersAdvertsImages";

        private readonly IIncludableQueryable<Advert, ICollection<Image>> adverts;

        private async Task<string> saveImage(IFormFile file,IWebHostEnvironment env)
        {
            string fileName  = Guid.NewGuid().ToString("N")+Path.GetExtension(file.FileName);
            string filePath = Path.Combine(env.WebRootPath, imageDirPath, fileName);
            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
               await  file.CopyToAsync(fileStream);
            }
            var location = new Uri($"{Request.Scheme}://{Request.Host}/{imageDirPath}/{fileName}");
            return location.AbsoluteUri;
        }

        public UserController(OlxDBContext context)
        {
            this.context = context;
            adverts = context.Adverts.Include(x => x.Category).Include(x => x.City).Include(x => x.Images);
        }

        public async Task<IActionResult> Index()
        {
           // await context.Images.LoadAsync();
            return View(await adverts.ToArrayAsync());
        }

        public async Task<IActionResult> AddAdvert()
        {
            ViewBag.Categories = await context.Categories.Select(x => x.Name).ToArrayAsync();
            ViewBag.Cities = await context.Cities.Select(x => x.Name).ToArrayAsync();
            return View();
        }

        public IActionResult PersonalAccount()
        {
            return View();
        }
        

        [HttpPost]
        public async Task<IActionResult> Create(AdvertModel arvertModel, [FromServices] IWebHostEnvironment env)
        {
            var newAdvert = new Advert
            {
                Date = DateTime.Now,
                Description = arvertModel.Description,
                SellerName = arvertModel.SellerName,
                IsNew = arvertModel.IsNew,
                CategoryId = context.Categories.FirstOrDefaultAsync(x => x.Name == arvertModel.Category).Id,
                CityId = context.Cities.FirstOrDefaultAsync(x => x.Name == arvertModel.City).Id,
                Price = arvertModel.Price,
                Title = arvertModel.Title
            };

            foreach (var item in arvertModel.Images)
                newAdvert.Images.Add(new Image() { Url = await saveImage(item, env) });
            context.Adverts.Add(newAdvert);      
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
