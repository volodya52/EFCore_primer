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

namespace EFCore.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage :Page
    {
        public Student? student { get; set; } = null;

        public StudentService service { get; set; } = new( );
        public MainPage ()
        {
            InitializeComponent( );
        }

        public void go_form (object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StudentFormPage( ));
        }

        public void Edit(object sender, EventArgs e)
        {
            if (student == null)
            {
                MessageBox.Show("Выберите элемент из списка");
                return;
            }
            NavigationService.Navigate(new StudentFormPage(student));
        }

        public void remove(object sender, EventArgs e)
        {
            if (student == null)
            {
                MessageBox.Show("Выберите запись");
                return;
            }
            if(MessageBox.Show("Вы хотите удалить запись?","Удалить?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                service.Remove(student);
            }
        }

        public void GoGroup(object sender, EventArgs e)
        {
            NavigationService.Navigate(new GroupeList());
        }

        public void GoCourse(object sender, EventArgs e)
        {
            NavigationService.Navigate(new CoursePage());
        }

        public void AddCourse(object sender, EventArgs e)
        {
            if(student == null)
            {
                MessageBox.Show("Выберите студента");
            }
            else
            {
                NavigationService.Navigate(new AddCourse(student));
            }              
        }
    }
}
