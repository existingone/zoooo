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
        SolidColorBrush original = new SolidColorBrush(System.Windows.Media.Color.FromRgb(221, 221, 221));
        SolidColorBrush changed = new SolidColorBrush(System.Windows.Media.Color.FromRgb(170, 58, 58));


        private string CalculateHash(string password)
        {
            MD5 md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            return Convert.ToBase64String(hash);
        }
        private void buttonLogin_Click_1(object sender, RoutedEventArgs e)
        {

            var hash = CalculateHash("1");
            if (string.IsNullOrWhiteSpace(textBoxLogin.Text) || string.IsNullOrWhiteSpace(passwordBox.Password))
            {
                buttonLogin.Background = changed;
                MessageBox.Show("Введите данные.", "ОШИБКА");
                buttonLogin.Background = original;
            }

            else if (textBoxLogin.Text == "1")
            {
                if (CalculateHash(passwordBox.Password) == hash)
                {
                    passwordBox.Clear();
                    textBoxLogin.Clear();
                    NavigationService.Navigate(Pages.MainPage);
                }
                else
                {
                    Logging.Log("Введен неверный пароль.");
                    buttonLogin.Background = changed;
                    MessageBox.Show("Неверный пароль.", "ОШИБКА");
                    passwordBox.Clear();
                    buttonLogin.Background = original;

                }
            }
            else
            {
                Logging.Log("Введен неверный логин.");
                buttonLogin.Background = changed;
                MessageBox.Show("Неверный логин.", "ОШИБКА");
                textBoxLogin.Clear();
                buttonLogin.Background = original;

            }


        }

        private void buttonGuestLogin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.GuestPage);

        }

        private void textBoxLogin_GotFocus(object sender, RoutedEventArgs e)
        {
            textBoxLogin.Text = "";
        }

        private void textBoxLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxLogin.Text))
            {
                textBoxLogin.Text = "Введите логин";

            }

        }

    }
}
