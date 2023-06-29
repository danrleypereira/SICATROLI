using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class ForeingKeyBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GuardianId",
                table: "book",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_guardian_book_id",
                table: "guardian",
                column: "book_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_guardian_book_book_id",
                table: "guardian",
                column: "book_id",
                principalTable: "book",
                principalColumn: "book_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_guardian_book_book_id",
                table: "guardian");

            migrationBuilder.DropIndex(
                name: "IX_guardian_book_id",
                table: "guardian");

            migrationBuilder.DropColumn(
                name: "GuardianId",
                table: "book");
        }
    }
}
