using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Data.Migrations
{
    public partial class AddProviderSMSEntity : Migration
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

            migrationBuilder.CreateTable(
                name: "ProviderSMS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    URL = table.Column<string>(nullable: true),
                    TimeOut = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    UserPassword = table.Column<string>(nullable: true),
                    SenderName = table.Column<string>(nullable: true),
                    ProviderID = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderSMS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProviderSMSParams",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    ProviderSMSID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderSMSParams", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProviderSMSParams_ProviderSMS_ProviderSMSID",
                        column: x => x.ProviderSMSID,
                        principalTable: "ProviderSMS",
                        principalColumn: "ID");
                });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 11, 24, 11, 42, 5, 498, DateTimeKind.Local).AddTicks(9429));

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 11, 24, 11, 42, 5, 498, DateTimeKind.Local).AddTicks(9468));

            migrationBuilder.UpdateData(
                table: "Entities",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 11, 24, 11, 42, 5, 499, DateTimeKind.Local).AddTicks(254));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 11, 24, 11, 42, 5, 497, DateTimeKind.Local).AddTicks(531));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 11, 24, 11, 42, 5, 498, DateTimeKind.Local).AddTicks(452));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "ID",
                keyValue: 11,
                column: "CreationDate",
                value: new DateTime(2021, 11, 24, 11, 42, 5, 498, DateTimeKind.Local).AddTicks(474));

            migrationBuilder.CreateIndex(
                name: "IX_ProviderSMSParams_ProviderSMSID",
                table: "ProviderSMSParams",
                column: "ProviderSMSID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProviderSMSParams");

            migrationBuilder.DropTable(
                name: "ProviderSMS");

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
