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

namespace zoooo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Animal> animals = new List<Animal>();
        List<Employee> employees = new List<Employee>();


        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

                    }

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
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
            Animal temp = new Animal(forid1.Text, textBox8.Text, textBox9.Text, forsection1.Text, forfoodset1.Text, forspecies1.Text);
            animals.Add(temp);
            listBox.Items.Add(animals[animals.Count-1].Species);
            //MessageBox.Show(animals[0].Species);
            //дописать стримрайтер и лейбл, который будет говорить, что объект добавлен
  
            
        }

        private void forspecies1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
