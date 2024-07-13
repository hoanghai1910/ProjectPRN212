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
using Repositories;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainCustomerWindow.xaml
    /// </summary>
    public partial class MainCustomerWindow : Window
    {
        private readonly MyShoesShopContext context = new MyShoesShopContext();
        private readonly Customer sessionCustomer;
        private readonly IShoeRepository shoeRepository = new ShoeRepository();
        private readonly List<ShoppingCart> shopCart;
        public MainCustomerWindow(Customer sessionCustomer)
        {
            InitializeComponent();
            lstShoes.ItemsSource = context.Shoes.Include(s => s.Brand).Include(s => s.Category).ToList();
            this.sessionCustomer = sessionCustomer;
            shopCart = new List<ShoppingCart>();
        }

        public MainCustomerWindow(Customer sessionCustomer, List<ShoppingCart> shopCart)
        {
            InitializeComponent();
            lstShoes.ItemsSource = context.Shoes.Include(s => s.Brand).Include(s => s.Category).ToList();
            this.sessionCustomer = sessionCustomer;
            if (shopCart != null)
            {
                this.shopCart = shopCart;
            }
        }

        private void btnCheckout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            int quantity = 0;
            if (txtSelectedShoeId.Text.Length == 0)
            {
                MessageBox.Show("Please select a shoes!");
                return;
            }
            if (txtQuantity.Text.Length != 0)
            {
                try
                {
                    quantity = Int32.Parse(txtQuantity.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid quantity input!");
                    return;
                }

                if (quantity == 0)
                {
                    MessageBox.Show("Quantity must greater than 0!");
                }
            }
            else
            {
                MessageBox.Show("Please input a quantity!");
                return;
            }
            int selectedShoeId = Int32.Parse(txtSelectedShoeId.Text);
            Shoe shoe = shoeRepository.GetShoeById(selectedShoeId);
            ShoppingCart shoppingCart = new ShoppingCart() { Quantity = quantity, Shoes = shoe};
            shopCart.Add(shoppingCart);
            MessageBox.Show("Shoes add to cart successfully!");
        }

        private void btnViewCart_Click(object sender, RoutedEventArgs e)
        {
            ViewCartWindow viewCartWindow = new ViewCartWindow(sessionCustomer,shopCart);
            viewCartWindow.Show();
            this.Close();
        }

        private void lstShoes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
