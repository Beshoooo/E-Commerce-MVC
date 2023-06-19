using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Project.Migrations
{
    /// <inheritdoc />
    public partial class addROleID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1eaad449-767c-4d72-9d08-91fca6d0ea9d");

            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "91ab4b97-27ec-47fe-b666-e80939102090", null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RoleId", "SecurityStamp" },
                values: new object[] { "ace11db2-25b1-4844-89ab-0427727e35d3", "AQAAAAIAAYagAAAAEECtTsLHWOncnZzJLd79jf4kB7pXunGk0pUMcoRHldDumMaxleedpDkBJRhQYoD0tg==", "341743f0-asd2–42de-afbf-59kmkkmk72cf6", "1182e588-5895-42e6-8da5-71281b24036e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91ab4b97-27ec-47fe-b666-e80939102090");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1eaad449-767c-4d72-9d08-91fca6d0ea9d", null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f7e43467-7528-4c2d-ba22-b633df499483", "AQAAAAIAAYagAAAAEH55tbnoIfjJyBsU8ibOT/8uKtSQf8LlZZCPumyys3cvDxidUYpIvb1K/zWetaIT6Q==", "eb62dae0-b2bf-41ef-a534-93e33ed56f88" });
        }
    }
}
