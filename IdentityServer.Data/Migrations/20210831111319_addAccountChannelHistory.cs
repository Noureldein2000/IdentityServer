using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Data.Migrations
{
    public partial class addAccountChannelHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountChannelHistoryID",
                table: "OTPs",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AccountChannelHistories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    AccountID = table.Column<int>(nullable: false),
                    ChannelID = table.Column<int>(nullable: false),
                    Status = table.Column<short>(nullable: false),
                    Reason = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountChannelHistories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AccountChannelHistories_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_AccountChannelHistories_Channels_ChannelID",
                        column: x => x.ChannelID,
                        principalTable: "Channels",
                        principalColumn: "ID");
                });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 31, 13, 13, 18, 500, DateTimeKind.Local).AddTicks(2113));

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 8, 31, 13, 13, 18, 500, DateTimeKind.Local).AddTicks(2171));

            migrationBuilder.UpdateData(
                table: "Entities",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 31, 13, 13, 18, 500, DateTimeKind.Local).AddTicks(3193));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 31, 13, 13, 18, 498, DateTimeKind.Local).AddTicks(1168));

            migrationBuilder.CreateIndex(
                name: "IX_OTPs_AccountChannelHistoryID",
                table: "OTPs",
                column: "AccountChannelHistoryID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountChannelHistories_AccountID",
                table: "AccountChannelHistories",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountChannelHistories_ChannelID",
                table: "AccountChannelHistories",
                column: "ChannelID");

            migrationBuilder.AddForeignKey(
                name: "FK_OTPs_AccountChannelHistories_AccountChannelHistoryID",
                table: "OTPs",
                column: "AccountChannelHistoryID",
                principalTable: "AccountChannelHistories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OTPs_AccountChannelHistories_AccountChannelHistoryID",
                table: "OTPs");

            migrationBuilder.DropTable(
                name: "AccountChannelHistories");

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
                value: new DateTime(2021, 8, 29, 15, 38, 42, 850, DateTimeKind.Local).AddTicks(1916));

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 8, 29, 15, 38, 42, 850, DateTimeKind.Local).AddTicks(1969));

            migrationBuilder.UpdateData(
                table: "Entities",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 29, 15, 38, 42, 850, DateTimeKind.Local).AddTicks(2937));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 29, 15, 38, 42, 848, DateTimeKind.Local).AddTicks(2506));
        }
    }
}
