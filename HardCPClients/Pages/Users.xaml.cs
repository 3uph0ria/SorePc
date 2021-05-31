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
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        public void Update()
        {
            

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
            var services = ShopPCEntities.GetContext().Services.ToList();
            if (service.Categoris.Name == "Процессоры")
                services = services.Where(p => p.Categoris.Name.ToLower().Contains("Материнские платы".ToLower())).ToList();
            if (service.Categoris.Name == "Материнские платы")
                services = services.Where(p => p.Categoris.Name.ToLower().Contains("HDD".ToLower())).ToList();
            if (service.Categoris.Name == "HDD")
                services = services.Where(p => p.Categoris.Name.ToLower().Contains("SSD".ToLower())).ToList();
            if (service.Categoris.Name == "SSD")
                services = services.Where(p => p.Categoris.Name.ToLower().Contains("Блоки питания".ToLower())).ToList();
            if (service.Categoris.Name == "Блоки питания")
                services = services.Where(p => p.Categoris.Name.ToLower().Contains("Видеокарты".ToLower())).ToList();
            if (service.Categoris.Name == "Видеокарты")
                services = services.Where(p => p.Categoris.Name.ToLower().Contains("Воздушное охлаждение".ToLower())).ToList();
            if (service.Categoris.Name == "Воздушное охлаждение")
                services = services.Where(p => p.Categoris.Name.ToLower().Contains("Жидкостное охлаждение".ToLower())).ToList();
            if (service.Categoris.Name == "Жидкостное охлаждение")
                services = services.Where(p => p.Categoris.Name.ToLower().Contains("Корпуса".ToLower())).ToList();
            if (service.Categoris.Name == "Корпуса")
                services = services.Where(p => p.Categoris.Name.ToLower().Contains("ОЗУ".ToLower())).ToList();

            ListServices.ItemsSource = services;

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

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var service = (sender as Button).DataContext as Services;
            CurrentUser.currentCost -= service.Cost;

            var itemToRemove = CurrentUser.currentServices.Single(r => r.Id == service.Id);
            CurrentUser.currentServices.Remove(itemToRemove);

            NavManager.MainFrame.Navigate(new Users());
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            var content = (sender as Button).Content;
            var services = ShopPCEntities.GetContext().Services.ToList();
            services = services.Where(p => p.Categoris.Name.ToLower().Contains(content.ToString().ToLower())).ToList();
            services = services.Where(p => p.Platforms.Name.ToLower().Contains(CurrentUser.platform.ToLower())).ToList();
            ListServices.ItemsSource = services;
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            var content = (sender as Button).Content;
            var services = ShopPCEntities.GetContext().Services.ToList();
            services = services.Where(p => p.Categoris.Name.ToLower().Contains(content.ToString().ToLower())).ToList();
            ListServices.ItemsSource = services;
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            var content = (sender as Button).Content;
            var services = ShopPCEntities.GetContext().Services.ToList();
            services = services.Where(p => p.Categoris.Name.ToLower().Contains(content.ToString().ToLower())).ToList();
            ListServices.ItemsSource = services;
        }

        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            var content = (sender as Button).Content;
            var services = ShopPCEntities.GetContext().Services.ToList();
            services = services.Where(p => p.Categoris.Name.ToLower().Contains(content.ToString().ToLower())).ToList();
            ListServices.ItemsSource = services;
        }

        private void Btn5_Click(object sender, RoutedEventArgs e)
        {
            var content = (sender as Button).Content;
            var services = ShopPCEntities.GetContext().Services.ToList();
            services = services.Where(p => p.Categoris.Name.ToLower().Contains(content.ToString().ToLower())).ToList();
            ListServices.ItemsSource = services;
        }

        private void Btn6_Click(object sender, RoutedEventArgs e)
        {
            var content = (sender as Button).Content;
            var services = ShopPCEntities.GetContext().Services.ToList();
            services = services.Where(p => p.Categoris.Name.ToLower().Contains(content.ToString().ToLower())).ToList();
            ListServices.ItemsSource = services;
        }

        private void Btn7_Click(object sender, RoutedEventArgs e)
        {
            var content = (sender as Button).Content;
            var services = ShopPCEntities.GetContext().Services.ToList();
            services = services.Where(p => p.Categoris.Name.ToLower().Contains(content.ToString().ToLower())).ToList();
            ListServices.ItemsSource = services;
        }

        private void Btn8_Click(object sender, RoutedEventArgs e)
        {
            var content = (sender as Button).Content;
            var services = ShopPCEntities.GetContext().Services.ToList();
            services = services.Where(p => p.Categoris.Name.ToLower().Contains(content.ToString().ToLower())).ToList();
            ListServices.ItemsSource = services;
        }

        private void Btn9_Click(object sender, RoutedEventArgs e)
        {
            var content = (sender as Button).Content;
            var services = ShopPCEntities.GetContext().Services.ToList();
            services = services.Where(p => p.Categoris.Name.ToLower().Contains(content.ToString().ToLower())).ToList();
            ListServices.ItemsSource = services;
        }

        private void Btn10_Click(object sender, RoutedEventArgs e)
        {
            var content = (sender as Button).Content;
            var services = ShopPCEntities.GetContext().Services.ToList();
            services = services.Where(p => p.Categoris.Name.ToLower().Contains(content.ToString().ToLower())).ToList();
            ListServices.ItemsSource = services;
        }
    }
}
