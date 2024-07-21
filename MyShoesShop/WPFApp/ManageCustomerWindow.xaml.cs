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
    /// Interaction logic for CustomerAdminWindow.xaml
    /// </summary>
    public partial class CustomerAdminWindow : Window
    {
        private readonly ICustomerRepository _CR;
        public CustomerAdminWindow()
        {
            InitializeComponent();
            _CR = new CustomerRepository();
        }

        private void resetInput()
        {
            txtCustomerID.Text = "";
            txtCustomersName.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            MainAdminWindow mainAdminWindow = new MainAdminWindow();
            mainAdminWindow.Show();
            this.Close();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                new CreateCustomerDialog().ShowDialog();
                Customer customer = CreateCustomerDialog.customer;
                if(customer != null)
                {
                    _CR.AddCustomer(customer);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot create Customer!");
            }
            finally
            {
                LoadCustomer();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Int32.Parse(txtCustomerID.Text);
                if (!string.IsNullOrEmpty(id.ToString()))
                {
                    Customer customer = _CR.GetCustomers().FirstOrDefault(cus => cus.CustomerId == id);
                    if (customer != null)
                    {
                        new UpdateCustomerDialog(customer).ShowDialog();
                        customer = UpdateCustomerDialog.cus;
                        _CR.UpdateCustomer(customer);
                    }
                    else
                        MessageBox.Show("Please Select a Customer!");
                }
            }
            catch (Exception ex) { MessageBox.Show("Cannot update Customer"); }
                
            finally { LoadCustomer(); }

        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                int id = Int32.Parse(txtCustomerID.Text);
                if (!string.IsNullOrEmpty(id.ToString()))
                {
                    Customer customer = _CR.GetCustomers().FirstOrDefault(cus => cus.CustomerId == id);
                    new ConfirmDeleteDialog().ShowDialog();
                    if(ConfirmDeleteDialog.confirm)
                        _CR.DeleteCustomer(customer);
                }
                else
                {
                    MessageBox.Show("Please select a customer!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select a customer!");
            }
            finally
            {
                LoadCustomer();
            }

        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGrid dataGrid = sender as DataGrid;
                if (dataGrid.SelectedIndex >= 0)
                {
                    DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
                    DataGridCell RowColumn = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
                    String id = ((TextBlock)RowColumn.Content).Text;
                    if(id != "")
                    {
                        var customer = _CR.GetCustomers().FirstOrDefault(cus => cus.CustomerId == Int32.Parse(id));
                        txtCustomerID.Text = id;
                        txtCustomersName.Text = customer.CustomerName;
                        txtEmail.Text = customer.Email;
                        txtPassword.Text = customer.Password;
                        txtPhone.Text = customer.PhoneNumber;
                        txtAddress.Text = customer.Address;
                    }else resetInput();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCustomer();
        }
        private void LoadCustomer()
        {
            try
            {
                var list = _CR.GetCustomers();
                dgData.ItemsSource = null;
                dgData.ItemsSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot load Customer List!");
            }
            finally
            {
                resetInput();
            }

        }
    }
}
