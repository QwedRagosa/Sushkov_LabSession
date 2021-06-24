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
    /// Логика взаимодействия для TakeBio.xaml
    /// </summary>
    public partial class TakeBio : Window
    {
        public TakeBio(int UserID)
        {
            InitializeComponent();
            UserNameTbl.Text = DataBase.DB.Users.FirstOrDefault(x => x.ID == UserID).Name;
            PatientCbx.ItemsSource = DataBase.DB.Patient.Select(x => x.FullName).OrderBy(x => x).ToList();
            AnalyzerCbx.ItemsSource = DataBase.DB.Analyzer.Select(x => x.Name).OrderBy(x => x).ToList();
            ServiceCbx.ItemsSource = DataBase.DB.LabService.Select(x => x.Name).OrderBy(x => x).ToList();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AcceptBtn_Click(object sender, RoutedEventArgs e)
        {
            Blood Blood = new Blood()
            {
                PatientID = DataBase.DB.Patient.FirstOrDefault(x => x.FullName == PatientCbx.SelectedItem.ToString()).ID,
                Barcode = BarCodeTbx.Text,
                Date = DateTime.Now,
            };
            DataBase.DB.Blood.Add(Blood);
            DataBase.DB.SaveChanges();

            OrderedService OrderedService = new OrderedService()
            {
                UserID = AuthoID.AuthoIDInt,
                LabServiceID = DataBase.DB.LabService.FirstOrDefault(x => x.Name == ServiceCbx.SelectedItem.ToString()).Code,
                BloodID = DataBase.DB.Blood.FirstOrDefault(x => x.Barcode == BarCodeTbx.Text).ID,
                FinDate = DateTime.Now,
                AnalyzerID = DataBase.DB.Analyzer.FirstOrDefault(x => x.Name == AnalyzerCbx.SelectedItem.ToString()).ID,
            };
            DataBase.DB.OrderedService.Add(OrderedService);
            DataBase.DB.SaveChanges();
            MessageBox.Show("Биоматериал принят.\nЗаказ сформирован успешно.", "Успех!");
        }
    }
}

