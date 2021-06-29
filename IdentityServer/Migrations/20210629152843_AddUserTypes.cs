using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Migrations
{
    public partial class AddUserTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "341743f0-asd2–42de-afbf-59kmkkmk72cf1", "341743f0-asd2–42de-afbf-59kmkkmk72cf1", "SuperAdmin", "SUPERADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c5f22262-d570-40fa-82fd-c5597e60aca3", "AQAAAAEAACcQAAAAEEnEfbqbyOrSNkA5JqIW+1IEbj+KCsAoQ9uuzAT9WaTngG9TI+41Qa+ScS0C9Il0vQ==", "d7de2a69-9398-4b1a-a5ed-a35c7c11a7d9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3950",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b6235037-9dbc-41d4-9cc2-e85bb9745606", "AQAAAAEAACcQAAAAEGzPBD4GN3nCwP0xx+TJIFnxWW9pSCHxZllWGt7Glo5K2CxQaxxWdkrxfgwSCkUOog==", "1fdbaa6d-397e-4933-91ef-7d64680339ed" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3961",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8a0d3f4-f41e-4f04-9564-d962fba3ce6c", "AQAAAAEAACcQAAAAEA5vAEf5/iO5j2fp+O/Xa8ikoq3vAtYIPydYZI6DOuGbrishYeedzL9qktoKKwRrcQ==", "6c59ac5d-266b-4cb6-b0c3-4dc225bb8c8b" });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "ID", "CreationDate", "Name", "UpdateDate" },
                values: new object[] { 1, new DateTime(2021, 6, 29, 17, 28, 43, 422, DateTimeKind.Local).AddTicks(7539), "AccountUser", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf1");

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "94081b80-cbdf-4d9c-8c7f-7874ffce6ce3", "AQAAAAEAACcQAAAAENvsx/HjEacQ6p1py72HOuYrmNNgV1QPsYp6wTQ6vFRv0vIwU998X/yUOBAh7XJm5Q==", "764df601-6ac1-49f9-800e-e1fd95112cca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3950",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8096d23c-00d3-4a6e-b537-3f08a6b0890e", "AQAAAAEAACcQAAAAEH+NIwXcnAa3ZIn1PLeiRbz5KDyxkXVGv/Rwd9rH3MjaAEfj+5KPiXxGm9E9YbD+hA==", "0c0af987-bbf4-417d-a38c-f3f666e9d6bf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3961",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca97f20f-cd11-47c1-a0e0-e467163f428e", "AQAAAAEAACcQAAAAEEwOYOOq1zC5017UCTYCp/X9z+BhqS2gFXZPLdviDkgQfdv3QJxZYJWQ+8biym9mPQ==", "8ee3bf94-41eb-47b0-a8d3-4c8ff037682e" });
        }
    }
}
