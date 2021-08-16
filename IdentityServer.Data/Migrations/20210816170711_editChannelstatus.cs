using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Data.Migrations
{
    public partial class editChannelstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ChannelIdentifiers_ChannelID",
                table: "ChannelIdentifiers");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "ChannelIdentifiers",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 16, 19, 7, 11, 299, DateTimeKind.Local).AddTicks(773));

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 8, 16, 19, 7, 11, 299, DateTimeKind.Local).AddTicks(886));

            migrationBuilder.UpdateData(
                table: "Entities",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 16, 19, 7, 11, 299, DateTimeKind.Local).AddTicks(3173));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 16, 19, 7, 11, 296, DateTimeKind.Local).AddTicks(2187));

            migrationBuilder.CreateIndex(
                name: "IX_ChannelIdentifiers_ChannelID",
                table: "ChannelIdentifiers",
                column: "ChannelID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ChannelIdentifiers_ChannelID",
                table: "ChannelIdentifiers");

            migrationBuilder.AlterColumn<short>(
                name: "Status",
                table: "ChannelIdentifiers",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 15, 18, 0, 25, 244, DateTimeKind.Local).AddTicks(6098));

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 8, 15, 18, 0, 25, 244, DateTimeKind.Local).AddTicks(6185));

            migrationBuilder.UpdateData(
                table: "Entities",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 15, 18, 0, 25, 244, DateTimeKind.Local).AddTicks(7637));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 15, 18, 0, 25, 241, DateTimeKind.Local).AddTicks(9252));

            migrationBuilder.CreateIndex(
                name: "IX_ChannelIdentifiers_ChannelID",
                table: "ChannelIdentifiers",
                column: "ChannelID");
        }
    }
}
