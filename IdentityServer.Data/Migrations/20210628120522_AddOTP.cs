using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Data.Migrations
{
    public partial class AddOTP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OTPs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    AccountChannelID = table.Column<int>(nullable: false),
                    OTPCode = table.Column<string>(nullable: true),
                    SmsSequence = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: false),
                    LocalIP = table.Column<string>(nullable: true),
                    AccountIP = table.Column<string>(nullable: true),
                    OriginalOTPID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OTPs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OTPs_AccountChannels_AccountChannelID",
                        column: x => x.AccountChannelID,
                        principalTable: "AccountChannels",
                        principalColumn: "ID");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_OTPs_AccountChannelID",
                table: "OTPs",
                column: "AccountChannelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OTPs");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "44d9f16d-5bee-460e-abe3-a1006d825544", "AQAAAAEAACcQAAAAEPAJLv+A+OzgpR1LgmKGCDTyJOw5cLQxwhj+e4jJ9s7P6Llt1G3zlpDkO5hQ4M5iJQ==", "1b4c59d3-a3bb-4c59-948a-6d5dbd4bd295" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3950",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "135e460b-26e6-4554-8d5b-26599c8c708c", "AQAAAAEAACcQAAAAEF+AwL7IjvVS82GiyvmBH42k1FPJ6Zh6LcNfCBDGzG3Rjs6yLqwku9tWgOfQSS8QnQ==", "c5302857-9c1b-488f-9489-51b52ac51252" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3961",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6e8446a-f124-4f76-928f-d803de0562ca", "AQAAAAEAACcQAAAAEG2N7w8DmsunuYZIc0esgqsCvdWISNoWuWb+vj1Du3/Rjenfkk+QPj1d8NNXWPFXYA==", "6b7e94f0-0c6b-4a25-8baa-12d322bab1ab" });
        }
    }
}
