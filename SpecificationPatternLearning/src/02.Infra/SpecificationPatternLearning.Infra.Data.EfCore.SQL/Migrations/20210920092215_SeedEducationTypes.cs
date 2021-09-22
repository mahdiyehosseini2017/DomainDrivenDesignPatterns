using Microsoft.EntityFrameworkCore.Migrations;

namespace SpecificationPatternLearning.Infra.Data.EfCore.SQL.Migrations
{
    public partial class SeedEducationTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EducationType",
                columns: new[] { "Id", "Code", "Title" },
                values: new object[,]
                {
                    { 1, "diplom", "Diploma" },
                    { 2, "lisans", "Bachelor" },
                    { 3, "foghe-lisance", "Masters" },
                    { 4, "doktora", "PhD" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EducationType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EducationType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EducationType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EducationType",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
