using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Data.Migrations
{
    public partial class CreateEntityTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "longitude",
                table: "Accounts",
                newName: "Longitude");

            migrationBuilder.AddColumn<int>(
                name: "EntityID",
                table: "Accounts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DemonationEntities",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    DemonationID = table.Column<int>(nullable: false),
                    EntityID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemonationEntities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Entities",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entities", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 9, 13, 10, 40, 291, DateTimeKind.Local).AddTicks(257));

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2,
                column: "ClaimType",
                value: "FinancialReports");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3a176a3-b4e5-44fe-a5a5-dc44ac1cd760", "AQAAAAEAACcQAAAAEGBlbfiwYWYZ1cpnVRWY5y2V2bTH2mfW6ebhn6nlS9UHghmqyMTrp9v7Cg9Mm3+RFQ==", "ae3ab22b-7192-4ebb-9559-5e1c4197c3ae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3950",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "423619d7-beed-4929-8f39-013858d5123c", "AQAAAAEAACcQAAAAEGqTF+tPjToIhvUsawfSZZoobrweTRJgRfP5tSWuJ+1KMaJBHN5UgMqTm2B4asMX5Q==", "7a2292fd-6b77-46da-b4fe-6ba94a186784" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3961",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e4cfb5c5-5638-4743-afc1-fc2269e28687", "AQAAAAEAACcQAAAAEG1eRnVMN+lojbxNijLNO4kYsIdeygvInKy2rX6qyHucrt+dXe1I8mwoI3TLSnjNSg==", "14a9e229-fe6b-43d8-9369-e7c981a94d22" });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 9, 13, 10, 40, 288, DateTimeKind.Local).AddTicks(2938));

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_EntityID",
                table: "Accounts",
                column: "EntityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Entities_EntityID",
                table: "Accounts",
                column: "EntityID",
                principalTable: "Entities",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Entities_EntityID",
                table: "Accounts");

            migrationBuilder.DropTable(
                name: "DemonationEntities");

            migrationBuilder.DropTable(
                name: "Entities");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_EntityID",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "EntityID",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "Accounts",
                newName: "longitude");

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 7, 6, 13, 26, 1, 892, DateTimeKind.Local).AddTicks(9789));

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2,
                column: "ClaimType",
                value: "FinantialReports");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "420745c8-4d67-46d3-bc18-bd6111490785", "AQAAAAEAACcQAAAAEDyoo4EtQyYQJFnB6lhoa5iJHT58aRMMFSG7Sm4dbRxWB0Q8L+8yNHr8fo2n7JwlAw==", "f6bec819-c3fe-48cd-bd5a-4e0639960aeb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3950",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "07310a53-c8fa-4581-ae1a-3c772115ed71", "AQAAAAEAACcQAAAAELy5zO8zhQyyUL9/zW0HuCUM7y45q7zi9ijUykbrKWaC5jTFIAMacSAde8RPlqD8eA==", "a666bb88-e1b5-4daf-a32e-1cc4fcce1462" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3961",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8750bdd1-c2ae-4cf9-b87d-c07f0aeb9357", "AQAAAAEAACcQAAAAEMFjtqBn/ThOT47NEJY541IXsi8K4d+aO2Cj9Pit4XGHnSAgPKHMzvSPOHl1Q3fkpQ==", "8dbd385b-6795-43b7-9892-8a25026c03ac" });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 7, 6, 13, 26, 1, 890, DateTimeKind.Local).AddTicks(9129));
        }
    }
}
