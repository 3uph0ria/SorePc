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
    /// Логика взаимодействия для PageBasket.xaml
    /// </summary>
    public partial class PageBasket : Page
    {
        public PageBasket()
        {
            InitializeComponent();
            Update();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavManager.MainFrame.Navigate(new Users());
        }

        private void AddBasket_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder erros = new StringBuilder();

            if (String.IsNullOrEmpty(FullName.Text))
                erros.AppendLine("Введите ФИО");
            else if (String.IsNullOrEmpty(Phone.Text))
                erros.AppendLine("Введите телефон");

            if (erros.Length > 0)
            {
                MessageBox.Show(erros.ToString());
                return;
            }

            MessageBox.Show(FullName.Text +", Ваш заказ успешно сформирован, скоро Вам перезвонит администратор");
        }

        private void BtnDelService_Click(object sender, RoutedEventArgs e)
        {
            var service = (sender as Button).DataContext as Services;
            CurrentUser.currentCost -= service.Cost;

            var itemToRemove = CurrentUser.currentServices.Single(r => r.Id == service.Id);
            CurrentUser.currentServices.Remove(itemToRemove);

            NavManager.MainFrame.Navigate(new PageBasket());
        }

        public void Update()
        {
            ListServices.ItemsSource = CurrentUser.currentServices;
            currentCost.Text = "Итого: " + CurrentUser.currentCost + "₽";
        }
    }
}
