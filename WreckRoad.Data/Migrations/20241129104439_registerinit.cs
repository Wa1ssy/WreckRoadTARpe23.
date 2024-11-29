using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WreckRoad.Data.Migrations
{
    /// <inheritdoc />
    public partial class registerinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarXP = table.Column<int>(type: "int", nullable: false),
                    CarXPNextLevel = table.Column<int>(type: "int", nullable: false),
                    CarLevel = table.Column<int>(type: "int", nullable: false),
                    CarType = table.Column<int>(type: "int", nullable: false),
                    CarStatus = table.Column<int>(type: "int", nullable: false),
                    TurnSpeed = table.Column<int>(type: "int", nullable: false),
                    TurnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarWasBuilt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarCrashed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BuiltAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FilesToDatabase",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CarID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilesToDatabase", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "FilesToDatabase");
        }
    }
}
