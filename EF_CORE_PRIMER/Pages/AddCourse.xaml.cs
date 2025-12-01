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
    public partial class AddCourse : Page
    {
        public CourseStudentService service;

        public GroupService groupService;

        public Student CurrentStudent { get; set; } = new();

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
    }
}
