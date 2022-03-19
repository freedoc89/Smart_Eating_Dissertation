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
using System.Windows.Shapes;
using System.IO;
using Smart_Eating_Dissertation_Services;
using Smart_Eating_Dissertation_Services.Data;

namespace Smart_Eating_Dissertation_WPF
{
    /// <summary>
    /// Interaction logic for Calorie_Calculator_Window.xaml
    /// </summary>
    public partial class Calorie_Calculator_Window : Window
    {
        #region Lokális/Globális változók

        public int BMR_Value = 0;
        public int sum_AllValues = 0;
        public int [] mealsPerValues = new int [3];

        private int age = 0;
        private int height = 0;
        private int weight = 0;
        private double sleep = 0;
        private double working = 0;
        private double SportMinute = 0;
        private double sportKcal = 0;
        private string[] sport_Minutes = new string[5];
        

        #endregion

        private readonly ApplicationDbContext _contex;

        public Calorie_Calculator_Window()
        {
            InitializeComponent();
            _contex = new ApplicationDbContext();
            ComboBFill();
        }

        #region Kilépés
        private void btn_exit_calc_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

        #region További beállítások menü
        private void tg_btn_plus_menu_Checked(object sender, RoutedEventArgs e)
        {
            menu_stackP.Visibility = Visibility.Visible;

        }

        private void tg_btn_plus_menu_Unchecked(object sender, RoutedEventArgs e)
        {
            menu_stackP.Visibility = Visibility.Collapsed;
        }
        #endregion

        #region Textboxok figyelése validálása

