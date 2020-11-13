using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SeekQ.Interests.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlackLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlackLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    PeopleCount = table.Column<int>(nullable: false),
                    Visibility = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInterests",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdUser = table.Column<Guid>(nullable: false),
                    IdInterest = table.Column<Guid>(nullable: false),
                    Visibility = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInterests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInterests_Interests_IdInterest",
                        column: x => x.IdInterest,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlackLists_Name",
                table: "BlackLists",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Interests_Name",
                table: "Interests",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserInterests_IdInterest",
                table: "UserInterests",
                column: "IdInterest");

            migrationBuilder.CreateIndex(
                name: "IX_UserInterests_IdUser_IdInterest",
                table: "UserInterests",
                columns: new[] { "IdUser", "IdInterest" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlackLists");

            migrationBuilder.DropTable(
                name: "UserInterests");

            migrationBuilder.DropTable(
                name: "Interests");
        }
    }
}
