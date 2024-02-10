using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Orders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvertId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Adverts_AdvertId",
                        column: x => x.AdvertId,
                        principalTable: "Adverts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 2, 10, 14, 20, 27, 808, DateTimeKind.Local).AddTicks(9780));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 2, 10, 14, 20, 27, 811, DateTimeKind.Local).AddTicks(4315));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 2, 10, 14, 20, 27, 811, DateTimeKind.Local).AddTicks(4355));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 2, 10, 14, 20, 27, 811, DateTimeKind.Local).AddTicks(4361));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 2, 10, 14, 20, 27, 811, DateTimeKind.Local).AddTicks(4365));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2024, 2, 10, 14, 20, 27, 811, DateTimeKind.Local).AddTicks(4369));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2024, 2, 10, 14, 20, 27, 811, DateTimeKind.Local).AddTicks(4373));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 8,
                column: "Date",
                value: new DateTime(2024, 2, 10, 14, 20, 27, 811, DateTimeKind.Local).AddTicks(4377));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 9,
                column: "Date",
                value: new DateTime(2024, 2, 10, 14, 20, 27, 811, DateTimeKind.Local).AddTicks(4380));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2024, 2, 10, 14, 20, 27, 811, DateTimeKind.Local).AddTicks(4384));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "028582c83a914a45b330b5234f4131fb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5af2448d-1c4d-4da1-b97a-12743f9a4de7", "AQAAAAIAAYagAAAAEAez6x1MdH1+qXu2aCfXZk0z4TNgF7RHljmuDm5JeyV4roWSR6qEAH/obUPPJuMnkQ==", "deb1341f-f97d-4bf3-a554-45f5c7a65723" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c86dc56aedf549f6afe5ceb4d414ebf1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8775280-dbe5-4e87-9ef1-b1fd1d4f27f4", "AQAAAAIAAYagAAAAEC4bP1m+LUIfuGKEFEoEGmLuA8wVtmgvnGMknkqQr0u7bn+06q1mpr/fZDQikm98yQ==", "c5263257-a44e-43e6-84f6-482d2d8d8e80" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d1901b2435594da2a255db13fc57509b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6863a389-65c9-4577-b0c9-936ebc9d65a7", "AQAAAAIAAYagAAAAEDgdEczLQb98872kseIPBVERPCVCheLNjb6ChGSQt8yBViTh71don8H0SOkYEla6hQ==", "c4dd1079-bb10-4a84-b65d-bfe66bb61371" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb05f9548a2c4cf8adcc2be7305fc732",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9770328d-cc3e-4a0f-94ef-cf492dbe9457", "AQAAAAIAAYagAAAAEDWcCH48Y+9zWfT/sg6hpzTIxocsJa5vTaWKsaYRFBcLimyquzNW55vl5ZUlMURfUA==", "39a3224f-f229-4021-8f57-a110ad52ca6c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f66e492517d7414495e988c4c50fd107",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d9602e6-68ef-4a45-8180-5ac22075f7d2", "AQAAAAIAAYagAAAAELvJ8XfngbGUDVUCMdkvALkq5PO9YA3eK3znunlo6AJtT4foi9bvDLj/CiQ8nBP5DA==", "019c503b-fd5f-4ef1-9254-1ba1c94bf7f3" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AdvertId",
                table: "Orders",
                column: "AdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 2, 9, 15, 15, 19, 545, DateTimeKind.Local).AddTicks(3617));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 2, 9, 15, 15, 19, 547, DateTimeKind.Local).AddTicks(6711));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 2, 9, 15, 15, 19, 547, DateTimeKind.Local).AddTicks(6747));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 2, 9, 15, 15, 19, 547, DateTimeKind.Local).AddTicks(6767));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 2, 9, 15, 15, 19, 547, DateTimeKind.Local).AddTicks(6771));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2024, 2, 9, 15, 15, 19, 547, DateTimeKind.Local).AddTicks(6775));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2024, 2, 9, 15, 15, 19, 547, DateTimeKind.Local).AddTicks(6779));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 8,
                column: "Date",
                value: new DateTime(2024, 2, 9, 15, 15, 19, 547, DateTimeKind.Local).AddTicks(6783));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 9,
                column: "Date",
                value: new DateTime(2024, 2, 9, 15, 15, 19, 547, DateTimeKind.Local).AddTicks(6787));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2024, 2, 9, 15, 15, 19, 547, DateTimeKind.Local).AddTicks(6851));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "028582c83a914a45b330b5234f4131fb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e89faec2-86cf-4309-b218-35a2297779d5", "AQAAAAIAAYagAAAAEK+poJi6A5Pgwf8gHAk9PKLvK1rz8WQY6c3ceLCeZrlQEWsnB70mZUZ/nu9JeMngEg==", "558511b0-9a39-4b29-a64e-c2bcf92639dd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c86dc56aedf549f6afe5ceb4d414ebf1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "67341caf-b243-4985-9887-8efe156db04e", "AQAAAAIAAYagAAAAEGxU70hsU6tjVYxt7d6iZ9RxNRGalefyKp3tLDu3j7WgZne8q4ApIljhURW7CUtk1A==", "ded86213-52c4-4d04-b9e7-935026591239" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d1901b2435594da2a255db13fc57509b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea38645e-7ca6-44a3-93a3-a8140e8de99c", "AQAAAAIAAYagAAAAECZ0lOYTvuVNeCapF6wLhgzR0UTCwtHJGyLn3eb5w/pSkni0/blDcn9SxmuHQML9eQ==", "b2048d84-1b0f-447f-a23d-436907cba57b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb05f9548a2c4cf8adcc2be7305fc732",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6bacbba0-e16a-4bd2-8f1e-4ae8b7fa1c22", "AQAAAAIAAYagAAAAEOxz2sW2y79e/cDmyXyK3dJraM/D9EGLFvEkYZUBqxLEmkLE08a8r6fWyYJRfNqaFA==", "41220dcc-f9a5-4eed-979c-9d1aabb3e61f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f66e492517d7414495e988c4c50fd107",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04c99863-588c-4132-95f9-4300b7b124f7", "AQAAAAIAAYagAAAAEGSCLhjkasopUBGYiDimJPpnYMxCwWxKmGrNin77LvCaEZnx7ngryvD4k4xF2z7Bqg==", "dff33fc5-9168-4736-9000-79af7a470d35" });
        }
    }
}
