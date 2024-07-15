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
    /// Interaction logic for CheckoutWindow.xaml
    /// </summary>
    public partial class CheckoutWindow : Window
    {
        private readonly Customer sessionCustomer;
        private readonly List<ShoppingCart> shopCart;
        private readonly IOrderRepository orderRepository;
        private readonly IOrderDetailRepository orderDetailRepository;
        private readonly IShoeRepository shoeRepository;
        public CheckoutWindow(Customer sessionCustomer, List<ShoppingCart> shopCart)
        {
            int total = 0;
            shopCart.ForEach(c => total += c.Shoes.Price * c.Quantity);
            InitializeComponent();
            this.sessionCustomer = sessionCustomer;

            this.shopCart = GetCartItemsWithDetails(shopCart);

            lstCartItems.ItemsSource = this.shopCart;
            txtTotalPrice.Text += total.ToString();

            orderRepository = new OrderRepository();
            orderDetailRepository = new OrderDetailRepository();
            shoeRepository = new ShoeRepository();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {

            int total = 0;
            shopCart.ForEach(c => total += c.Shoes.Price * c.Quantity);
            //Add order to DB
            Order order = new Order()
            {
                OrderDate = DateTime.Now,
                CustomerId = sessionCustomer.CustomerId,
                TotalAmount = total
            };
            orderRepository.AddOrder(order);
            //Add orderDetail to DB
            foreach (var cart in shopCart)
            {
                OrderDetail orderDetail = new OrderDetail()
                {
                    OrderId = order.OrderId,
                    ShoesId = cart.Shoes.ShoesId,
                    Quantity = cart.Quantity,
                    Price = cart.Quantity * cart.Shoes.Price
                };

                Shoe shoe = cart.Shoes;
                shoe.StockQuantity -= cart.Quantity;
                
                shoeRepository.UpdateShoe(shoe);
                orderDetailRepository.AddOrderDetail(orderDetail);
            }
            MessageBox.Show("Payment complete!");
            MainCustomerWindow mainCustomerWindow = new MainCustomerWindow(sessionCustomer);
            mainCustomerWindow.Show();
            this.Close();
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            ViewCartWindow viewCartWindow = new ViewCartWindow(sessionCustomer, shopCart);
            viewCartWindow.Show();
            this.Close();
        }
        public List<ShoppingCart> GetCartItemsWithDetails(List<ShoppingCart> shopCart)
        {
            using (var context = new MyShoesShopContext())
            {
                // Extract shoeIds from shopCart
                var shoeIds = shopCart.Select(cartItem => cartItem.Shoes.ShoesId).ToList();

                // Fetch shoes with navigation properties
                var shoes = context.Shoes
                                   .Where(shoe => shoeIds.Contains(shoe.ShoesId))
                                   .Include(shoe => shoe.Brand)
                                   .Include(shoe => shoe.Category)
                                   .ToList();

                // Create a new shopCart with fully loaded Shoe objects
                var detailedShopCart = new List<ShoppingCart>();

                foreach (var cartItem in shopCart)
                {
                    var detailedShoe = shoes.First(shoe => shoe.ShoesId == cartItem.Shoes.ShoesId);
                    detailedShopCart.Add(new ShoppingCart
                    {
                        Shoes = detailedShoe,
                        Quantity = cartItem.Quantity
                    });
                }

                return detailedShopCart;
            }
        }

    }
}
