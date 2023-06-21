using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Project.Migrations
{
    /// <inheritdoc />
    public partial class updateMyDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e236331b-5a07-4e4e-8203-8d647c2521bd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d0a62864-1256-43fc-ad03-bc8039d82a87", null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9fe98550-65d8-4b85-9625-cf5decaafbdb", "AQAAAAIAAYagAAAAECVSPvo5InDh3KK50IVeY6xrMY2ND/1bFMX3RiOLewivLC8AUoWb0sty7HmxyWYgWA==", "1eb645c9-d890-482b-952b-820fdd685079" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0a62864-1256-43fc-ad03-bc8039d82a87");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e236331b-5a07-4e4e-8203-8d647c2521bd", null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7737034d-3ae8-4471-8e0e-2f63b5da4108", "AQAAAAIAAYagAAAAEOoXqq923esVpTRcHHvkxz/cvWqnXsESf95jlRnLpoG9vnnBGWeHFrbITye2jxtAYw==", "b76ceb4c-bf66-4833-909d-1aa76080b0ba" });
        }
    }
}
