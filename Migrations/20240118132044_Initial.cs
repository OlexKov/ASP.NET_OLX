using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ASP.NET_OLX.Migrations
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
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.CheckConstraint("Url_check", "[Url] <> ''");
                });

            migrationBuilder.CreateTable(
                name: "SaleAdvertisements",
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
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleAdvertisements", x => x.Id);
                    table.CheckConstraint("Description_check", "[Description] <> ''");
                    table.CheckConstraint("SellerName_check", "[SellerName] <> ''");
                    table.CheckConstraint("Title_check", "[Title] <> ''");
                    table.ForeignKey(
                        name: "FK_SaleAdvertisements_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleAdvertisements_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleAdvertisementsImages",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    SaleAdvertisementId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleAdvertisementsImages", x => new { x.ImageId, x.SaleAdvertisementId });
                    table.ForeignKey(
                        name: "FK_SaleAdvertisementsImages_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SaleAdvertisementsImages_SaleAdvertisements_SaleAdvertisementId",
                        column: x => x.SaleAdvertisementId,
                        principalTable: "SaleAdvertisements",
                        principalColumn: "Id");
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
                table: "Images",
                columns: new[] { "Id", "Url" },
                values: new object[,]
                {
                    { 1, "https://ireland.apollo.olxcdn.com/v1/files/1we2pcjh47763-UA/image;s=1000x700" },
                    { 2, "https://ireland.apollo.olxcdn.com/v1/files/yg15qnxbohat2-UA/image;s=1000x700" },
                    { 3, "https://ireland.apollo.olxcdn.com/v1/files/ewnblvgqpds9-UA/image;s=1000x700" },
                    { 4, "https://ireland.apollo.olxcdn.com/v1/files/u5ndzznrfi6u1-UA/image;s=1000x700" },
                    { 5, "https://ireland.apollo.olxcdn.com/v1/files/nkiymda9lrje3-UA/image;s=1000x700" },
                    { 6, "https://ireland.apollo.olxcdn.com/v1/files/yki05lj0glt51-UA/image;s=1000x700" },
                    { 7, "https://ireland.apollo.olxcdn.com/v1/files/mqcdn2fy2uy52-UA/image;s=1000x700" },
                    { 8, "https://ireland.apollo.olxcdn.com/v1/files/gjtip058jonr-UA/image;s=1000x700" },
                    { 9, "https://ireland.apollo.olxcdn.com/v1/files/ji9icjvsej54-UA/image;s=1000x700" },
                    { 10, "https://ireland.apollo.olxcdn.com/v1/files/mcydp7sgssqy1-UA/image;s=1000x700" },
                    { 11, "https://ireland.apollo.olxcdn.com/v1/files/95zqr3wiv1my1-UA/image;s=1000x700" },
                    { 12, "https://ireland.apollo.olxcdn.com/v1/files/33kqgn9kli8m1-UA/image;s=3024x4032;r=90" },
                    { 13, "https://ireland.apollo.olxcdn.com/v1/files/mp4qu07wkpr83-UA/image;s=1000x700" },
                    { 14, "https://ireland.apollo.olxcdn.com/v1/files/nq9ectqnizw4-UA/image;s=1000x700" },
                    { 15, "https://ireland.apollo.olxcdn.com/v1/files/52ljmc61u5ng3-UA/image;s=1000x700" },
                    { 16, "https://ireland.apollo.olxcdn.com/v1/files/824trbs276xu1-UA/image;s=1000x700" },
                    { 17, "https://ireland.apollo.olxcdn.com/v1/files/3dln9mvifzek2-UA/image;s=1000x700" },
                    { 18, "https://ireland.apollo.olxcdn.com/v1/files/4267u72kg6wt3-UA/image;s=1000x700" },
                    { 19, "https://ireland.apollo.olxcdn.com/v1/files/jpzsul0ocu1u3-UA/image;s=1000x700" },
                    { 20, "https://ireland.apollo.olxcdn.com/v1/files/w739nrwpg84x2-UA/image;s=1000x700" },
                    { 21, "https://ireland.apollo.olxcdn.com/v1/files/ryqlkuv5uecs1-UA/image;s=1000x700" },
                    { 22, "https://ireland.apollo.olxcdn.com/v1/files/1n3vzg4k83xe-UA/image;s=1000x700" },
                    { 23, "https://ireland.apollo.olxcdn.com/v1/files/l8d663ab98y82-UA/image;s=1000x700" },
                    { 24, "https://ireland.apollo.olxcdn.com/v1/files/6nwdckysvc833-UA/image;s=1000x700" },
                    { 25, "https://ireland.apollo.olxcdn.com/v1/files/3s59y8e2rjyh2-UA/image;s=1000x700" },
                    { 26, "https://ireland.apollo.olxcdn.com/v1/files/xafjn7617wgg1-UA/image;s=1000x700" },
                    { 27, "https://ireland.apollo.olxcdn.com/v1/files/9entkpyrsyqm2-UA/image;s=1000x700" }
                });

            migrationBuilder.InsertData(
                table: "SaleAdvertisements",
                columns: new[] { "Id", "CategoryId", "CityId", "Date", "Description", "IsNew", "Price", "SellerName", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 1, 18, 15, 20, 43, 760, DateTimeKind.Local).AddTicks(2974), "Продам телефон Redmi 9A в гарному стані на фото видно що має незначні царини роботі вони не впливають а загалом він як новий .", false, 1500m, "Олександр", "Телефон REDMI 9A" },
                    { 2, 2, 2, new DateTime(2024, 1, 18, 15, 20, 43, 763, DateTimeKind.Local).AddTicks(9389), "Ніяких mdm блокувань немає. Ноутбук без жодних дефектів і повний комплект(зарядка, коробка, шнур, макулатура і наклейки). Фото коробки і інших дрібниць не кидаю але все маю, нічого не викидав.", false, 99900m, "Михайло", "MacBook M1 Max 14” 64RAM/32GPU/2Tb ssd" },
                    { 3, 3, 3, new DateTime(2024, 1, 18, 15, 20, 43, 763, DateTimeKind.Local).AddTicks(9441), "Смарт тв 32” Samsung UE32T4510AUXUA, Smart TV, WiFi, T2. Телевізор білого кольору, 2021 року виробництва.Телевізор в ідеальному стані та повному комплекті, - пульт, ніжнки. Усе в оригіналі, всі функції перевірені та працюють", false, 7900m, "Микола", "Смарт тв 32” Samsung UE32T4510AUXUA, Smart TV, WiFi, T2" },
                    { 4, 4, 4, new DateTime(2024, 1, 18, 15, 20, 43, 763, DateTimeKind.Local).AddTicks(9448), "Продам полностью рабочую в отличном состоянии игровую видеокарту AMD RX 5700XT 8GB GDDR6 ASUS.Температура отличная, без каких либо проблем.Проходит тесты ОССТ/FurMark/3DMark без проблем.Потянет большинство популярных игр на хороших настройках графики!", false, 8500m, "Олена", "Как новая! Видеокарта AMD RX 5700XT 8GB GDDR6 Гарантия!" },
                    { 5, 5, 5, new DateTime(2024, 1, 18, 15, 20, 43, 763, DateTimeKind.Local).AddTicks(9453), "Intel i5 7400, причина продажу апгрейд, комплектаці BOX, любі тести, також можна купити комплектом, дивіться інші мої оголошення)комплектом віддам за 5к", false, 1500m, "Ольга", "Процессор intel i5 7400" },
                    { 6, 6, 6, new DateTime(2024, 1, 18, 15, 20, 43, 763, DateTimeKind.Local).AddTicks(9457), "Продам оперативну пям'ять SAMSUNG 8 GB. SODIMM. DDR-4. 2400 MHz.Планки по 4GB.Були в роботі 1 рік.", false, 1000m, "Володимир", "Оперативна пям'ять DDR-4 2400 MHz" },
                    { 7, 7, 7, new DateTime(2024, 1, 18, 15, 20, 43, 763, DateTimeKind.Local).AddTicks(9462), "Продам тихий игровой компьютер, в хорошем исполнении, с качественных комплектующих, с запасом на апгрейд. Любые проверки и тесты , предпочтительно по месту! Компьютер будет радовать своего нового владельца высокой продуктивностью, и ждет именно вас!", false, 14700m, "Антон", "Silens! Игровой компьютер I5 9400f, z390, gtx 1070 8 gb,16 gb" },
                    { 8, 8, 8, new DateTime(2024, 1, 18, 15, 20, 43, 763, DateTimeKind.Local).AddTicks(9467), "Все летает , новые игры без проблем на ультрах! Battlefield 2042, Call of Duty Modern Warfare прошел 3 части!", false, 23500m, "Іван", "Игровой компютер, комплект! GTX 1080, монитор MSI 244 герц!" },
                    { 9, 9, 9, new DateTime(2024, 1, 18, 15, 20, 43, 763, DateTimeKind.Local).AddTicks(9471), "Все летает , новые игры без проблем на ультрах! Battlefield 2042, Call of Duty Modern Warfare прошел 3 части!", true, 50m, "Роман", "Зовнішня звукова карта USB 5.1 для комп'ютера та ноутбука (Внешняя)" },
                    { 10, 10, 10, new DateTime(2024, 1, 18, 15, 20, 43, 763, DateTimeKind.Local).AddTicks(9476), "Продаю свою GoPro 10 так як перейшов на новішу модель . Завжди була в захисних склах і у захиснобу силіконовому чохлі , не топилась (Використовувалась як влогова камера ) можлива зустріч у Києві (правий берег ) або Олх доставка/наложка Торг !!!", true, 8000m, "Сергій", "Пртдам Gopro 10 black в дуже горошому стані !!!" }
                });

            migrationBuilder.InsertData(
                table: "SaleAdvertisementsImages",
                columns: new[] { "ImageId", "SaleAdvertisementId", "Id" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 1, 3 },
                    { 4, 2, 4 },
                    { 5, 2, 5 },
                    { 6, 2, 6 },
                    { 7, 3, 7 },
                    { 8, 3, 8 },
                    { 9, 3, 9 },
                    { 10, 4, 10 },
                    { 11, 4, 11 },
                    { 12, 4, 12 },
                    { 13, 5, 13 },
                    { 14, 5, 14 },
                    { 15, 5, 15 },
                    { 16, 6, 16 },
                    { 17, 6, 17 },
                    { 18, 7, 18 },
                    { 19, 7, 19 },
                    { 20, 7, 20 },
                    { 21, 8, 21 },
                    { 22, 8, 22 },
                    { 23, 8, 23 },
                    { 24, 9, 24 },
                    { 25, 10, 25 },
                    { 26, 10, 26 },
                    { 27, 10, 27 }
                });

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
                name: "IX_Images_Url",
                table: "Images",
                column: "Url",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SaleAdvertisements_CategoryId",
                table: "SaleAdvertisements",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleAdvertisements_CityId",
                table: "SaleAdvertisements",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleAdvertisementsImages_SaleAdvertisementId",
                table: "SaleAdvertisementsImages",
                column: "SaleAdvertisementId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleAdvertisementsImages");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "SaleAdvertisements");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
