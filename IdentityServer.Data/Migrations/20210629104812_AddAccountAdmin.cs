using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Data.Migrations
{
    public partial class AddAccountAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "341743f0-asd2–42de-afbf-59kmkkmk72cf3", "341743f0-asd2–42de-afbf-59kmkkmk72cf3", "AccountAdmin", "ACCOUNTADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "821fe04a-b76c-4305-a150-2fd28b315b59", "AQAAAAEAACcQAAAAEHo8LNczNIft0G/PUkdNDVKX9w01vVV1PzANuTui1xUGBNOzq/t48JqEm0zwcq2nrA==", "f6a5ad7a-ee68-428c-b969-5c6143d99146" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3950",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d0215a1-0c04-4314-94be-5cdca266237c", "AQAAAAEAACcQAAAAEK+b2vvoof5BIKnIpy/bRPkFuikF/VIha1NQzQD3SLgrO+5tYyf/YecFYHNGr5ehbw==", "41611cb9-9406-4f0c-9898-4ce7fb97ea84" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3961",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e57ce46f-94f2-452e-880a-7983c3c0a630", "AQAAAAEAACcQAAAAEMjuT1IswCqQkiypLTOhV8yBuqC41VXjuDDMH4OuHTMgAk1BtLSvq6GiE4jheLHL8w==", "fff6a26b-7dcc-4ab7-a48f-513e3a013b35" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf3");

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
        }
    }
}
