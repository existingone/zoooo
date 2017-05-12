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
        public List<Animal> animals = new List<Animal>();
        public List<Employee> employees = new List<Employee>();

        


        private void Updatinganimals()
        {
            using (FileStream fsa = new FileStream("animals.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer xmla = new XmlSerializer(typeof(List<Animal>));
                xmla.Serialize(fsa, animals);
            }


            Logging.Log("Выполнена сериализация списка животных");
        }


        private void Updatingemployees()
        { 
            using (FileStream fse = new FileStream("employees.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer xmle = new XmlSerializer(typeof(List<Employee>));
                xmle.Serialize(fse, employees);
            }

        
            Logging.Log("Выполнена сериализация списка работников");
        }






        public MainWindow()
        {
            InitializeComponent();
            Logging.Log("Программа запущена");
            Updatinganimals();
            Updatingemployees();

        }

        /// <summary>
        /// 
        /// </summary>
        private void Loadinginfo()
        {
            using (FileStream fsa = new FileStream("animals.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer xmla = new XmlSerializer(typeof(List<Animal>));
                animals = (List<Animal>)xmla.Deserialize(fsa);
            }

            //foreach (Animal animal in animals)
            //{
            //    textBox.AppendText(animal.postinganimal());
            //}
            Logging.Log("Выполнена десериализация списка животных");

            using (FileStream fse = new FileStream("employees.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer xmle = new XmlSerializer(typeof(List<Employee>));
                employees = (List<Employee>)xmle.Deserialize(fse);
            }

            //foreach (Employee employee in employees)
            //{
            //    textBox.AppendText(employee.postingemployee());
            //}
            Logging.Log("Выполнена десериализация работников");
        }
        

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {  }

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
        

        private void add_animal_Click_(object sender, RoutedEventArgs e)
        {
            Animal temp = new Animal(forid1.Text, fortimeforfeeding1.Text, forworker1.Text, forsection1.Text, forfoodset1.Text, forspecies1.Text);
            animals.Add(temp);
            MessageBox.Show(temp.Species, "добавлен");
            //labelforadding.Content= temp.Species + "добавлен";
            Updatinganimals();

        }

        private void forspecies1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void add_employee_Click(object sender, RoutedEventArgs e)
        {
            Employee temp = new Employee(forname2.Text, forsurname2.Text, forworkinghours2.Text, forid.Text, foranimal2.Text);
            employees.Add(temp);
            MessageBox.Show(temp.Surname, "добавлен");
            string message = "добавлен сотрудник с id " + temp.Id;
            Logging.Log(message);
            Updatingemployees();
        }

        private void delete_employee_Click(object sender, RoutedEventArgs e)
        {

            
            
            Updatingemployees();
        }

        private void delete_animal_Click(object sender, RoutedEventArgs e)
        {


            foreach (var temp in animals)
            {
                if (write_animal_id.Text == temp.Id)
                {
                    animals.Remove(temp);
                    Logging.Log("Удалено животное с id" + temp.Id);
                }
                else
                {
                    MessageBox.Show("Животного с таким id не существует.");
                }
            }





           

            Updatinganimals();
        }

        private void find_animal_Click(object sender, RoutedEventArgs e)
        {
            foreach (var animal in animals)
            {
                if (write_animal_id.Text == animal.Id)
                {
                    MessageBox.Show("");
                }
            }
        }

        

        private void textBoxFocus(object sender, RoutedEventArgs e)
        {
            write_animal_id.Text = "";
        }

        private void textBoxLostFocus(object sender, RoutedEventArgs e)
        {
            if ( string.IsNullOrWhiteSpace(write_animal_id.Text))
            {
                write_animal_id.Text = "Введите id";
            }

        }


        private void updatingInfoAboutAnimals()
        {
            listBoxforanimals.ItemsSource=null;
            listBoxforanimals.ItemsSource = animals;
          
        }

        private void updatingInfoAboutEmployees()
        {
            listBoxforemployees.ItemsSource = null;
            listBoxforemployees.ItemsSource = employees;

        }






    }
}
