using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PetitionsApi.Migrations
{
    public partial class PetitionChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Petitions_PetitionArea_PetitionAreaId",
                table: "Petitions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PetitionArea",
                table: "PetitionArea");

            migrationBuilder.RenameTable(
                name: "PetitionArea",
                newName: "PetitionAreas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PetitionAreas",
                table: "PetitionAreas",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PetitionUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    IdentityId = table.Column<int>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetitionUsers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Petitions_PetitionUserId",
                table: "Petitions",
                column: "PetitionUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Petitions_PetitionAreas_PetitionAreaId",
                table: "Petitions",
                column: "PetitionAreaId",
                principalTable: "PetitionAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Petitions_PetitionUsers_PetitionUserId",
                table: "Petitions",
                column: "PetitionUserId",
                principalTable: "PetitionUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Petitions_PetitionAreas_PetitionAreaId",
                table: "Petitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Petitions_PetitionUsers_PetitionUserId",
                table: "Petitions");

            migrationBuilder.DropTable(
                name: "PetitionUsers");

            migrationBuilder.DropIndex(
                name: "IX_Petitions_PetitionUserId",
                table: "Petitions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PetitionAreas",
                table: "PetitionAreas");

            migrationBuilder.RenameTable(
                name: "PetitionAreas",
                newName: "PetitionArea");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PetitionArea",
                table: "PetitionArea",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Petitions_PetitionArea_PetitionAreaId",
                table: "Petitions",
                column: "PetitionAreaId",
                principalTable: "PetitionArea",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
