using Sushkov_LabSession.Classes;
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
using System.Windows.Shapes;

namespace Sushkov_LabSession.Pages
{
    /// <summary>
    /// Логика взаимодействия для ShowOrder.xaml
    /// </summary>
    public partial class ShowOrder : Window
    {
        public ShowOrder()
        {
            InitializeComponent();
            OrderList.ItemsSource = DataBase.DB.Order.OrderByDescending(x => x.OrderedService.FinDate).ToList();
        }
        private void AcceptBtn_Click(object sender, RoutedEventArgs e)
        {
            dynamic row = OrderList.SelectedItem;
            int AcceptOrderID = row.ID;
            var AcceptProcess = DataBase.DB.Order.FirstOrDefault(x => x.ID == AcceptOrderID);
            AcceptProcess.Accepted = true;
            DataBase.DB.SaveChanges();
            OrderList.ItemsSource = DataBase.DB.Order.OrderByDescending(x => x.OrderedService.FinDate).ToList();
        }
        private void UnAcceptBtn_Click(object sender, RoutedEventArgs e)
        {
            dynamic row = OrderList.SelectedItem;
            int AcceptOrderID = row.ID;
            var AcceptProcess = DataBase.DB.Order.FirstOrDefault(x => x.ID == AcceptOrderID);
            AcceptProcess.Accepted = false;
            DataBase.DB.SaveChanges();
            OrderList.ItemsSource = DataBase.DB.Order.OrderByDescending(x => x.OrderedService.FinDate).ToList();
        }
        private void FinishBtn_Click(object sender, RoutedEventArgs e)
        {
            dynamic row = OrderList.SelectedItem;
            int FinishOrderID = row.ID;
            var FinishProcess = DataBase.DB.Order.FirstOrDefault(x => x.ID == FinishOrderID);
            FinishProcess.Finished = true;
            DataBase.DB.SaveChanges();
            OrderList.ItemsSource = DataBase.DB.Order.OrderByDescending(x => x.OrderedService.FinDate).ToList();
        }
        private void UnFinishBtn_Click(object sender, RoutedEventArgs e)
        {
            dynamic row = OrderList.SelectedItem;
            int FinishOrderID = row.ID;
            var FinishProcess = DataBase.DB.Order.FirstOrDefault(x => x.ID == FinishOrderID);
            FinishProcess.Finished = false;
            DataBase.DB.SaveChanges();
            OrderList.ItemsSource = DataBase.DB.Order.OrderByDescending(x => x.OrderedService.FinDate).ToList();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
