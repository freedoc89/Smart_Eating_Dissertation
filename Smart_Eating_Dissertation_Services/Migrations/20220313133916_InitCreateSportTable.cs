using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smart_Eating_Dissertation_Services.Migrations
{
    public partial class InitCreateSportTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SportsData_DB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sportName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sportKcal = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportsData_DB", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SportsData_DB");
        }
    }
}
