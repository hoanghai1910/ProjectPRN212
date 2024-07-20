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
using BusinessObjects;
using Microsoft.Extensions.Configuration;
using Repositories;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly ICustomerRepository iCustomerRepository;
        public LoginWindow()
        {
            iCustomerRepository = new CustomerRepository();
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                IConfiguration configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", true, true).Build();

                String adminEmail = configuration["Admin:email"];
                String adminPassword = configuration["Admin:password"];


                String enteredEmail = txtUser.Text;
                String enteredPassword = txtPass.Password;

                if (string.IsNullOrEmpty(enteredEmail) || string.IsNullOrEmpty(enteredPassword))
                {
                    MessageBox.Show("Please enter both email and password.");
                    return;
                }


                // Valid Admin
                if (enteredEmail.Equals(adminEmail) && enteredPassword.Equals(adminPassword))
                {
                    //Admin
                    MainAdminWindow mainAdminWindow = new MainAdminWindow();
                    mainAdminWindow.Show();
                    this.Close();
                    //MessageBox.Show("This is admin");

                    return;
                }

                //Valid Customer
                Customer customer = iCustomerRepository.GetCustomerByEmail(enteredEmail);
                if (customer != null && customer.Password.Equals(enteredPassword))
                {
                    MainCustomerWindow mainCustomerWindow = new MainCustomerWindow(customer);
                    mainCustomerWindow.Show();
                    this.Close();
                    //MessageBox.Show("This is customer");
                    return;
                }


                //Invalid credential
                StringBuilder debugInfo = new StringBuilder();
                debugInfo.AppendLine("Invalid credentials. Please try again.");
                debugInfo.AppendLine($"Entered Email: {enteredEmail}");
                debugInfo.AppendLine($"Entered Password: {enteredPassword}");
                debugInfo.AppendLine($"Admin Email: {adminEmail}");
                debugInfo.AppendLine($"Admin Password: {adminPassword}");
                MessageBox.Show(debugInfo.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }



        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterDialog registerDialog = new RegisterDialog();
            registerDialog.ShowDialog();
        }
    }
}
