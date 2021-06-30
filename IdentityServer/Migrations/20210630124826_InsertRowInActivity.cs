using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Migrations
{
    public partial class InsertRowInActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "Activity",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Activity",
                columns: new[] { "ID", "CreationDate", "Name", "NameAr", "UpdateDate" },
                values: new object[] { 1, new DateTime(2021, 6, 30, 14, 48, 25, 943, DateTimeKind.Local).AddTicks(2930), "SuperMarket", "سوبرماركت", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d512f1ce-96aa-4175-b39b-7e0654de666d", "AQAAAAEAACcQAAAAEH0t1THZh6xXUIu62FCr9y7Z2Mw9nN94WNj1KBVptiUIQiH66vsJALi29N5g1MdINA==", "bdf400eb-9b75-4e01-bf82-61301f9027ca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3950",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2c9576a3-88d4-4a40-8b1a-f385f25cc312", "AQAAAAEAACcQAAAAEObgiGf2tsSwIxKHHRtaN7jmxu16TzLEWXTaH0fFZaNXxrw6BNt19aW7I87+Tg10cw==", "e83b0a4a-594c-4433-85e2-02b93a6e0a18" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3961",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1becb078-8001-4a8d-86cd-21e6fff877cd", "AQAAAAEAACcQAAAAEKTw60riCEj4q9Ldx/IXUfWW8PYIkPSQ4VWEMmoPMmmf/oJ+/PoUfsvqxjXniTZc8Q==", "9b20c46e-2d43-43d9-acdb-03f5d14a4da6" });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 6, 30, 14, 48, 25, 941, DateTimeKind.Local).AddTicks(3241));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "Activity");

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
    }
}
