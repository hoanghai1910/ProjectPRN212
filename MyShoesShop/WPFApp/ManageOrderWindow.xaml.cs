using BusinessObjects;
using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for ManageOrderWindow.xaml
    /// </summary>
    public partial class ManageOrderWindow : Window
    {
        private readonly IOrderRepository _OR;
        private readonly IOrderDetailRepository _ODR;
        private readonly IShoeRepository _S;
        public ManageOrderWindow()
        {
            InitializeComponent();
            _OR = new OrderRepository();
            _S = new ShoeRepository();
            _ODR = new OrderDetailRepository();
        }

        private void resetInput()
        {
            txtOrderID.Text = "";
            txtOrderDate.Text = "";
            txtCustomerID.Text = "";
            txttotal.Text = "";
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
                new CreateOrderDialog().ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot create Customer!");
            }
            finally
            {
                LoadOrders();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Int32.Parse(txtOrderID.Text);
                if (!string.IsNullOrEmpty(id.ToString()))
                {
                    Order order = _OR.GetOrders().FirstOrDefault(o => o.OrderId == id);
                    new UpdateOrderDialog(order).ShowDialog();
                    order = UpdateOrderDialog.order;
                    _OR.UpdateOrder(order);
                }
                else
                {
                    MessageBox.Show("Please select a Order!");
                }
        }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            finally { LoadOrders(); }

        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                int id = Int32.Parse(txtOrderID.Text);
                if (!string.IsNullOrEmpty(id.ToString()))
                {
                    Order order = _OR.GetOrders().FirstOrDefault(o => o.OrderId == id);
                    new ConfirmDeleteDialog().ShowDialog();
                    if (ConfirmDeleteDialog.confirm) 
                    {
                        _OR.DeleteOrder(order);
                        foreach (OrderDetail detail in order.OrderDetails)
                        {
                            Shoe shoe = _S.GetShoeById(detail.ShoesId);
                            shoe.StockQuantity += detail.Quantity;
                            _S.UpdateShoe(shoe);
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Please select a Order!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                LoadOrders();
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
                    if (id != "")
                    {
                        var order = _OR.GetOrders().FirstOrDefault(cus => cus.OrderId == Int32.Parse(id));
                        txtOrderID.Text = id;
                        txtOrderDate.Text = order.OrderDate.ToString();
                        txtCustomerID.Text = order.CustomerId.ToString();
                        txttotal.Text = order.TotalAmount.ToString();
                    }
                    else resetInput();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadOrders();
        }

        private void LoadOrders()
        {
            try
            {
                var list = _OR.GetOrders();
                dgData.ItemsSource = null;
                dgData.ItemsSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot load Orders List!");
            }
            finally
            {
                resetInput();
            }

        }

        private void btnDetail_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                int id = Int32.Parse(txtOrderID.Text);
                if (!string.IsNullOrEmpty(id.ToString()))
                {
                    Order order = _OR.GetOrders().FirstOrDefault(o => o.OrderId == id);
                    new ViewOrderDetailDialog(order).ShowDialog();
                }
                else
                {
                    MessageBox.Show("Please select a Order!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
