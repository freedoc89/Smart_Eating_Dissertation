using Microsoft.EntityFrameworkCore.Migrations;
using System.Reflection;

#nullable disable

namespace Smart_Eating_Dissertation_Services.Migrations
{
    public partial class SeedMealsData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            #region Napok tábla feltöltése
            migrationBuilder.Sql("INSERT INTO WeekDays_EatingDatas_DB(Days)VALUES('Hétfő'),('Kedd'),('Szerda'),('Csütörtök'),('Péntek'),('Szombat'),('Vasárnap')");

            #endregion

            #region Reggeli Tábla Feltöltése
            Random random_Day = new Random();
            var output = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            using (StreamReader breakfastRead = new StreamReader(new FileStream($@"{output}\Data Text Files\breakfast_data.txt", FileMode.Open)))
            {


                string breakfast_Sql = "INSERT INTO breakfast_EatingDatas_DB(Name_of_food,Protein_weight,Fat_weight,Carbohydrate_weight,Calorie_kcal,WeekDaysId)VALUES";
                while (!breakfastRead.EndOfStream)
                {
                    int day = random_Day.Next(1, 7);
                    string[] parts = breakfastRead.ReadLine().Split(';');

                    breakfast_Sql += $"('{parts[0]}', '{parts[1]}', '{parts[2]}', '{parts[3]}', '{parts[4]}', '{day}'), ";
                }
                breakfast_Sql = breakfast_Sql.Trim().Remove(breakfast_Sql.Length - 2);
                migrationBuilder.Sql(breakfast_Sql);
            }
            #endregion

            #region Leves Tábla Feltöltése
            using (StreamReader Lunch_Soup_Read = new StreamReader(new FileStream($@"{output}\Data Text Files\lunch_soup_data.txt", FileMode.Open)))
            {
                string Lunch_Soup_Sql = "INSERT INTO lunch_Soup_EatingDatas_DB (Name_of_food,Protein_weight,Fat_weight,Carbohydrate_weight,Calorie_kcal,WeekDaysId)VALUES";
                while (!Lunch_Soup_Read.EndOfStream)
                {
                    int day = random_Day.Next(1, 7);
                    string[] parts = Lunch_Soup_Read.ReadLine().Split(';');
                    Lunch_Soup_Sql += $"('{parts[0]}', '{parts[1]}', '{parts[2]}', '{parts[3]}', '{parts[4]}', '{day}'), ";
                }
                Lunch_Soup_Sql = Lunch_Soup_Sql.Trim().Remove(Lunch_Soup_Sql.Length - 2);
                migrationBuilder.Sql(Lunch_Soup_Sql);
            }
            #endregion

            #region Főétel Tábla Feltöltése
            using (StreamReader Lunch_main_Read = new StreamReader(new FileStream($@"{output}\Data Text Files\lunch_main_course_data.txt", FileMode.Open)))
            {
                string Lunch_main_Sql = "INSERT INTO lunch_Main_Course_EatingDatas_DB (Name_of_food,Protein_weight,Fat_weight,Carbohydrate_weight,Calorie_kcal,WeekDaysId)VALUES";
                while (!Lunch_main_Read.EndOfStream)
                {
                    int day = random_Day.Next(1, 7);
                    string[] parts = Lunch_main_Read.ReadLine().Split(';');
                    for (int i = 1; i < parts.Length; i++)
                    {
                        if (parts[i].Contains(','))
                        {
                            parts[i] = parts[i].Replace(',', '.');


                        }
                    }
                    Lunch_main_Sql += $"('{parts[0]}', '{parts[1]}', '{parts[2]}', '{parts[3]}', '{parts[4]}', '{day}'), ";
                }
                Lunch_main_Sql = Lunch_main_Sql.Trim().Remove(Lunch_main_Sql.Length - 2);
                migrationBuilder.Sql(Lunch_main_Sql);
            }
            #endregion

            #region Vacsora Tábla Feltöltése
            using (StreamReader Dinner_Read = new StreamReader(new FileStream($@"{output}\Data Text Files\dinner_data.txt", FileMode.Open)))
            {
                string Dinner_Sql = "INSERT INTO dinner_EatingDatas_DB (Name_of_food,Protein_weight,Fat_weight,Carbohydrate_weight,Calorie_kcal,WeekDaysId)VALUES";
                while (!Dinner_Read.EndOfStream)
                {
                    int day = random_Day.Next(1, 7);
                    string[] parts = Dinner_Read.ReadLine().Split(';');
                    for (int i = 1; i < parts.Length; i++)
                    {
                        if (parts[i].Contains(','))
                        {
                            parts[i] = parts[i].Replace(',', '.');


                        }
                    }
                    Dinner_Sql += $"('{parts[0]}', '{parts[1]}', '{parts[2]}', '{parts[3]}', '{parts[4]}', '{day}'), ";
                }
                Dinner_Sql = Dinner_Sql.Trim().Remove(Dinner_Sql.Length - 2);
                migrationBuilder.Sql(Dinner_Sql);
            }
            #endregion
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
