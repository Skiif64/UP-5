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

namespace UP_3
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class ErrorWindow : Window
    {
        
        public ErrorWindow(string mes)
        {
            InitializeComponent();
            errorMessage.Text = mes;
        }



        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
