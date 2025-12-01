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
    /// Логика взаимодействия для StudentFormPage.xaml
    /// </summary>
    public partial class StudentFormPage :Page
    {
        private StudentService _service = new( );
        public Student _student = new( );
        bool isEdit = false;
        public StudentFormPage (Student?_editStudent=null)
        {
            InitializeComponent( );
            if (_editStudent != null)
            {
                _student = _editStudent;
                isEdit = true;
            }
            if (_student.Passport == null)
                _student.Passport = new( );
            DataContext = _student;

        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (isEdit)
                _service.Commit( ); 
            else
                _service.Add(_student);
            NavigationService.GoBack( );
           
        }

        public void Back (object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack( );
        }

        public void AddCourse(object sender, RoutedEventArgs e)
        {
          
        }
    }
}
