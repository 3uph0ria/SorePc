using HardCP.Models;
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
    /// Логика взаимодействия для PageClients.xaml
    /// </summary>
    public partial class PageClients : Page
    {
        public PageClients(string header)
        {
            InitializeComponent();
            Header.Text = header;
            DGridClients.ItemsSource = ShopPCEntities.GetContext().Clients.ToList();
        }

        private void BtnEditClient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtndelClient_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
