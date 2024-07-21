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
    /// Interaction logic for CreateCustomerDialog.xaml
    /// </summary>
    public partial class CreateCustomerDialog : Window
    {
        public static Customer customer { get; private set; }
        public CreateCustomerDialog()
        {
            InitializeComponent();
            customer = null;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (txtCustomersName.Text != "" && txtEmail.Text != "" && txtPassword.Text != "" && txtPhone.Text != "" && txtAddress.Text != "")
            {
                customer = new Customer()
                {
                    CustomerName = txtCustomersName.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    PhoneNumber = txtPhone.Text,
                    Address = txtAddress.Text,
                };
            }
            else
                MessageBox.Show("Please fill in all information!");
            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
