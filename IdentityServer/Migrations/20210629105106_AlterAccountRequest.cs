using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Migrations
{
    public partial class AlterAccountRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "AccountRequest",
                nullable: false,
                defaultValue: false);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "AccountRequest");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "821fe04a-b76c-4305-a150-2fd28b315b59", "AQAAAAEAACcQAAAAEHo8LNczNIft0G/PUkdNDVKX9w01vVV1PzANuTui1xUGBNOzq/t48JqEm0zwcq2nrA==", "f6a5ad7a-ee68-428c-b969-5c6143d99146" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3950",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d0215a1-0c04-4314-94be-5cdca266237c", "AQAAAAEAACcQAAAAEK+b2vvoof5BIKnIpy/bRPkFuikF/VIha1NQzQD3SLgrO+5tYyf/YecFYHNGr5ehbw==", "41611cb9-9406-4f0c-9898-4ce7fb97ea84" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3961",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e57ce46f-94f2-452e-880a-7983c3c0a630", "AQAAAAEAACcQAAAAEMjuT1IswCqQkiypLTOhV8yBuqC41VXjuDDMH4OuHTMgAk1BtLSvq6GiE4jheLHL8w==", "fff6a26b-7dcc-4ab7-a48f-513e3a013b35" });
        }
    }
}
