using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbContextLib.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FirstName = table.Column<string>(type: "nvarchar (200)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar (200)", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar (200)", nullable: true),
                    ZipCode = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar (200)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar (200)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    OrderCount = table.Column<int>(type: "int", nullable: false),
                    OrderValue = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CustomerID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NrOfArticles = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Freight = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
