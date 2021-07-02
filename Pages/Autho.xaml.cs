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
using System.Collections.Specialized;
using static System.Net.WebRequestMethods;
using System.Net;

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
            try
            {
                var VarUsersLoginPass = DataBase.DB.Users.FirstOrDefault(x => x.Login == LoginTbx.Text && x.Password == PasswordTbx.Password);
                if (VarUsersLoginPass != null)
                {
                    //Проверка ID роли у входящего пользователя.
                    if (VarUsersLoginPass.RoleID == 1) // 1 = Лаборант
                    {
                        VarUsersLoginPass.LastEnter = DateTime.Now;
                        DataBase.DB.SaveChanges();
                        AuthoID.AuthoIDInt = VarUsersLoginPass.ID; // Радостно присваиваем глобальной переменной ID нашего входящего лаборанта
                        PagesData.pageframe.Navigate(new Laborant(AuthoID.AuthoIDInt)); // Переход на страницу лаборанта с передачей ИД пользователя.
                    }
                    else if (VarUsersLoginPass.RoleID == 2) // 2 = Лаборант-исследователь
                    {
                        VarUsersLoginPass.LastEnter = DateTime.Now;
                        DataBase.DB.SaveChanges();
                        AuthoID.AuthoIDInt = VarUsersLoginPass.ID;
                        PagesData.pageframe.Navigate(new Laborant_Researcher(AuthoID.AuthoIDInt)); // Переход на страницу лаборанта-исследователя с передачей ИД пользователя.
                    }
                    else if (VarUsersLoginPass.RoleID == 3) // 3 = Бухгалтер
                    {
                        VarUsersLoginPass.LastEnter = DateTime.Now;
                        DataBase.DB.SaveChanges();
                        AuthoID.AuthoIDInt = VarUsersLoginPass.ID;
                        PagesData.pageframe.Navigate(new Accountant(AuthoID.AuthoIDInt)); // Переход на страницу бухгалтера с передачей ИД пользователя.
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!");
            }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void LastEnterBtn_Click(object sender, RoutedEventArgs e)
        {
            LastEnter LastEnter = new LastEnter();
            LastEnter.Show();
        }
        //Поставить Like приложению. (Отправляет уведомление о поставленном лайке в Discord)
        #region Лайк
        internal class Http
        {
            public Http()
            {
            }

            public static byte[] Post(string uri, NameValueCollection pairs)
            {
                byte[] numArray;
                using (WebClient webClient = new WebClient())
                {
                    numArray = webClient.UploadValues(uri, pairs);
                }
                return numArray;
            }
        }
        public static void sendWebHook(string URL, string msg)
        {
            Http.Post(URL, new NameValueCollection()
            {
                { "content", msg }
            });
        }
        private void LikeBtn_Click(object sender, RoutedEventArgs e)
        {
            sendWebHook("https://discord.com/api/webhooks/857597951538233364/7bGaI4U_E42zSC5VG8BvZeu1FDnBJhuwY92PL5Hh5uqDaIIq9BAX4Y4O-AYgLBdtvbWy", string.Concat(new string[] { "Кто-то поставил Like приложению Старого! ♥ ♥ ♥", }));
            MessageBox.Show(" Ура! Вы успешно поставили Like приложению!\nРазработчик получил уведомление об этом событии на своем сервере Discord!", "Like отправлен");
        }
        #endregion
    }
}
