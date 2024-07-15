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
    /// Interaction logic for ViewOrderDetailDialog.xaml
    /// </summary>
    public partial class ViewOrderDetailDialog : Window
    {
        private readonly List<OrderDetail> orderDetails;
        public ViewOrderDetailDialog(Order order)
        {
            InitializeComponent();
            orderDetails = order.OrderDetails.ToList();
            dgOrderDetails.ItemsSource = orderDetails;
        }
    }
}
