using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Migrations
{
    public partial class ModifyAccountRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "AccountRequest");

            migrationBuilder.AlterColumn<string>(
                name: "TaxNo",
                table: "AccountRequest",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OwnerName",
                table: "AccountRequest",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NationalID",
                table: "AccountRequest",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Mobile",
                table: "AccountRequest",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CommercialRegistrationNo",
                table: "AccountRequest",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "AccountRequest",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AccountName",
                table: "AccountRequest",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountRequestStatus",
                table: "AccountRequest",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "446dd599-44e7-47de-aa75-03d76e19134c", "AQAAAAEAACcQAAAAEMasFCK9MmsKATOcR97vLp7SgCnTwqEtYoqH8DFlFofej+QO7J/tiBsGAts5ZD9i1g==", "2deac188-9d3a-4122-a8c5-d5b6bc9dfbbc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3950",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c7f18ba-fa2c-49cb-8526-ea672f3dcbb3", "AQAAAAEAACcQAAAAEKeJ9hJt8sPslm42LQEhvcJsdSxgeT02RT0TJaDvvmq6nmv/LKwFRrolLefhOd8e/g==", "326f4465-c226-4a32-810a-2532244701f9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3961",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c3fd645-cdc3-4a17-b394-f14b7607549b", "AQAAAAEAACcQAAAAEKS57hPtmn3dpVcoofRzUXvtqAcCB8iVTxqWqyOrnI22wjCGnx4R5lZkOAms5vuvgw==", "d60ab020-b092-49e4-868d-f76d34b25e3a" });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 6, 30, 14, 3, 59, 972, DateTimeKind.Local).AddTicks(7172));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountRequestStatus",
                table: "AccountRequest");

            migrationBuilder.AlterColumn<string>(
                name: "TaxNo",
                table: "AccountRequest",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "OwnerName",
                table: "AccountRequest",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "NationalID",
                table: "AccountRequest",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Mobile",
                table: "AccountRequest",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "CommercialRegistrationNo",
                table: "AccountRequest",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "AccountRequest",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "AccountName",
                table: "AccountRequest",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "AccountRequest",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 6, 29, 17, 28, 43, 422, DateTimeKind.Local).AddTicks(7539));
        }
    }
}
