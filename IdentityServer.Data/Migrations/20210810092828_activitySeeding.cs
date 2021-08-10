using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Data.Migrations
{
    public partial class activitySeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreationDate", "Name", "NameAr" },
                values: new object[] { new DateTime(2021, 8, 10, 11, 28, 27, 456, DateTimeKind.Local).AddTicks(596), "General", "عام" });

            migrationBuilder.InsertData(
                table: "Activity",
                columns: new[] { "ID", "CreationDate", "Name", "NameAr", "UpdateDate" },
                values: new object[] { 2, new DateTime(2021, 8, 10, 11, 28, 27, 456, DateTimeKind.Local).AddTicks(656), "SuperMarket", "سوبرماركت", null });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreationDate", "Name", "NameAr" },
                values: new object[] { new DateTime(2021, 8, 9, 13, 35, 50, 678, DateTimeKind.Local).AddTicks(9072), "SuperMarket", "سوبرماركت" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "673322ca-3ac6-4e1b-8ee1-7a53e0a98df0", "AQAAAAEAACcQAAAAEBipe4oBqPUNi0NxCM/ZqkXFYIf6VdIdDbRbPMxDI4GuRjG1V/Vl3XLEQ5zGorjYAA==", "4f9c319e-521d-4fc0-917a-bb8b8d361712" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3950",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eaaeb5c1-8ef5-4f52-9154-4fcca85253c2", "AQAAAAEAACcQAAAAELrRA/XSA4r+T6WBL7hxXgln7pkHMedXsyRSV60ywCNvY2csEp8qqynrmesNFue+Jg==", "0809f281-7d52-4fdd-8f66-bce59a38cf54" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3961",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4f366d1-6822-4844-b848-871ebd549aa3", "AQAAAAEAACcQAAAAEG7PIAV2FosSMnrQa5NMhugdhwM1L91AzIJc8TvjsHVV80KY+Fv7D/VuLC/5rFpO9Q==", "987ef20f-9d53-4c0a-be30-549ac33b7983" });

            migrationBuilder.UpdateData(
                table: "Entities",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 9, 13, 35, 50, 679, DateTimeKind.Local).AddTicks(495));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 9, 13, 35, 50, 676, DateTimeKind.Local).AddTicks(3612));
        }
    }
}
