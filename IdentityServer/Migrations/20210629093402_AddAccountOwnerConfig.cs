using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Migrations
{
    public partial class AddAccountOwnerConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AccountOwners_AccountOwnerID",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_AccountOwnerID",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AccountOwnerID",
                table: "Accounts");

            migrationBuilder.AlterColumn<string>(
                name: "NationalID",
                table: "AccountOwners",
                type: "nvarchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AccountOwners",
                type: "nvarchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Mobile",
                table: "AccountOwners",
                type: "nvarchar(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AccountOwners",
                type: "nvarchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "AccountOwners",
                type: "nvarchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountID",
                table: "AccountOwners",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9bcc1363-4f8f-4302-beff-e054691b0264", "AQAAAAEAACcQAAAAEFOMyKDhe08/iDKHjDOxyiCMxq6YXpHOcasXqOHME28cH+UHKvLmq0Q5S9Y56rVsIA==", "ca90a8da-fdc8-4920-b62a-504a4b6981d1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3950",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7cb7130b-9dc3-477a-9ef7-3471b94ab56e", "AQAAAAEAACcQAAAAEOLtVVawfVWMyqe/RiUKPoIwWndYQhUyPsga6a+JAbiZu1wd5V1S9ljrI/ZiuztNtw==", "09396f3c-1003-4938-b692-40410d0e4fa5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3961",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d211f6e-e1f4-4e06-8b80-42a64b574fab", "AQAAAAEAACcQAAAAEOqjHPv2CsPt0ab/B9E51pjrDvy3UHQDgxM2OKhlk/aPw3TXMR0o0G+uPx9vvBMLMA==", "ab787f67-7b21-4596-916a-018da25e45c5" });

            migrationBuilder.CreateIndex(
                name: "IX_AccountOwners_AccountID",
                table: "AccountOwners",
                column: "AccountID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountOwners_Accounts_AccountID",
                table: "AccountOwners",
                column: "AccountID",
                principalTable: "Accounts",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountOwners_Accounts_AccountID",
                table: "AccountOwners");

            migrationBuilder.DropIndex(
                name: "IX_AccountOwners_AccountID",
                table: "AccountOwners");

            migrationBuilder.DropColumn(
                name: "AccountID",
                table: "AccountOwners");

            migrationBuilder.AddColumn<int>(
                name: "AccountOwnerID",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "NationalID",
                table: "AccountOwners",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AccountOwners",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Mobile",
                table: "AccountOwners",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AccountOwners",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "AccountOwners",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountOwnerID",
                table: "Accounts",
                column: "AccountOwnerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AccountOwners_AccountOwnerID",
                table: "Accounts",
                column: "AccountOwnerID",
                principalTable: "AccountOwners",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
