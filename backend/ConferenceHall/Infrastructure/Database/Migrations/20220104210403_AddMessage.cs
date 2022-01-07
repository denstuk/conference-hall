using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConferenceHall.Infrastructure.Database.Migrations
{
    public partial class AddMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MessageEntity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    text = table.Column<string>(type: "text", nullable: false),
                    creator_id = table.Column<Guid>(type: "uuid", nullable: false),
                    conference_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageEntity", x => x.id);
                    table.ForeignKey(
                        name: "FK_MessageEntity_conferences_conference_id",
                        column: x => x.conference_id,
                        principalTable: "conferences",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessageEntity_users_creator_id",
                        column: x => x.creator_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MessageEntity_conference_id",
                table: "MessageEntity",
                column: "conference_id");

            migrationBuilder.CreateIndex(
                name: "IX_MessageEntity_creator_id",
                table: "MessageEntity",
                column: "creator_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MessageEntity");
        }
    }
}
