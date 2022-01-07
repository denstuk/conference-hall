using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConferenceHall.Infrastructure.Database.Migrations
{
    public partial class UpdateMessageTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageEntity_conferences_conference_id",
                table: "MessageEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageEntity_users_creator_id",
                table: "MessageEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageEntity",
                table: "MessageEntity");

            migrationBuilder.RenameTable(
                name: "MessageEntity",
                newName: "message");

            migrationBuilder.RenameIndex(
                name: "IX_MessageEntity_creator_id",
                table: "message",
                newName: "IX_message_creator_id");

            migrationBuilder.RenameIndex(
                name: "IX_MessageEntity_conference_id",
                table: "message",
                newName: "IX_message_conference_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_message",
                table: "message",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_message_conferences_conference_id",
                table: "message",
                column: "conference_id",
                principalTable: "conferences",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_message_users_creator_id",
                table: "message",
                column: "creator_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_message_conferences_conference_id",
                table: "message");

            migrationBuilder.DropForeignKey(
                name: "FK_message_users_creator_id",
                table: "message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_message",
                table: "message");

            migrationBuilder.RenameTable(
                name: "message",
                newName: "MessageEntity");

            migrationBuilder.RenameIndex(
                name: "IX_message_creator_id",
                table: "MessageEntity",
                newName: "IX_MessageEntity_creator_id");

            migrationBuilder.RenameIndex(
                name: "IX_message_conference_id",
                table: "MessageEntity",
                newName: "IX_MessageEntity_conference_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageEntity",
                table: "MessageEntity",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageEntity_conferences_conference_id",
                table: "MessageEntity",
                column: "conference_id",
                principalTable: "conferences",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageEntity_users_creator_id",
                table: "MessageEntity",
                column: "creator_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
