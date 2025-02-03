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
using System.Windows.Shapes;

namespace praktikaAnohin.Pages
{
    /// <summary>
    /// Логика взаимодействия для ADDOhranaWindow.xaml
    /// </summary>
    public partial class ADDOhranaWindow : Window
    {
        praktikaAnohin.AppData.Ohrana ohran;
        bool chek;
        public ADDOhranaWindow(praktikaAnohin.AppData.Ohrana c)
        {
            InitializeComponent();
            if (c == null)
            {
                c = new praktikaAnohin.AppData.Ohrana();
                chek = true;
            }
            else
                chek = false;
            DataContext = ohran = c;
        }
        private void DobavitBtn_Click(object sender, RoutedEventArgs e)
        {
            if(chek)
            {
                connect.context.Ohrana.Add(ohran);
            }
            try
            {
                connect.context.SaveChanges();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK , MessageBoxImage.Error);
            }
            this.Hide();
            OhranaWindow ohranaWindow = new OhranaWindow();
            ohranaWindow.Show();
        }

        private void ExitBtn_Click()
        {

        }
    }
}
