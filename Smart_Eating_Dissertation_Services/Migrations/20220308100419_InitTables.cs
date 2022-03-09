using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smart_Eating_Dissertation_Services.Migrations
{
    public partial class InitTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeekDays_EatingDatas_DB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Days = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekDays_EatingDatas_DB", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "breakfast_EatingDatas_DB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_of_food = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Protein_weight = table.Column<double>(type: "float", nullable: false),
                    Fat_weight = table.Column<double>(type: "float", nullable: false),
                    Carbohydrate_weight = table.Column<double>(type: "float", nullable: false),
                    Calorie_kcal = table.Column<double>(type: "float", nullable: false),
                    WeekDaysId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_breakfast_EatingDatas_DB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_breakfast_EatingDatas_DB_WeekDays_EatingDatas_DB_WeekDaysId",
                        column: x => x.WeekDaysId,
                        principalTable: "WeekDays_EatingDatas_DB",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "dinner_EatingDatas_DB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_of_food = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Protein_weight = table.Column<double>(type: "float", nullable: false),
                    Fat_weight = table.Column<double>(type: "float", nullable: false),
                    Carbohydrate_weight = table.Column<double>(type: "float", nullable: false),
                    Calorie_kcal = table.Column<double>(type: "float", nullable: false),
                    WeekDaysId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dinner_EatingDatas_DB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dinner_EatingDatas_DB_WeekDays_EatingDatas_DB_WeekDaysId",
                        column: x => x.WeekDaysId,
                        principalTable: "WeekDays_EatingDatas_DB",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "lunch_Main_Course_EatingDatas_DB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_of_food = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Protein_weight = table.Column<double>(type: "float", nullable: false),
                    Fat_weight = table.Column<double>(type: "float", nullable: false),
                    Carbohydrate_weight = table.Column<double>(type: "float", nullable: false),
                    Calorie_kcal = table.Column<double>(type: "float", nullable: false),
                    WeekDaysId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lunch_Main_Course_EatingDatas_DB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lunch_Main_Course_EatingDatas_DB_WeekDays_EatingDatas_DB_WeekDaysId",
                        column: x => x.WeekDaysId,
                        principalTable: "WeekDays_EatingDatas_DB",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "lunch_Soup_EatingDatas_DB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_of_food = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Protein_weight = table.Column<double>(type: "float", nullable: false),
                    Fat_weight = table.Column<double>(type: "float", nullable: false),
                    Carbohydrate_weight = table.Column<double>(type: "float", nullable: false),
                    Calorie_kcal = table.Column<double>(type: "float", nullable: false),
                    WeekDaysId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lunch_Soup_EatingDatas_DB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lunch_Soup_EatingDatas_DB_WeekDays_EatingDatas_DB_WeekDaysId",
                        column: x => x.WeekDaysId,
                        principalTable: "WeekDays_EatingDatas_DB",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_breakfast_EatingDatas_DB_WeekDaysId",
                table: "breakfast_EatingDatas_DB",
                column: "WeekDaysId");

            migrationBuilder.CreateIndex(
                name: "IX_dinner_EatingDatas_DB_WeekDaysId",
                table: "dinner_EatingDatas_DB",
                column: "WeekDaysId");

            migrationBuilder.CreateIndex(
                name: "IX_lunch_Main_Course_EatingDatas_DB_WeekDaysId",
                table: "lunch_Main_Course_EatingDatas_DB",
                column: "WeekDaysId");

            migrationBuilder.CreateIndex(
                name: "IX_lunch_Soup_EatingDatas_DB_WeekDaysId",
                table: "lunch_Soup_EatingDatas_DB",
                column: "WeekDaysId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "breakfast_EatingDatas_DB");

            migrationBuilder.DropTable(
                name: "dinner_EatingDatas_DB");

            migrationBuilder.DropTable(
                name: "lunch_Main_Course_EatingDatas_DB");

            migrationBuilder.DropTable(
                name: "lunch_Soup_EatingDatas_DB");

            migrationBuilder.DropTable(
                name: "WeekDays_EatingDatas_DB");
        }
    }
}
