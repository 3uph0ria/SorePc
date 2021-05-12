using HardCP.Classes;
using HardCP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
    /// Логика взаимодействия для Users.xaml
    /// </summary>
    public partial class Users : Page
    {
        public Users()
        {
            InitializeComponent();
            Update();
            ListButtons.ItemsSource = ShopPCEntities.GetContext().Categoris.ToList();
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        public void Update()
        {
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

            var services = ShopPCEntities.GetContext().Services.ToList();
            services = services.Where(p => p.Platforms.Name.ToLower().Contains(CurrentUser.platform.ToLower())).ToList();
            services = services.Where(p => p.Name.ToLower().Contains(Search.Text.ToLower())).ToList();
            ListServices.ItemsSource = services;
            
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavManager.MainFrame.Navigate(new SignIn());
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void AddBasket_Click(object sender, RoutedEventArgs e)
        {
            var service = (sender as Button).DataContext as Services;
            CurrentUser.currentCost += service.Cost;
            CurrentUser.currentServices.Add((sender as Button).DataContext as Services);
            Update();
            MessageBox.Show("Товар '" + service.Name + "' успешно добавлен к корзину!", "Внимание!", MessageBoxButton.OK);
            
        }

        private void BtnBack_Click_1(object sender, RoutedEventArgs e)
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

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
        }

        private void BtnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            NavManager.MainFrame.Navigate(new PageBasket());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Categoris selectCategory = (sender as Button).DataContext as Categoris;
            var services = ShopPCEntities.GetContext().Services.ToList();

            // сортировка для intel & amd
            if(selectCategory.Name == "Процессоры")
                services = services.Where(p => p.Platforms.Name.ToLower().Contains(CurrentUser.platform.ToLower())).ToList();

            services = services.Where(p => Convert.ToString(p.Categoris.Name).Contains(selectCategory.Name)).ToList();
            ListServices.ItemsSource = services;
        }
    }
}
