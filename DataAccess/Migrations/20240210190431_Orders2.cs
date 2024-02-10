using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Orders2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Branch",
                table: "Orders",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Orders",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Orders",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecondName",
                table: "Orders",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Orders",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 2, 10, 21, 4, 29, 118, DateTimeKind.Local).AddTicks(1441));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 2, 10, 21, 4, 29, 121, DateTimeKind.Local).AddTicks(1804));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 2, 10, 21, 4, 29, 121, DateTimeKind.Local).AddTicks(1852));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 2, 10, 21, 4, 29, 121, DateTimeKind.Local).AddTicks(1859));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 2, 10, 21, 4, 29, 121, DateTimeKind.Local).AddTicks(1864));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2024, 2, 10, 21, 4, 29, 121, DateTimeKind.Local).AddTicks(1869));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2024, 2, 10, 21, 4, 29, 121, DateTimeKind.Local).AddTicks(1873));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 8,
                column: "Date",
                value: new DateTime(2024, 2, 10, 21, 4, 29, 121, DateTimeKind.Local).AddTicks(1878));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 9,
                column: "Date",
                value: new DateTime(2024, 2, 10, 21, 4, 29, 121, DateTimeKind.Local).AddTicks(1882));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2024, 2, 10, 21, 4, 29, 121, DateTimeKind.Local).AddTicks(1887));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "028582c83a914a45b330b5234f4131fb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3af932b2-7200-4f94-a97e-f71adb629bb1", "AQAAAAIAAYagAAAAEIIVsBcyhhd3MyO+UquOY0gSD3Ueey/cH1HFOtA0c51kcJO3HnlfPdz/0KMIDKr52Q==", "fd746a1c-73d5-4bd1-ab62-cd9d62799f84" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c86dc56aedf549f6afe5ceb4d414ebf1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e882a363-b8e9-4f49-875a-c2477fd7045b", "AQAAAAIAAYagAAAAEGnRUHc+WRkCg6dRxTZlcSxCYEVf5luMxbzsWTUnw2ErqU17ukLU9mQ8kUXxxezKVQ==", "e92cfd08-93e3-47a9-baa5-4ec84adcee0f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d1901b2435594da2a255db13fc57509b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c9c0ee69-f41b-41dd-a99c-dcc1c4b8c844", "AQAAAAIAAYagAAAAEFkNKV74/C0A7E8z0GU9yaQM0U+kwAIKMgnUd6uf719lr/wa9E8iAASNGX4Duoislg==", "59ba17cc-8053-4e2f-b184-8310b01d97e7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb05f9548a2c4cf8adcc2be7305fc732",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "596b091f-bac2-49bb-8409-2b62f4699361", "AQAAAAIAAYagAAAAECP8L6qH4ugF7x0E/4PRmZnrX7C/WDY9TYCnubmjqAgaB7e4laBAiaFD9epLdnS6aQ==", "c30caa10-fa92-49cf-9e9c-91cd729fac39" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f66e492517d7414495e988c4c50fd107",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52d08bac-243f-40e4-8209-767a86340c36", "AQAAAAIAAYagAAAAEIvhGjYyhXglS1z8BnBsqFT6D3GjB5C4I8oUzjF7K4O5mZmOHsw8IvnWdx/xKWUHvw==", "bb3b1491-ce00-4b6e-9b40-dd04ab09dd8f" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CityId",
                table: "Orders",
                column: "CityId");

            migrationBuilder.AddCheckConstraint(
                name: "Branch_check",
                table: "Orders",
                sql: "[Branch] <> ''");

            migrationBuilder.AddCheckConstraint(
                name: "Name_check2",
                table: "Orders",
                sql: "[Name] <> ''");

            migrationBuilder.AddCheckConstraint(
                name: "Phone_check",
                table: "Orders",
                sql: "[Phone] <> ''");

            migrationBuilder.AddCheckConstraint(
                name: "SecondName_check",
                table: "Orders",
                sql: "[SecondName] <> ''");

            migrationBuilder.AddCheckConstraint(
                name: "Surname_check",
                table: "Orders",
                sql: "[Surname] <> ''");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Cities_CityId",
                table: "Orders",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Cities_CityId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CityId",
                table: "Orders");

            migrationBuilder.DropCheckConstraint(
                name: "Branch_check",
                table: "Orders");

            migrationBuilder.DropCheckConstraint(
                name: "Name_check2",
                table: "Orders");

            migrationBuilder.DropCheckConstraint(
                name: "Phone_check",
                table: "Orders");

            migrationBuilder.DropCheckConstraint(
                name: "SecondName_check",
                table: "Orders");

            migrationBuilder.DropCheckConstraint(
                name: "Surname_check",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Branch",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SecondName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Orders");

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
        }
    }
}
