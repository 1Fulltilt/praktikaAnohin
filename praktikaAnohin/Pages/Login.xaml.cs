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
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
            ImageBrush backgroundBrush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/BackGroundImage.jpg")));
            backgroundBrush.Opacity = 0.3;
            this.Background = backgroundBrush;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var currectUser = connect.context.Users.FirstOrDefault(x => x.name == txtLogin.Text);
            if (connect.context.Users.FirstOrDefault(x => x.password == txtPswrd.Password) != null &&
                connect.context.Users.FirstOrDefault(x => x.name == txtLogin.Text) != null ||
                connect.context.Users.FirstOrDefault(x => x.email == txtLogin.Text) != null)              
            {
                var currectRole = connect.context.Roles.FirstOrDefault(x => x.id == currectUser.role_id);
                if (currectRole != null)
                {
                    PriorityLVL.RoleId = currectRole.id;
                    PriorityLVL.Priority = currectRole.priority;
                    NAV.MainFrame.Navigate(new MenuPage());
                }
                else
                {
                    MessageBox.Show("Не удалось получить данные о правах пользователя", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Не верный логин или пароль", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
