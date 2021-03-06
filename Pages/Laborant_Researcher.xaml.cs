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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sushkov_LabSession.Pages
{
    /// <summary>
    /// Логика взаимодействия для Laborant_Researcher.xaml
    /// </summary>
    public partial class Laborant_Researcher : Page
    {
        public Laborant_Researcher(int UserID) //Переданный ID залогинившегося пользователя
        {
            InitializeComponent();
            // Выводим в Textblocks информацию о пользователе
            NameTbl.Text = DataBase.DB.Users.FirstOrDefault(x => x.ID == UserID).Name;
            RoleTbl.Text = DataBase.DB.Users.FirstOrDefault(x => x.ID == UserID).Role.Name;
            IPTbl.Text = DataBase.DB.Users.FirstOrDefault(x => x.ID == UserID).IP;
        }
        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            PagesData.pageframe.Navigate(new Autho()); // Выход на окно авторизации
        }

        private void LastEnterBtn_Click(object sender, RoutedEventArgs e)
        {
            LastEnter LastEnter = new LastEnter();
            LastEnter.Show();
        }

        private void GetBioBtn_Click(object sender, RoutedEventArgs e)
        {
            TakeBio TakeBio = new TakeBio(AuthoID.AuthoIDInt);
            TakeBio.Show();
        }

        private void MakeReportBtn_Click(object sender, RoutedEventArgs e)
        {
            ShowOrder ShowOrder = new ShowOrder();
            ShowOrder.Show();
        }

        private void AnalyzerWorkBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы работаете с анализатором.\nВжух-вжух!", "Удивительно!");
        }
    }
}
