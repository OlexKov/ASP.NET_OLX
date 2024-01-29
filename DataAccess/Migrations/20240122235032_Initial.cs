using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ASP.NET_OLX_DATABASE.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.CheckConstraint("Category_check", "[Name] <> ''");
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.CheckConstraint("Name_check", "[Name] <> ''");
                });

            migrationBuilder.CreateTable(
                name: "Adverts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellerName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsNew = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adverts", x => x.Id);
                    table.CheckConstraint("Description_check", "[Description] <> ''");
                    table.CheckConstraint("SellerName_check", "[SellerName] <> ''");
                    table.CheckConstraint("Title_check", "[Title] <> ''");
                    table.ForeignKey(
                        name: "FK_Adverts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adverts_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdvertId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.CheckConstraint("Url_check", "[Url] <> ''");
                    table.ForeignKey(
                        name: "FK_Images_Adverts_AdvertId",
                        column: x => x.AdvertId,
                        principalTable: "Adverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Телефони" },
                    { 2, "Ноутбуки" },
                    { 3, "Телевізори" },
                    { 4, "Відеокарти" },
                    { 5, "Процессори" },
                    { 6, "Оперативна пам'ять" },
                    { 7, "Компьютери" },
                    { 8, "Монитори" },
                    { 9, "Звукові карти" },
                    { 10, "Екшн-камери" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Київ" },
                    { 2, "Харків" },
                    { 3, "Одеса" },
                    { 4, "Дніпро" },
                    { 5, "Запоріжжя" },
                    { 6, "Кривий Ріг" },
                    { 7, "Mиколаїв" },
                    { 8, "Луганськ" },
                    { 9, "Вінниця" },
                    { 10, "Чернігів" }
                });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "CategoryId", "CityId", "Date", "Description", "IsNew", "Price", "SellerName", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 1, 23, 1, 50, 31, 458, DateTimeKind.Local).AddTicks(4253), "Продам телефон Redmi 9A в гарному стані на фото видно що має незначні царини роботі вони не впливають а загалом він як новий .", false, 1500m, "Олександр", "Телефон REDMI 9A" },
                    { 2, 2, 2, new DateTime(2024, 1, 23, 1, 50, 31, 461, DateTimeKind.Local).AddTicks(288), "Ніяких mdm блокувань немає. Ноутбук без жодних дефектів і повний комплект(зарядка, коробка, шнур, макулатура і наклейки). Фото коробки і інших дрібниць не кидаю але все маю, нічого не викидав.", false, 99900m, "Михайло", "MacBook M1 Max 14” 64RAM/32GPU/2Tb ssd" },
                    { 3, 3, 3, new DateTime(2024, 1, 23, 1, 50, 31, 461, DateTimeKind.Local).AddTicks(327), "Смарт тв 32” Samsung UE32T4510AUXUA, Smart TV, WiFi, T2. Телевізор білого кольору, 2021 року виробництва.Телевізор в ідеальному стані та повному комплекті, - пульт, ніжнки. Усе в оригіналі, всі функції перевірені та працюють", false, 7900m, "Микола", "Смарт тв 32” Samsung UE32T4510AUXUA, Smart TV, WiFi, T2" },
                    { 4, 4, 4, new DateTime(2024, 1, 23, 1, 50, 31, 461, DateTimeKind.Local).AddTicks(332), "Продам полностью рабочую в отличном состоянии игровую видеокарту AMD RX 5700XT 8GB GDDR6 ASUS.Температура отличная, без каких либо проблем.Проходит тесты ОССТ/FurMark/3DMark без проблем.Потянет большинство популярных игр на хороших настройках графики!", false, 8500m, "Олена", "Как новая! Видеокарта AMD RX 5700XT 8GB GDDR6 Гарантия!" },
                    { 5, 5, 5, new DateTime(2024, 1, 23, 1, 50, 31, 461, DateTimeKind.Local).AddTicks(336), "Intel i5 7400, причина продажу апгрейд, комплектаці BOX, любі тести, також можна купити комплектом, дивіться інші мої оголошення)комплектом віддам за 5к", false, 1500m, "Ольга", "Процессор intel i5 7400" },
                    { 6, 6, 6, new DateTime(2024, 1, 23, 1, 50, 31, 461, DateTimeKind.Local).AddTicks(339), "Продам оперативну пям'ять SAMSUNG 8 GB. SODIMM. DDR-4. 2400 MHz.Планки по 4GB.Були в роботі 1 рік.", false, 1000m, "Володимир", "Оперативна пям'ять DDR-4 2400 MHz" },
                    { 7, 7, 7, new DateTime(2024, 1, 23, 1, 50, 31, 461, DateTimeKind.Local).AddTicks(342), "Продам тихий игровой компьютер, в хорошем исполнении, с качественных комплектующих, с запасом на апгрейд. Любые проверки и тесты , предпочтительно по месту! Компьютер будет радовать своего нового владельца высокой продуктивностью, и ждет именно вас!", false, 14700m, "Антон", "Silens! Игровой компьютер I5 9400f, z390, gtx 1070 8 gb,16 gb" },
                    { 8, 8, 8, new DateTime(2024, 1, 23, 1, 50, 31, 461, DateTimeKind.Local).AddTicks(345), "Все летает , новые игры без проблем на ультрах! Battlefield 2042, Call of Duty Modern Warfare прошел 3 части!", false, 23500m, "Іван", "Игровой компютер, комплект! GTX 1080, монитор MSI 244 герц!" },
                    { 9, 9, 9, new DateTime(2024, 1, 23, 1, 50, 31, 461, DateTimeKind.Local).AddTicks(348), "Все летает , новые игры без проблем на ультрах! Battlefield 2042, Call of Duty Modern Warfare прошел 3 части!", true, 50m, "Роман", "Зовнішня звукова карта USB 5.1 для комп'ютера та ноутбука (Внешняя)" },
                    { 10, 10, 10, new DateTime(2024, 1, 23, 1, 50, 31, 461, DateTimeKind.Local).AddTicks(351), "Продаю свою GoPro 10 так як перейшов на новішу модель . Завжди була в захисних склах і у захиснобу силіконовому чохлі , не топилась (Використовувалась як влогова камера ) можлива зустріч у Києві (правий берег ) або Олх доставка/наложка Торг !!!", true, 8000m, "Сергій", "Пртдам Gopro 10 black в дуже горошому стані !!!" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "AdvertId", "Url" },
                values: new object[,]
                {
                    { 1, 1, "https://localhost:7203/UsersAdvertsImages/046a6c9cbe3948a388001eff7c842786.webp" },
                    { 2, 1, "https://localhost:7203/UsersAdvertsImages/6c54c58f313c46b8b08fb276cd89ede1.webp" },
                    { 3, 1, "https://localhost:7203/UsersAdvertsImages/07a281155d454adb81ad4b170fbd0a03.webp" },
                    { 4, 2, "https://localhost:7203/UsersAdvertsImages/a366c4b673c4466aae1799e4b417b19b.webp" },
                    { 5, 2, "https://localhost:7203/UsersAdvertsImages/5f3b586ef071461bbcdf7841cf2ff67c.webp" },
                    { 6, 2, "https://localhost:7203/UsersAdvertsImages/ba0ff206dacc47d6956d606aef5edd5d.webp" },
                    { 7, 3, "https://localhost:7203/UsersAdvertsImages/f2855d828be54f93acf0485d7b874cdb.webp" },
                    { 8, 3, "https://localhost:7203/UsersAdvertsImages/844edaa8c7b8427b9d2b56063ce8977c.webp" },
                    { 9, 3, "https://localhost:7203/UsersAdvertsImages/54b271dc78fe427fae3a68f07540a8ea.webp" },
                    { 10, 4, "https://localhost:7203/UsersAdvertsImages/c81082a052484beb8699ff467d1122dc.webp" },
                    { 11, 4, "https://localhost:7203/UsersAdvertsImages/2b69dadd1dcd40eb94ecc40bd8e66d31.webp" },
                    { 12, 4, "https://localhost:7203/UsersAdvertsImages/c9e78a957e84442e9cf0915167d62add.webp" },
                    { 13, 5, "https://localhost:7203/UsersAdvertsImages/d90a8e5655204c0eb035e382c8a293a3.webp" },
                    { 14, 5, "https://localhost:7203/UsersAdvertsImages/d7229686d2444bf7aad0f9f22b5c671a.webp" },
                    { 15, 5, "https://localhost:7203/UsersAdvertsImages/fff47682d2db4df9a0a51ac6288eb881.webp" },
                    { 16, 6, "https://localhost:7203/UsersAdvertsImages/a165f34c4bcf4de28ac3df3e670217d6.webp" },
                    { 17, 6, "https://localhost:7203/UsersAdvertsImages/7d6097e652cf44b5a5298d1e94db142c.webp" },
                    { 18, 7, "https://localhost:7203/UsersAdvertsImages/3ba07c21e7b44ef993412fd0b40c3385.webp" },
                    { 19, 7, "https://localhost:7203/UsersAdvertsImages/0af4ad7eb0a24f45b0008090b1b0a3f6.webp" },
                    { 20, 7, "https://localhost:7203/UsersAdvertsImages/90cc095ed7134cc78c6af6e2f38b8403.webp" },
                    { 21, 8, "https://localhost:7203/UsersAdvertsImages/2d49a4fb86c74a79bff1bcedcf8aae24.webp" },
                    { 22, 8, "https://localhost:7203/UsersAdvertsImages/a92a25d946284f70bfb93866233f8c88.webp" },
                    { 23, 8, "https://localhost:7203/UsersAdvertsImages/f2f938f084374eebb76be6436e689714.webp" },
                    { 24, 9, "https://localhost:7203/UsersAdvertsImages/dc521bca678948cca942fa4b029c0905.webp" },
                    { 25, 10, "https://localhost:7203/UsersAdvertsImages/eafe376a8c994ac282c37a12e8f989c3.webp" },
                    { 26, 10, "https://localhost:7203/UsersAdvertsImages/75efa1d600fd4e0eb976ab4dddcdacb7.webp" },
                    { 27, 10, "https://localhost:7203/UsersAdvertsImages/57e5aec69d234333bdc7625a54f96945.webp" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_CategoryId",
                table: "Adverts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_CityId",
                table: "Adverts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Name",
                table: "Cities",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_AdvertId",
                table: "Images",
                column: "AdvertId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Adverts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
