using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Data.Migrations
{
    public partial class editAccountChannelStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "AccountChannels",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 15, 14, 28, 35, 351, DateTimeKind.Local).AddTicks(6835));

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 8, 15, 14, 28, 35, 351, DateTimeKind.Local).AddTicks(6909));

            migrationBuilder.UpdateData(
                table: "Entities",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 15, 14, 28, 35, 351, DateTimeKind.Local).AddTicks(8155));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 15, 14, 28, 35, 349, DateTimeKind.Local).AddTicks(5803));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "Status",
                table: "AccountChannels",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 10, 18, 46, 23, 811, DateTimeKind.Local).AddTicks(1394));

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 8, 10, 18, 46, 23, 811, DateTimeKind.Local).AddTicks(1469));

            migrationBuilder.UpdateData(
                table: "Entities",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 10, 18, 46, 23, 811, DateTimeKind.Local).AddTicks(2843));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 10, 18, 46, 23, 808, DateTimeKind.Local).AddTicks(5734));
        }
    }
}
