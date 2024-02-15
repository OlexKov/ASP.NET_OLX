using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adverts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    table.CheckConstraint("Title_check", "[Title] <> ''");
                    table.ForeignKey(
                        name: "FK_Adverts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdvertId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.CheckConstraint("Name_check1", "[Name] <> ''");
                    table.ForeignKey(
                        name: "FK_Images_Adverts_AdvertId",
                        column: x => x.AdvertId,
                        principalTable: "Adverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvertId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Postal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Branch = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.CheckConstraint("Branch_check", "[Branch] <> ''");
                    table.CheckConstraint("Name_check2", "[Name] <> ''");
                    table.CheckConstraint("Phone_check", "[Phone] <> ''");
                    table.CheckConstraint("SecondName_check", "[SecondName] <> ''");
                    table.CheckConstraint("Surname_check", "[Surname] <> ''");
                    table.ForeignKey(
                        name: "FK_Orders_Adverts_AdvertId",
                        column: x => x.AdvertId,
                        principalTable: "Adverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserFavouriteAdverts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AdvertId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavouriteAdverts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFavouriteAdverts_Adverts_AdvertId",
                        column: x => x.AdvertId,
                        principalTable: "Adverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFavouriteAdverts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "15b04d9eff654d8d966a172db59e2722", "15b04d9eff654d8d966a172db59e2722", "Admin", "ADMIN" },
                    { "59139483f3d1417db1efee50d14b6a7f", "59139483f3d1417db1efee50d14b6a7f", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthdate", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "028582c83a914a45b330b5234f4131fb", 0, new DateTime(1999, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "69229fd9-abee-47d5-85fc-12aebd927dc6", "User3@gmail.com", true, false, null, "Олег", null, "USER3@GMAIL.COM", "AQAAAAIAAYagAAAAEBPOwvrNw/RWHe3IqLdE0tVwP9MYsKDWT0kf432HkWYspMwgYqaL15t/4WcFO83Mqw==", null, false, "ab655a35-23f1-4d19-af41-9b0f4fbcdd90", "Панасенко", false, "User3@gmail.com" },
                    { "c86dc56aedf549f6afe5ceb4d414ebf1", 0, new DateTime(2000, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "833412c9-a15d-48c1-a118-654bceb84dae", "User2@gmail.com", true, false, null, "Петро", null, "USER2@GMAIL.COM", "AQAAAAIAAYagAAAAEHBvU+3myh5WDadW5yVEGAthFcb7lEJzyvZNRXL3elmT5UKnLGP70pA7gMWGI5nAbw==", null, false, "143f0c04-c565-4927-ada3-69084b908ee7", "Дякуленко", false, "User2@gmail.com" },
                    { "d1901b2435594da2a255db13fc57509b", 0, new DateTime(1988, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "b67b53f2-68fe-49b2-8546-fe21d05cda26", "User1@gmail.com", true, false, null, "Iван", null, "USER1@GMAIL.COM", "AQAAAAIAAYagAAAAEJL+cjfE3KS/coBQd5Gm5lncxWoxY7k8SYQBYFOxIyyWlWrK8VjC2ABMizM2YvtUVQ==", null, false, "7f266972-5613-4dc8-bce2-a0b91c8900ad", "Калита", false, "User1@gmail.com" },
                    { "eb05f9548a2c4cf8adcc2be7305fc732", 0, new DateTime(2001, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "173cae5a-ce58-4f62-aea5-36dbbe7f638f", "User4@gmail.com", true, false, null, "Тимофій", null, "USER4@GMAIL.COM", "AQAAAAIAAYagAAAAEIKa0xHweV4XtB9wr4ObLlZpXPKwgH+huDwpYgQHfAoH7LCL9QcWf/3sAI9k1NHh3Q==", null, false, "2b4fde1c-2c7b-49f3-9aa7-e4cf9dd53153", "Гнатенко", false, "User4@gmail.com" },
                    { "f66e492517d7414495e988c4c50fd107", 0, new DateTime(1998, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "df0d5b22-6ed8-4e1f-9a85-201f30b19832", "Admin@gmail.com", true, false, null, "Петро", null, "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEN8KmIfS85AfmTMZenpeZANmfWCp5/vM3MiUExv/6YiXTfWVVmvvwMHdnNz6dOSWDQ==", null, false, "24d095d9-f003-47c8-9d63-533008723c49", "Левак", false, "Admin@gmail.com" }
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
                columns: new[] { "Id", "CategoryId", "CityId", "Date", "Description", "IsNew", "Price", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 2, 15, 18, 6, 26, 856, DateTimeKind.Local).AddTicks(770), "Продам телефон Redmi 9A в гарному стані на фото видно що має незначні царини роботі вони не впливають а загалом він як новий .", false, 1500m, "Телефон REDMI 9A", "d1901b2435594da2a255db13fc57509b" },
                    { 2, 2, 1, new DateTime(2024, 2, 15, 18, 6, 26, 861, DateTimeKind.Local).AddTicks(8879), "Ніяких mdm блокувань немає. Ноутбук без жодних дефектів і повний комплект(зарядка, коробка, шнур, макулатура і наклейки). Фото коробки і інших дрібниць не кидаю але все маю, нічого не викидав.", false, 99900m, "MacBook M1 Max 14” 64RAM/32GPU/2Tb ssd", "d1901b2435594da2a255db13fc57509b" },
                    { 3, 3, 3, new DateTime(2024, 2, 15, 18, 6, 26, 861, DateTimeKind.Local).AddTicks(8968), "Смарт тв 32” Samsung UE32T4510AUXUA, Smart TV, WiFi, T2. Телевізор білого кольору, 2021 року виробництва.Телевізор в ідеальному стані та повному комплекті, - пульт, ніжнки. Усе в оригіналі, всі функції перевірені та працюють", false, 7900m, "Смарт тв 32” Samsung UE32T4510AUXUA, Smart TV, WiFi, T2", "c86dc56aedf549f6afe5ceb4d414ebf1" },
                    { 4, 4, 3, new DateTime(2024, 2, 15, 18, 6, 26, 861, DateTimeKind.Local).AddTicks(8984), "Продам полностью рабочую в отличном состоянии игровую видеокарту AMD RX 5700XT 8GB GDDR6 ASUS.Температура отличная, без каких либо проблем.Проходит тесты ОССТ/FurMark/3DMark без проблем.Потянет большинство популярных игр на хороших настройках графики!", false, 8500m, "Как новая! Видеокарта AMD RX 5700XT 8GB GDDR6 Гарантия!", "c86dc56aedf549f6afe5ceb4d414ebf1" },
                    { 5, 5, 5, new DateTime(2024, 2, 15, 18, 6, 26, 861, DateTimeKind.Local).AddTicks(8995), "Intel i5 7400, причина продажу апгрейд, комплектаці BOX, любі тести, також можна купити комплектом, дивіться інші мої оголошення)комплектом віддам за 5к", false, 1500m, "Процессор intel i5 7400", "028582c83a914a45b330b5234f4131fb" },
                    { 6, 6, 5, new DateTime(2024, 2, 15, 18, 6, 26, 861, DateTimeKind.Local).AddTicks(9005), "Продам оперативну пям'ять SAMSUNG 8 GB. SODIMM. DDR-4. 2400 MHz.Планки по 4GB.Були в роботі 1 рік.", false, 1000m, "Оперативна пям'ять DDR-4 2400 MHz", "028582c83a914a45b330b5234f4131fb" },
                    { 7, 7, 7, new DateTime(2024, 2, 15, 18, 6, 26, 861, DateTimeKind.Local).AddTicks(9014), "Продам тихий игровой компьютер, в хорошем исполнении, с качественных комплектующих, с запасом на апгрейд. Любые проверки и тесты , предпочтительно по месту! Компьютер будет радовать своего нового владельца высокой продуктивностью, и ждет именно вас!", false, 14700m, "Silens! Игровой компьютер I5 9400f, z390, gtx 1070 8 gb,16 gb", "eb05f9548a2c4cf8adcc2be7305fc732" },
                    { 8, 8, 7, new DateTime(2024, 2, 15, 18, 6, 26, 861, DateTimeKind.Local).AddTicks(9024), "Все летает , новые игры без проблем на ультрах! Battlefield 2042, Call of Duty Modern Warfare прошел 3 части!", false, 23500m, "Игровой компютер, комплект! GTX 1080, монитор MSI 244 герц!", "eb05f9548a2c4cf8adcc2be7305fc732" },
                    { 9, 9, 7, new DateTime(2024, 2, 15, 18, 6, 26, 861, DateTimeKind.Local).AddTicks(9033), "Все летает , новые игры без проблем на ультрах! Battlefield 2042, Call of Duty Modern Warfare прошел 3 части!", true, 50m, "Зовнішня звукова карта USB 5.1 для комп'ютера та ноутбука (Внешняя)", "eb05f9548a2c4cf8adcc2be7305fc732" },
                    { 10, 10, 5, new DateTime(2024, 2, 15, 18, 6, 26, 861, DateTimeKind.Local).AddTicks(9043), "Продаю свою GoPro 10 так як перейшов на новішу модель . Завжди була в захисних склах і у захиснобу силіконовому чохлі , не топилась (Використовувалась як влогова камера ) можлива зустріч у Києві (правий берег ) або Олх доставка/наложка Торг !!!", true, 8000m, "Пртдам Gopro 10 black в дуже горошому стані !!!", "028582c83a914a45b330b5234f4131fb" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "59139483f3d1417db1efee50d14b6a7f", "028582c83a914a45b330b5234f4131fb" },
                    { "59139483f3d1417db1efee50d14b6a7f", "c86dc56aedf549f6afe5ceb4d414ebf1" },
                    { "59139483f3d1417db1efee50d14b6a7f", "d1901b2435594da2a255db13fc57509b" },
                    { "59139483f3d1417db1efee50d14b6a7f", "eb05f9548a2c4cf8adcc2be7305fc732" },
                    { "15b04d9eff654d8d966a172db59e2722", "f66e492517d7414495e988c4c50fd107" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "AdvertId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "046a6c9cbe3948a388001eff7c842786.webp" },
                    { 2, 1, "6c54c58f313c46b8b08fb276cd89ede1.webp" },
                    { 3, 1, "07a281155d454adb81ad4b170fbd0a03.webp" },
                    { 4, 2, "a366c4b673c4466aae1799e4b417b19b.webp" },
                    { 5, 2, "5f3b586ef071461bbcdf7841cf2ff67c.webp" },
                    { 6, 2, "ba0ff206dacc47d6956d606aef5edd5d.webp" },
                    { 7, 3, "f2855d828be54f93acf0485d7b874cdb.webp" },
                    { 8, 3, "844edaa8c7b8427b9d2b56063ce8977c.webp" },
                    { 9, 3, "54b271dc78fe427fae3a68f07540a8ea.webp" },
                    { 10, 4, "c81082a052484beb8699ff467d1122dc.webp" },
                    { 11, 4, "2b69dadd1dcd40eb94ecc40bd8e66d31.webp" },
                    { 12, 4, "c9e78a957e84442e9cf0915167d62add.webp" },
                    { 13, 5, "d90a8e5655204c0eb035e382c8a293a3.webp" },
                    { 14, 5, "d7229686d2444bf7aad0f9f22b5c671a.webp" },
                    { 15, 5, "fff47682d2db4df9a0a51ac6288eb881.webp" },
                    { 16, 6, "a165f34c4bcf4de28ac3df3e670217d6.webp" },
                    { 17, 6, "7d6097e652cf44b5a5298d1e94db142c.webp" },
                    { 18, 7, "3ba07c21e7b44ef993412fd0b40c3385.webp" },
                    { 19, 7, "0af4ad7eb0a24f45b0008090b1b0a3f6.webp" },
                    { 20, 7, "90cc095ed7134cc78c6af6e2f38b8403.webp" },
                    { 21, 8, "2d49a4fb86c74a79bff1bcedcf8aae24.webp" },
                    { 22, 8, "a92a25d946284f70bfb93866233f8c88.webp" },
                    { 23, 8, "f2f938f084374eebb76be6436e689714.webp" },
                    { 24, 9, "dc521bca678948cca942fa4b029c0905.webp" },
                    { 25, 10, "eafe376a8c994ac282c37a12e8f989c3.webp" },
                    { 26, 10, "75efa1d600fd4e0eb976ab4dddcdacb7.webp" },
                    { 27, 10, "57e5aec69d234333bdc7625a54f96945.webp" }
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
                name: "IX_Adverts_UserId",
                table: "Adverts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AdvertId",
                table: "Orders",
                column: "AdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CityId",
                table: "Orders",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavouriteAdverts_AdvertId",
                table: "UserFavouriteAdverts",
                column: "AdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavouriteAdverts_UserId",
                table: "UserFavouriteAdverts",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "UserFavouriteAdverts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Adverts");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
