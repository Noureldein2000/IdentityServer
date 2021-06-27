using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServer.Migrations
{
    public partial class AddChannelAndAccountEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "UserToken");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "UserToken");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "UserToken",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "UserToken",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "UserToken",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NameAr = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    TreeLevel = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ChannelCategories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ArName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChannelCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ChannelOwners",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ArName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChannelOwners", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ChannelPaymentMethods",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ArName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChannelPaymentMethods", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NameAr = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    CentralName = table.Column<string>(nullable: true),
                    CenterName = table.Column<string>(nullable: true),
                    OwnerName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CommNo = table.Column<string>(nullable: true),
                    TaxNo = table.Column<string>(nullable: true),
                    Active = table.Column<int>(nullable: false),
                    ChgTime = table.Column<DateTime>(nullable: false),
                    AllowTransfeer = table.Column<bool>(nullable: true),
                    NationalId = table.Column<string>(nullable: true),
                    Activity = table.Column<string>(nullable: true),
                    sim_no = table.Column<string>(nullable: true),
                    is_agent = table.Column<bool>(nullable: true),
                    Date_To = table.Column<string>(nullable: true),
                    UserUpdate = table.Column<int>(nullable: true),
                    MachineCode = table.Column<string>(nullable: true),
                    edDesc = table.Column<string>(nullable: true),
                    Logged_In = table.Column<bool>(nullable: true),
                    Last_login = table.Column<DateTime>(nullable: true),
                    last_logout = table.Column<DateTime>(nullable: true),
                    last_channel = table.Column<string>(nullable: true),
                    TotalPoints = table.Column<double>(nullable: true),
                    Serial = table.Column<string>(nullable: true),
                    Parent_CenterID = table.Column<int>(nullable: true),
                    Total_Parent_Amount = table.Column<double>(nullable: true),
                    ProfitDailyControl = table.Column<bool>(nullable: true),
                    AccountTypeID = table.Column<int>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    AccountProfileID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Accounts_AccountTypes_AccountTypeID",
                        column: x => x.AccountTypeID,
                        principalTable: "AccountTypes",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ChannelTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    ArName = table.Column<string>(nullable: false),
                    Version = table.Column<int>(nullable: true),
                    ChannelCategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChannelTypes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ChannelTypes_ChannelCategories_ChannelCategoryID",
                        column: x => x.ChannelCategoryID,
                        principalTable: "ChannelCategories",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "AccountProfiles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    AccountTypeID = table.Column<int>(nullable: false),
                    ProfileID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountProfiles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AccountProfiles_AccountTypes_AccountTypeID",
                        column: x => x.AccountTypeID,
                        principalTable: "AccountTypes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_AccountProfiles_Profiles_ProfileID",
                        column: x => x.ProfileID,
                        principalTable: "Profiles",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "AccountChannelTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    AccountID = table.Column<int>(nullable: false),
                    ChannelTypeID = table.Column<int>(nullable: false),
                    HasLimitedAccess = table.Column<bool>(nullable: false),
                    ExpirationPeriod = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountChannelTypes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AccountChannelTypes_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_AccountChannelTypes_ChannelTypes_ChannelTypeID",
                        column: x => x.ChannelTypeID,
                        principalTable: "ChannelTypes",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Channels",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    ChannelTypeID = table.Column<int>(nullable: false),
                    ChannelOwnerID = table.Column<int>(nullable: false),
                    Serial = table.Column<string>(nullable: true),
                    PaymentMethodID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channels", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Channels_ChannelOwners_ChannelOwnerID",
                        column: x => x.ChannelOwnerID,
                        principalTable: "ChannelOwners",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Channels_ChannelTypes_ChannelTypeID",
                        column: x => x.ChannelTypeID,
                        principalTable: "ChannelTypes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Channels_ChannelPaymentMethods_PaymentMethodID",
                        column: x => x.PaymentMethodID,
                        principalTable: "ChannelPaymentMethods",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "AccountChannels",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    AccountID = table.Column<int>(nullable: false),
                    ChannelID = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountChannels", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AccountChannels_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_AccountChannels_Channels_ChannelID",
                        column: x => x.ChannelID,
                        principalTable: "Channels",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ChannelIdentifiers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Value = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ChannelID = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChannelIdentifiers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ChannelIdentifiers_Channels_ChannelID",
                        column: x => x.ChannelID,
                        principalTable: "Channels",
                        principalColumn: "ID");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "44d9f16d-5bee-460e-abe3-a1006d825544", "AQAAAAEAACcQAAAAEPAJLv+A+OzgpR1LgmKGCDTyJOw5cLQxwhj+e4jJ9s7P6Llt1G3zlpDkO5hQ4M5iJQ==", "1b4c59d3-a3bb-4c59-948a-6d5dbd4bd295" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3950",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "135e460b-26e6-4554-8d5b-26599c8c708c", "AQAAAAEAACcQAAAAEF+AwL7IjvVS82GiyvmBH42k1FPJ6Zh6LcNfCBDGzG3Rjs6yLqwku9tWgOfQSS8QnQ==", "c5302857-9c1b-488f-9489-51b52ac51252" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3961",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6e8446a-f124-4f76-928f-d803de0562ca", "AQAAAAEAACcQAAAAEG2N7w8DmsunuYZIc0esgqsCvdWISNoWuWb+vj1Du3/Rjenfkk+QPj1d8NNXWPFXYA==", "6b7e94f0-0c6b-4a25-8baa-12d322bab1ab" });

            migrationBuilder.CreateIndex(
                name: "IX_AccountChannels_AccountID",
                table: "AccountChannels",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountChannels_ChannelID",
                table: "AccountChannels",
                column: "ChannelID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountChannelTypes_AccountID",
                table: "AccountChannelTypes",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountChannelTypes_ChannelTypeID",
                table: "AccountChannelTypes",
                column: "ChannelTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountProfiles_AccountTypeID",
                table: "AccountProfiles",
                column: "AccountTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountProfiles_ProfileID",
                table: "AccountProfiles",
                column: "ProfileID");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountTypeID",
                table: "Accounts",
                column: "AccountTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ChannelIdentifiers_ChannelID",
                table: "ChannelIdentifiers",
                column: "ChannelID");

            migrationBuilder.CreateIndex(
                name: "IX_Channels_ChannelOwnerID",
                table: "Channels",
                column: "ChannelOwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Channels_ChannelTypeID",
                table: "Channels",
                column: "ChannelTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Channels_PaymentMethodID",
                table: "Channels",
                column: "PaymentMethodID");

            migrationBuilder.CreateIndex(
                name: "IX_ChannelTypes_ChannelCategoryID",
                table: "ChannelTypes",
                column: "ChannelCategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountChannels");

            migrationBuilder.DropTable(
                name: "AccountChannelTypes");

            migrationBuilder.DropTable(
                name: "AccountProfiles");

            migrationBuilder.DropTable(
                name: "ChannelIdentifiers");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Channels");

            migrationBuilder.DropTable(
                name: "AccountTypes");

            migrationBuilder.DropTable(
                name: "ChannelOwners");

            migrationBuilder.DropTable(
                name: "ChannelTypes");

            migrationBuilder.DropTable(
                name: "ChannelPaymentMethods");

            migrationBuilder.DropTable(
                name: "ChannelCategories");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "UserToken");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "UserToken");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "UserToken",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "UserToken",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "UserToken",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77bc1031-2c3e-4317-a800-0c1d9c3c5ea8", "AQAAAAEAACcQAAAAEIWse9ypXtlnUqn860OQjau3pwY9USkEvlbhgK5hSlTggDWuTuxF9FtFg4pTUsfoYg==", "552e94ed-538c-4f30-9087-cd6e0a8e8d3e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3950",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "03fc6962-5971-4bcf-9369-f487c6d6506c", "AQAAAAEAACcQAAAAECGKthBymTs5KSlNylpAMmQUy7iRFpkVPFchju/s0ER+8LPnreq8tzo7VUyKTlSApQ==", "5b5e8635-c665-448c-8035-3caee462bbcd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a9b78e-a694-4026-af7f-6d559d8a3961",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "120e48a5-9fb8-48bc-a709-b89375304ace", "AQAAAAEAACcQAAAAEFeX+f8LvTk6jmXf/l2MmKIDhd4HQB3uo/ea5YGncwFNN7IUbPtFOE+b2DKAVCzBwg==", "f5ede44e-440b-42c2-a39f-481b4d667a11" });
        }
    }
}
