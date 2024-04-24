using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NS.Infrastructure.MSSQL.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProduceDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ManufacturePhone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ManufactureEmail = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.UniqueConstraint("AK_Products_ManufactureEmail", x => x.ManufactureEmail);
                    table.UniqueConstraint("AK_Products_ProduceDate", x => x.ProduceDate);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
