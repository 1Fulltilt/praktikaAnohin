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
    /// Логика взаимодействия для ADDSpisVladelca.xaml
    /// </summary>
    public partial class ADDSpisVladelca : Page
    {
        Spiski_vladelca spiski_Vladelca;
        bool chek;
        public ADDSpisVladelca(Spiski_vladelca c)
        {
            InitializeComponent();
            if (c == null)
            {
                c = new Spiski_vladelca();
                chek = true;
            }
            else
                chek = false;
            DataContext = spiski_Vladelca = c;
        }

        private void DobavitBtn_Click(object sender, RoutedEventArgs e)
        {
            if (chek)
            {
                connect.context.Spiski_vladelca.Add(spiski_Vladelca);
            }
            try
            {
                connect.context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void ExitBtn_Click()
        {

        }
    }
}
