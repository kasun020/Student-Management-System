using System.Collections.Generic;
using System.Linq;
using System.Windows;
using StudentManagementSystem.DataAccess;
using StudentManagementSystem.entities;
using StudentManagementSystem.Model;

namespace StudentManagementSystem.View
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    ///
    
    public partial class Dashboard : Window
    {
        
        public void boxClear()
        {
            NameTextBox.Clear();
            AddressTextBox.Clear();
        }
        
        public List<User> DatabaseUsers { get; private set; }

        private UserDA _userDa;

        public Dashboard()
        {
            InitializeComponent();
            _userDa = new UserDA();
        }
        

        public void Read()
        {

            DatabaseUsers = _userDa.GetAll().ToList();
            ItemList.ItemsSource = DatabaseUsers;

        }

        public void Update()
        {
            User selectedUser = ItemList.SelectedItem as User;

            if (selectedUser != null)
            {
                var id = selectedUser.Id;
                var name = NameTextBox.Text;
                var address = AddressTextBox.Text;
                var regno = RegnoTextBox.Text;

                selectedUser.FullName = name;
                selectedUser.Address = address;
                selectedUser.RegNum = regno;

                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(address) && !string.IsNullOrEmpty(regno))
                {
                    _userDa.UpdateUser(selectedUser);
                }
            }
        }


        public void Delete()
        {
            User selectedUser = ItemList.SelectedItem as User;

                if (selectedUser != null)
                {

                    _userDa.RemoveUser(selectedUser.Id);

                }

        }

        

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            Read();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Update();
            Read();
            boxClear();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Delete();
            Read();
            boxClear();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            ItemList.Items.Clear();

        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            FirstPage firstPage = new FirstPage();
            Close();
            firstPage.ShowDialog();
        }

        private void NameTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void EnableCheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
