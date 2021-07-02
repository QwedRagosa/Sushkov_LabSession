using Sushkov_LabSession.Classes;
using Sushkov_LabSession.LabDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        public AddUser()
        {
            InitializeComponent();
            InsuranceCbx.ItemsSource = DataBase.DB.InsuranceComp.Select(x => x.Name).OrderBy(x => x).ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (FullNameTbx.Text != null && LoginTbx.Text != null && PasswordTbx.Text != null && BirthDayCld.SelectedDate != null && PassportSerTbx.Text != null && PassportNumTbx != null && PhoneTbx.Text != null && EmailTbx.Text != null && InsuranceCbx.SelectedItem != null && InsuranceTbx.Text != null)
                {
                    Patient Patient = new Patient
                    {
                        Login = LoginTbx.Text,
                        Password = PasswordTbx.Text,
                        FullName = FullNameTbx.Text,
                        Burthday = BirthDayCld.SelectedDate,
                        PassportS = PassportSerTbx.Text,
                        PassportN = PassportNumTbx.Text,
                        Phone = PhoneTbx.Text,
                        Email = EmailTbx.Text,
                        InsuranceID = DataBase.DB.InsuranceComp.FirstOrDefault(x => x.Name == InsuranceCbx.SelectedItem.ToString()).ID,
                        InsuranceNumb = InsuranceTbx.Text,
                    };
                    DataBase.DB.Patient.Add(Patient);
                    DataBase.DB.SaveChanges();
                    MessageBox.Show("Пользователь успешно добавлен.\nНе забудьте нажать клавишу |↻| чтобы обновить список.", "Успех!");
                }
                else
                {
                    MessageBox.Show("Проверьте заполненость полей и правильность данных", "Ошибка");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!");
            }
        }
        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #region Ограничения
        private void PhoneTbx_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == "+") || (e.Text == "-") || (e.Text == "(") || (e.Text == ")") || (e.Text == ")")
               && (!PhoneTbx.Text.Contains("+")
               && (!PhoneTbx.Text.Contains("-")
               && (!PhoneTbx.Text.Contains("(")
               && (!PhoneTbx.Text.Contains(")")
               && PhoneTbx.Text.Length != 0))))))
            {
                e.Handled = true;
            }
        }

        private void PassportSerTbx_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void FullNameTbx_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string Symbol = e.Text.ToString();

            if (!Regex.Match(Symbol, @"[ ]|[a-zA-Z]").Success)
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}
