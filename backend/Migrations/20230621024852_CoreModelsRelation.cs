using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class CoreModelsRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_guardian_institution_guardian_id1",
                table: "guardian");

            migrationBuilder.DropForeignKey(
                name: "FK_institution_address_address_id",
                table: "institution");

            migrationBuilder.DropPrimaryKey(
                name: "PK_institution",
                table: "institution");

            migrationBuilder.DropIndex(
                name: "IX_institution_address_id",
                table: "institution");

            migrationBuilder.DropIndex(
                name: "IX_guardian_guardian_id1",
                table: "guardian");

            migrationBuilder.DropColumn(
                name: "organization_id",
                table: "institution");

            migrationBuilder.DropColumn(
                name: "guardian_id1",
                table: "guardian");

            migrationBuilder.RenameColumn(
                name: "address_id",
                table: "institution",
                newName: "institution_id");

            migrationBuilder.AlterColumn<int>(
                name: "institution_id",
                table: "institution",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "institution_id",
                table: "guardian",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_institution",
                table: "institution",
                column: "institution_id");

            migrationBuilder.CreateIndex(
                name: "IX_guardian_institution_id",
                table: "guardian",
                column: "institution_id");

            migrationBuilder.AddForeignKey(
                name: "FK_guardian_institution_institution_id",
                table: "guardian",
                column: "institution_id",
                principalTable: "institution",
                principalColumn: "institution_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_guardian_institution_institution_id",
                table: "guardian");

            migrationBuilder.DropPrimaryKey(
                name: "PK_institution",
                table: "institution");

            migrationBuilder.DropIndex(
                name: "IX_guardian_institution_id",
                table: "guardian");

            migrationBuilder.DropColumn(
                name: "institution_id",
                table: "guardian");

            migrationBuilder.RenameColumn(
                name: "institution_id",
                table: "institution",
                newName: "address_id");

            migrationBuilder.AlterColumn<int>(
                name: "address_id",
                table: "institution",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "organization_id",
                table: "institution",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "guardian_id1",
                table: "guardian",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_institution",
                table: "institution",
                column: "organization_id");

            migrationBuilder.CreateIndex(
                name: "IX_institution_address_id",
                table: "institution",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_guardian_guardian_id1",
                table: "guardian",
                column: "guardian_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_guardian_institution_guardian_id1",
                table: "guardian",
                column: "guardian_id1",
                principalTable: "institution",
                principalColumn: "organization_id");

            migrationBuilder.AddForeignKey(
                name: "FK_institution_address_address_id",
                table: "institution",
                column: "address_id",
                principalTable: "address",
                principalColumn: "address_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
