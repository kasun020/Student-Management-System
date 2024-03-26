using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using StudentManagementSystem.DataAccess;
using StudentManagementSystem.entities;

namespace StudentManagementSystem.View
{
    /// <summary>
    /// Interaction logic for Sign_Up_View.xaml
    /// </summary>
    public partial class Sign_Up_View : Window
    {

        private readonly UserDA _userDa;
        
        private byte[] _imageBytes;
        private string _selectedImagePath;
        
        public Sign_Up_View()
        {
            InitializeComponent();
            TxtErrorMsg.Text = "";
            
            _userDa = new UserDA();
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            if (TxtPassword.Password == TxtRePassword.Password)
            {
                _userDa.AddUser(new User
                {
                    Name = TxtUsername.Text,
                    Address = TxtFaculty.Text,
                    Password = TxtPassword.Password,
                    FullName = TxtFullName.Text,
                    RegNum = TxtRegNo.Text,
                    ImagePath = _selectedImagePath,
                    ImageData = _imageBytes
                });

                StudentForm studentForm = new StudentForm(TxtUsername.Text);
                Close();
                studentForm.ShowDialog();
            }
            else
            {
                TxtErrorMsg.Text = "The password and re-password should be same.";
            }
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png;*.jfif;*.jpeg;*.jpg;*.gif;*.bmp)|*.png;*.jfif;*.jpeg;*.jpg;*.gif;*.bmp|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                _selectedImagePath = openFileDialog.FileName;
                _imageBytes = File.ReadAllBytes(_selectedImagePath);

            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
