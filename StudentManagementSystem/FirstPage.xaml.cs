using StudentManagementSystem.View;
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

namespace StudentManagementSystem
{
    /// <summary>
    /// Interaction logic for FirstPage.xaml
    /// </summary>
    public partial class FirstPage : Window
    {
        public FirstPage()
        {
            InitializeComponent();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            AdminSignIn view = new AdminSignIn();
            Close();
            view.ShowDialog();

        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            MainWindow Mainwindow = new MainWindow();
            Close();
            Mainwindow.ShowDialog();

        }


    }
}
