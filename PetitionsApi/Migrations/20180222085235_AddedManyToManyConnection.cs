using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PetitionsApi.Migrations
{
    public partial class AddedManyToManyConnection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PetitionVoter",
                columns: table => new
                {
                    PetitionId = table.Column<int>(nullable: false),
                    PetitionUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetitionVoter", x => new { x.PetitionId, x.PetitionUserId });
                    table.ForeignKey(
                        name: "FK_PetitionVoter_Petitions_PetitionId",
                        column: x => x.PetitionId,
                        principalTable: "Petitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PetitionVoter_PetitionUsers_PetitionUserId",
                        column: x => x.PetitionUserId,
                        principalTable: "PetitionUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PetitionVoter_PetitionUserId",
                table: "PetitionVoter",
                column: "PetitionUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PetitionVoter");
        }
    }
}
