using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Migrations
{
    public partial class ChangeStatusEnumType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "Status",
                table: "Profiles",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<short>(
                name: "Status",
                table: "ChannelIdentifiers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<short>(
                name: "Status",
                table: "AccountTypes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<short>(
                name: "Active",
                table: "Accounts",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<short>(
                name: "AccountRequestStatus",
                table: "AccountRequest",
                nullable: false,
                defaultValue: (short)1,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<short>(
                name: "Status",
                table: "AccountChannels",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Profiles",
                type: "int",
                nullable: false,
                oldClrType: typeof(short));

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "ChannelIdentifiers",
                type: "int",
                nullable: false,
                oldClrType: typeof(short));

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "AccountTypes",
                type: "int",
                nullable: false,
                oldClrType: typeof(short));

            migrationBuilder.AlterColumn<int>(
                name: "Active",
                table: "Accounts",
                type: "int",
                nullable: false,
                oldClrType: typeof(short));

            migrationBuilder.AlterColumn<int>(
                name: "AccountRequestStatus",
                table: "AccountRequest",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(short),
                oldDefaultValue: (short)1);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "AccountChannels",
                type: "int",
                nullable: false,
                oldClrType: typeof(short));

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
        }
    }
}
