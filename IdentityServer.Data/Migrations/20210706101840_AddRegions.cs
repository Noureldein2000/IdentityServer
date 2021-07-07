using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Data.Migrations
{
    public partial class AddRegions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegionID",
                table: "Accounts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegionID",
                table: "AccountRequest",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Governorates",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governorates", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    GovernorateID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Regions_Governorates_GovernorateID",
                        column: x => x.GovernorateID,
                        principalTable: "Governorates",
                        principalColumn: "ID");
                });

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
                name: "IX_Accounts_RegionID",
                table: "Accounts",
                column: "RegionID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountRequest_RegionID",
                table: "AccountRequest",
                column: "RegionID");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_GovernorateID",
                table: "Regions",
                column: "GovernorateID");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRequest_Regions_RegionID",
                table: "AccountRequest",
                column: "RegionID",
                principalTable: "Regions",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountRequest_Regions_RegionID",
                table: "AccountRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Regions_RegionID",
                table: "Accounts");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Governorates");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_RegionID",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_AccountRequest_RegionID",
                table: "AccountRequest");

            migrationBuilder.DropColumn(
                name: "RegionID",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "RegionID",
                table: "AccountRequest");

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 7, 6, 12, 2, 14, 66, DateTimeKind.Local).AddTicks(2652));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "627dbcd6-9ded-4aad-8c18-af7fac9e7cd7", "AQAAAAEAACcQAAAAECC5o69mgJEjJyRZiyXRWeLPOu27zA14ijAjz/E4JHz6Yqe1G+LFaXluoZFUJIWRxg==", "1fff586c-8a30-496e-8483-c3640572d964" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3950",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd6ca053-0f65-43fc-9876-4b4d83a26730", "AQAAAAEAACcQAAAAEMTvaLqqTEJeXjmvrSOkVOKeCI86WSmrqg2r9hUz4CgJavqTbQecMtAfMcSO4YjkJg==", "dc8e2d55-0a53-41cd-b9a1-74fea5e517d2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3961",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "788ee157-29e5-460b-b724-65213960619f", "AQAAAAEAACcQAAAAEPJH6fmHL6jhOYoTVKnK2YHeYPpZQQtPNEK+C3hpO5yN/JtbyoH89XtsuLHGqsgZeA==", "7fc6accf-aa89-4e0d-a208-5a25b859cce6" });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 7, 6, 12, 2, 14, 63, DateTimeKind.Local).AddTicks(7164));
        }
    }
}
