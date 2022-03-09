using Smart_Eating_Dissertation_Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Smart_Eating_Dissertation_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Random rand_Eat = new Random();
        private readonly ApplicationDbContext _contex;
        public MainWindow()
        {
            InitializeComponent();
            _contex = new ApplicationDbContext();
            Days();
            InitBreakfast();
            InitLunchSoup();
            InitLunchMain();
            InitDinner();
            Sum_allValue();
        }

        #region Új Reggeli véletlen generálása
        private void btn_newBreakfast_Click(object sender, RoutedEventArgs e)
        {
            InitBreakfast();
            Sum_allValue();


        }
        #endregion

        #region Új Leves véletlen generálása
        private void btn_newLunch_Soup_Click(object sender, RoutedEventArgs e)
        {
            InitLunchSoup();
            Sum_allValue();
        }
        #endregion

        #region Új Főétel véletlen generálása
        private void btn_newLunch_Main_Click(object sender, RoutedEventArgs e)
        {
            InitLunchMain();
            Sum_allValue();

        }
        #endregion

        #region Új Vacsora véletlen generálása
        private void btn_newDinner_Click(object sender, RoutedEventArgs e)
        {
            InitDinner();
            Sum_allValue();

        }
        #endregion



        #region Reggeli Inicializálás induláskor
        private void InitBreakfast()
        {
            int count = _contex.breakfast_EatingDatas_DB.Count();
            int index = rand_Eat.Next(1, count);
            var breakfast = _contex.breakfast_EatingDatas_DB.Where(x => x.Id == index);
            if (breakfast.Count() > 0)
            {
                foreach (var item in breakfast)
                {
                    tb_breakfast.Text = item.Name_of_food.ToString();
                    lb_breakfast_protein.Content = item.Protein_weight.ToString() + "g";
                    lb_breakfast_fat.Content = item.Fat_weight.ToString() + "g";
                    lb_breakfast_carbohydrate.Content = item.Carbohydrate_weight.ToString() + "g";
                    lb_breakfast_kcal.Content = item.Calorie_kcal.ToString() + "Kcal";
                }
            }

            else
            {
                MessageBox.Show("Nincs megjeleníthető étel!", "Figyelem!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        #region Leves Inicializálás induláskor
        private void InitLunchSoup()
        {
            int count = _contex.lunch_Soup_EatingDatas_DB.Count();
            int index = rand_Eat.Next(1, count);
            var lunch_soup = _contex.lunch_Soup_EatingDatas_DB.Where(x => x.Id == index);
            if (lunch_soup.Count() > 0)
            {
                foreach (var item in lunch_soup)
                {
                    tb_lunch_Soup.Text = item.Name_of_food.ToString();
                    lb_soup_protein.Content = item.Protein_weight.ToString() + "g";
                    lb_soup_fat.Content = item.Fat_weight.ToString() + "g";
                    lb_soup_carbohydrate.Content = item.Carbohydrate_weight.ToString() + "g";
                    lb_soup_kcal.Content = item.Calorie_kcal.ToString() + "Kcal";
                }
            }
            else
            {
                MessageBox.Show("Nincs megjeleníthető étel!", "Figyelem!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        #endregion

        #region Főétel Inicializálás induláskor
        private void InitLunchMain()
        {
            int count = _contex.lunch_Main_Course_EatingDatas_DB.Count();
            int index = rand_Eat.Next(1, count);
            var lunch_main = _contex.lunch_Main_Course_EatingDatas_DB.Where(x => x.Id == index);

            if (lunch_main.Count() > 0)
            {
                foreach (var item in lunch_main)
                {
                    tb_lunch_Main.Text = item.Name_of_food.ToString();
                    lb_main_protein.Content = item.Protein_weight.ToString() + "g";
                    lb_main_fat.Content = item.Fat_weight.ToString() + "g";
                    lb_main_carbohydrate.Content = item.Carbohydrate_weight.ToString() + "g";
                    lb_main_kcal.Content = item.Calorie_kcal.ToString() + "Kcal";
                }

            }
            else
            {
                MessageBox.Show("Nincs megjeleníthető étel!", "Figyelem!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        #endregion

        #region Vacsora Inicializálás induláskor
        private void InitDinner()
        {
            int count = _contex.dinner_EatingDatas_DB.Count();
            int index = rand_Eat.Next(1, count);
            var dinner = _contex.dinner_EatingDatas_DB.Where(x => x.Id == index);

            if (dinner.Count() > 0)
            {
                foreach (var item in dinner)
                {
                    tb_dinner.Text = item.Name_of_food.ToString();
                    lb_dinner_protein.Content = item.Protein_weight.ToString() + "g";
                    lb_dinner_fat.Content = item.Fat_weight.ToString() + "g";
                    lb_dinner_carbohydrate.Content = item.Carbohydrate_weight.ToString() + "g";
                    lb_dinner_kcal.Content = item.Calorie_kcal.ToString() + "Kcal";
                }
            }

            else
            {
                MessageBox.Show("Nincs megjeleníthető étel!", "Figyelem!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion



        #region Összegzés
        private void Sum_allValue()
        {
            double[,] save_values = new double[4, 4];
            double[] sum_all_values = new double[4];

            string breakfast_all = Meals_labels_converter(lb_breakfast_protein.Content.ToString(), lb_breakfast_fat.Content.ToString(), lb_breakfast_carbohydrate.Content.ToString(), lb_breakfast_kcal.Content.ToString());
            string[] breakfast_parts = breakfast_all.Split(';');

            string lunch_soup_all = Meals_labels_converter(lb_soup_protein.Content.ToString(), lb_soup_fat.Content.ToString(), lb_soup_carbohydrate.Content.ToString(), lb_soup_kcal.Content.ToString());
            string[] lunch_soup_parts = lunch_soup_all.Split(';');

            string lunch_main_all = Meals_labels_converter(lb_main_protein.Content.ToString(), lb_main_fat.Content.ToString(), lb_main_carbohydrate.Content.ToString(), lb_main_kcal.Content.ToString());
            string[] lunch_main_parts = lunch_main_all.Split(';');

            string dinner_all = Meals_labels_converter(lb_dinner_protein.Content.ToString(), lb_dinner_fat.Content.ToString(), lb_dinner_carbohydrate.Content.ToString(), lb_dinner_kcal.Content.ToString());
            string[] dinner_parts = dinner_all.Split(';');

            for (int i = 0; i < 4; i++)
            {
                save_values[0, i] = Convert.ToDouble(breakfast_parts[i]);
                save_values[1, i] = Convert.ToDouble(lunch_soup_parts[i]);
                save_values[2, i] = Convert.ToDouble(lunch_main_parts[i]);
                save_values[3, i] = Convert.ToDouble(dinner_parts[i]);
            }
            sum_all_values[0] = save_values[0, 0] + save_values[1, 0] + save_values[2, 0] + save_values[3, 0];
            lb_sum_protein.Content = Math.Round(sum_all_values[0], 2).ToString() + "g";

            sum_all_values[1] = save_values[0, 1] + save_values[1, 1] + save_values[2, 1] + save_values[3, 1];
            lb_sum_fat.Content = Math.Round(sum_all_values[1], 2).ToString() + "g";

            sum_all_values[2] = save_values[0, 2] + save_values[1, 2] + save_values[2, 2] + save_values[3, 2];
            lb_sum_carbohydrate.Content = Math.Round(sum_all_values[2], 2).ToString() + "g";

            sum_all_values[3] = save_values[0, 3] + save_values[1, 3] + save_values[2, 3] + save_values[3, 3];
            lb_sum_kcal.Content = Math.Round(sum_all_values[3], 2).ToString() + "kcal";




        }
        #endregion

        #region Étkezések label-nek a konvertálása
        private string Meals_labels_converter(string protein, string fat, string carbohydrate, string kcal)
        {


            protein = protein.Remove(protein.Length - 1);
            fat = fat.Remove(fat.Length - 1);
            carbohydrate = carbohydrate.Remove(carbohydrate.Length - 1);
            kcal = kcal.Remove(kcal.Length - 4);

            string elemei = protein + ";" + fat + ";" + carbohydrate + ";" + kcal;

            return elemei;
        }
        #endregion

        #region Napok jelölése
        private void Days()
        {
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    textB_monday.Foreground = Brushes.White;
                    break;
                case DayOfWeek.Tuesday:
                    textB_tuesday.Foreground = Brushes.White;
                    break;
                case DayOfWeek.Wednesday:
                    textB_wednesday.Foreground = Brushes.White;
                    break;
                case DayOfWeek.Thursday:
                    textB_thursday.Foreground = Brushes.White;
                    break;
                case DayOfWeek.Friday:
                    textB_friday.Foreground = Brushes.White;
                    break;
                case DayOfWeek.Saturday:
                    textB_saturday.Foreground = Brushes.White;
                    break;
                case DayOfWeek.Sunday:
                    textB_sunday.Foreground = Brushes.White;
                    break;
            }
        }
        #endregion

        private void btn_calorieCalc_Click(object sender, RoutedEventArgs e)
        {
            Calorie_Calculator_Window calorie_Calculator_Window = new Calorie_Calculator_Window();
            calorie_Calculator_Window.ShowDialog();

        }
    }
}
