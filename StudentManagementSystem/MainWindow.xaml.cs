
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using StudentManagementSystem.DataAccess;
using StudentManagementSystem.entities;
using StudentManagementSystem.View;

namespace StudentManagementSystem
{
    public partial class MainWindow : Window
    {
        private UserDA _userDa;
        public MainWindow()
        {
            InitializeComponent();
            _userDa = new UserDA();
        }

        private void textEmail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtEmail.Focus();
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text) && txtEmail.Text.Length > 0) 
            {
                textEmail.Visibility = Visibility.Collapsed;
            }
            else
            {
                textEmail.Visibility= Visibility.Visible;
            }
        }

        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtPassword.Focus();
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPassword.Password) && txtPassword.Password.Length > 0)
            {
                textPassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                textPassword.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtPassword.Password))
            {
                User user = _userDa.Get(txtEmail.Text);
                if (user != null)
                {
                    if (user.Password == txtPassword.Password)
                    {
                        StudentForm studentForm = new StudentForm(txtEmail.Text);
                        Close();
                        studentForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Wrong password", "Login Error", MessageBoxButton.OK,
                            MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Wrong username", "Login Error", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
                
            }
            else
            {
                MessageBox.Show("Please fill the input fields", "Login Error", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }

        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Sign_up_Click(object sender, RoutedEventArgs e)
        {
            Sign_Up_View view = new Sign_Up_View();
            Close();
            view.ShowDialog();
        }
    }

  
}
