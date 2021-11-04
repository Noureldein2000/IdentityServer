using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Data.Migrations
{
    public partial class ChangeSeededMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf3");

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "d5a9b78e-a694-4026-af7f-6d559d8a3949", "341743f0-asd2–42de-afbf-59kmkkmk72cf4" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "d5a9b78e-a694-4026-af7f-6d559d8a3950", "341743f0-asd2–42de-afbf-59kmkkmk72cf6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "d5a9b78e-a694-4026-af7f-6d559d8a3961", "341743f0-asd2–42de-afbf-59kmkkmk72cf5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3949");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3950");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3961");

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 10, 14, 52, 36, 144, DateTimeKind.Local).AddTicks(7462));

            migrationBuilder.UpdateData(
                table: "Entities",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 10, 14, 52, 36, 144, DateTimeKind.Local).AddTicks(9053));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 10, 14, 52, 36, 141, DateTimeKind.Local).AddTicks(5237));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 9, 13, 35, 50, 678, DateTimeKind.Local).AddTicks(9072));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "341743f0-asd2–42de-afbf-59kmkkmk72cf1", "341743f0-asd2–42de-afbf-59kmkkmk72cf1", "SuperAdmin", "SUPERADMIN" },
                    { "341743f0-asd2–42de-afbf-59kmkkmk72cf6", "341743f0-asd2–42de-afbf-59kmkkmk72cf6", "Admin", "ADMIN" },
                    { "341743f0-asd2–42de-afbf-59kmkkmk72cf5", "341743f0-asd2–42de-afbf-59kmkkmk72cf5", "Manager", "MANAGER" },
                    { "341743f0-asd2–42de-afbf-59kmkkmk72cf4", "341743f0-asd2–42de-afbf-59kmkkmk72cf4", "Consumer", "CONSUMER" },
                    { "341743f0-asd2–42de-afbf-59kmkkmk72cf3", "341743f0-asd2–42de-afbf-59kmkkmk72cf3", "AccountAdmin", "ACCOUNTADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "Email", "EmailConfirmed", "LastModified", "LockoutEnabled", "LockoutEnd", "MustChangePassword", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ReferenceID", "SecurityStamp", "TwoFactorEnabled", "UserId", "UserName", "UserTypeID" },
                values: new object[,]
                {
                    { "d5a9b78e-a694-4026-af7f-6d559d8a3950", 0, "eaaeb5c1-8ef5-4f52-9154-4fcca85253c2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", true, null, true, null, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAELrRA/XSA4r+T6WBL7hxXgln7pkHMedXsyRSV60ywCNvY2csEp8qqynrmesNFue+Jg==", "012111111111", false, null, "0809f281-7d52-4fdd-8f66-bce59a38cf54", false, 0, "admin", null },
                    { "d5a9b78e-a694-4026-af7f-6d559d8a3961", 0, "b4f366d1-6822-4844-b848-871ebd549aa3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "manager@manager.com", true, null, true, null, false, null, "MANAGER@MANAGER.COM", "MANAGER", "AQAAAAEAACcQAAAAEG7PIAV2FosSMnrQa5NMhugdhwM1L91AzIJc8TvjsHVV80KY+Fv7D/VuLC/5rFpO9Q==", "012222222222", false, null, "987ef20f-9d53-4c0a-be30-549ac33b7983", false, 0, "manager", null },
                    { "d5a9b78e-a694-4026-af7f-6d559d8a3949", 0, "673322ca-3ac6-4e1b-8ee1-7a53e0a98df0", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "consumer@consumer.com", true, null, true, null, false, null, "CONSUMER@CONSUMER.COM", "CONSUMER", "AQAAAAEAACcQAAAAEBipe4oBqPUNi0NxCM/ZqkXFYIf6VdIdDbRbPMxDI4GuRjG1V/Vl3XLEQ5zGorjYAA==", "01201371236", false, null, "4f9c319e-521d-4fc0-917a-bb8b8d361712", false, 0, "consumer", null }
                });

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

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 3, "SalesReports", "1", "d5a9b78e-a694-4026-af7f-6d559d8a3961" },
                    { 4, "TransactionReports", "1", "d5a9b78e-a694-4026-af7f-6d559d8a3961" },
                    { 1, "DoTransaction", "1", "d5a9b78e-a694-4026-af7f-6d559d8a3949" },
                    { 2, "FinancialReports", "1", "d5a9b78e-a694-4026-af7f-6d559d8a3949" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "d5a9b78e-a694-4026-af7f-6d559d8a3950", "341743f0-asd2–42de-afbf-59kmkkmk72cf6" },
                    { "d5a9b78e-a694-4026-af7f-6d559d8a3961", "341743f0-asd2–42de-afbf-59kmkkmk72cf5" },
                    { "d5a9b78e-a694-4026-af7f-6d559d8a3949", "341743f0-asd2–42de-afbf-59kmkkmk72cf4" }
                });
        }
    }
}
