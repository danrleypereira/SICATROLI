using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace dal.Migrations
{
    /// <inheritdoc />
    public partial class CoreModelsAuthSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Readers");

            migrationBuilder.DropTable(
                name: "Institutions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "category");

            migrationBuilder.RenameColumn(
                name: "Rarity",
                table: "category",
                newName: "rarity");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "category",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Pages",
                table: "category",
                newName: "pages");

            migrationBuilder.RenameColumn(
                name: "Genre",
                table: "category",
                newName: "genre");

            migrationBuilder.RenameColumn(
                name: "Conservation",
                table: "category",
                newName: "conservation");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "category",
                newName: "category_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_category",
                table: "category",
                column: "category_id");

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    address_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number = table.Column<int>(type: "integer", nullable: false),
                    cep = table.Column<int>(type: "integer", nullable: false),
                    city = table.Column<string>(type: "text", nullable: false),
                    uf = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    neighbourhood = table.Column<string>(type: "text", nullable: false),
                    country = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.address_id);
                });

            migrationBuilder.CreateTable(
                name: "institution",
                columns: table => new
                {
                    organization_id = table.Column<string>(type: "text", nullable: false),
                    moderator_id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    address_id = table.Column<int>(type: "integer", nullable: false),
                    telephone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_institution", x => x.organization_id);
                    table.ForeignKey(
                        name: "FK_institution_address_address_id",
                        column: x => x.address_id,
                        principalTable: "address",
                        principalColumn: "address_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "guardian",
                columns: table => new
                {
                    guardian_id = table.Column<string>(type: "text", nullable: false),
                    book_id = table.Column<int>(type: "integer", nullable: false),
                    contributions = table.Column<int>(type: "integer", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    guardian_id1 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guardian", x => x.guardian_id);
                    table.ForeignKey(
                        name: "FK_guardian_institution_guardian_id1",
                        column: x => x.guardian_id1,
                        principalTable: "institution",
                        principalColumn: "organization_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_guardian_guardian_id1",
                table: "guardian",
                column: "guardian_id1");

            migrationBuilder.CreateIndex(
                name: "IX_institution_address_id",
                table: "institution",
                column: "address_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "guardian");

            migrationBuilder.DropTable(
                name: "institution");

            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropPrimaryKey(
                name: "PK_category",
                table: "category");

            migrationBuilder.RenameTable(
                name: "category",
                newName: "Categories");

            migrationBuilder.RenameColumn(
                name: "rarity",
                table: "Categories",
                newName: "Rarity");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Categories",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "pages",
                table: "Categories",
                newName: "Pages");

            migrationBuilder.RenameColumn(
                name: "genre",
                table: "Categories",
                newName: "Genre");

            migrationBuilder.RenameColumn(
                name: "conservation",
                table: "Categories",
                newName: "Conservation");

            migrationBuilder.RenameColumn(
                name: "category_id",
                table: "Categories",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Institutions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Readers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InstitutionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Readers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Readers_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Readers_InstitutionId",
                table: "Readers",
                column: "InstitutionId");
        }
    }
}
