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
    /// Логика взаимодействия для ADDSpisAvto.xaml
    /// </summary>
    public partial class ADDSpisAvto : Page
    {
        praktikaAnohin.AppData.Spisok_Avto spisok_Avto;
        bool chek;
        public ADDSpisAvto(praktikaAnohin.AppData.Spisok_Avto c)
        {
            InitializeComponent();
            if (c == null)
            {
                c = new praktikaAnohin.AppData.Spisok_Avto();
                chek = true;
            }
            else
                chek = false;
            DataContext = spisok_Avto = c;
        }

        private void DobavitBtn_Click(object sender, RoutedEventArgs e)
        {
            if (chek)
            {
                connect.context.Spisok_Avto.Add(spisok_Avto);
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
    }
}
