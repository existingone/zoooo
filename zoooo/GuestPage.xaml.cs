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

        private void UpdatingAnimals()
        {
            using (FileStream fsa = new FileStream("animals.xml", FileMode.Create))
            {
                XmlSerializer xmla = new XmlSerializer(typeof(List<Animal>));
                xmla.Serialize(fsa, animals);
            }
            Logging.Log("Выполнена сериализация списка животных");
        }
        private void UpdatingEmployees()
        {
            using (FileStream fse = new FileStream("employees.xml", FileMode.Create))
            {
                XmlSerializer xmle = new XmlSerializer(typeof(List<Employee>));
                xmle.Serialize(fse, employees);
            }


            Logging.Log("Выполнена сериализация списка работников");
        }

        private void LoadingInfoAboutAnimals()
        {
            using (FileStream fsa = new FileStream("animals.xml", FileMode.Open))
            {
                XmlSerializer xmla = new XmlSerializer(typeof(List<Animal>));
                animals = (List<Animal>)xmla.Deserialize(fsa);
            }

            Logging.Log("Выполнена десериализация списка животных");
        }
        private void LoadingInfoAboutEmployees()
        {
            using (FileStream fse = new FileStream("employees.xml", FileMode.Open))
            {
                XmlSerializer xmle = new XmlSerializer(typeof(List<Employee>));
                employees = (List<Employee>)xmle.Deserialize(fse);
            }


            Logging.Log("Выполнена десериализация списка работников");
        }

        private void updatingInfoAboutAnimals()
        {
            listBoxAnimals.ItemsSource = null;
            listBoxAnimals.ItemsSource = animals;

        }
        private void updatingInfoAboutEmployees()
        {
            listBoxEmployees.ItemsSource = null;
            listBoxEmployees.ItemsSource = employees;

        }



        public GuestPage()
        {
            InitializeComponent();
            Logging.Log("Программа запущена");
            LoadingInfoAboutAnimals();
            updatingInfoAboutAnimals();
            LoadingInfoAboutEmployees();
            updatingInfoAboutEmployees();
        }

        private void buttonFindAnimal_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonFindEmployee_Click(object sender, RoutedEventArgs e)
        {
            List<Employee> found_employees = new List<Employee>();
            foreach (var employee in employees)
            {
                if (textBoxEmployee.Text == employee.Id)
                {
                    found_employees.Add(employee);

                    Logging.Log("Выполнен поиск работника с id" + employee.Id);
                    break;
                }

            }
            if (found_employees.Count == 0)
            {
                MessageBox.Show("Работник с таким айди не существует.", "ОШИБКА");
                textBoxEmployee.Clear();
            }
            else
            {
                listBoxEmployees.ItemsSource = null;
                listBoxEmployees.ItemsSource = found_employees;
            }

            //foreach (var employee in employees)
            //{
            //    if (write_employee_id.Text == employee.Animal)
            //    {
            //        found_employees.Add(employee);

            //        Logging.Log("Выполнен поиск работников, ответственных за животное с id" + employee.Animal);
            //    }

            //}
            //if (found_employees.Count == 0)
            //{
            //    MessageBox.Show("Животное с таким айди не существует.", "ОШИБКА");
            //    write_employee_id.Clear();
            //}
            //else
            //{
            //    listBoxforemployees.ItemsSource = null;
            //    listBoxforemployees.ItemsSource = found_employees;
            //} сделай айди для работникво начинающимся с 1 и проврять через парс айди для проверок


        }

        private void buttonResetAnimal_Click(object sender, RoutedEventArgs e)
        {
            updatingInfoAboutAnimals();

        }

        private void buttonResetEmployee_Click(object sender, RoutedEventArgs e)
        {
            updatingInfoAboutEmployees();

        }
    }
}
