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
    /// Логика взаимодействия для ADDPrihod.xaml
    /// </summary>
    public partial class ADDPrihod : Page
    {
        Prihod___uhod_avto prihod_Uhod;
        bool chek;
        public ADDPrihod(Prihod___uhod_avto c)
        {
            InitializeComponent();
            if (c == null)
            {
                c = new Prihod___uhod_avto();
                chek = true;
            }
            else
                chek = false;
            DataContext = prihod_Uhod = c;
        }

       

        private void DobavitBtn_Click_1(object sender, RoutedEventArgs e)
        {
            if (chek)
            {
                connect.context.Prihod___uhod_avto.Add(prihod_Uhod);
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

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
