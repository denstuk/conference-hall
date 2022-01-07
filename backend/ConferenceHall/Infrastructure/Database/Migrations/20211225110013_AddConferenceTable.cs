using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConferenceHall.Infrastructure.Database.Migrations
{
    public partial class AddConferenceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "conferences",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conferences", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_conference",
                columns: table => new
                {
                    ConferencesId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_conference", x => new { x.ConferencesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_user_conference_conferences_ConferencesId",
                        column: x => x.ConferencesId,
                        principalTable: "conferences",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_conference_users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_conference_UsersId",
                table: "user_conference",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_conference");

            migrationBuilder.DropTable(
                name: "conferences");
        }
    }
}
