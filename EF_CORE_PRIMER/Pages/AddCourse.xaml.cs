using EFCore.Service;
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
    /// Логика взаимодействия для AddCourse.xaml
    /// </summary>
    public partial class AddCourse :Page
    {
        public CourseService service { get; set; } = new( );

        public Student CurrentStudent { get; set; } = new( );

        public Course? current { get; set; } = null;

        public CourseStudentService service2 { get; set; } = new( );

        public CourseStudent courseStudent { get; set; } = new( );

        public AddCourse(Student student)
        {
            InitializeComponent();
            CurrentStudent = student;
            DataContext = this;
        }

        public void Back(object sender, EventArgs e)
        {
            NavigationService.GoBack();
        }

        public void Add(object sender, RoutedEventArgs e)
        {
            if (current == null)
            {
                MessageBox.Show("Выберите курс для добавления");
            }
            else
            {
                service2.Add(courseStudent);
                MessageBox.Show("Добавлено");
            }
        }
    }
}
