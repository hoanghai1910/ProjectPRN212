using BusinessObjects;
using DataAccessLayer;
using Repositories;
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

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for UpdateProfile.xaml
    /// </summary>
    public partial class UpdateProfile : Window
    {
        private readonly MyShoesShopContext context = new MyShoesShopContext();
        private readonly Customer sessionCustomer;
        private readonly ICustomerRepository customerRepository;

        public UpdateProfile(Customer sesstionCutomer)
        {
            InitializeComponent();
            this.sessionCustomer = sesstionCutomer;
            customerRepository = new CustomerRepository();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            ChangePassword changePassword = new ChangePassword(sessionCustomer);
            changePassword.Show();
            this.Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            sessionCustomer.CustomerName = CustomerNameTextBox.Text;
            sessionCustomer.Email = EmailTextBox.Text;
            sessionCustomer.PhoneNumber = PhoneNumberTextBox.Text;
            sessionCustomer.Address = AddressTextBox.Text;
            customerRepository.UpdateCustomer(sessionCustomer);
            MessageBox.Show("Update Profile Successfull!");
            LoadCustomer();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CustomerNameTextBox.Text = sessionCustomer.CustomerName.ToString();
            EmailTextBox.Text = sessionCustomer.Email.ToString();
            PhoneNumberTextBox.Text = sessionCustomer.PhoneNumber.ToString();
            AddressTextBox.Text = sessionCustomer.Address.ToString();
            
            
        }
        private void LoadCustomer()
        {
            sessionCustomer.CustomerName = CustomerNameTextBox.Text;
            sessionCustomer.Email = EmailTextBox.Text;
            sessionCustomer.PhoneNumber = PhoneNumberTextBox.Text;
            sessionCustomer.Address = AddressTextBox.Text;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainCustomerWindow mainCustomerWindow = new MainCustomerWindow(sessionCustomer);
            mainCustomerWindow.Show();
            this.Close();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MainCustomerWindow mainCustomerWindow = new MainCustomerWindow(sessionCustomer);
            mainCustomerWindow.Show();
            this.Close();
        }
    }
}
