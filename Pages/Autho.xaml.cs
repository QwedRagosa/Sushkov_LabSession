using System;
using Sushkov_LabSession.Classes;
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
using Sushkov_LabSession.LabDB;

namespace Sushkov_LabSession.Pages
{
    /// <summary>
    /// Логика взаимодействия для Autho.xaml
    /// </summary>
    public partial class Autho : Page
    {
        public Autho()
        {
            InitializeComponent();
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            var VarUsersLoginPass = DataBase.DB.Users.FirstOrDefault(x => x.Login == LoginTbx.Text && x.Password == PasswordTbx.Password);
            if (VarUsersLoginPass != null)
            {
                //Проверка ID роли у входящего пользователя.
                if (VarUsersLoginPass.RoleID == 1) // 1 = Лаборант
                {
                    MessageBox.Show("Добро пожаловать в систему, " + VarUsersLoginPass.Name + "!\nВы: " + VarUsersLoginPass.Role.Name, "Успешный вход ЛАБОРАНТА!");
                    PagesData.pageframe.Navigate(new Laborant(VarUsersLoginPass.ID)); // Переход на страницу лаборанта с передачей ИД пользователя.
                }
                else if (VarUsersLoginPass.RoleID == 2) // 2 = Лаборант-исследователь
                {
                    MessageBox.Show("Добро пожаловать в систему, " + VarUsersLoginPass.Name + "!\nВы: " + VarUsersLoginPass.Role.Name, "Успешный вход ЛАБОРАНТА-ИССЛЕДОВАТЕЛЯ!");
                }
                else if (VarUsersLoginPass.RoleID == 3) // 3 = Бухгалтер
                {
                    MessageBox.Show("Добро пожаловать в систему, " + VarUsersLoginPass.Name + "!\nВы: " + VarUsersLoginPass.Role.Name, "Успешный вход БУХГАЛТЕРА!");
                }
                else
                {
                    MessageBox.Show("??????\nВозможна ошибка базы данных. Обратитесь к разработчику и накажите его.", "??????");
                }
            }
            else
            {
                MessageBox.Show("Проверьте заполненность полей и правильность введенных данных.", "Ошибка");
            }
    }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
