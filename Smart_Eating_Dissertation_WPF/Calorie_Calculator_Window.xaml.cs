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
        #region Változók
        List<string> sports_list = new List<string>();
        private readonly ApplicationDbContext _contex;
        #endregion
        public Calorie_Calculator_Window()
        {
            InitializeComponent();
            _contex = new ApplicationDbContext();
            ComboBFill();
        }

        private void btn_exit_calc_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tg_btn_plus_menu_Checked(object sender, RoutedEventArgs e)
        {
            menu_stackP.Visibility = Visibility.Visible;

        }

        private void tg_btn_plus_menu_Unchecked(object sender, RoutedEventArgs e)
        {
            menu_stackP.Visibility = Visibility.Collapsed;
        }

        private void tb_age_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Int32.TryParse(tb_age.Text, out int x))
            {

            }
            else
            {
                tb_age.Text = "";
            }
        }

        private void tb_height_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Int32.TryParse(tb_height.Text, out int x))
            {

            }
            else
            {
                tb_age.Text = "";
            }
        }

        private void tb_weight_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Int32.TryParse(tb_weight.Text, out int x))
            {

            }
            else
            {
                tb_age.Text = "";
            }
        }

        private void tb_fat_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Int32.TryParse(tb_fat.Text, out int x))
            {

            }
            else
            {
                tb_age.Text = "";
            }
        }

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
            if (tb_sport_minute.Text.Length > 0)
            {
                actual_sport = cb_sport_type.SelectedItem.ToString();

                add_sportStack.Visibility = Visibility.Visible;

                if (lb1_sport.Content == null)
                {
                    lb1_sport.Content = actual_sport;
                }
                if (lb1_sport.Content != actual_sport && lb2_sport.Content == null)
                {
                    lb2_sport.Content = actual_sport;
                }
                if (lb1_sport.Content != actual_sport && lb2_sport.Content != actual_sport && lb3_sport.Content == null)
                {
                    lb3_sport.Content = cb_sport_type.SelectedItem.ToString();
                }
                if (lb1_sport.Content != actual_sport && lb2_sport.Content != actual_sport && lb3_sport.Content != actual_sport && lb4_sport.Content == null)
                {
                    lb4_sport.Content = cb_sport_type.SelectedItem.ToString();
                }
                if (lb1_sport.Content != actual_sport && lb2_sport.Content != actual_sport && lb3_sport.Content != actual_sport && lb4_sport.Content != actual_sport && lb5_sport.Content == null)
                {
                    lb5_sport.Content = cb_sport_type.SelectedItem.ToString();
                }
            }
            else
            {
                MessageBox.Show("Adja meg az időt!", "Figyelem!",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
        }
        #endregion
        private void btn_Calc_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
