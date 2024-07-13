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
            lstCartItems.ItemsSource = shopCart;
            this.sessionCustomer = sessionCustomer;
            this.shopCart = shopCart;
        }

        private void btnUpdateCart_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCheckout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {

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
