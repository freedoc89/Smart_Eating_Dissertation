using Microsoft.EntityFrameworkCore;
using Smart_Eating_Dissertation_Services.Models.Meals;
using Smart_Eating_Dissertation_Services.Models.WeekDays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Eating_Dissertation_Services.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Breakfast_EatingData> breakfast_EatingDatas_DB { get; set; }
        public DbSet<Lunch_Soup_EatingData> lunch_Soup_EatingDatas_DB { get; set; }
        public DbSet<Lunch_Main_Course_EatingData> lunch_Main_Course_EatingDatas_DB { get; set; }
        public DbSet<Dinner_EatingData> dinner_EatingDatas_DB { get; set; }
        public DbSet<WeekDays> WeekDays_EatingDatas_DB { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = (LocalDB)\MSSQLLocalDB; Initial Catalog = Smart_Eating_Database; Integrated Security = True;");
            base.OnConfiguring(optionsBuilder);

            base.OnConfiguring(optionsBuilder);
        }

    }
}
