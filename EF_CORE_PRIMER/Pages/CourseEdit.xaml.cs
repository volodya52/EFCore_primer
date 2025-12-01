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
    /// Логика взаимодействия для CourseEdit.xaml
    /// </summary>
    public partial class CourseEdit : Page
    {

        Course _course = new();
        CourseService service = new();
        bool isEdit = false;
        public CourseEdit(Course? course=null)
        {
            InitializeComponent();
            if (course != null)
            {
                _course = course;
                isEdit = true;
            }
            DataContext = _course;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (isEdit)
                service.Commit();
            else
                service.Add(_course);
            Back(sender, e);
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
