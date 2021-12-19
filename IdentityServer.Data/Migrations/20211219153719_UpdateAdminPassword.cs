using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Data.Migrations
{
    public partial class UpdateAdminPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OTPs_AccountChannelHistories_AccountChannelHistoryID",
                table: "OTPs");

            migrationBuilder.DropIndex(
                name: "IX_OTPs_AccountChannelHistoryID",
                table: "OTPs");

            migrationBuilder.DropColumn(
                name: "AccountChannelHistoryID",
                table: "OTPs");

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 12, 19, 17, 37, 19, 355, DateTimeKind.Local).AddTicks(6834));

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 12, 19, 17, 37, 19, 355, DateTimeKind.Local).AddTicks(6867));

            migrationBuilder.UpdateData(
                table: "Entities",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 12, 19, 17, 37, 19, 355, DateTimeKind.Local).AddTicks(7595));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 12, 19, 17, 37, 19, 354, DateTimeKind.Local).AddTicks(2044));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 12, 19, 17, 37, 19, 354, DateTimeKind.Local).AddTicks(8661));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "ID",
                keyValue: 11,
                column: "CreationDate",
                value: new DateTime(2021, 12, 19, 17, 37, 19, 354, DateTimeKind.Local).AddTicks(8679));

            migrationBuilder.Sql("Update AspNetUsers SET PasswordHash = '3b1abd4308d5468a5126ebb5c0f24d1915b8ab1894598b0f517465fbbd8bac86' WHERE Id = 'd5a9b78e-a694-4026-af7f-6d559d8a3950'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountChannelHistoryID",
                table: "OTPs",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 9, 5, 15, 46, 49, 344, DateTimeKind.Local).AddTicks(1732));

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 9, 5, 15, 46, 49, 344, DateTimeKind.Local).AddTicks(1774));

            migrationBuilder.UpdateData(
                table: "Entities",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 9, 5, 15, 46, 49, 344, DateTimeKind.Local).AddTicks(2802));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 9, 5, 15, 46, 49, 342, DateTimeKind.Local).AddTicks(380));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 9, 5, 15, 46, 49, 343, DateTimeKind.Local).AddTicks(921));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "ID",
                keyValue: 11,
                column: "CreationDate",
                value: new DateTime(2021, 9, 5, 15, 46, 49, 343, DateTimeKind.Local).AddTicks(947));

            migrationBuilder.CreateIndex(
                name: "IX_OTPs_AccountChannelHistoryID",
                table: "OTPs",
                column: "AccountChannelHistoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_OTPs_AccountChannelHistories_AccountChannelHistoryID",
                table: "OTPs",
                column: "AccountChannelHistoryID",
                principalTable: "AccountChannelHistories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
