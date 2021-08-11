using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Data.Migrations
{
    public partial class editAccountStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Accounts",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 10, 18, 46, 23, 811, DateTimeKind.Local).AddTicks(1394));

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 8, 10, 18, 46, 23, 811, DateTimeKind.Local).AddTicks(1469));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "93e63dba-0299-4f01-a514-3cd3d08adbea", "AQAAAAEAACcQAAAAELiwiVP3MZW5PW7fRzbmgh/BusHnLNMSGonRhiJCSvLfHGM7dAxjlny8qguQ3kZ/Gw==", "f30e6608-e589-4da7-abb8-238f904bcd5b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3950",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f9de121e-fbd2-4d84-b604-516151f3f8ac", "AQAAAAEAACcQAAAAEEh2MX/DwCjsy+tEUII/N/G9FPJLm617YX/y42BqscfonjAFNrBA3ECdBnxAsJiDeA==", "4aeb102d-03bb-4e90-a9b1-5a33df3933b9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3961",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "672836bd-c444-4088-a785-65c70d27aa26", "AQAAAAEAACcQAAAAEC3sZ0CJIChckS99GY9oSHvoMbxPaQq6ZuAi8UXzl9VaFz3jkE27uGlK721gqxKIBA==", "d430027e-7215-4696-abcf-88de59b28ec0" });

            migrationBuilder.UpdateData(
                table: "Entities",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 10, 18, 46, 23, 811, DateTimeKind.Local).AddTicks(2843));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 10, 18, 46, 23, 808, DateTimeKind.Local).AddTicks(5734));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "Active",
                table: "Accounts",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 10, 11, 28, 27, 456, DateTimeKind.Local).AddTicks(596));

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 8, 10, 11, 28, 27, 456, DateTimeKind.Local).AddTicks(656));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2c298a9d-6925-4946-a9df-b6464f9dd157", "AQAAAAEAACcQAAAAEBS+3WXt0/7xQPQFMoEZTO6i+comsMoBV6tIMgjdbRhJKvLd+V3J0SLLgSI0y+pRrA==", "ed08619d-ad21-47b6-bae0-f7c6611986a5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3950",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73102008-03f2-4198-bf7d-866c4ea0ae50", "AQAAAAEAACcQAAAAENNOS9Z+JFUhN5hUjqe9v+5PzfQaEV+zNcg4Crsp9UskjTgm9rkdA4QIwp4TDD84zQ==", "9621ae67-1544-47c9-b49b-8875dcb22871" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3961",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c9006941-fd4a-4246-af6b-40bf40b33381", "AQAAAAEAACcQAAAAEEVTpiYMfp0e3V0LRqrb4Q1EM1hT3F78+5EMj8y4aG0BGSuD8fumrQu/mYM2Vq5VBg==", "9cb28ddf-a0b0-4118-8723-a4ef57e255cc" });

            migrationBuilder.UpdateData(
                table: "Entities",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 10, 11, 28, 27, 456, DateTimeKind.Local).AddTicks(1767));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 10, 11, 28, 27, 453, DateTimeKind.Local).AddTicks(9930));
        }
    }
}
