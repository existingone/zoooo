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
using System.IO;
using System.Xml.Serialization;
namespace zoooo
{
    /// <summary>
    /// Логика взаимодействия для GuestPage.xaml
    /// </summary>
    public partial class GuestPage : Page
    {
        List<Animal> animals = new List<Animal>();
        List<Employee> employees = new List<Employee>();

        private void LoadingInfoAboutAnimals()
        {
            if (File.Exists("animals.xml"))
            {
                try
                {
                    using (FileStream fsa = new FileStream("animals.xml", FileMode.Open))
                    {
                        XmlSerializer xmla = new XmlSerializer(typeof(List<Animal>));
                        animals = (List<Animal>)xmla.Deserialize(fsa);
                    }
                    Logging.Log("Выполнена десериализация списка животных");
                }
                catch
                {
                    MessageBox.Show("Файлы не могут быть восстановлены.");
                }
            }
        }
        private void LoadingInfoAboutEmployees()
        {
            if (File.Exists("employees.xml"))
            {
                try
                {
                    using (FileStream fse = new FileStream("employees.xml", FileMode.Open))
                    {
                        XmlSerializer xmle = new XmlSerializer(typeof(List<Employee>));
                        employees = (List<Employee>)xmle.Deserialize(fse);
                    }

                    Logging.Log("Выполнена десериализация списка работников");
                }
                catch
                {
                    MessageBox.Show("Файлы не могут быть восстановлены.");
                }
            }
        }
        private void UpdatingListboxAnimals()
        {
            listBoxAnimals.ItemsSource = null;
            listBoxAnimals.ItemsSource = animals;

        }
        private void UpdatingListboxEmployees()
        {
            listBoxEmployees.ItemsSource = null;
            listBoxEmployees.ItemsSource = employees;

        }

        public GuestPage()
        {
            InitializeComponent();
            Logging.Log("Программа запущена в режиме гостя.");
            LoadingInfoAboutAnimals();
            UpdatingListboxAnimals();
            LoadingInfoAboutEmployees();
            UpdatingListboxEmployees();
        }

        private void buttonFindAnimal_Click(object sender, RoutedEventArgs e)
        {
            List<Animal> found_animals = new List<Animal>();
            int number;
            if (!int.TryParse(textBoxAnimal.Text, out number) || string.IsNullOrWhiteSpace(textBoxAnimal.Text)) { MessageBox.Show("Введите шестизначное число.", "ОШИБКА"); }
            else {
                foreach (var animal in animals)
                    {
                        if (int.Parse(textBoxAnimal.Text) < 100000)
                        {
                            if (textBoxAnimal.Text == animal.Id)
                            {
                                found_animals.Add(animal);
                                Logging.Log("Выполнен поиск животного с id " + animal.Id + ".");
                                break;
                            }
                        }
                        else
                        {
                            if (textBoxAnimal.Text == animal.Worker)
                            {
                                found_animals.Add(animal);
                                Logging.Log("Выполнен поиск животных, обслуживаемых работником с id " + animal.Worker + ".");
                                break;
                            }
                        }

                    }
                    if (found_animals.Count == 0)
                    {
                        MessageBox.Show("Такого айди не существует.", "ОШИБКА");
                        textBoxAnimal.Clear();
                    }
                    else
                    {
                        listBoxAnimals.ItemsSource = null;
                        listBoxAnimals.ItemsSource = found_animals;
                    }
                }
            
        }

        private void buttonFindEmployee_Click(object sender, RoutedEventArgs e)
        {
            List<Employee> found_employees = new List<Employee>();
            int number;
            if (!int.TryParse(textBoxEmployee.Text, out number) || string.IsNullOrWhiteSpace(textBoxEmployee.Text)) { MessageBox.Show("Введите шестизначное число.", "ОШИБКА"); }
            else
            {
                foreach (var employee in employees)
                {

                    if (int.Parse(textBoxEmployee.Text) >= 100000)
                    {
                        if (textBoxEmployee.Text == employee.Id)
                        {
                            found_employees.Add(employee);

                            Logging.Log("Выполнен поиск работника с id " + employee.Id + ".");
                            break;
                        }
                    }
                    else
                    {
                        if (textBoxEmployee.Text == employee.Animal)
                        {
                            found_employees.Add(employee);

                            Logging.Log("Выполнен поиск работников, ответственных за животное с id " + employee.Animal + ".");
                            break;
                        }
                    }

                }
                if (found_employees.Count == 0)
                {
                    MessageBox.Show("Такого айди не существует.", "ОШИБКА");
                    textBoxEmployee.Clear();
                }
                else
                {
                    listBoxEmployees.ItemsSource = null;
                    listBoxEmployees.ItemsSource = found_employees;
                }
            }
        }

        private void buttonResetAnimal_Click(object sender, RoutedEventArgs e)
        {
            UpdatingListboxAnimals();

        }

        private void buttonResetEmployee_Click(object sender, RoutedEventArgs e)
        {
            UpdatingListboxEmployees();

        }

        private void buttonGoLogin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.LoginPage);
            Logging.Log("Выполнен переход на страницу авторизации.");

        }

        private void textBoxAnimal_GotFocus(object sender, RoutedEventArgs e)
        {
            textBoxAnimal.Text = "";
        }

        private void textBoxAnimal_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxAnimal.Text))
            {
                textBoxAnimal.Text = "Введите id";
            }

        }

        private void textBoxEmployee_GotFocus(object sender, RoutedEventArgs e)
        {
            textBoxEmployee.Text = "";
        }

        private void textBoxEmployee_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxEmployee.Text))
            {
                textBoxEmployee.Text = "Введите id";
            }

        }
    }
}
