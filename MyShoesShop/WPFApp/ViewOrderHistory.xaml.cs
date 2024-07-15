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
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for ViewOrderHistory.xaml
    /// </summary>
    public partial class ViewOrderHistory : Window
    {
        private readonly Customer sessionCustomer;
        private readonly List<ShoppingCart> shopCart;
        private readonly MyShoesShopContext context = new MyShoesShopContext();

        public ViewOrderHistory(Customer sessionCustomer, List<ShoppingCart> shopCart)
        {
            InitializeComponent();
            this.sessionCustomer = sessionCustomer;
            this.shopCart = shopCart;  
            dgOrderHistory.ItemsSource = context.Orders.Include(o => o.OrderDetails).ThenInclude(od => od.Shoes).Where(o => o.CustomerId == sessionCustomer.CustomerId).ToList();
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            MainCustomerWindow mainCustomerWindow = new MainCustomerWindow(sessionCustomer, shopCart);
            mainCustomerWindow.Show();
            this.Close();
        }
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var date = dpOrderDate.SelectedDate;
            if (date != null)
            {
                DateTime orderDate = (DateTime)dpOrderDate.SelectedDate;
                dgOrderHistory.ItemsSource = context.Orders.Include(o => o.OrderDetails).ThenInclude(od => od.Shoes).Where(o => o.CustomerId == sessionCustomer.CustomerId && orderDate.Date == o.OrderDate.Date).ToList();
            }
            else MessageBox.Show("Please select a date!");
        }

        private void dgOrderHistory_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Order order = dgOrderHistory.SelectedItem as Order;
            if (order != null)
            {
                ViewOrderDetailDialog viewOrderDetailDialog = new ViewOrderDetailDialog(order);
                viewOrderDetailDialog.ShowDialog();
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            dpOrderDate.SelectedDate = null;
            dgOrderHistory.ItemsSource = context.Orders.Include(o => o.OrderDetails).ThenInclude(od => od.Shoes).Where(o => o.CustomerId == sessionCustomer.CustomerId).ToList();
        }
    }
}
