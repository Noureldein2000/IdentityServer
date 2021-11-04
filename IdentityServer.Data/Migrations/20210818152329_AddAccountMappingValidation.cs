using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Data.Migrations
{
    public partial class AddAccountMappingValidation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountRelationMappings_Accounts_AccountId",
                table: "AccountRelationMappings");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "AccountRelationMappings",
                newName: "ParentID");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "AccountRelationMappings",
                newName: "AccountID");

            migrationBuilder.RenameIndex(
                name: "IX_AccountRelationMappings_AccountId",
                table: "AccountRelationMappings",
                newName: "IX_AccountRelationMappings_AccountID");

            migrationBuilder.CreateTable(
                name: "AccountMappingValidation",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    ParentID = table.Column<int>(nullable: false),
                    ChildID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountMappingValidation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AccountMappingValidation_AccountTypes_ChildID",
                        column: x => x.ChildID,
                        principalTable: "AccountTypes",
                        principalColumn: "ID");
                });

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 18, 17, 23, 28, 921, DateTimeKind.Local).AddTicks(179));

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 8, 18, 17, 23, 28, 921, DateTimeKind.Local).AddTicks(262));

            migrationBuilder.UpdateData(
                table: "Entities",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 18, 17, 23, 28, 921, DateTimeKind.Local).AddTicks(1335));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 18, 17, 23, 28, 918, DateTimeKind.Local).AddTicks(5410));

            migrationBuilder.CreateIndex(
                name: "IX_AccountMappingValidation_ChildID",
                table: "AccountMappingValidation",
                column: "ChildID");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRelationMappings_Accounts_AccountID",
                table: "AccountRelationMappings",
                column: "AccountID",
                principalTable: "Accounts",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountRelationMappings_Accounts_AccountID",
                table: "AccountRelationMappings");

            migrationBuilder.DropTable(
                name: "AccountMappingValidation");

            migrationBuilder.RenameColumn(
                name: "ParentID",
                table: "AccountRelationMappings",
                newName: "ParentId");

            migrationBuilder.RenameColumn(
                name: "AccountID",
                table: "AccountRelationMappings",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountRelationMappings_AccountID",
                table: "AccountRelationMappings",
                newName: "IX_AccountRelationMappings_AccountId");

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 17, 19, 23, 42, 821, DateTimeKind.Local).AddTicks(1682));

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2021, 8, 17, 19, 23, 42, 821, DateTimeKind.Local).AddTicks(1829));

            migrationBuilder.UpdateData(
                table: "Entities",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 17, 19, 23, 42, 821, DateTimeKind.Local).AddTicks(5579));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 8, 17, 19, 23, 42, 816, DateTimeKind.Local).AddTicks(3440));

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRelationMappings_Accounts_AccountId",
                table: "AccountRelationMappings",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "ID");
        }
    }
}
