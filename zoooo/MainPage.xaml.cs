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
using System.Xml;

namespace zoooo
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        List<Animal> animals = new List<Animal>();
        List<Employee> employees = new List<Employee>();

     private void RecordingAnimals()
        {
            using (FileStream fsa = new FileStream("animals.xml", FileMode.Create))
            {
                XmlSerializer xmla = new XmlSerializer(typeof(List<Animal>));
                xmla.Serialize(fsa, animals);
            }
            Logging.Log("Выполнена сериализация списка животных");
        }
        private void RecordingEmployees()
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
            listBoxforanimals.ItemsSource = null;
            listBoxforanimals.ItemsSource = animals;

        }
        private void UpdatingListboxEmployees()
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


        public MainPage()
        {
            InitializeComponent();
            Logging.Log("Программа запущена в режиме администратора.");
            LoadingInfoAboutAnimals();
            LoadingInfoAboutEmployees();
            UpdatingListboxAnimals();
            UpdatingListboxEmployees();
        }

        /// <summary>
        /// 
        /// </summary>
        private void add_animal_Click_(object sender, RoutedEventArgs e)
        {
            int number;
            float tempFloat;
            if (string.IsNullOrWhiteSpace(adding_id1.Text))
            {
                MessageBox.Show("Введите id.", "ОШИБКА");
                return;
            }
            if (string.IsNullOrWhiteSpace(adding_timeforfeeding1.Text) || !float.TryParse(adding_timeforfeeding1.Text, out tempFloat) || float.Parse(adding_timeforfeeding1.Text) < 25 || float.Parse(adding_timeforfeeding1.Text) > 0)
            {
                MessageBox.Show("Введите время кормления от 0.00 до 24.00.", "ОШИБКА");
                adding_timeforfeeding1.Clear();
                return;
            }
            if (string.IsNullOrWhiteSpace(adding_worker1.Text))
            {
                MessageBox.Show("Введите id работника.", "ОШИБКА");
                return;
            }
            else if (!int.TryParse(adding_worker1.Text, out number) || adding_worker1.Text.Length != 6)
            {
                MessageBox.Show("Введите шестизначное число.", "ОШИБКА");
                adding_worker1.Clear();
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
            else if (employees.Count !=0)
            {
                List<Employee> linked_employees = new List<Employee>();
                foreach (var worker in employees)
                {

                    if (adding_worker1.Text == worker.Id)
                    {
                        linked_employees.Add(worker);
                        break;
                    }
                }
                if (linked_employees.Count == 0)
                {
                    MessageBox.Show("Работника с таким айди не существует.", "ОШИБКА");
                    adding_worker1.Clear();
                }
            }
            if (string.IsNullOrWhiteSpace(adding_worker1.Text))
            {
                MessageBox.Show("Введите id работника.", "ОШИБКА");
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
            if (string.IsNullOrWhiteSpace(adding_id1.Text))
            {
                MessageBox.Show("Введите id.", "ОШИБКА");
                return;
            }
            Animal temp = new Animal(adding_id1.Text, adding_timeforfeeding1.Text, adding_worker1.Text, adding_section1.Text, adding_foodset1.Text, adding_species1.Text);
            animals.Add(temp);
            MessageBox.Show("Животное с айди " + temp.Id + " добавлено.");
            Logging.Log("Добавлено животное с id " + temp.Id + ".");
            RecordingAnimals(); //сериализация
            UpdatingListboxAnimals(); //листбокс
            adding_id1.Clear();
            adding_timeforfeeding1.Clear();
            adding_worker1.Clear();
            adding_section1.Clear();
            adding_foodset1.Clear();
            adding_species1.Clear();
        }


        private void add_employee_Click(object sender, RoutedEventArgs e)
        {
            int number;
            if (string.IsNullOrWhiteSpace(adding_id2.Text))
            {
                MessageBox.Show("Введите id.", "ОШИБКА");
                return;
            }
            else if (!int.TryParse(adding_id2.Text, out number) || adding_id2.Text.Length != 6)
            {
                MessageBox.Show("Введите шестизначное число.", "ОШИБКА");
                adding_id2.Clear();
            }

            if (string.IsNullOrWhiteSpace(adding_name2.Text))
            {
                MessageBox.Show("Введите имя.", "ОШИБКА");
                return;
            }
            if (string.IsNullOrWhiteSpace(adding_surname2.Text))
            {
                MessageBox.Show("Введите фамилию.", "ОШИБКА");
                return;
            }
            if (string.IsNullOrWhiteSpace(adding_workinghours2.Text))
            {
                MessageBox.Show("Введите время работы в формате 'число-число'.", "ОШИБКА");
                return;
            }
            List<Animal> linked_animals = new List<Animal>();
            if (string.IsNullOrWhiteSpace(adding_animal2.Text))
            {
                MessageBox.Show("Введите id животного.", "ОШИБКА");
                return;
            }
            else    if (!int.TryParse(adding_animal2.Text, out number) || adding_animal2.Text.Length != 6)
                {
                    MessageBox.Show("Введите шестизначное число.", "ОШИБКА");
                    adding_animal2.Clear();
                }


             if (animals.Count != 0)
             {
                    foreach (var animal in animals)
                    {

                        if (adding_animal2.Text == animal.Id)
                        {
                            linked_animals.Add(animal);
                            break;
                        }
                    }
                    if (linked_animals.Count == 0)
                    {
                        MessageBox.Show("Животного с таким айди не существует.", "ОШИБКА");
                        adding_animal2.Clear();
                    }
            }
            if (string.IsNullOrWhiteSpace(adding_animal2.Text))
            {
                MessageBox.Show("Введите id животного.", "ОШИБКА");
                return;
            }
            foreach (var employee in employees)
            {
                if (adding_id1.Text == employee.Id)
                {
                    MessageBox.Show("Работник с таким айди уже существует.", "ОШИБКА");
                    adding_id2.Clear();
                    break;
                }
            }
            if (string.IsNullOrWhiteSpace(adding_id2.Text))
            {
                MessageBox.Show("Введите id.", "ОШИБКА");
                return;
            }

            Employee temp = new Employee(adding_name2.Text, adding_surname2.Text, adding_workinghours2.Text, adding_id2.Text, adding_animal2.Text);
            employees.Add(temp);
            MessageBox.Show(temp.Surname + " добавлен.");
            Logging.Log("добавлен сотрудник с id " + temp.Id + ".");
            RecordingEmployees();
            UpdatingListboxEmployees();
            adding_id2.Clear();
            adding_name2.Clear();
            adding_surname2.Clear();
            adding_workinghours2.Clear();
            adding_animal2.Clear();

        }

        private void delete_animal_Click(object sender, RoutedEventArgs e)
        {
            int count = animals.Count;
            int number, lastIndex;
            if (!int.TryParse(write_animal_id.Text, out number) || write_animal_id.Text.Length != 6)
            {
               MessageBox.Show("Введите шестизначное число.", "ОШИБКА");
               write_animal_id.Clear();
            }
            else if (count > 1)
                {
                    foreach (var temp in animals)
                    {
                        if (write_animal_id.Text == temp.Id)
                        {
                            Logging.Log("Удалено животное с id" + temp.Id);
                            MessageBox.Show("Удалено");
                            animals.Remove(temp);
                            lastIndex = animals.Count() - 1;
                            foreach (var employee in employees)
                            {
                              if (write_animal_id.Text == employee.Animal)
                              {
                                Random rnd = new Random();
                                int temInt = rnd.Next(0, lastIndex);
                                employee.Animal = animals[temInt].Id;
                              }
                             }
                        break;
                        }
                    }
                    if (count == animals.Count) { MessageBox.Show("Животного с таким id не существует.", "ОШИБКА"); }
                }
            else {
                MessageBox.Show("В списке должно быть более одного животного.", "ОШИБКА");
            }
            UpdatingListboxAnimals();
            RecordingAnimals();
            UpdatingListboxEmployees();
            RecordingEmployees();
        }

        private void delete_employee_Click(object sender, RoutedEventArgs e)
        {
            int count = employees.Count;
            int number, lastIndex;
            if (!int.TryParse(write_employee_id.Text, out number) || write_employee_id.Text.Length != 6)
            {
                MessageBox.Show("Поле пусто.", "ОШИБКА");
                write_employee_id.Clear();
            }
            else if (count > 1)
            {
                foreach (var temp in employees)
                {
                    if (write_employee_id.Text == temp.Id)
                    {
                        Logging.Log("Удален работник с id" + temp.Id + ".");
                        MessageBox.Show("Удалено.");
                        employees.Remove(temp);
                        lastIndex = employees.Count() - 1;
                        foreach (var animal in animals)
                        {
                            if (write_employee_id.Text == animal.Worker)
                            {
                                Random rnd = new Random();
                                int temInt = rnd.Next(0, lastIndex);
                                animal.Worker =employees[temInt].Id;
                            }
                        }

                        break;
                    }
                }
                if (count == employees.Count) { MessageBox.Show("Работника с таким id не существует.", "ОШИБКА"); }
            }
            else {
                MessageBox.Show("В списке должно быть более одного работника.", "ОШИБКА");
            }
            UpdatingListboxAnimals();
            RecordingAnimals();
            UpdatingListboxEmployees();
            RecordingEmployees();
        }

        private void find_animal_Click(object sender, RoutedEventArgs e)
        {
            List<Animal> found_animals = new List<Animal>();
            int number;
            if (!int.TryParse(write_animal_id.Text, out number) || write_animal_id.Text.Length != 6)
            {
                MessageBox.Show("Введите шестизначное число.", "ОШИБКА");
                write_animal_id.Clear();

            }
            else
            {
                foreach (var animal in animals)
                    {
                        if (int.Parse(write_animal_id.Text) < 100000)
                        {
                            if (write_animal_id.Text == animal.Id)
                            {
                                found_animals.Add(animal);
                                Logging.Log("Выполнен поиск животного с id" + animal.Id + ".");
                                break;
                            }
                        }
                        else
                        {
                            if (write_animal_id.Text == animal.Worker)
                            {
                                found_animals.Add(animal);
                                Logging.Log("Выполнен поиск животных, обслуживаемых работником с id" + animal.Worker + ".");
                                break;
                            }
                        }

                    }
                    if (found_animals.Count == 0)
                    {
                        MessageBox.Show("Такого айди не существует.", "ОШИБКА");
                        write_animal_id.Clear();
                    }
                    else
                    {
                        listBoxforanimals.ItemsSource = null;
                        listBoxforanimals.ItemsSource = found_animals;
                    }
                }
        }


        private void find_employee_Click(object sender, RoutedEventArgs e)
        {

            List<Employee> found_employees = new List<Employee>();
            int number;
            if (!int.TryParse(write_employee_id.Text, out number) || write_employee_id.Text.Length != 6)
            {
                MessageBox.Show("Введите шестизначное число.", "ОШИБКА");
                write_employee_id.Clear();
            }
            else
            {
                foreach (var employee in employees)
                {

                    if (int.Parse(write_employee_id.Text) >= 100000)
                    {
                        if (write_employee_id.Text == employee.Id)
                        {
                            found_employees.Add(employee);

                            Logging.Log("Выполнен поиск работника с id" + employee.Id + ".");
                            break;
                        }
                    }
                    else if (write_employee_id.Text == employee.Animal)
                    {
                        found_employees.Add(employee);

                        Logging.Log("Выполнен поиск работников, ответственных за животное с id" + employee.Animal + ".");
                        break;
                    }

                }
                if (found_employees.Count == 0)
                {
                    MessageBox.Show("Такого айди не существует.", "ОШИБКА");
                    write_employee_id.Clear();
                }
                else
                {
                    listBoxforemployees.ItemsSource = null;
                    listBoxforemployees.ItemsSource = found_employees;
                }
            }
        }


        private void edit_animal_Click(object sender, RoutedEventArgs e)
        {
            List<Animal> edited_animals = new List<Animal>();
            foreach (var temp in animals)
            {
                if (writing_id1.Text == temp.Id)
                {
                    edited_animals.Add(temp);
                    float tempFloat;
                    if (string.IsNullOrWhiteSpace(changing_timeforfeeding1.Text) || !float.TryParse(changing_timeforfeeding1.Text, out tempFloat) || float.Parse(changing_timeforfeeding1.Text) < 25 || float.Parse(changing_timeforfeeding1.Text) > 0)
                    {
                        MessageBox.Show("Введите время кормления от 0.00 до 24.00.", "ОШИБКА");
                        changing_timeforfeeding1.Clear();
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

                    List<Employee> linked_employees = new List<Employee>();
                    foreach (var worker in employees)
                    {

                        if (changing_worker1.Text == worker.Id)
                        {
                            linked_employees.Add(worker);
                            break;
                        }
                    }
                    if (linked_employees.Count == 0)
                    {
                        MessageBox.Show("Работника с таким айди не существует.", "ОШИБКА");
                        changing_worker1.Clear();
                    }
                    if (string.IsNullOrWhiteSpace(changing_worker1.Text))
                    {
                        MessageBox.Show("Введите id работника.", "ОШИБКА");
                        return;
                    }



                    Animal buffer = new Animal(writing_id1.Text, changing_timeforfeeding1.Text, changing_worker1.Text, changing_section1.Text, changing_foodset1.Text, changing_species1.Text);


                    MessageBox.Show("Животное с айди " + temp.Id + " обновлено.");
                    writing_id1.Clear();
                    changing_timeforfeeding1.Clear();
                    changing_worker1.Clear();
                    changing_section1.Clear();
                    changing_foodset1.Clear();
                    changing_species1.Clear();

                    animals.Remove(temp);
                    animals.Add(buffer);

                    Logging.Log("Изменены характристики животного с id " + buffer.Id + ".");
                    break;
                }
            }
            if (edited_animals.Count == 0)
            {
                MessageBox.Show("Животное с таким айди не существует.", "ОШИБКА");
            }


            RecordingAnimals();
            UpdatingListboxAnimals();

        }
        private void edit_employee_Click(object sender, RoutedEventArgs e)
        {
            List<Employee> edited_employees = new List<Employee>();
            foreach (var temp in employees)
            {
                if (writing_id2.Text == temp.Id)
                {
                    edited_employees.Add(temp);
                    if (string.IsNullOrWhiteSpace(changing_name2.Text))
                    {
                        MessageBox.Show("Введите имя.", "ОШИБКА");
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(changing_surname2.Text))
                    {
                        MessageBox.Show("Введите фамилию.", "ОШИБКА");
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(changing_workinghours2.Text))
                    {
                        MessageBox.Show("Введите время работы.", "ОШИБКА");
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(changing_animal2.Text))
                    {
                        MessageBox.Show("Введите id животного.", "ОШИБКА");
                        return;
                    }
                    List<Animal> linked_animals = new List<Animal>();
                    foreach (var animal in animals)
                    {

                        if (changing_animal2.Text == animal.Id)
                        {
                            linked_animals.Add(animal);
                            break;
                        }
                    }
                    if (linked_animals.Count == 0)
                    {
                        MessageBox.Show("Животного с таким айди не существует.", "ОШИБКА");
                        changing_animal2.Clear();
                    }
                    if (string.IsNullOrWhiteSpace(changing_animal2.Text))
                    {
                        MessageBox.Show("Введите id животного.", "ОШИБКА");
                        return;
                    }



                    Employee buffer = new Employee(changing_name2.Text, changing_surname2.Text, changing_workinghours2.Text, writing_id2.Text, changing_animal2.Text);


                    MessageBox.Show("Работник с айди " + temp.Id + " обновлен.");
                    writing_id2.Clear();
                    changing_name2.Clear();
                    changing_surname2.Clear();
                    changing_workinghours2.Clear();
                    changing_animal2.Clear();

                    employees.Remove(temp);
                    employees.Add(buffer);

                    Logging.Log("Изменены характристики работника с id " + buffer.Id + ".");
                    break;
                }
            }
            if (edited_employees.Count == 0)
            {
                MessageBox.Show("Работник с таким айди не существует.", "ОШИБКА");
            }


            RecordingEmployees();
            UpdatingListboxEmployees();
        }
        private void update_animal_Click(object sender, RoutedEventArgs e)
        {
            UpdatingListboxAnimals();
        }

        private void update_employee_Click(object sender, RoutedEventArgs e)
        {
            UpdatingListboxEmployees();
        }

        private void buttonGoBack1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.LoginPage);
            Logging.Log("Выполнен переход на страницу авторизации.");

        }

        private void write_employee_id_GotFocus(object sender, RoutedEventArgs e)
        {
            write_employee_id.Text = "";
        }

        private void write_employee_id_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(write_employee_id.Text))
            {
                write_employee_id.Text = "Введите id";
            }
        }
    }

}
