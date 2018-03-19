using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CityServicesPortal.Petitions.Infra.Data.Migrations
{
    public partial class ModifiedPropAddedToPetitionModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PetitionStatus",
                table: "Petitions");

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Petitions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Petitions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Petitions");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Petitions");

            migrationBuilder.AddColumn<int>(
                name: "PetitionStatus",
                table: "Petitions",
                nullable: false,
                defaultValue: 0);
        }
    }
}
