using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IdentityApp.Data.Migrations
{
    public partial class UserRights : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserRights",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserRights",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
