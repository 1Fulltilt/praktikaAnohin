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
    /// Логика взаимодействия для Ohrana.xaml
    /// </summary>
    public partial class Ohrana : Page
    {
        public Ohrana()
        {
            InitializeComponent();
            OhranaDG.ItemsSource = connect.context.Ohrana.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NAV.MainFrame.Navigate(new ADDOhrana(null));
        }

        private void DellBtn_Click_1(object sender, RoutedEventArgs e)
        {
            var del = OhranaDG.SelectedItems.Cast<praktikaAnohin.AppData.Ohrana>().ToList();
            foreach (var delcl in del)
            {

                if (MessageBox.Show($"Удалить {del.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) connect.context.Ohrana.RemoveRange(del);

                try
                {
                    connect.context.SaveChanges();
                    OhranaDG.ItemsSource = connect.context.Ohrana.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ObnovitBtn_Click(object sender, RoutedEventArgs e)
        {
            OhranaDG.ItemsSource = connect.context.Ohrana.ToList().OrderBy(x => x.id_storozha);
        }

        private void NazadBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NAV.MainFrame.CanGoBack)
            {
                NAV.MainFrame.GoBack();
            }
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            NAV.MainFrame.Navigate(new ADDOhrana((sender as Button).DataContext as praktikaAnohin.AppData.Ohrana));
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
                        OhranaDG.ItemsSource = connect.context.Ohrana.Where(x => x.id_storozha.Equals(searchInt)).ToList();
                    }
                    else
                    {
                        searchText.Foreground = Brushes.Red;
                    }
                }
                else if (cmbBx.SelectedIndex == 1 || cmbBx.SelectedIndex == 2 || cmbBx.SelectedIndex == 3) // Поиск по строкам (FIO, Telefon, Adres)
                {
                    // Используйте searchTxt как строку
                    if (cmbBx.SelectedIndex == 1)
                    {
                        OhranaDG.ItemsSource = connect.context.Ohrana.Where(x => x.FIO.Contains(searchTxt)).ToList();
                    }
                    else if (cmbBx.SelectedIndex == 2)
                    {
                        OhranaDG.ItemsSource = connect.context.Ohrana.Where(x => x.Telefon.Contains(searchTxt)).ToList();
                    }
                    else if (cmbBx.SelectedIndex == 3)
                    {
                        OhranaDG.ItemsSource = connect.context.Ohrana.Where(x => x.Adres.Contains(searchTxt)).ToList();
                    }
                }
            }
            catch
            {
                searchText.Foreground = Brushes.Red;
            }
        }

    }
}
