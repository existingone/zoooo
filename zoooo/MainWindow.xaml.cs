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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
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
            listBoxforanimals.ItemsSource = null;
            listBoxforanimals.ItemsSource = animals;

        }
        private void updatingInfoAboutEmployees()
        {
            listBoxforemployees.ItemsSource = null;
            listBoxforemployees.ItemsSource = employees;

        }

        private void textBoxFocus(object sender, RoutedEventArgs e)
        {
            write_animal_id.Text = "";
        }

        private void textBoxLostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(write_animal_id.Text))
            {
                write_animal_id.Text = "Введите id";
            }

        }


        public MainWindow()
        {
            InitializeComponent();
            Logging.Log("Программа запущена");
            LoadingInfoAboutAnimals();
            updatingInfoAboutAnimals();
        }

        /// <summary>
        /// 
        /// </summary>
        private void add_animal_Click_(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(adding_id1.Text))
            {
                MessageBox.Show("Введите id.", "ОШИБКА");
                return;
            }
            if (string.IsNullOrWhiteSpace(adding_timeforfeeding1.Text))
            {
                MessageBox.Show("Введите время кормления.", "ОШИБКА");
                return;
            }
            if (string.IsNullOrWhiteSpace(adding_worker1.Text))
            {
                MessageBox.Show("Введите id работника.", "ОШИБКА");
                return;
            }
            if (string.IsNullOrWhiteSpace(adding_section1.Text))
            {
                MessageBox.Show("Введите секцию.", "ОШИБКА");
                return;
            }
            if (string.IsNullOrWhiteSpace(adding_foodset1.Text))
            {
                MessageBox.Show("Введите набор пищи.", "ОШИБКА");
                return;
            }

            if (string.IsNullOrWhiteSpace(adding_species1.Text))
            {
                MessageBox.Show("Введите вид.", "ОШИБКА");
                return;
            }

            foreach (var animal in animals)
            {
                if (adding_id1.Text == animal.Id)
                {
                    MessageBox.Show("Животное с таким айди уже существует.", "ОШИБКА");
                    adding_id1.Clear();
                    break;

                }
            }
                Animal temp = new Animal(adding_id1.Text, adding_timeforfeeding1.Text, adding_worker1.Text, adding_section1.Text, adding_foodset1.Text, adding_species1.Text);
            // foreach (var worker in employees)
            //{
            //  if (adding_worker1.Text == worker.Id)
            //{
            //  break;
            //   }
            // else { adding_worker1.Clear();}
            // }
            // if (adding_worker1.Text == null)
            // {
            //   MessageBox.Show("Работника с таким айди не существует.", "ОШИБКА");
            // 
            //  }

            animals.Add(temp);
            MessageBox.Show("Животное с айди " + temp.Id + " добавлено.");
            UpdatingAnimals(); //сериализация
            updatingInfoAboutAnimals(); //листбокс
            adding_id1.Clear();
            adding_timeforfeeding1.Clear();
            adding_worker1.Clear();
            adding_section1.Clear();
            adding_foodset1.Clear();
            adding_species1.Clear();
        }


        private void add_employee_Click(object sender, RoutedEventArgs e)
        {
            Employee temp = new Employee(adding_name2.Text, adding_surname2.Text, adding_workinghours2.Text, adding_id2.Text, adding_animal2.Text);
            employees.Add(temp);
            MessageBox.Show(temp.Surname, "добавлен");
            string message = "добавлен сотрудник с id " + temp.Id;
            Logging.Log(message);
            UpdatingEmployees();
        }

        private void delete_animal_Click(object sender, RoutedEventArgs e)
        {
            foreach (var temp in animals)
            {
                int count;
                if (write_animal_id.Text == temp.Id)
                {
                    Logging.Log("Удалено животное с id" + temp.Id);
                    animals.Remove(temp);
                    count = 1;
                    break;
                }
                else
                {
                    count = 0;
                }
                if (count == 0) { MessageBox.Show("Животного с таким id не существует.", "ОШИБКА"); }
            }

            updatingInfoAboutAnimals();
            UpdatingAnimals();
        }

        private void delete_employee_Click(object sender, RoutedEventArgs e)
        {


            updatingInfoAboutEmployees();
            UpdatingEmployees();
        }

        private void find_animal_Click(object sender, RoutedEventArgs e)
        {
            foreach (var animal in animals)
            {
                int count;
                if (write_animal_id.Text == animal.Id)
                {
                    MessageBox.Show("-Вид: " + animal.Species + "-Секция: " + animal.Section + "-Время кормления: " + animal.Timeforfeeding + "-Id работника: " + animal.Worker + "-Набор пищи: " + animal.Foodset);
                    count = 1;
                    Logging.Log("Выполнен поиск животного с id" + animal.Id);
                    break;
                }
                else { count = 0; }
                if (count == 0)
                {
                    MessageBox.Show("Животное с таким айди НЕ существует.", "ОШИБКА");
                }
            }
        }




        private void edit_animal_Click(object sender, RoutedEventArgs e)
        {
            foreach (var temp in animals)
            {
                int count;
                if (writing_id1.Text == temp.Id)
                {
                    count = 1;
                    if (string.IsNullOrWhiteSpace(changing_timeforfeeding1.Text))
                    {
                        MessageBox.Show("Введите время кормления.", "ОШИБКА");
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(changing_worker1.Text))
                    {
                        MessageBox.Show("Введите id работника.", "ОШИБКА");
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(changing_section1.Text))
                    {
                        MessageBox.Show("Введите секцию.", "ОШИБКА");
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(changing_foodset1.Text))
                    {
                        MessageBox.Show("Введите набор пищи.", "ОШИБКА");
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(changing_species1.Text))
                    {
                        MessageBox.Show("Введите вид.", "ОШИБКА");
                        return;
                    }
                    Animal buffer = new Animal(writing_id1.Text, changing_timeforfeeding1.Text, changing_worker1.Text, changing_section1.Text, changing_foodset1.Text, changing_species1.Text);


                    // foreach (var worker in employees)
                    //{
                    //  if (adding_worker1.Text == worker.Id)
                    //{
                    //  break;
                    //   }
                    // else { adding_worker1.Clear();}
                    // }
                    // if (adding_worker1.Text == null)
                    // {
                    //   MessageBox.Show("Работника с таким айди не существует.", "ОШИБКА");
                    // 
                    //  }

                    MessageBox.Show("Животное с айди " + temp.Id + " обновлено.");
                    writing_id1.Clear();
                    changing_timeforfeeding1.Clear();
                    changing_worker1.Clear();
                    changing_section1.Clear();
                    changing_foodset1.Clear();
                    changing_species1.Clear();

                    animals.Remove(temp);
                    animals.Add(buffer);

                    Logging.Log("Изменены характристики животного с id" + buffer.Id);
                    break;
                }
                else
                {
                    count = 0;
                }
                if (count == 0) { MessageBox.Show("Животного с таким id не существует.", "ОШИБКА"); }
            }

            UpdatingAnimals();
            updatingInfoAboutAnimals();

        }
        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { }
        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {

        }
        private void listBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
        private void tabControl_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
        private void tabControl_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void button8_Click(object sender, RoutedEventArgs e)
        {

        }
        private void forspecies1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


    }
}
