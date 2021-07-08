using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Data.Migrations
{
    public partial class ChangeAccountTypeProfileEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AccountTypes_AccountTypeID",
                table: "Accounts");

            migrationBuilder.DropTable(
                name: "AccountProfiles");

            migrationBuilder.DropColumn(
                name: "AccountProfileID",
                table: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "AccountTypeProfileID",
                table: "Accounts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AccountTypeProfiles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    AccountTypeID = table.Column<int>(nullable: false),
                    ProfileID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypeProfiles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AccountTypeProfiles_AccountTypes_AccountTypeID",
                        column: x => x.AccountTypeID,
                        principalTable: "AccountTypes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_AccountTypeProfiles_Profiles_ProfileID",
                        column: x => x.ProfileID,
                        principalTable: "Profiles",
                        principalColumn: "ID");
                });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 7, 6, 11, 36, 21, 649, DateTimeKind.Local).AddTicks(9813));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec24cd5b-e4d8-4c68-a082-2ad222ba4473", "AQAAAAEAACcQAAAAEGWXSitzH/SsATRABpicAtMh+iPCy8I6Zxcf0mn743zM+S2riar4manzp9kxNB3cuA==", "72f28c7f-7e9a-4d04-bf2c-62cb1f8dc50b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3950",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a684ced3-1ff4-4f32-aedd-06c507d49f22", "AQAAAAEAACcQAAAAEPWODQnARLpPe8Y8J5HVXff5Xwn5eeyrhyPuXy3LiXCiQP+9PAB85i4rZoU144rmTQ==", "459281d2-deab-4ebd-93f0-f43c7d4b0b1f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3961",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "037664ce-7d65-42b7-b777-52b56f8d3c4c", "AQAAAAEAACcQAAAAEKuxBBo+2iz8hemzjr4QfUlXtkIIIpQM7VsaMLhy6ncZLyiAcJGwKXR+vqbYB7aRIg==", "e6ca0634-0506-461b-8c5a-179cf3e004bd" });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 7, 6, 11, 36, 21, 647, DateTimeKind.Local).AddTicks(7976));

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountTypeProfileID",
                table: "Accounts",
                column: "AccountTypeProfileID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTypeProfiles_AccountTypeID",
                table: "AccountTypeProfiles",
                column: "AccountTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTypeProfiles_ProfileID",
                table: "AccountTypeProfiles",
                column: "ProfileID");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AccountTypes_AccountTypeID",
                table: "Accounts",
                column: "AccountTypeID",
                principalTable: "AccountTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AccountTypeProfiles_AccountTypeProfileID",
                table: "Accounts",
                column: "AccountTypeProfileID",
                principalTable: "AccountTypeProfiles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AccountTypes_AccountTypeID",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AccountTypeProfiles_AccountTypeProfileID",
                table: "Accounts");

            migrationBuilder.DropTable(
                name: "AccountTypeProfiles");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_AccountTypeProfileID",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AccountTypeProfileID",
                table: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "AccountProfileID",
                table: "Accounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AccountProfiles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountTypeID = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfileID = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountProfiles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AccountProfiles_AccountTypes_AccountTypeID",
                        column: x => x.AccountTypeID,
                        principalTable: "AccountTypes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_AccountProfiles_Profiles_ProfileID",
                        column: x => x.ProfileID,
                        principalTable: "Profiles",
                        principalColumn: "ID");
                });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 7, 6, 11, 22, 0, 616, DateTimeKind.Local).AddTicks(8803));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77c82310-300b-4de9-b5f6-1936c77cf524", "AQAAAAEAACcQAAAAEAMYUM8XA92ZezoQlNy5E8V8livuR4eOQBXPKJoMAzf1iKhgKVkx9gbpnOBRyPWymw==", "a707ae96-f50e-4e5d-9870-8a72610f72e2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3950",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "42dbf8b7-a9a4-4f08-a699-b5af0aa42f22", "AQAAAAEAACcQAAAAEO88LejUOMlqjQkK+Rlv5vCcJmtC4ERWO6L4bUB5+u6QaNQNgrAHSp0sZSoo2PSFwQ==", "67b699a6-ec34-4061-98fe-4360bf60d540" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3961",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dca9ee21-baa0-41c3-a7f1-7a83ff361b30", "AQAAAAEAACcQAAAAEN2y/XN6v+6UvHtYKfYT6LWX6P8e2utQvaTgNa4u53Ho5nsnzEsIor5+zvHq9/16xg==", "35345a9b-3a75-49fb-97b1-bbd034ad72ac" });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 7, 6, 11, 22, 0, 614, DateTimeKind.Local).AddTicks(8095));

            migrationBuilder.CreateIndex(
                name: "IX_AccountProfiles_AccountTypeID",
                table: "AccountProfiles",
                column: "AccountTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountProfiles_ProfileID",
                table: "AccountProfiles",
                column: "ProfileID");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AccountTypes_AccountTypeID",
                table: "Accounts",
                column: "AccountTypeID",
                principalTable: "AccountTypes",
                principalColumn: "ID");
        }
    }
}
