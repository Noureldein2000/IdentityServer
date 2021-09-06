using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Data.Migrations
{
    public partial class addUserTypeSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "CreationDate", "Name" },
                values: new object[] { new DateTime(2021, 9, 5, 15, 46, 49, 342, DateTimeKind.Local).AddTicks(380), "ConsumerAccount" });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "ID", "CreationDate", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { 2, new DateTime(2021, 9, 5, 15, 46, 49, 343, DateTimeKind.Local).AddTicks(921), "AdminAccount", null },
                    { 11, new DateTime(2021, 9, 5, 15, 46, 49, 343, DateTimeKind.Local).AddTicks(947), "Company", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "ID",
                keyValue: 11);

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
                columns: new[] { "CreationDate", "Name" },
                values: new object[] { new DateTime(2021, 8, 31, 13, 13, 18, 498, DateTimeKind.Local).AddTicks(1168), "AccountUser" });
        }
    }
}
