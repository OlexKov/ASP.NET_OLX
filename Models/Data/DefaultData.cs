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
            modelBuilder.Entity<SaleAdvertisement>().HasData(SaleAdvertisements);
            modelBuilder.Entity<SaleAdvertisementImage>().HasData(SaleAdvertisementImages);
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

            new() { Id = 1, Url = "https://ireland.apollo.olxcdn.com/v1/files/1we2pcjh47763-UA/image;s=1000x700" },
            new() { Id = 2, Url = "https://ireland.apollo.olxcdn.com/v1/files/yg15qnxbohat2-UA/image;s=1000x700" },
            new() { Id = 3, Url = "https://ireland.apollo.olxcdn.com/v1/files/ewnblvgqpds9-UA/image;s=1000x700" },

            new() { Id = 4, Url = "https://ireland.apollo.olxcdn.com/v1/files/u5ndzznrfi6u1-UA/image;s=1000x700" },
            new() { Id = 5, Url = "https://ireland.apollo.olxcdn.com/v1/files/nkiymda9lrje3-UA/image;s=1000x700" },
            new() { Id = 6, Url = "https://ireland.apollo.olxcdn.com/v1/files/yki05lj0glt51-UA/image;s=1000x700" },

            new() { Id = 7, Url = "https://ireland.apollo.olxcdn.com/v1/files/mqcdn2fy2uy52-UA/image;s=1000x700" },
            new() { Id = 8, Url = "https://ireland.apollo.olxcdn.com/v1/files/gjtip058jonr-UA/image;s=1000x700" },
            new() { Id = 9, Url = "https://ireland.apollo.olxcdn.com/v1/files/ji9icjvsej54-UA/image;s=1000x700" },

            new() { Id = 10, Url = "https://ireland.apollo.olxcdn.com/v1/files/mcydp7sgssqy1-UA/image;s=1000x700" },
            new() { Id = 11, Url = "https://ireland.apollo.olxcdn.com/v1/files/95zqr3wiv1my1-UA/image;s=1000x700" },
            new() { Id = 12, Url = "https://ireland.apollo.olxcdn.com/v1/files/33kqgn9kli8m1-UA/image;s=3024x4032;r=90" },

            new() { Id = 13, Url = "https://ireland.apollo.olxcdn.com/v1/files/mp4qu07wkpr83-UA/image;s=1000x700" },
            new() { Id = 14, Url = "https://ireland.apollo.olxcdn.com/v1/files/nq9ectqnizw4-UA/image;s=1000x700" },
            new() { Id = 15, Url = "https://ireland.apollo.olxcdn.com/v1/files/52ljmc61u5ng3-UA/image;s=1000x700" },

            new() { Id = 16, Url = "https://ireland.apollo.olxcdn.com/v1/files/824trbs276xu1-UA/image;s=1000x700" },
            new() { Id = 17, Url = "https://ireland.apollo.olxcdn.com/v1/files/3dln9mvifzek2-UA/image;s=1000x700" },


            new() { Id = 18, Url = "https://ireland.apollo.olxcdn.com/v1/files/4267u72kg6wt3-UA/image;s=1000x700" },
            new() { Id = 19, Url = "https://ireland.apollo.olxcdn.com/v1/files/jpzsul0ocu1u3-UA/image;s=1000x700" },
            new() { Id = 20, Url = "https://ireland.apollo.olxcdn.com/v1/files/w739nrwpg84x2-UA/image;s=1000x700" },

            new() { Id = 21, Url = "https://ireland.apollo.olxcdn.com/v1/files/ryqlkuv5uecs1-UA/image;s=1000x700" },
            new() { Id = 22, Url = "https://ireland.apollo.olxcdn.com/v1/files/1n3vzg4k83xe-UA/image;s=1000x700" },
            new() { Id = 23, Url = "https://ireland.apollo.olxcdn.com/v1/files/l8d663ab98y82-UA/image;s=1000x700" },

            new() { Id = 24, Url = "https://ireland.apollo.olxcdn.com/v1/files/6nwdckysvc833-UA/image;s=1000x700" },

            new() { Id = 25, Url = "https://ireland.apollo.olxcdn.com/v1/files/3s59y8e2rjyh2-UA/image;s=1000x700" },
            new() { Id = 26, Url = "https://ireland.apollo.olxcdn.com/v1/files/xafjn7617wgg1-UA/image;s=1000x700" },
            new() { Id = 27, Url = "https://ireland.apollo.olxcdn.com/v1/files/9entkpyrsyqm2-UA/image;s=1000x700" },
        ];

        public static readonly SaleAdvertisementImage[] SaleAdvertisementImages =
        [
            new() { Id = 1, ImageId = 1, SaleAdvertisementId = 1},
            new() { Id = 2, ImageId = 2, SaleAdvertisementId = 1 },
            new() { Id = 3, ImageId = 3, SaleAdvertisementId = 1 },

            new() { Id = 4, ImageId = 4, SaleAdvertisementId = 2 },
            new() { Id = 5, ImageId = 5, SaleAdvertisementId = 2 },
            new() { Id = 6, ImageId = 6, SaleAdvertisementId = 2 },

            new() { Id = 7, ImageId = 7, SaleAdvertisementId = 3 },
            new() { Id = 8, ImageId = 8, SaleAdvertisementId = 3 },
            new() { Id = 9, ImageId = 9, SaleAdvertisementId = 3 },

            new() { Id = 10, ImageId = 10, SaleAdvertisementId = 4 },
            new() { Id = 11, ImageId = 11, SaleAdvertisementId = 4 },
            new() { Id = 12, ImageId = 12, SaleAdvertisementId = 4 },

            new() { Id = 13, ImageId = 13, SaleAdvertisementId = 5 },
            new() { Id = 14, ImageId = 14, SaleAdvertisementId = 5 },
            new() { Id = 15, ImageId = 15, SaleAdvertisementId = 5 },

            new() { Id = 16, ImageId = 16, SaleAdvertisementId = 6 },
            new() { Id = 17, ImageId = 17, SaleAdvertisementId = 6 },

            new() { Id = 18, ImageId = 18, SaleAdvertisementId = 7 },
            new() { Id = 19, ImageId = 19, SaleAdvertisementId = 7 },
            new() { Id = 20, ImageId = 20, SaleAdvertisementId = 7 },

            new() { Id = 21, ImageId = 21, SaleAdvertisementId = 8 },
            new() { Id = 22, ImageId = 22, SaleAdvertisementId = 8 },
            new() { Id = 23, ImageId = 23, SaleAdvertisementId = 8 },

            new() { Id = 24, ImageId = 24, SaleAdvertisementId = 9 },
           
            new() { Id = 25, ImageId = 25, SaleAdvertisementId = 10 },
            new() { Id = 26, ImageId = 26, SaleAdvertisementId = 10 },
            new() { Id = 27, ImageId = 27, SaleAdvertisementId = 10 },


        ];

        public static readonly SaleAdvertisement[] SaleAdvertisements =
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

