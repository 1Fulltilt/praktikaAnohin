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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace praktikaAnohin.Pages
{
    /// <summary>
    /// Логика взаимодействия для OhranaWindow.xaml
    /// </summary>
    public partial class OhranaWindow : Window
    {
        public OhranaWindow()
        {
            InitializeComponent();
            OhranaDG.ItemsSource = connect.context.Ohrana.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            ADDOhranaWindow aDDOhranaWindow = new ADDOhranaWindow(null);
            aDDOhranaWindow.Show();
            this.Hide();
        }

        private void DellBtn_Click()
        {          

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
    }
}
