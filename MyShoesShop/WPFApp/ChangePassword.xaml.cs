using BusinessObjects;
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
    /// Interaction logic for ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        private readonly ICustomerRepository customerRepository;
        private readonly Customer sessionCustomer;
        public ChangePassword(Customer customer)
        {
            InitializeComponent();
            customerRepository = new CustomerRepository();
            this.sessionCustomer = customer;           
        }

        private void ChangePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            if (!CurrentPasswordBox.Password.Equals(sessionCustomer.Password))
            {
                MessageBox.Show("Current Password is wrong!");
            }
            else
            {
                sessionCustomer.Password = NewPasswordBox.Password;
                customerRepository.UpdateCustomer(sessionCustomer);
                MessageBox.Show("Change passwords Successfull!");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            MainCustomerWindow mainCustomerWindow = new MainCustomerWindow(sessionCustomer);
            mainCustomerWindow.Show();
            this.Close();
        }
    }
}
