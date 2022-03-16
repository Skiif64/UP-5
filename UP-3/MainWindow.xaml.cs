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
using System.Text.RegularExpressions;


namespace UP_3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AutorizationPage autorizationPage;
        private CreatePage createPage;

       public MainWindow()
        {
            InitializeComponent();
            autorizationPage = new AutorizationPage(this);
            createPage = new CreatePage(this);
            LoadAutorizationPage();
        }

        public void LoadCreatePage()
        {
            mainFrame.Content = createPage;
        }

        public void LoadAutorizationPage()
        {
            mainFrame.Content = autorizationPage;
        }

        public void ThrowErrorWindow(string message)
        {
            ErrorWindow errorWindow = new ErrorWindow(message);
            errorWindow.Owner = App.Current.MainWindow;
            errorWindow.Show();
        }
    }
}
