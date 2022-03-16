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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UP_3
{
    /// <summary>
    /// Логика взаимодействия для CreatePage.xaml
    /// </summary>
    public partial class CreatePage : Page
    {
        private MainWindow mainWindow;
        private Regex emailRegex;
        private Regex phoneRegex;
        private Regex passportRegex;
        private Regex nameRegex;

        private SolidColorBrush correctColor = new SolidColorBrush(Colors.Green);
        private SolidColorBrush wrongColor = new SolidColorBrush(Colors.DarkRed);
        public CreatePage(MainWindow main)
        {
            InitializeComponent();
            mainWindow = main;
            emailRegex = new Regex(@"(\w*)[@](\w*)[.](\w*)", RegexOptions.IgnoreCase);
            phoneRegex = new Regex(@"^([+7]|[8])\d{10}");
            passportRegex = new Regex(@"(\d{10})");
            nameRegex = new Regex(@"(^[А-Я])[а-я]*");
            UpdateListView();
        }

        private void createEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckData())
            {
                mainWindow.ThrowErrorWindow("Неправильные данные");
                return;
            }

            Repository.WriteEmployee(new Employee(
                    uint.Parse(id.Text)
                    , lastName.Text
                    , firstName.Text
                    , secondName.Text
                    , passportId.Text
                    , phone.Text
                    , email.Text));
            UpdateListView();
        }

        private bool CheckData()
        {

            try
            {
                bool idCheck = Repository.FreeId(id.Text);
                bool emailCheck = Check(email.Text, emailRegex);
                bool phoneCheck = Check(phone.Text, phoneRegex);
                bool lastNameCheck = Check(lastName.Text, nameRegex);
                bool firstNameCheck = Check(firstName.Text, nameRegex);
                bool secondNameCheck = Check(secondName.Text, nameRegex);
                bool passportCheck = Check(passportId.Text, passportRegex);

                return idCheck && emailCheck && phoneCheck && lastNameCheck && firstNameCheck && secondNameCheck && passportCheck;
            }
            catch (Exception e)
            {

            }
            return false;
        }

        private bool Check(string arg, Regex reg)
        {
            try
            {
                if (reg.IsMatch(arg))
                {
                    return true;
                }
            }
            catch (Exception e)
            {

            }
            return false;
        }

        private void ChangeColor(object obj, Brush color)
        {
            (obj as Control).Background = color;
        }

        private void UpdateListView()
        {
            employersView.ItemsSource = Repository.GetEmployers();
            employersView.Items.Refresh();
        }

        private void id_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Repository.FreeId(id.Text))
            {
                ChangeColor(sender, correctColor);
            }
            else
            {
                ChangeColor(sender, wrongColor);
            }
        }

        private void lastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Check(lastName.Text, nameRegex))
            {
                ChangeColor(sender, correctColor);
            }
            else
            {
                ChangeColor(sender, wrongColor);
            }
        }

        private void firstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Check(firstName.Text, nameRegex))
            {
                ChangeColor(sender, correctColor);
            }
            else
            {
                ChangeColor(sender, wrongColor);
            }
        }

        private void secondName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Check(secondName.Text, nameRegex))
            {
                ChangeColor(sender, correctColor);
            }
            else
            {
                ChangeColor(sender, wrongColor);
            }
        }

        private void passportId_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Check(passportId.Text, passportRegex))
            {
                ChangeColor(sender, correctColor);
            }
            else
            {
                ChangeColor(sender, wrongColor);
            }
        }

        private void phone_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Check(phone.Text, phoneRegex))
            {
                ChangeColor(sender, correctColor);
            }
            else
            {
                ChangeColor(sender, wrongColor);
            }
        }

        private void email_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Check(email.Text, emailRegex))
            {
                ChangeColor(sender, correctColor);
            }
            else
            {
                ChangeColor(sender, wrongColor);
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.LoadAutorizationPage();
        }
    }
}
