using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Migrations
{
    public partial class ModifyAccountEntityAccountOwnerUSerTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AllowTransfeer",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "CenterName",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "CentralName",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "ChgTime",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "CommNo",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Date_To",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Last_login",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Logged_In",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "MachineCode",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "OwnerName",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Serial",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "TotalPoints",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "UserUpdate",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "edDesc",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "is_agent",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "last_channel",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "last_logout",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "sim_no",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "ReferenceID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserTypeID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountOwnerID",
                table: "Accounts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CommertialRegistrationNo",
                table: "Accounts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "Accounts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Accounts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateBy",
                table: "Accounts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "longitude",
                table: "Accounts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AccountOwners",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NationalID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountOwners", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ChannelSims",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    ChannelID = table.Column<int>(nullable: false),
                    SimNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChannelSims", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ChannelSims_Channels_ChannelID",
                        column: x => x.ChannelID,
                        principalTable: "Channels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AccountOwnerContacts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    AccountOwnerID = table.Column<int>(nullable: false),
                    Mobile = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountOwnerContacts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AccountOwnerContacts_AccountOwners_AccountOwnerID",
                        column: x => x.AccountOwnerID,
                        principalTable: "AccountOwners",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserTypeID",
                table: "AspNetUsers",
                column: "UserTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountOwnerID",
                table: "Accounts",
                column: "AccountOwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountOwnerContacts_AccountOwnerID",
                table: "AccountOwnerContacts",
                column: "AccountOwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_ChannelSims_ChannelID",
                table: "ChannelSims",
                column: "ChannelID");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AccountOwners_AccountOwnerID",
                table: "Accounts",
                column: "AccountOwnerID",
                principalTable: "AccountOwners",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserTypes_UserTypeID",
                table: "AspNetUsers",
                column: "UserTypeID",
                principalTable: "UserTypes",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AccountOwners_AccountOwnerID",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserTypes_UserTypeID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AccountOwnerContacts");

            migrationBuilder.DropTable(
                name: "ChannelSims");

            migrationBuilder.DropTable(
                name: "UserTypes");

            migrationBuilder.DropTable(
                name: "AccountOwners");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserTypeID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_AccountOwnerID",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "ReferenceID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserTypeID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AccountOwnerID",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "CommertialRegistrationNo",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "longitude",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AllowTransfeer",
                table: "Accounts",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CenterName",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CentralName",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ChgTime",
                table: "Accounts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CommNo",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Date_To",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Last_login",
                table: "Accounts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Logged_In",
                table: "Accounts",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MachineCode",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerName",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Serial",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalPoints",
                table: "Accounts",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserUpdate",
                table: "Accounts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "edDesc",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_agent",
                table: "Accounts",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "last_channel",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_logout",
                table: "Accounts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "sim_no",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

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
    }
}
