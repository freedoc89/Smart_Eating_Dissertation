using Microsoft.EntityFrameworkCore.Migrations;
using System.Reflection;
using Smart_Eating_Dissertation_Services;

#nullable disable

namespace Smart_Eating_Dissertation_Services.Migrations
{
    public partial class SeedSportTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            #region Sport Tábla Feltöltése
            var output = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            using (StreamReader sportsDataRead = new StreamReader(new FileStream($@"{output}\Data Text Files\sports_Data.txt", FileMode.Open)))
            {
                string fejlec = sportsDataRead.ReadLine();

                string sports_Sql = "INSERT INTO SportsData_DB(sportName,sportKcal)VALUES";
                while (!sportsDataRead.EndOfStream)
                {
                    string[] parts = sportsDataRead.ReadLine().Split(';');

                    sports_Sql += $"('{parts[0]}', '{parts[1]}'), ";
                }
                sports_Sql = sports_Sql.Trim().Remove(sports_Sql.Length - 2);
                migrationBuilder.Sql(sports_Sql);
            }
            #endregion

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
