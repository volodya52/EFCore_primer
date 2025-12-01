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
    /// Логика взаимодействия для CoursePage.xaml
    /// </summary>
    public partial class CoursePage : Page
    {
        public CourseService service { get; set; } = new();

        public Course? current { get; set; }= null;
        public CoursePage()
        {
            InitializeComponent();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CourseEdit());
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            if (current != null)
            {
                NavigationService.Navigate(new CourseEdit(current));
            }
            else
            {
                MessageBox.Show("Выберите курс");
            }
        }

        private void Remove (object sender, RoutedEventArgs e)
        {
            if(current != null)
            {
                if(MessageBox.Show("Хотите удалить курс?", "Удалить курс", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    service.Remove(current);
                }
            }
            else
            {
                MessageBox.Show("Выберите курс для удаления","Выберите курс", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
