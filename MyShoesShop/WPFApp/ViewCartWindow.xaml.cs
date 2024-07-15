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

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for ViewCartWindow.xaml
    /// </summary>
    public partial class ViewCartWindow : Window
    {
        private readonly Customer sessionCustomer;
        private readonly List<ShoppingCart> shopCart;
        public ViewCartWindow(Customer sessionCustomer, List<ShoppingCart> shopCart)
        {
            InitializeComponent();
            this.sessionCustomer = sessionCustomer;
            this.shopCart = shopCart;
            lstCartItems.ItemsSource = this.shopCart;

        }
        private void btnCheckout_Click(object sender, RoutedEventArgs e)
        {
            if (shopCart.Count == 0)
            {
                MessageBox.Show("Shopping Cart is empty!");
                return;
            }

            string error = "";
            foreach (var cartItem in shopCart)
            {
                // Validate and update quantity
                if (cartItem.Quantity > cartItem.Shoes.StockQuantity)
                {
                    error += $"Requested quantity for {cartItem.Shoes.ShoesName} exceeds available stock ({cartItem.Shoes.StockQuantity}).\n";
                    cartItem.Quantity = 1;
                }
            }
            if (error.Length != 0)
            {
                MessageBox.Show(error);
                lstCartItems.ItemsSource = null;
                lstCartItems.ItemsSource = this.shopCart;
                return;
            }

            CheckoutWindow checkoutWindow = new CheckoutWindow(this.sessionCustomer, this.shopCart);
            checkoutWindow.Show();
            this.Close();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            ShoppingCart shoppingCart = lstCartItems.SelectedItem as ShoppingCart;
            if (shoppingCart == null)
            {
                MessageBox.Show("Please chose an item!");
                return;
            }
            this.shopCart.Remove(shoppingCart);
            MessageBox.Show("Item has been removed!");
            // Reset ItemsSource to update the UI
            lstCartItems.ItemsSource = null;
            lstCartItems.ItemsSource = this.shopCart;
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            MainCustomerWindow mainCustomerWindow = new MainCustomerWindow(sessionCustomer, shopCart);
            mainCustomerWindow.Show();
            this.Close();
        }

        private void lstCartItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
