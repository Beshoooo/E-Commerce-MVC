using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Project.Migrations
{
    /// <inheritdoc />
    public partial class ProductsWithCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91ab4b97-27ec-47fe-b666-e80939102090");

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DepartmentIcon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeptManger = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DeptManger_Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Is_Deleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    DeptId = table.Column<int>(type: "int", nullable: true),
                    Is_Deleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Departments_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Products_DeptId",
                table: "Products",
                column: "DeptId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e236331b-5a07-4e4e-8203-8d647c2521bd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "91ab4b97-27ec-47fe-b666-e80939102090", null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ace11db2-25b1-4844-89ab-0427727e35d3", "AQAAAAIAAYagAAAAEECtTsLHWOncnZzJLd79jf4kB7pXunGk0pUMcoRHldDumMaxleedpDkBJRhQYoD0tg==", "1182e588-5895-42e6-8da5-71281b24036e" });
        }
    }
}
