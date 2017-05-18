using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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


namespace zoooo
{
    /// <summary>
    /// Логика взаимодействия для loginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        private string CalculateHash(string password)
        {
            MD5 md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            return Convert.ToBase64String(hash);
        }
        private void buttonLogin_Click_1(object sender, RoutedEventArgs e)
        {
            var hash = CalculateHash("zoo123");

            if (textBoxLogin.Text == "administrator" && CalculateHash(passwordBox.Password) == hash)
                NavigationService.Navigate(Pages.MainPage);
            else
                MessageBox.Show("Введите корректные данные.", "ОШИБКА");
        }

        private void buttonGuestLogin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.GuestPage);

        }
    }
}
