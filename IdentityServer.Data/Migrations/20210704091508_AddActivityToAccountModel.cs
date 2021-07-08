using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Data.Migrations
{
    public partial class AddActivityToAccountModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activity",
                table: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "ActivityID",
                table: "Accounts",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 7, 4, 11, 15, 8, 20, DateTimeKind.Local).AddTicks(1653));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8facfb1e-3658-457f-9e23-4a65ca1582ce", "AQAAAAEAACcQAAAAEDbZ0TC29sh6yNol/Y41fm8bl49ZMzsDP2lubLaS9XlXbucigY15YU0hUPocHn/IXg==", "0c032b53-59d8-4da2-bf36-06824fb5f97b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3950",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "178ad76c-573d-4fde-9286-81aaaf8cd894", "AQAAAAEAACcQAAAAEGupMq8W44NiAoe9LVreYVyneRIZfqH+0wSbunX0vqXVl6YIjFcjRyB2JTnvPGhw5A==", "11f955fd-0e4c-40b0-9162-3a1d548bf3b2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3961",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d9559106-3bd6-4023-b90a-36cce3efcbd2", "AQAAAAEAACcQAAAAEGxDQgDGTUfaaXBKfvAN3zeGgbDKfM+vKl3tLG2Il2/UC6qzc7IU5LJwJZIG/DcGnQ==", "30734457-fd3a-4a32-b5fb-0aae338a8bc8" });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 7, 4, 11, 15, 8, 18, DateTimeKind.Local).AddTicks(1122));

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ActivityID",
                table: "Accounts",
                column: "ActivityID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountRequest_Mobile",
                table: "AccountRequest",
                column: "Mobile",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Activity_ActivityID",
                table: "Accounts",
                column: "ActivityID",
                principalTable: "Activity",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Activity_ActivityID",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_ActivityID",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_AccountRequest_Mobile",
                table: "AccountRequest");

            migrationBuilder.DropColumn(
                name: "ActivityID",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "Activity",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 6, 30, 14, 48, 25, 943, DateTimeKind.Local).AddTicks(2930));

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
    }
}
