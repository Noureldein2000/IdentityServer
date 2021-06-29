using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Migrations
{
    public partial class AccountCommercialName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommertialRegistrationNo",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "NationalId",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "CommercialRegistrationNo",
                table: "Accounts",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "feb4b82f-0d0c-40e5-8703-c6328e578ca7", "AQAAAAEAACcQAAAAEGo/KCetiMHs1Kw8U/GK9xbSgzEOtPpcmx0b0uPVRQrn9j81RM6zCnv/eV2a4Hq+Yg==", "1a4d68d4-0bc2-480b-9063-8d50d5d88fe7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3950",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ebdd9cd3-c7a4-439b-bd96-ddb525af8562", "AQAAAAEAACcQAAAAEDdWjjIuIcTs1m7C0tXEom5I/oBqAjCZ6Y4KiT+2g0t+F0ZA9OqwENQ2XAPFXSFiyQ==", "57c7225a-0267-4612-a12e-0d07db9792ec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3961",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "feb86e19-b979-4006-a2ea-78bbd80c2b22", "AQAAAAEAACcQAAAAEGjvsIjopS+fR860ilGSXVABST0Rg9zi070e91WPydCcPjdmpnLKR98ZBHdpVZW/0Q==", "d0e32e6b-c4d3-41f0-8485-4b9ff4b97cbc" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommercialRegistrationNo",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "CommertialRegistrationNo",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NationalId",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e54c1a8-36df-4068-b01d-595767bca172", "AQAAAAEAACcQAAAAEKMV2asdE4tFnkG0vXoaCjxTnlfShDfjPYaZB6L+bMnoC62p2pxER3WwA/Q+KcrycA==", "fcf6492f-c452-413f-b5b2-e5408ff3da8b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3950",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5efd1d8e-50b2-40fd-a1c2-08716d545add", "AQAAAAEAACcQAAAAEOHOD64U9rXCDip/+Ps2V4hpEuJQJy0+630AfNtSvJC/J4t9OLChzaksorpnuyeNdg==", "298648f9-aa40-4934-a5c7-6751c6e80df6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3961",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b147703-f407-4e30-84a4-977f3c9eaa2d", "AQAAAAEAACcQAAAAEFE1lNozVoKCuV6nsfxWLbZ6L5VfvjE80FKHJcQTlw+KFFYGKrlflu0aSE1zpeYcEQ==", "98958caf-bf98-4cf8-b6a0-35faebfaef77" });
        }
    }
}
