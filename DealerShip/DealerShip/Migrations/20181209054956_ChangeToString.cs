using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DealerShip.Migrations
{
    public partial class ChangeToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Color = table.Column<string>(nullable: true),
                    HasHeatedSeats = table.Column<bool>(nullable: true),
                    HasNavigation = table.Column<bool>(nullable: true),
                    HasPowerWindows = table.Column<bool>(nullable: true),
                    HasSunRoof = table.Column<bool>(nullable: true),
                    HaslowMiles = table.Column<bool>(nullable: true),
                    IsFourWheelDrive = table.Column<bool>(nullable: true),
                    Make = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: true),
                    Year = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
