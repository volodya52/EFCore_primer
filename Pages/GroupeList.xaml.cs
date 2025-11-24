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
    /// Логика взаимодействия для GroupeList.xaml
    /// </summary>
    public partial class GroupeList : Page
    {
        public GroupService service { get; set; } = new();
        public Group? current { get; set; } = null;
        
        public GroupeList()
        {
            InitializeComponent();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GroupForm());
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            if(current != null)
            {
                NavigationService.Navigate(new GroupForm(current));
            }
            else
            {
                MessageBox.Show("Выберите группу");
            }
        }

        private void Remove(object sender, RoutedEventArgs e)
        {
            if(current != null)
            {
                if(MessageBox.Show("Вы действительно хотите удалить запись?", "Удалить группу", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    service.Remove(current);
                }
            }
            else
            {
                MessageBox.Show("Выберите группу для удаления","Выберите группу",MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