        // Kor textbox vizsgálata
        private void tb_age_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(tb_age.Text, out int x) && Convert.ToInt32(tb_age.Text) < 99)
            {
                if (!btn_Calc.IsEnabled)
                {
                    ButtonEnable();

                }

            }
            else
            {
                tb_age.Text = "";
                ButtonEnable();
            }
        }

        //Magasság textbox vizsgálata
        private void tb_height_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(tb_height.Text, out int x) && tb_height.Text.Length > 2 && tb_height.Text.Length <= 3 && Convert.ToInt32(tb_height.Text) < 210)
            {
                if (!btn_Calc.IsEnabled)
                {
                    ButtonEnable();

                }

            }
            else
            {
                tb_height.Text = "";
                ButtonEnable();
            }
        }

        //Testsúly textbox vizsgálata
        private void tb_weight_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(tb_weight.Text, out int x) && tb_weight.Text.Length <= 3 && Convert.ToInt32(tb_weight.Text) < 250 && Convert.ToInt32(tb_weight.Text) > 35)
            {
                if (!btn_Calc.IsEnabled)
                {
                    ButtonEnable();

                }

            }
            else
            {
                tb_weight.Text = "";
                ButtonEnable();
            }
        }

        //Test zsír textbox vizsgálata (opcionális)
        private void tb_fat_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(tb_weight.Text, out int x) && tb_weight.Text.Length <= 3 && Convert.ToInt32(tb_weight.Text) < 250)
            {

            }
            else
            {
                tb_weight.Text = "";
            }
        }
        private void ButtonEnable()
        {
            if (tb_age.Text.Length > 0 && tb_height.Text.Length > 0 && tb_weight.Text.Length > 0)
            {
                btn_Calc.IsEnabled = true;
              
            }
            else
            {
                btn_Calc.IsEnabled = false;
            }
        }
        #endregion

        #region Sport Combobox Feltöltése 
        private void ComboBFill()
        {

            var lekerdezes = _contex.SportsData_DB.Select(x => x.sportName);
            if (lekerdezes != null)
            {
                foreach (var item in lekerdezes)
                {
                    cb_sport_type.Items.Add(item);
                }
                cb_sport_type.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Nem sikerült betölteni adatot a sport lehetőségek közé!", "Figyelem", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        #endregion

        #region Sport hozzáadása
        private void btn_add_newSport_Click(object sender, RoutedEventArgs e)
        {
            string actual_sport;
            int label_db = 0;

            if (tb_sport_minute.Text.Length > 0 && label_db < 5)
            {
                actual_sport = cb_sport_type.SelectedItem.ToString();

                add_sportStack.Visibility = Visibility.Visible;

                if (lb1_sport.Content == null)
                {
                    lb1_sport_minute.Content = tb_sport_minute.Text;
                    sport_Minutes[0] = tb_sport_minute.Text;
                    lb1_sport.Content = actual_sport;
                    added_sport1.Visibility = Visibility.Visible;
                    label_db++;
                }
                if (lb1_sport.Content != actual_sport && lb2_sport.Content == null)
                {
                    lb2_sport_minute.Content = tb_sport_minute.Text;
                    sport_Minutes[1] = tb_sport_minute.Text;
                    lb2_sport.Content = actual_sport;
                    added_sport2.Visibility = Visibility.Visible;
                    label_db++;
                }
                if (lb1_sport.Content != actual_sport && lb2_sport.Content != actual_sport && lb3_sport.Content == null)
                {
                    lb3_sport_minute.Content = tb_sport_minute.Text;
                    sport_Minutes[2] = tb_sport_minute.Text;
                    lb3_sport.Content = cb_sport_type.SelectedItem.ToString();
                    added_sport3.Visibility = Visibility.Visible;
                    label_db++;
                }
                if (lb1_sport.Content != actual_sport && lb2_sport.Content != actual_sport && lb3_sport.Content != actual_sport && lb4_sport.Content == null)
                {
                    lb4_sport_minute.Content = tb_sport_minute.Text;
                    sport_Minutes[3] = tb_sport_minute.Text;
                    lb4_sport.Content = cb_sport_type.SelectedItem.ToString();
                    added_sport4.Visibility = Visibility.Visible;
                    label_db++;
                }
                if (lb1_sport.Content != actual_sport && lb2_sport.Content != actual_sport && lb3_sport.Content != actual_sport && lb4_sport.Content != actual_sport && lb5_sport.Content == null)
                {
                    lb5_sport_minute.Content = tb_sport_minute.Text;
                    sport_Minutes[4] = tb_sport_minute.Text;
                    lb5_sport.Content = cb_sport_type.SelectedItem.ToString();
                    added_sport5.Visibility = Visibility.Visible;
                    label_db++;
                }
            }
            else
            {
                MessageBox.Show("Adja meg az időt!", "Figyelem!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        #region Sportok törlése
        private void btn_remove_thisSport_Click(object sender, RoutedEventArgs e)
        {

            Button btn = (Button)sender;
            switch (btn.Tag)
            {
                case "1":
                    {
                        lb1_sport_minute.Content = null;
                        lb1_sport.Content = null;
                        added_sport1.Visibility = Visibility.Collapsed;

                    }
                    break;

                case "2":
                    {
                        lb2_sport_minute.Content = null;
                        lb2_sport.Content = null;
                        added_sport2.Visibility = Visibility.Collapsed;
                    }
                    break;

                case "3":
                    {
                        lb3_sport_minute.Content = null;
                        lb3_sport.Content = null;
                        added_sport3.Visibility = Visibility.Collapsed;
                    }
                    break;

                case "4":
                    {
                        lb4_sport_minute.Content = null;
                        lb4_sport.Content = null;
                        added_sport4.Visibility = Visibility.Collapsed;
                    }
                    break;

                case "5":
                    {
                        lb5_sport_minute.Content = null;
                        lb5_sport.Content = null;
                        added_sport5.Visibility = Visibility.Collapsed;
                    }
                    break;
            }
        }
        #endregion
        private void btn_Calc_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        #region Számítás
        public void Calc_Kcal()
        {

            #region BMR számítás magyarázat
            //BMR számítás 
            /*
               Férfiak esetében: BMR = 10 x W + 6,25 x H – 5 x A + 5
               Nők esetében: BMR = 10 x W + 6,25 x H – 5 x A – 161

            A W, H és A értékek jelentése a következő:

            W (weight) a testsúly kg-ban megadva
            H (high) a testmagasság cm-ben megadva
            A (age) az életkor években megadva
             */
            #endregion

            #region BMR Számítás
            age = Convert.ToInt32(tb_age.Text);
            height = Convert.ToInt32(tb_height.Text);
            weight = Convert.ToInt32(tb_weight.Text);



            if (cb_gender.SelectionBoxItem.ToString() == "Férfi")
            {
                BMR_Value = Convert.ToInt32(((10 * weight) + (6.25 * height)) - (5 * (age + 5)));

            }
            if (cb_gender.SelectionBoxItem.ToString() == "Nő")
            {
                BMR_Value = Convert.ToInt32(((10 * Convert.ToInt32(tb_weight.Text)) + (6.25 * Convert.ToInt64(tb_height.Text))) - (5 * (Convert.ToInt32(tb_age.Text) + 5)));

            }
            #endregion

            #region Kalória szükséglet kalkulátor

            double hour = 24;
            double bmrPerHour = BMR_Value / hour;

            sleep = bmrPerHour * 0.95;

            if (tb_sleep.Text.Length > 0)
            {
                sleep = sleep * Convert.ToInt32(tb_sleep.Text);
                hour -= Convert.ToInt32(tb_sleep.Text);
            }
            else
            {
                tb_sleep.Text = "8";
                sleep = sleep * Convert.ToInt32(tb_sleep.Text);
                hour -= Convert.ToInt32(tb_sleep.Text);
            }

            switch (cb_working_type.SelectedItem)
            {
                case "Ülőmunka/Tanuló": working = (Convert.ToInt32(tb_working.Text) * 1.1) * bmrPerHour; hour -= Convert.ToInt32(tb_working.Text); break;
                case "Átlagos aktivitású munka": working = (Convert.ToInt32(tb_working.Text) * 1.3) * bmrPerHour; hour -= Convert.ToInt32(tb_working.Text); break;
                case "Könnyű fizikai munka": working = (Convert.ToInt32(tb_working.Text) * 1.5) * bmrPerHour; hour -= Convert.ToInt32(tb_working.Text); break;
                case "Nehéz fizikai munka": working = (Convert.ToInt32(tb_working.Text) * 1.7) * bmrPerHour; hour -= Convert.ToInt32(tb_working.Text); break;
            }

            if (menu_stackP.Visibility == Visibility.Visible)
            {
                var lekerdez = _contex.SportsData_DB.Where(x => x.sportName == lb1_sport.Content || x.sportName == lb2_sport.Content || x.sportName == lb3_sport.Content || x.sportName == lb4_sport.Content || x.sportName == lb5_sport.Content).ToList();


                int i = 0;
                foreach (var item in lekerdez)
                {
                    sportKcal += Math.Round((Convert.ToDouble(item.sportKcal) * Convert.ToInt32(sport_Minutes[i])) * weight, 2);
                    SportMinute += Convert.ToInt32(sport_Minutes[i]) * 0.01;
                    i++;

                }
                hour -= SportMinute;
            }

            sum_AllValues = Convert.ToInt32((working + sleep + sportKcal) + (hour * bmrPerHour));
            mealsPerValues[0] = Convert.ToInt32(sum_AllValues*0.3);
            mealsPerValues[1] = Convert.ToInt32(sum_AllValues * 0.4);
            mealsPerValues[2] = Convert.ToInt32(sum_AllValues * 0.25);
            #endregion
        }
        #endregion

    }
}
