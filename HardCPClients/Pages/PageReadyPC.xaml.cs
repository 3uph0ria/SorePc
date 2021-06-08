using HardCP.Classes;
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
    /// Логика взаимодействия для PageReadyPC.xaml
    /// </summary>
    public partial class PageReadyPC : Page
    {
        public PageReadyPC()
        {
            InitializeComponent();
            Update();
            ListCurrentServices.ItemsSource = CurrentUser.currentServices;
            ListCurrentServices.Items.Refresh();
            if (CurrentUser.currentCost != 0)
            {
                AllCost.Text = "Итог: " + CurrentUser.currentCost;
                BtnAddOrder.Visibility = Visibility.Visible;
            }
            else
            {
                AllCost.Text = "";
                BtnAddOrder.Visibility = Visibility.Hidden;
            }
            CountService.Badge = CurrentUser.currentServices.Count.ToString();
        }

        private void BtnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            NavManager.MainFrame.Navigate(new PageBasket());
        }

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            var service = (sender as Button).DataContext as Services;
            CurrentUser.currentCost += service.Cost;
            CurrentUser.currentServices.Add((sender as Button).DataContext as Services);
            NavManager.MainFrame.Navigate(new PageBasket());
        }

        private void BtnAddBasket_Click(object sender, RoutedEventArgs e)
        {
            var service = (sender as Button).DataContext as Services;
            CurrentUser.currentCost += service.Cost;
            CurrentUser.currentServices.Add((sender as Button).DataContext as Services);

            ListCurrentServices.ItemsSource = CurrentUser.currentServices;
            ListCurrentServices.Items.Refresh();
            if (CurrentUser.currentCost != 0)
            {
                AllCost.Text = "Итог: " + CurrentUser.currentCost;
                BtnAddOrder.Visibility = Visibility.Visible;
            }
            else
            {
                AllCost.Text = "";
                BtnAddOrder.Visibility = Visibility.Hidden;
            }
            CountService.Badge = CurrentUser.currentServices.Count.ToString();
        }

        public void Update()
        {

            var services = ShopPCEntities.GetContext().Services.ToList();
            services = services.Where(p => p.Categoris.Name.Contains("Готовые сборки")).ToList();
            services = services.Where(p => p.Name.ToLower().Contains(Search.Text.ToLower())).ToList();
            ListServices.ItemsSource = services;

        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var service = (sender as Button).DataContext as Services;
            CurrentUser.currentCost -= service.Cost;

            var itemToRemove = CurrentUser.currentServices.Single(r => r.Id == service.Id);
            CurrentUser.currentServices.Remove(itemToRemove);

            NavManager.MainFrame.Navigate(new Users());
        }
    }
}
