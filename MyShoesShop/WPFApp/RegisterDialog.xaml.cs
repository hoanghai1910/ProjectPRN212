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
using BusinessObjects;
using Repositories;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for RegisterDialog.xaml
    /// </summary>
    public partial class RegisterDialog : Window
    {
        private readonly ICustomerRepository iCustomerRepository = new CustomerRepository();

        public RegisterDialog()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Customer c = new Customer();
            c.CustomerName = tbFullName.Text;
            c.PhoneNumber = tbTelephone.Text;
            c.Email = tbEmailAddress.Text;
            c.Password = pbPassword.Password;
            iCustomerRepository.AddCustomer(c);
            MessageBox.Show("Add Successfully!");
            this.DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

    }
}

