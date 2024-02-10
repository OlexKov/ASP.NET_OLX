using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Orders3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Postal",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 2, 10, 22, 25, 2, 414, DateTimeKind.Local).AddTicks(991));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 2, 10, 22, 25, 2, 417, DateTimeKind.Local).AddTicks(4656));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 2, 10, 22, 25, 2, 417, DateTimeKind.Local).AddTicks(4703));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 2, 10, 22, 25, 2, 417, DateTimeKind.Local).AddTicks(4710));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 2, 10, 22, 25, 2, 417, DateTimeKind.Local).AddTicks(4716));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2024, 2, 10, 22, 25, 2, 417, DateTimeKind.Local).AddTicks(4721));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2024, 2, 10, 22, 25, 2, 417, DateTimeKind.Local).AddTicks(4726));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 8,
                column: "Date",
                value: new DateTime(2024, 2, 10, 22, 25, 2, 417, DateTimeKind.Local).AddTicks(4731));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 9,
                column: "Date",
                value: new DateTime(2024, 2, 10, 22, 25, 2, 417, DateTimeKind.Local).AddTicks(4736));

            migrationBuilder.UpdateData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2024, 2, 10, 22, 25, 2, 417, DateTimeKind.Local).AddTicks(4741));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "028582c83a914a45b330b5234f4131fb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "215e8dfe-670b-4067-a98a-d96746b95e6d", "AQAAAAIAAYagAAAAELYXTqiUWt/+WW7DWdBi0fIftY4cPdfOPzlh9c8L1bIfBgU3ZAlrQaNwOeH+xp5rKA==", "0dd431ae-e8f8-427f-a0ab-84c46abc429d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c86dc56aedf549f6afe5ceb4d414ebf1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c52a2a78-8d22-4243-b302-ae2689021788", "AQAAAAIAAYagAAAAEDuSQPQX+5eSSYmfJ3hlYcAsW/yiG1DgnzQXMPXCAA2VslfA878J/okzYKGpzBOV4Q==", "48b8d8e0-ecf5-47b9-86eb-07868c25b804" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d1901b2435594da2a255db13fc57509b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65542195-f200-4d80-a4f2-90215d6733fe", "AQAAAAIAAYagAAAAEO0UZO5LnQu7WkVSY+luUkSOAIf09oXfJEdJQ1u4JhREOImMWJReVfbP8LjanyBB0w==", "0e700e98-08ce-424d-9912-65568a70ad47" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb05f9548a2c4cf8adcc2be7305fc732",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8731ae9e-b0e8-4c75-989f-75eac4a42cdb", "AQAAAAIAAYagAAAAEDm63+E+Hg5Kq0idylqqqzb6n2j1tZ/6r7k3Wt4yJtbxYg1CxgdGPhm3otL4LUVZzg==", "defc34fd-5398-49b4-9bb9-aecc374e0ec7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f66e492517d7414495e988c4c50fd107",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f380502-affa-4cfa-a1c0-e22c932e6a32", "AQAAAAIAAYagAAAAEKLkU31gGKwemBeliLCi190c59G47ANDVaUI+3VcdjJk3taBLKCD84utDyEg1tOoUQ==", "e133f8b5-059a-4390-abc4-72bf0bd75132" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Postal",
                table: "Orders");

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
        }
    }
}
