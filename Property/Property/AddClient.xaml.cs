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
using System.Text.RegularExpressions;

namespace Property
{
    /// <summary>
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        public AddClient()
        {
            InitializeComponent();
        }

        private void SaveClient_Click(object sender, RoutedEventArgs e)
        {
            var input = Password.Text;

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{6,}");
            var hasCymbols = new Regex(@"[+]{1}[1-9]{1} [0-9]{3} [0-9]{3} [0-9]{2} [0-9]{2}");

            var isValidated = hasNumber.IsMatch(input) && hasUpperChar.IsMatch(input) && hasMinimum8Chars.IsMatch(input);

            var inputTepelhone = Telephone.Text;
            var hasTelephone = new Regex(@"^((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$");
            var TelephoneValid = hasCymbols.IsMatch(inputTepelhone);
            if (E_mail.Text == "" || LastName.Text == "" || FirstName.Text == "" || Patronomyc.Text == "" || Adress.Text == "" || Telephone.Text == "" || Password.Text == "" || PasswordRepeat.Text == "")
            {
                MessageBox.Show("Заполните все поля!", "Внимание");
            }
            else if (TelephoneValid == false)
            {
                MessageBox.Show("Телефон должен быть записан в международном формате: +Х ХХХ ХХХ ХХ ХХ","Внимание");
            }
            else if (isValidated == false || (Password.Text.Contains('!') == false && Password.Text.Contains('@') == false && Password.Text.Contains('#') == false && Password.Text.Contains('$') == false && Password.Text.Contains('%') == false && Password.Text.Contains('^') == false))
            {
                MessageBox.Show("Пароль должен соответствовать следующим требованиям: Минимум 6 символов, Минимум 1 прописная буква, Минимум 1 цифра, По крайней мере один из следующих символов : !@#$%^", "Внимание");
            }
            else if (Password.Text != PasswordRepeat.Text)
            {
                MessageBox.Show("Пароль и повтор пароля не совпадают", "Внимание");
            }
            else if (DateTime.Now.Year - DateBirth.SelectedDate.Value.Year < 18)
            {
                MessageBox.Show("Нельзя регистрировать клиентов младше 18");
            }
            else
            {
                ServiceReference1.Users SaveClient = new ServiceReference1.Users();
                SaveClient.Email = Convert.ToString(E_mail.Text);
                SaveClient.LastName = Convert.ToString(LastName.Text);
                SaveClient.FirstName = Convert.ToString(FirstName.Text);
                SaveClient.Patronymic = Convert.ToString(Patronomyc.Text);
                SaveClient.DateBirth = Convert.ToDateTime(DateBirth.SelectedDate);
                SaveClient.Adress = Convert.ToString(Adress.Text);
                SaveClient.Telephone = Convert.ToString(Telephone.Text);
                SaveClient.Password = Convert.ToString(PasswordRepeat.Text);
                SaveClient.Role_ID = 1;
                ServiceReference1.Service1Client Service = new ServiceReference1.Service1Client();
                Service.AddUsers(SaveClient);
                Base_of_Clients Window = new Base_of_Clients();
                Window.Show();
                this.Close();
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Base_of_Clients Window = new Base_of_Clients();
            Window.Show();
            this.Close();
        }
    }
}
