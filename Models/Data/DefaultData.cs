using ASP.NET_OLX.Models.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_OLX.Models.Data
{
    public static class DefaultData
    {
        public static void Initialize(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(Cities);
            modelBuilder.Entity<Category>().HasData(Categories);
            modelBuilder.Entity<Image>().HasData(Images);
            modelBuilder.Entity<Advert>().HasData(Adverts);
            modelBuilder.Entity<AdvertImage >().HasData(AdvertImages);
        }

        public static readonly City[] Cities =
        [
            new (){ Id = 1, Name = "Київ" },
            new (){ Id = 2, Name = "Харків" },
            new (){ Id = 3, Name = "Одеса" },
            new (){ Id = 4, Name = "Дніпро" },
            new (){ Id = 5, Name = "Запоріжжя" },
            new (){ Id = 6, Name = "Кривий Ріг" },
            new (){ Id = 7, Name = "Mиколаїв" },
            new (){ Id = 8, Name = "Луганськ" },
            new (){ Id = 9, Name = "Вінниця" },
            new (){ Id = 10, Name = "Чернігів" }
        ];

        public static readonly Category[] Categories =
        [
            new() { Id = 1, Name = "Телефони" },
            new() { Id = 2, Name = "Ноутбуки" },
            new() { Id = 3, Name = "Телевізори" },
            new() { Id = 4, Name = "Відеокарти" },
            new() { Id = 5, Name = "Процессори" },
            new() { Id = 6, Name = "Оперативна пам'ять" },
            new() { Id = 7, Name = "Компьютери" },
            new() { Id = 8, Name = "Монитори" },
            new() { Id = 9, Name = "Звукові карти" },
            new() { Id = 10, Name = "Екшн-камери" }
        ];

        public static readonly Image[] Images =
        [

            new() { Id = 1, Url = "https://localhost:7203/UsersAdvertsImages/046a6c9cbe3948a388001eff7c842786.webp" },
            new() { Id = 2, Url = "https://localhost:7203/UsersAdvertsImages/6c54c58f313c46b8b08fb276cd89ede1.webp" },
            new() { Id = 3, Url = "https://localhost:7203/UsersAdvertsImages/07a281155d454adb81ad4b170fbd0a03.webp" },

            new() { Id = 4, Url = "https://localhost:7203/UsersAdvertsImages/a366c4b673c4466aae1799e4b417b19b.webp" },
            new() { Id = 5, Url = "https://localhost:7203/UsersAdvertsImages/5f3b586ef071461bbcdf7841cf2ff67c.webp" },
            new() { Id = 6, Url = "https://localhost:7203/UsersAdvertsImages/ba0ff206dacc47d6956d606aef5edd5d.webp" },

            new() { Id = 7, Url = "https://localhost:7203/UsersAdvertsImages/f2855d828be54f93acf0485d7b874cdb.webp" },
            new() { Id = 8, Url = "https://localhost:7203/UsersAdvertsImages/844edaa8c7b8427b9d2b56063ce8977c.webp" },
            new() { Id = 9, Url = "https://localhost:7203/UsersAdvertsImages/54b271dc78fe427fae3a68f07540a8ea.webp" },

            new() { Id = 10, Url = "https://localhost:7203/UsersAdvertsImages/c81082a052484beb8699ff467d1122dc.webp" },
            new() { Id = 11, Url = "https://localhost:7203/UsersAdvertsImages/2b69dadd1dcd40eb94ecc40bd8e66d31.webp" },
            new() { Id = 12, Url = "https://localhost:7203/UsersAdvertsImages/c9e78a957e84442e9cf0915167d62add.webp" },

            new() { Id = 13, Url = "https://localhost:7203/UsersAdvertsImages/d90a8e5655204c0eb035e382c8a293a3.webp" },
            new() { Id = 14, Url = "https://localhost:7203/UsersAdvertsImages/d7229686d2444bf7aad0f9f22b5c671a.webp" },
            new() { Id = 15, Url = "https://localhost:7203/UsersAdvertsImages/fff47682d2db4df9a0a51ac6288eb881.webp" },

            new() { Id = 16, Url = "https://localhost:7203/UsersAdvertsImages/a165f34c4bcf4de28ac3df3e670217d6.webp" },
            new() { Id = 17, Url = "https://localhost:7203/UsersAdvertsImages/7d6097e652cf44b5a5298d1e94db142c.webp" },


            new() { Id = 18, Url = "https://localhost:7203/UsersAdvertsImages/3ba07c21e7b44ef993412fd0b40c3385.webp" },
            new() { Id = 19, Url = "https://localhost:7203/UsersAdvertsImages/0af4ad7eb0a24f45b0008090b1b0a3f6.webp" },
            new() { Id = 20, Url = "https://localhost:7203/UsersAdvertsImages/90cc095ed7134cc78c6af6e2f38b8403.webp" },

            new() { Id = 21, Url = "https://localhost:7203/UsersAdvertsImages/2d49a4fb86c74a79bff1bcedcf8aae24.webp" },
            new() { Id = 22, Url = "https://localhost:7203/UsersAdvertsImages/a92a25d946284f70bfb93866233f8c88.webp" },
            new() { Id = 23, Url = "https://localhost:7203/UsersAdvertsImages/f2f938f084374eebb76be6436e689714.webp" },

            new() { Id = 24, Url = "https://localhost:7203/UsersAdvertsImages/dc521bca678948cca942fa4b029c0905.webp" },

            new() { Id = 25, Url = "https://localhost:7203/UsersAdvertsImages/eafe376a8c994ac282c37a12e8f989c3.webp" },
            new() { Id = 26, Url = "https://localhost:7203/UsersAdvertsImages/75efa1d600fd4e0eb976ab4dddcdacb7.webp" },
            new() { Id = 27, Url = "https://localhost:7203/UsersAdvertsImages/57e5aec69d234333bdc7625a54f96945.webp" },
        ];

        public static readonly AdvertImage [] AdvertImages =
        [
            new() { Id = 1, ImageId = 1, AdvertId = 1},
            new() { Id = 2, ImageId = 2, AdvertId = 1 },
            new() { Id = 3, ImageId = 3, AdvertId = 1 },

            new() { Id = 4, ImageId = 4, AdvertId = 2 },
            new() { Id = 5, ImageId = 5, AdvertId = 2 },
            new() { Id = 6, ImageId = 6, AdvertId = 2 },

            new() { Id = 7, ImageId = 7, AdvertId = 3 },
            new() { Id = 8, ImageId = 8, AdvertId = 3 },
            new() { Id = 9, ImageId = 9, AdvertId = 3 },

            new() { Id = 10, ImageId = 10, AdvertId = 4 },
            new() { Id = 11, ImageId = 11, AdvertId = 4 },
            new() { Id = 12, ImageId = 12, AdvertId = 4 },

            new() { Id = 13, ImageId = 13, AdvertId = 5 },
            new() { Id = 14, ImageId = 14, AdvertId = 5 },
            new() { Id = 15, ImageId = 15, AdvertId = 5 },

            new() { Id = 16, ImageId = 16, AdvertId = 6 },
            new() { Id = 17, ImageId = 17, AdvertId = 6 },

            new() { Id = 18, ImageId = 18, AdvertId = 7 },
            new() { Id = 19, ImageId = 19, AdvertId = 7 },
            new() { Id = 20, ImageId = 20, AdvertId = 7 },

            new() { Id = 21, ImageId = 21, AdvertId = 8 },
            new() { Id = 22, ImageId = 22, AdvertId = 8 },
            new() { Id = 23, ImageId = 23, AdvertId = 8 },

            new() { Id = 24, ImageId = 24, AdvertId = 9 },
           
            new() { Id = 25, ImageId = 25, AdvertId = 10 },
            new() { Id = 26, ImageId = 26, AdvertId = 10 },
            new() { Id = 27, ImageId = 27, AdvertId = 10 },


        ];

        public static readonly Advert[] Adverts =
        [
            new()
            {
                Id = 1,
                SellerName = "Олександр",
                Title = "Телефон REDMI 9A",
                Price = 1500,
                CityId = 1,
                CategoryId = 1,
                Date = DateTime.Now,
                Description = "Продам телефон Redmi 9A в гарному стані на фото видно що має незначні царини роботі вони не впливають а загалом він як новий .",
                IsNew = false
            },

            new()
            {
                Id = 2,
                SellerName = "Михайло",
                Title = "MacBook M1 Max 14” 64RAM/32GPU/2Tb ssd",
                Price = 99900,
                CityId = 2,
                CategoryId = 2,
                Date = DateTime.Now,
                Description = "Ніяких mdm блокувань немає. Ноутбук без жодних дефектів і повний комплект(зарядка, коробка, шнур, макулатура і наклейки). Фото коробки і інших дрібниць не кидаю але все маю, нічого не викидав.",
                IsNew = false
            },
            new()
            {
                Id = 3,
                SellerName = "Микола",
                Title = "Смарт тв 32” Samsung UE32T4510AUXUA, Smart TV, WiFi, T2",
                Price = 7900,
                CityId = 3,
                CategoryId = 3,
                Date = DateTime.Now,
                Description = "Смарт тв 32” Samsung UE32T4510AUXUA, Smart TV, WiFi, T2. Телевізор білого кольору, 2021 року виробництва.Телевізор в ідеальному стані та повному комплекті, - пульт, ніжнки. Усе в оригіналі, всі функції перевірені та працюють",
                IsNew = false
            },
            new()
            {
                Id = 4,
                SellerName = "Олена",
                Title = "Как новая! Видеокарта AMD RX 5700XT 8GB GDDR6 Гарантия!",
                Price = 8500,
                CityId = 4,
                CategoryId = 4,
                Date = DateTime.Now,
                Description = "Продам полностью рабочую в отличном состоянии игровую видеокарту AMD RX 5700XT 8GB GDDR6 ASUS.Температура отличная, без каких либо проблем.Проходит тесты ОССТ/FurMark/3DMark без проблем.Потянет большинство популярных игр на хороших настройках графики!",
                IsNew = false
            },
            new()
            {
                Id = 5,
                SellerName = "Ольга",
                Title = "Процессор intel i5 7400",
                Price = 1500,
                CityId = 5,
                CategoryId = 5,
                Date = DateTime.Now,
                Description = "Intel i5 7400, причина продажу апгрейд, комплектаці BOX, любі тести, також можна купити комплектом, дивіться інші мої оголошення)комплектом віддам за 5к",
                IsNew = false
            },
            new()
            {
                Id = 6,
                SellerName = "Володимир",
                Title = "Оперативна пям'ять DDR-4 2400 MHz",
                Price = 1000,
                CityId = 6,
                CategoryId = 6,
                Date = DateTime.Now,
                Description = "Продам оперативну пям'ять SAMSUNG 8 GB. SODIMM. DDR-4. 2400 MHz.Планки по 4GB.Були в роботі 1 рік.",
                IsNew = false
            },

            new()
            {
                Id = 7,
                SellerName = "Антон",
                Title = "Silens! Игровой компьютер I5 9400f, z390, gtx 1070 8 gb,16 gb",
                Price = 14700,
                CityId = 7,
                CategoryId = 7,
                Date = DateTime.Now,
                Description = "Продам тихий игровой компьютер, в хорошем исполнении, с качественных комплектующих, с запасом на апгрейд. Любые проверки и тесты , предпочтительно по месту! Компьютер будет радовать своего нового владельца высокой продуктивностью, и ждет именно вас!",
                IsNew = false
            },

            new()
            {
                Id = 8,
                SellerName = "Іван",
                Title = "Игровой компютер, комплект! GTX 1080, монитор MSI 244 герц!",
                Price = 23500,
                CityId = 8,
                CategoryId = 8,
                Date = DateTime.Now,
                Description = "Все летает , новые игры без проблем на ультрах! Battlefield 2042, Call of Duty Modern Warfare прошел 3 части!",
                IsNew = false
            },
            new()
            {
                Id = 9,
                SellerName = "Роман",
                Title = "Зовнішня звукова карта USB 5.1 для комп'ютера та ноутбука (Внешняя)",
                Price = 50,
                CityId = 9,
                CategoryId = 9,
                Date = DateTime.Now,
                Description = "Все летает , новые игры без проблем на ультрах! Battlefield 2042, Call of Duty Modern Warfare прошел 3 части!",
                IsNew = true
            },
            new()
            {
                Id = 10,
                SellerName = "Сергій",
                Title = "Пртдам Gopro 10 black в дуже горошому стані !!!",
                Price = 8000,
                CityId = 10,
                CategoryId = 10,
                Date = DateTime.Now,
                Description = "Продаю свою GoPro 10 так як перейшов на новішу модель . Завжди була в захисних склах і у захиснобу силіконовому чохлі , не топилась (Використовувалась як влогова камера ) можлива зустріч у Києві (правий берег ) або Олх доставка/наложка Торг !!!",
                IsNew = true
            },
        ];

        
    }
}

