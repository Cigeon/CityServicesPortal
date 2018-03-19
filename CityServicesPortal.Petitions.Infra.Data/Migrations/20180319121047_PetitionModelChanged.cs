using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CityServicesPortal.Petitions.Infra.Data.Migrations
{
    public partial class PetitionModelChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PetitionsStatus",
                table: "Petitions");

            migrationBuilder.AddColumn<int>(
                name: "PetitionStatus",
                table: "Petitions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PetitionStatus",
                table: "Petitions");

            migrationBuilder.AddColumn<int>(
                name: "PetitionsStatus",
                table: "Petitions",
                nullable: false,
                defaultValue: 0);
        }
    }
}
