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
    /// Логика взаимодействия для AddWorker.xaml
    /// </summary>
    public partial class AddWorker : Window
    {
        public AddWorker()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MenuDirector Window = new MenuDirector();
            Window.Show();
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
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
            if (Email.Text == "" || LastName.Text == "" || FirstName.Text == "" || Patronomyc.Text == "" ||  Telephone.Text == "" || Password.Text == "" || PasswordRepeat.Text == "")
            {
                MessageBox.Show("Заполните все поля!", "Внимание");
            }
            else if (TelephoneValid == false)
            {
                MessageBox.Show("Телефон должен быть записан в международном формате: +Х ХХХ ХХХ ХХ ХХ", "Внимание");
            }
            else if (isValidated == false || (Password.Text.Contains('!') == false && Password.Text.Contains('@') == false && Password.Text.Contains('#') == false && Password.Text.Contains('$') == false && Password.Text.Contains('%') == false && Password.Text.Contains('^') == false))
            {
                MessageBox.Show("Пароль должен соответствовать следующим требованиям: Минимум 6 символов, Минимум 1 прописная буква, Минимум 1 цифра, По крайней мере один из следующих символов : !@#$%^", "Внимание");
            }
            else if (Password.Text != PasswordRepeat.Text)
            {
                MessageBox.Show("Пароль и повтор пароля не совпадают", "Внимание");
            }
            else
            {
                ServiceReference1.Users SaveRieltor = new ServiceReference1.Users();
                SaveRieltor.Email = Convert.ToString(Email.Text);
                SaveRieltor.LastName = Convert.ToString(LastName.Text);
                SaveRieltor.FirstName = Convert.ToString(FirstName.Text);
                SaveRieltor.Patronymic = Convert.ToString(Patronomyc.Text);
                SaveRieltor.Telephone = Convert.ToString(Telephone.Text);
                SaveRieltor.Password = Convert.ToString(PasswordRepeat.Text);
                SaveRieltor.Role_ID = 2;
                SaveRieltor.DateBirth = DateTime.Now;
                SaveRieltor.Adress = "";
                ServiceReference1.Service1Client Service = new ServiceReference1.Service1Client();
                Service.AddUsers(SaveRieltor);
                Workers Window = new Workers();
                Window.Show();
                this.Close();
            }
        }
    }
}
