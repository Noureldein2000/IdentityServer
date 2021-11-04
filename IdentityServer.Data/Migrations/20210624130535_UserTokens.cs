using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Data.Migrations
{
    public partial class UserTokens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: true),
                    UserID = table.Column<string>(nullable: false),
                    Token = table.Column<string>(nullable: false),
                    IsValid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "72063bd4-f5af-4bad-9424-f9dde1f9e231", "AQAAAAEAACcQAAAAEBmK3smFVoUIsbPBEFf3BjAVQ7Hw12yF6D4vgjhcWU+t+lQzjDZmpYJ0hmrqBYBV0Q==", "9a9900f7-f6bd-4ca5-a93e-97a7846fe0b8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3950",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3273667-3ccb-4ba0-9478-00f39c4c0646", "AQAAAAEAACcQAAAAEDOkvSFWJAq/faoEwXjY04WqXcm4NW1bX+X5cC0eNuWj/VchlCH1DatGtKQHCCYMXQ==", "cb0e414d-93e0-49f5-bf88-85cd868844f7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3961",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9df83425-a390-48c2-9dcb-fb8968ea53ca", "AQAAAAEAACcQAAAAEIc5v8RbfV8TLAbVjJAmPhJ46M1Qszecyzreg8Q6Uw5oFrIpnhkriu/n7fvdW3FaxA==", "7bc0fec3-d560-465f-b8c4-ac07b173a53f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9acbf05b-eed2-43cc-aad6-7780346c50d1", "AQAAAAEAACcQAAAAEAY6bWk/eqm/yazYItFZmqCLm/rudU4LuWDvtvHtracFaT4+6LIRwXgfZe53qGc64Q==", "06ee6928-e465-4606-9d48-2fb294b8688e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3950",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "733a9ee9-abee-43eb-9739-24b9c2bb0ccc", "AQAAAAEAACcQAAAAEK6ILsO1FNyT83knIzRvHjzM1W17b+TY9AAeUuPOONiA4Ryf6BW7516UHT+Xfq1znQ==", "7c23d452-4459-4925-ae35-e8b74c0b008f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3961",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a9a148c2-af0b-4045-928b-b610020d9645", "AQAAAAEAACcQAAAAEFZjbBjmwboSyjJfVNLBT2fe1khLjbZ8mhjkwAT77Qdn85pKDdJ87G4OPlEtdy96EA==", "65de4970-c056-4753-ac6a-f2a862bf18bf" });
        }
    }
}
