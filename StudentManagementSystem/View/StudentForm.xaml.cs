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
    public partial class StudentForm : Window
    {
        private User _user;
        private readonly string _username;

        private UserDA _userDa;
        
        public StudentForm(string username)
        { 
            InitializeComponent();
            this._username = username;
            
            
            
            Uri uri = new Uri("pack://application:,,,/Images/university_logo.jpg");
            BitmapImage bitmapImage = new BitmapImage(uri);
            UniversityLogo.Source = bitmapImage;

            /*uri = new Uri("pack://application:,,,/Images/Barcode.png");
            bitmapImage = new BitmapImage(uri);
            BarCodeImage.Source = bitmapImage;*/
            

            _userDa = new UserDA();
            GetAllUsers();
        }

        private void GetAllUsers()
        {
            _user = _userDa.Get(_username);
            TxtName.Text = _user.FullName;
            TxtFaculty.Text = _user.Address;
            TxtRegNo.Text = _user.RegNum;
            ImageSource imageSource = ConvertByteArrayToImage(_user.ImageData);
            ImagePreview.Source = imageSource;
        }
        
        

        private ImageSource ConvertByteArrayToImage(byte[] imageData)
        {
            using (MemoryStream ms = new MemoryStream(imageData))
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = ms;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.EndInit();
                return image;
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            FirstPage firstPage = new FirstPage();
            Close();
            firstPage.ShowDialog();
        }
    }
}
