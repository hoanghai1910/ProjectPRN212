using BusinessObjects;
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
    /// Interaction logic for UpdateCustomerDialog.xaml
    /// </summary>
    public partial class UpdateCustomerDialog : Window
    {
        public static Customer cus { get; private set; }
        public UpdateCustomerDialog(Customer customer)
        {
            InitializeComponent();
            cus = customer;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtCustomerID.Text = cus.CustomerId.ToString();
            txtCustomersName.Text = cus.CustomerName.ToString();
            txtEmail.Text = cus.Email.ToString();
            txtPassword.Text = cus.Password.ToString();
            txtPhone.Text = cus.PhoneNumber;
            txtAddress.Text = cus.Address;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (txtCustomersName.Text != "" && txtEmail.Text != "" && txtPassword.Text != "" && txtPhone.Text != "" && txtAddress.Text != "")
            {
                cus.CustomerName = txtCustomersName.Text;
                cus.Email = txtEmail.Text;
                cus.Password = txtPassword.Text;
                cus.PhoneNumber = txtPhone.Text;
                cus.Address = txtAddress.Text;
                this.Close();
            }else
            {
                MessageBox.Show("Please dont let information blank!");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
