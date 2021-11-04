using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Data.Migrations
{
    public partial class EditEntitySeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "Entities",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 9, 13, 35, 50, 678, DateTimeKind.Local).AddTicks(9072));

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

            migrationBuilder.InsertData(
                table: "Entities",
                columns: new[] { "ID", "CreationDate", "Name", "NameAr", "UpdateDate" },
                values: new object[] { 1, new DateTime(2021, 8, 9, 13, 35, 50, 679, DateTimeKind.Local).AddTicks(495), "Momkn", "ممكن", null });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 9, 13, 35, 50, 676, DateTimeKind.Local).AddTicks(3612));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "Entities");

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 9, 13, 10, 40, 291, DateTimeKind.Local).AddTicks(257));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3a176a3-b4e5-44fe-a5a5-dc44ac1cd760", "AQAAAAEAACcQAAAAEGBlbfiwYWYZ1cpnVRWY5y2V2bTH2mfW6ebhn6nlS9UHghmqyMTrp9v7Cg9Mm3+RFQ==", "ae3ab22b-7192-4ebb-9559-5e1c4197c3ae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3950",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "423619d7-beed-4929-8f39-013858d5123c", "AQAAAAEAACcQAAAAEGqTF+tPjToIhvUsawfSZZoobrweTRJgRfP5tSWuJ+1KMaJBHN5UgMqTm2B4asMX5Q==", "7a2292fd-6b77-46da-b4fe-6ba94a186784" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3961",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e4cfb5c5-5638-4743-afc1-fc2269e28687", "AQAAAAEAACcQAAAAEG1eRnVMN+lojbxNijLNO4kYsIdeygvInKy2rX6qyHucrt+dXe1I8mwoI3TLSnjNSg==", "14a9e229-fe6b-43d8-9369-e7c981a94d22" });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 9, 13, 10, 40, 288, DateTimeKind.Local).AddTicks(2938));
        }
    }
}
