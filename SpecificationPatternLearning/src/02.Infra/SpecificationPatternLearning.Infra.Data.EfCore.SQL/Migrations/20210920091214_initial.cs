using Microsoft.EntityFrameworkCore.Migrations;

namespace SpecificationPatternLearning.Infra.Data.EfCore.SQL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EducationType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personnels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Family = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PersonnelNumber = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonnelEducations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonnelId = table.Column<int>(type: "int", nullable: false),
                    EducationTypeId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonnelEducations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonnelEducations_EducationType_EducationTypeId",
                        column: x => x.EducationTypeId,
                        principalTable: "EducationType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PersonnelEducations_Personnels_PersonnelId",
                        column: x => x.PersonnelId,
                        principalTable: "Personnels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonnelEducations_EducationTypeId",
                table: "PersonnelEducations",
                column: "EducationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonnelEducations_PersonnelId",
                table: "PersonnelEducations",
                column: "PersonnelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonnelEducations");

            migrationBuilder.DropTable(
                name: "EducationType");

            migrationBuilder.DropTable(
                name: "Personnels");
        }
    }
}
