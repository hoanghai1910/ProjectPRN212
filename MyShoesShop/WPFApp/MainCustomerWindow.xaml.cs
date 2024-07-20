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
        private readonly IBrandRepository brandRepository = new BrandRepository();
        private readonly ICategoryRepository categoryRepository = new CategoryRepository();
        private readonly List<ShoppingCart> shopCart;
        public MainCustomerWindow(Customer sessionCustomer)
        {
            InitializeComponent();
            LoadBrandList();
            LoadCategoryList();
            lstShoes.ItemsSource = context.Shoes.Include(s => s.Brand).Include(s => s.Category).ToList();
            this.sessionCustomer = sessionCustomer;
            shopCart = new List<ShoppingCart>();
        }

        public void LoadBrandList()
        {
            var brands = context.Brands.ToList();
            brands.Insert(0, new Brand { BrandId = 0, BrandName = "-- Select Brand --" });
            cbBrand.ItemsSource = brands;
            cbBrand.SelectedValuePath = "BrandId";
            cbBrand.DisplayMemberPath = "BrandName";
            cbBrand.SelectedIndex = 0;
        }

        public void LoadCategoryList()
        {
            var categories = context.Categories.ToList();
            categories.Insert(0, new Category { CategoryId = 0, CategoryName = "-- Select Category --" });
            cbCategory.ItemsSource = categories;
            cbCategory.SelectedValuePath = "CategoryId";
            cbCategory.DisplayMemberPath = "CategoryName";
            cbCategory.SelectedIndex = 0;
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
                ViewCartWindow viewCartWindow = new ViewCartWindow(sessionCustomer, shopCart);
                viewCartWindow.Show();
                this.Close();
                return;
            }

            CheckoutWindow checkoutWindow = new CheckoutWindow(this.sessionCustomer, this.shopCart);
            checkoutWindow.Show();
            this.Close();
        }

        private void btnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            int quantity = 0;
            //Shoes selected
            if (txtSelectedShoeId.Text.Length == 0)
            {
                MessageBox.Show("Please select a shoes!");
                return;
            }
            int selectedShoeId = Int32.Parse(txtSelectedShoeId.Text);
            Shoe shoe = shoeRepository.GetShoeById(selectedShoeId);
            if (shopCart.Select(sc => sc.Shoes).SingleOrDefault(s => s.ShoesId == shoe.ShoesId) != null)
            {
                MessageBox.Show("Shoes already in cart!");
                return;
            }

            //Valid quantity
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
                    return;
                }

                if (quantity > shoe.StockQuantity)
                {
                    MessageBox.Show("Shoes out of stock!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please input a quantity!");
                return;
            }
            ShoppingCart shoppingCart = new ShoppingCart() { Quantity = quantity, Shoes = shoe };
            shopCart.Add(shoppingCart);
            txtSelectedShoeId.Text = "";
            txtQuantity.Text = "0";
            txtSelectedShoes.Text = "";
            MessageBox.Show("Shoes add to cart successfully!");
        }

        private void btnViewCart_Click(object sender, RoutedEventArgs e)
        {
            ViewCartWindow viewCartWindow = new ViewCartWindow(sessionCustomer, shopCart);
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

        private void btnViewHistory_Click(object sender, RoutedEventArgs e)
        {
            ViewOrderHistory viewOrderHistory = new ViewOrderHistory(sessionCustomer, shopCart);
            viewOrderHistory.Show();
            this.Close();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            int brandId = (int)cbBrand.SelectedValue;
            int categoryId = (int)cbCategory.SelectedValue;
            //Both == 0
            if (categoryId == 0 && brandId == 0)
            {
                lstShoes.ItemsSource = context.Shoes.Include(s => s.Brand).Include(s => s.Category).ToList();
            }
            //Category == 0 && Brand !=0
            else if (categoryId == 0)
            {
                lstShoes.ItemsSource = context.Shoes.Include(s => s.Brand).Include(s => s.Category).ToList().Where(c => c.BrandId == brandId);
            }
            //Category != 0 && Brand == 0
            else if (brandId == 0)
            {
                lstShoes.ItemsSource = context.Shoes.Include(s => s.Brand).Include(s => s.Category).ToList().Where(c => c.CategoryId == categoryId);
            }
            //Both == 0
            else
            {
                lstShoes.ItemsSource = context.Shoes.Include(s => s.Brand).Include(s => s.Category).ToList().Where(c => c.CategoryId == categoryId && c.BrandId == brandId);
            }
        }
        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            UpdateProfile updateProfile = new UpdateProfile(sessionCustomer);
            updateProfile.Show();
            this.Close();
        }


    }
}
