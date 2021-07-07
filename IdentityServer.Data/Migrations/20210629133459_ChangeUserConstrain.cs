using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Data.Migrations
{
    public partial class ChangeUserConstrain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "ReferenceID",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserName_ReferenceID",
                table: "AspNetUsers",
                columns: new[] { "UserName", "ReferenceID" },
                unique: true,
                filter: "[UserName] IS NOT NULL AND [ReferenceID] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserName_ReferenceID",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "ReferenceID",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62e1d133-e7f4-455a-959d-82a40be8b082", "AQAAAAEAACcQAAAAEEUSAC2UL2KtSqTyIr+X+GPK8x4gFJxcI2csi0GcJbbH9ACEk1sdikpewj7rBgWdOw==", "02df0c60-2df0-45af-8818-254566b5aad4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3950",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d18e180e-25ca-48e5-ad79-cd3227b4e1ca", "AQAAAAEAACcQAAAAEAyeIhUA7ZDhk0RQKC4lAlDj79sBNr76yvDmfb8ac0oPaYNubl1WsVnALou/AneeZA==", "2d5f4dc5-e8c4-4543-bbd9-a4fa21a62e4a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3961",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a70023e0-159e-4e59-b683-1d61be40dd2f", "AQAAAAEAACcQAAAAEEwqif3Bc2lur6kfz8MMeWi+0tTchhL7zLkbTjzEwJ012NiNgqlHrit6ofsa0AvJtg==", "1a122ea3-943f-4201-8c42-eaf380ced4eb" });

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }
    }
}
