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

namespace Sushkov_LabSession
{
    /// <summary>
    /// Логика взаимодействия для LastEnter.xaml
    /// </summary>
    public partial class LastEnter : Window
    {
        public LastEnter()
        {
            InitializeComponent();
            LastEntryList.ItemsSource = DataBase.DB.Users.OrderByDescending(x => x.LastEnter).ToList();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
