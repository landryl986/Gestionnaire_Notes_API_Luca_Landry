﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestionnaire_Notes_API_Luca_Landry.Migrations
{
    public partial class UpdateAll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    userName = table.Column<string>(nullable: false),
                    userLastName = table.Column<string>(nullable: false),
                    userEmail = table.Column<string>(nullable: false),
                    userPassword = table.Column<string>(nullable: false),
                    Avatar = table.Column<byte[]>(nullable: true),
                    admin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Philials",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    philialName = table.Column<string>(nullable: false),
                    userId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Philials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Philials_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    brancheName = table.Column<string>(nullable: false),
                    barem = table.Column<int>(nullable: false),
                    philialId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branches_Philials_philialId",
                        column: x => x.philialId,
                        principalTable: "Philials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    note = table.Column<int>(nullable: false),
                    BrancheId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Branches_BrancheId",
                        column: x => x.BrancheId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branches_philialId",
                table: "Branches",
                column: "philialId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_BrancheId",
                table: "Notes",
                column: "BrancheId");

            migrationBuilder.CreateIndex(
                name: "IX_Philials_userId",
                table: "Philials",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Philials");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
