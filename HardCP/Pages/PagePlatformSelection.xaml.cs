using HardCP.Classes;
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

namespace HardCP.Pages
{
    /// <summary>
    /// Логика взаимодействия для PagePlatformSelection.xaml
    /// </summary>
    public partial class PagePlatformSelection : Page
    {
        public PagePlatformSelection()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CurrentUser.platform = "amd";
            NavManager.MainFrame.Navigate(new Users());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CurrentUser.platform = "intel";
            NavManager.MainFrame.Navigate(new Users());
        }
    }
}
