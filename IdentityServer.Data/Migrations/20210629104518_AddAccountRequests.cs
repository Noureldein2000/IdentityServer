using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Data.Migrations
{
    public partial class AddAccountRequests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activity",
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
                    table.PrimaryKey("PK_Activity", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AccountRequest",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    OwnerName = table.Column<string>(maxLength: 255, nullable: true),
                    AccountName = table.Column<string>(maxLength: 255, nullable: true),
                    Mobile = table.Column<string>(maxLength: 15, nullable: true),
                    Address = table.Column<string>(maxLength: 255, nullable: true),
                    Email = table.Column<string>(maxLength: 255, nullable: true),
                    NationalID = table.Column<string>(maxLength: 255, nullable: true),
                    CommercialRegistrationNo = table.Column<string>(maxLength: 50, nullable: true),
                    TaxNo = table.Column<string>(maxLength: 50, nullable: true),
                    ActivityID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountRequest", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AccountRequest_Activity_ActivityID",
                        column: x => x.ActivityID,
                        principalTable: "Activity",
                        principalColumn: "ID");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f1613391-f7b1-41a6-8753-32faab4aac2c", "AQAAAAEAACcQAAAAEK5mFxds7T8sVsQuq76xp55dyLiSkJA/A9hb7lmKVsLAoYp3G62SuO6Pr6laszTL2g==", "961e3081-9d9c-4cb9-baaa-975e3d9fab2d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3950",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "98e148ee-5763-4310-be4f-aa627b25d4a2", "AQAAAAEAACcQAAAAELSpRwssF3zJg3hZKGDZ795i4CeayNNCcELE1cxMfbU0HrPFfl+qIHq0n/Y3hGgsPg==", "36313dc7-c057-46c4-b7b5-65465a7ffdcc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3961",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad95031f-ce15-408a-801f-a724392ec222", "AQAAAAEAACcQAAAAEPWzCTHQRBHF/k8dRdETJ6PolRPgBOzU8ANvW+v1d7YBoEfg7V6EaaqhtMPUQTeSIA==", "245dae98-48cc-4979-88c5-ee0e93ba19cc" });

            migrationBuilder.CreateIndex(
                name: "IX_AccountRequest_ActivityID",
                table: "AccountRequest",
                column: "ActivityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountRequest");

            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9bcc1363-4f8f-4302-beff-e054691b0264", "AQAAAAEAACcQAAAAEFOMyKDhe08/iDKHjDOxyiCMxq6YXpHOcasXqOHME28cH+UHKvLmq0Q5S9Y56rVsIA==", "ca90a8da-fdc8-4920-b62a-504a4b6981d1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3950",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7cb7130b-9dc3-477a-9ef7-3471b94ab56e", "AQAAAAEAACcQAAAAEOLtVVawfVWMyqe/RiUKPoIwWndYQhUyPsga6a+JAbiZu1wd5V1S9ljrI/ZiuztNtw==", "09396f3c-1003-4938-b692-40410d0e4fa5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3961",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d211f6e-e1f4-4e06-8b80-42a64b574fab", "AQAAAAEAACcQAAAAEOqjHPv2CsPt0ab/B9E51pjrDvy3UHQDgxM2OKhlk/aPw3TXMR0o0G+uPx9vvBMLMA==", "ab787f67-7b21-4596-916a-018da25e45c5" });
        }
    }
}
