using Sushkov_LabSession.Classes;
using Sushkov_LabSession.Pages;
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

namespace Sushkov_LabSession
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataBase.DB = new LabDB.Sushkov_LabSessionEntities();
            PagesData.pageframe = Sushkov_LabSession;
            Sushkov_LabSession.Navigate(new Autho());
        }
    }
}
