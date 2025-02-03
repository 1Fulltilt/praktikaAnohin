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
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }
        private void ohranaBtn_Click(object sender, RoutedEventArgs e)
        {
            NAV.MainFrame.Navigate(new Ohrana());
        }

        private void PrihUhAvtoBtn_Click()
        {

        }

        private void PrihUhAvtoBtn_Click_1(object sender, RoutedEventArgs e)
        {
            NAV.MainFrame.Navigate(new Prihod_uhod());

        }

        private void SpisVladelecaBtn_Click(object sender, RoutedEventArgs e)
        {
            NAV.MainFrame.Navigate(new praktikaAnohin.Pages.SpisVladelca());
        }

        private void spisAvtoBtn_Click(object sender, RoutedEventArgs e)
        {
            NAV.MainFrame.Navigate(new Spisok_Avto());
        }

        private void otchetBtn_Click(object sender, RoutedEventArgs e)
        {
            NAV.MainFrame.Navigate(new Otchet());
        }

        private void VihodBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
