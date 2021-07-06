using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Migrations
{
    public partial class ModifyAccountRequestCreatedBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "AccountRequest",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AccountRequest");

            migrationBuilder.UpdateData(
                table: "Activity",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 7, 6, 11, 36, 21, 649, DateTimeKind.Local).AddTicks(9813));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec24cd5b-e4d8-4c68-a082-2ad222ba4473", "AQAAAAEAACcQAAAAEGWXSitzH/SsATRABpicAtMh+iPCy8I6Zxcf0mn743zM+S2riar4manzp9kxNB3cuA==", "72f28c7f-7e9a-4d04-bf2c-62cb1f8dc50b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3950",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a684ced3-1ff4-4f32-aedd-06c507d49f22", "AQAAAAEAACcQAAAAEPWODQnARLpPe8Y8J5HVXff5Xwn5eeyrhyPuXy3LiXCiQP+9PAB85i4rZoU144rmTQ==", "459281d2-deab-4ebd-93f0-f43c7d4b0b1f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3961",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "037664ce-7d65-42b7-b777-52b56f8d3c4c", "AQAAAAEAACcQAAAAEKuxBBo+2iz8hemzjr4QfUlXtkIIIpQM7VsaMLhy6ncZLyiAcJGwKXR+vqbYB7aRIg==", "e6ca0634-0506-461b-8c5a-179cf3e004bd" });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 7, 6, 11, 36, 21, 647, DateTimeKind.Local).AddTicks(7976));
        }
    }
}
