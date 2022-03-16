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

namespace UP_3
{
    /// <summary>
    /// Логика взаимодействия для AutorizationPage.xaml
    /// </summary>
    public partial class AutorizationPage : Page
    {
        private MainWindow mainWindow;
        private string _login = "employee";
        private string _password = "employee";
        private int countToBlock = 3;
        private int countLeft = 3;
        private bool isBlocked;
        DateTime timeFromBlock;
        public AutorizationPage(MainWindow main)
        {
            InitializeComponent();
            mainWindow = main;
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            if (isBlocked)
            {
                if (DateTime.Now > timeFromBlock + TimeSpan.FromMinutes(1))
                {
                    isBlocked = false;
                    countLeft = countToBlock;
                }
                else
                {
                    mainWindow.ThrowErrorWindow($"Доступ заблокирован на {(int)(timeFromBlock + TimeSpan.FromMinutes(1) - DateTime.Now).TotalSeconds} сек.");
                    return;
                }

            }

            if (login.Text != _login || password.Password != _password)
            {
                countLeft--;
                TryBlock();
                mainWindow.ThrowErrorWindow($"Неправильный логин и/или пароль. Осталось: {countLeft} попыток");
                return;

            }
            mainWindow.LoadCreatePage();
        }

        private void TryBlock()
        {
            if (countLeft != 0)
            {
                return;
            }
            isBlocked = true;
            timeFromBlock = DateTime.Now;

        }
    }
}
