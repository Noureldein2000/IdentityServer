using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Data.Migrations
{
    public partial class EditAccountEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountRequest_Regions_RegionID",
                table: "AccountRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AccountTypes_AccountTypeID",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AccountTypeProfiles_AccountTypeProfileID",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Regions_RegionID",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_AccountTypeID",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AccountTypeID",
                table: "Accounts");

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 7, 6, 13, 26, 1, 892, DateTimeKind.Local).AddTicks(9789));

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

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRequest_Regions_RegionID",
                table: "AccountRequest",
                column: "RegionID",
                principalTable: "Regions",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AccountTypeProfiles_AccountTypeProfileID",
                table: "Accounts",
                column: "AccountTypeProfileID",
                principalTable: "AccountTypeProfiles",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Regions_RegionID",
                table: "Accounts",
                column: "RegionID",
                principalTable: "Regions",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountRequest_Regions_RegionID",
                table: "AccountRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AccountTypeProfiles_AccountTypeProfileID",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Regions_RegionID",
                table: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "AccountTypeID",
                table: "Accounts",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 7, 6, 12, 18, 40, 81, DateTimeKind.Local).AddTicks(1487));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f9ac523a-66c1-46b2-9959-3fbd2bb2f59b", "AQAAAAEAACcQAAAAECQlE0WS4f1PSOgM685u2+jCfm158RAobWHas8RgWldNAQwih1lp7K3e5ubAz9cvzg==", "2e95c235-089e-48ae-92cc-324129051071" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3950",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41f0f0ef-cf9d-4b97-b662-699f04b12651", "AQAAAAEAACcQAAAAELlYWotD4SRkCslwfDF/xFlMCJAi50RV01StuarPuvT4MkcJ0Tc2vJfjMrRFIvbztQ==", "4db3939f-6ad8-49b7-b6e2-11b9083dcebc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3961",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3e0f19e-9a39-4773-9896-455ac26c4fe0", "AQAAAAEAACcQAAAAELcUTjALFMb62lR0/GqsyVNNWDIbpEq/RRnaGLpXwm+oJCOp48log2/b0YBEozYXxw==", "afd821ed-d7ed-4eda-9ee9-3e17aeddcbd8" });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 7, 6, 12, 18, 40, 79, DateTimeKind.Local).AddTicks(2671));

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountTypeID",
                table: "Accounts",
                column: "AccountTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRequest_Regions_RegionID",
                table: "AccountRequest",
                column: "RegionID",
                principalTable: "Regions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AccountTypes_AccountTypeID",
                table: "Accounts",
                column: "AccountTypeID",
                principalTable: "AccountTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AccountTypeProfiles_AccountTypeProfileID",
                table: "Accounts",
                column: "AccountTypeProfileID",
                principalTable: "AccountTypeProfiles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Regions_RegionID",
                table: "Accounts",
                column: "RegionID",
                principalTable: "Regions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
