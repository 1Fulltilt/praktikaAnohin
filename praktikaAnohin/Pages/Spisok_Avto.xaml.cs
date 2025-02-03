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
    /// Логика взаимодействия для Spisok_Avto.xaml
    /// </summary>
    public partial class Spisok_Avto : Page
    {
        public Spisok_Avto()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NAV.MainFrame.Navigate(new praktikaAnohin.Pages.ADDSpisAvto(null));
        }

        private void DellBtn_Click(object sender, RoutedEventArgs e)
        {
            var del = AvtoDG.SelectedItems.Cast<praktikaAnohin.AppData.Spisok_Avto>().ToList();
            foreach (var delcl in del)
            {
              
                if (MessageBox.Show($"Удалить {del.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) connect.context.Spisok_Avto.RemoveRange(del);

                try
                {
                    connect.context.SaveChanges();
                    AvtoDG.ItemsSource = connect.context.Spisok_Avto.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ObnovitBtn_Click(object sender, RoutedEventArgs e)
        {
            AvtoDG.ItemsSource = connect.context.Spisok_Avto.ToList().OrderBy(x => x.Id_avto);
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
                        AvtoDG.ItemsSource = connect.context.Spisok_Avto.Where(x => x.Id_avto.Equals(searchInt)).ToList();
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
                        AvtoDG.ItemsSource = connect.context.Spisok_Avto.Where(x => x.marka_avto.Contains(searchTxt)).ToList();
                    }
                    else if (cmbBx.SelectedIndex == 2)
                    {
                        AvtoDG.ItemsSource = connect.context.Spisok_Avto.Where(x => x.model_avto.Contains(searchTxt)).ToList();
                    }
                    else if (cmbBx.SelectedIndex == 3)
                    {
                        AvtoDG.ItemsSource = connect.context.Spisok_Avto.Where(x => x.gos_znak.Contains(searchTxt)).ToList();
                    }
                }
            }
            catch
            {
                searchText.Foreground = Brushes.Red;
            }
        }

        private void AvtoDG_SelectionChanged()
        {

        }
    }
}
