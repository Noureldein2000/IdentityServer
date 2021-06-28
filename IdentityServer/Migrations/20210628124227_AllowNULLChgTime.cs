using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Migrations
{
    public partial class AllowNULLChgTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "OTPs",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "StatusID",
                table: "OTPs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ChgTime",
                table: "Accounts",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87bc28c4-1a1b-4dfd-b191-7b9388cb5648", "AQAAAAEAACcQAAAAEC6Rx2J4Diqg/5vgIjOnuWD+0xS5JpGEzaHiKtEPjqN5/hTCwPgYfR7Af/4BcyLscg==", "6b213145-292b-4775-9d8d-0bce34fb05fd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3950",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b0b98889-9e08-4e22-a54c-5eec62059d53", "AQAAAAEAACcQAAAAEJIU+4iJzQljBBZZrJr56mPfbGdo6GF9L5hUPHbxyQnpiJKJdth1ArYtuIqv/MU2VQ==", "a930d226-c800-428c-b132-b8d3e11fc824" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3961",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05d8be0a-3c1a-44cc-8155-2ef6eb42b1ba", "AQAAAAEAACcQAAAAEBrglkWbaf3zLWBRePyiLBqsSKCwUgSM7e+UtGQqV97S2qtpGVSNvRQO44zlbSVbog==", "52b7aaa3-d1a3-4ee2-ba00-2a651f14933d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusID",
                table: "OTPs");

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "OTPs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ChgTime",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6df289b-3ae0-4c11-a5ee-e9184f9e2506", "AQAAAAEAACcQAAAAELIYfc9SFwecNXKZK3zRIyGCmwN4stNRcIeoUvb4sZ8fau99oyi4xBT41qx4EejRLA==", "60f1b0ae-0808-4c64-9af7-f05a4d706678" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3950",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b312b93-70a0-4c79-b835-62c46ec54f03", "AQAAAAEAACcQAAAAECNwew74ypFxGTpcX22lSg+/cc9Vyn4dgLHDNfVIdA956pNJLC2VQ66tKKUcEipHyA==", "e0a2094b-f0d7-43bf-91ce-7bbb1e6252b5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3961",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "366a1836-8acb-461c-b163-f4ac9739c9ec", "AQAAAAEAACcQAAAAEO6YXk9ss++nV2TkJUjLvoQWTQCwqJnK9W0pIKqsGCSJ28EDiD60j0PEId6jLUkDzQ==", "6554b82e-5180-4b3f-bd32-02186e58fca6" });
        }
    }
}
