using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Data.Migrations
{
    public partial class ChangeLoginData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3949",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77bc1031-2c3e-4317-a800-0c1d9c3c5ea8", "consumer@consumer.com", "CONSUMER", "AQAAAAEAACcQAAAAEIWse9ypXtlnUqn860OQjau3pwY9USkEvlbhgK5hSlTggDWuTuxF9FtFg4pTUsfoYg==", "552e94ed-538c-4f30-9087-cd6e0a8e8d3e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3950",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "03fc6962-5971-4bcf-9369-f487c6d6506c", "ADMIN", "AQAAAAEAACcQAAAAECGKthBymTs5KSlNylpAMmQUy7iRFpkVPFchju/s0ER+8LPnreq8tzo7VUyKTlSApQ==", "5b5e8635-c665-448c-8035-3caee462bbcd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3961",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "120e48a5-9fb8-48bc-a709-b89375304ace", "MANAGER", "AQAAAAEAACcQAAAAEFeX+f8LvTk6jmXf/l2MmKIDhd4HQB3uo/ea5YGncwFNN7IUbPtFOE+b2DKAVCzBwg==", "f5ede44e-440b-42c2-a39f-481b4d667a11" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3949",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "72063bd4-f5af-4bad-9424-f9dde1f9e231", "ebram@ebram.com", "CONSUMER@CONSUMER.COM", "AQAAAAEAACcQAAAAEBmK3smFVoUIsbPBEFf3BjAVQ7Hw12yF6D4vgjhcWU+t+lQzjDZmpYJ0hmrqBYBV0Q==", "9a9900f7-f6bd-4ca5-a93e-97a7846fe0b8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3950",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3273667-3ccb-4ba0-9478-00f39c4c0646", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEDOkvSFWJAq/faoEwXjY04WqXcm4NW1bX+X5cC0eNuWj/VchlCH1DatGtKQHCCYMXQ==", "cb0e414d-93e0-49f5-bf88-85cd868844f7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3961",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9df83425-a390-48c2-9dcb-fb8968ea53ca", "MANAGER@MANAGER.COM", "AQAAAAEAACcQAAAAEIc5v8RbfV8TLAbVjJAmPhJ46M1Qszecyzreg8Q6Uw5oFrIpnhkriu/n7fvdW3FaxA==", "7bc0fec3-d560-465f-b8c4-ac07b173a53f" });
        }
    }
}
