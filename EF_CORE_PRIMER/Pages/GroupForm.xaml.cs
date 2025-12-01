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
    /// Логика взаимодействия для GroupForm.xaml
    /// </summary>
    public partial class GroupForm : Page
    {
        Group _group = new();
        GroupService service = new();
        bool isEdit = false;
        public GroupForm(Group? group=null)
        {
            InitializeComponent();
            if(group != null)
            {               
                _group = group;
                isEdit = true;
            }
            DataContext = _group;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if(isEdit)
                service.Commit();
            else
                service.Add(_group);
            Back(sender, e);
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
