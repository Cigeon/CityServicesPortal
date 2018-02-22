using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PetitionsApi.Migrations
{
    public partial class AddedStatusAndAdditionalFieldsToPetition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Petitions_PetitionType_TypeId",
                table: "Petitions");

            migrationBuilder.DropTable(
                name: "PetitionType");

            migrationBuilder.DropIndex(
                name: "IX_Petitions_TypeId",
                table: "Petitions");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Petitions");

            migrationBuilder.RenameColumn(
                name: "Votes",
                table: "Petitions",
                newName: "PetitionUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Petitions",
                newName: "PetitionAreaId");

            migrationBuilder.AddColumn<int>(
                name: "PetitionsStatus",
                table: "Petitions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PetitionArea",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetitionArea", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Petitions_PetitionAreaId",
                table: "Petitions",
                column: "PetitionAreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Petitions_PetitionArea_PetitionAreaId",
                table: "Petitions",
                column: "PetitionAreaId",
                principalTable: "PetitionArea",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Petitions_PetitionArea_PetitionAreaId",
                table: "Petitions");

            migrationBuilder.DropTable(
                name: "PetitionArea");

            migrationBuilder.DropIndex(
                name: "IX_Petitions_PetitionAreaId",
                table: "Petitions");

            migrationBuilder.DropColumn(
                name: "PetitionsStatus",
                table: "Petitions");

            migrationBuilder.RenameColumn(
                name: "PetitionUserId",
                table: "Petitions",
                newName: "Votes");

            migrationBuilder.RenameColumn(
                name: "PetitionAreaId",
                table: "Petitions",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Petitions",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PetitionType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetitionType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Petitions_TypeId",
                table: "Petitions",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Petitions_PetitionType_TypeId",
                table: "Petitions",
                column: "TypeId",
                principalTable: "PetitionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
