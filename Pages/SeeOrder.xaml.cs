using Sushkov_LabSession.Classes;
using Sushkov_LabSession.LabDB;
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
    /// Логика взаимодействия для SeeOrder.xaml
    /// </summary>
    public partial class SeeOrder : Window
    {
        public SeeOrder()
        {
            InitializeComponent();
            OrderList.ItemsSource = DataBase.DB.Order.OrderByDescending(x => x.OrderedService.FinDate).ToList();
        }
        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BillBtn_Click(object sender, RoutedEventArgs e)
        {
            dynamic row = OrderList.SelectedItem;
            int BillID = row.ID;
            var BillProcess = DataBase.DB.Order.FirstOrDefault(x => x.ID == BillID);
            Bill Bill = new Bill
            {
                UserID = AuthoID.AuthoIDInt,
                OrderedServiceID = BillProcess.OrderedService.ID,
                InsuranceCompID = BillProcess.OrderedService.Blood.Patient.InsuranceComp.ID
            };
            DataBase.DB.Bill.Add(Bill);
            DataBase.DB.SaveChanges();
            MessageBox.Show("Счёт успешно выставлен.\n\nСтраховая компания: <" + BillProcess.OrderedService.Blood.Patient.InsuranceComp.Name + ">\nОказанная услуга: [" + BillProcess.OrderedService.LabService.Name + "]\nДля пациента: <" + BillProcess.OrderedService.Blood.Patient.FullName + ">\n\n Итоговая сумма = " + BillProcess.OrderedService.LabService.Cost + " $", "Успех!");
        }
    }
}
