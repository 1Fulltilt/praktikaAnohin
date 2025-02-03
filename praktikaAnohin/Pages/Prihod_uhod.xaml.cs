using praktikaAnohin.AppData;
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

namespace praktikaAnohin.Pages
{
    /// <summary>
    /// Логика взаимодействия для Prihod_uhod.xaml
    /// </summary>
    public partial class Prihod_uhod : Page
    {
        public Prihod_uhod()
        {
            InitializeComponent();
        }

        private void DellBtn_Click(object sender, RoutedEventArgs e)
        {
            var del = PrihodDG.SelectedItems.Cast<Prihod___uhod_avto>().ToList();
            foreach (var delcl in del)
            {
              
                if (MessageBox.Show($"Удалить {del.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) connect.context.Prihod___uhod_avto.RemoveRange(del);

                try
                {
                    connect.context.SaveChanges();
                    PrihodDG.ItemsSource = connect.context.Prihod___uhod_avto.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ObnovitBtn_Click(object sender, RoutedEventArgs e)
        {
            PrihodDG.ItemsSource = connect.context.Prihod___uhod_avto.ToList().OrderBy(x => x.id_zapisi);
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NazadBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NAV.MainFrame.CanGoBack)
            {
                NAV.MainFrame.GoBack();
            }
        }

        private void searchText_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                searchText.Foreground = Brushes.Black;
                string searchTxt = searchText.Text;

                if (cmbBx.SelectedIndex == 0) // Поиск по id_storozha (целое число)
                {
                    int searchInt;
                    if (int.TryParse(searchTxt, out searchInt))
                    {
                        PrihodDG.ItemsSource = connect.context.Prihod___uhod_avto.Where(x => x.id_zapisi.Equals(searchInt)).ToList();
                    }
                    else
                    {
                        searchText.Foreground = Brushes.Red;
                    }
                }
                else if (cmbBx.SelectedIndex == 1)
                {
                    DateTime searchDate = Convert.ToDateTime(searchText.Text);
                    PrihodDG.ItemsSource = connect.context.Prihod___uhod_avto.Where(x => x.data.Equals(searchDate)).ToList();
                }
                else if (cmbBx.SelectedIndex == 2)
                {
                    DateTime searchDate = Convert.ToDateTime(searchText.Text);
                    PrihodDG.ItemsSource = connect.context.Prihod___uhod_avto.Where(x => x.time.Equals(searchDate)).ToList();
                }
            }
            catch
            {
                searchText.Foreground = Brushes.Red;
            }
        }

        private void PrihodDG_SelectionChanged()
        {

        }
    }
}
