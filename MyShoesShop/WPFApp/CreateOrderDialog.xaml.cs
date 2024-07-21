using BusinessObjects;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for CreateOrderDialog.xaml
    /// </summary>
    public partial class CreateOrderDialog : Window
    {
        private readonly IOrderRepository _OR;
        private readonly IOrderDetailRepository _ODR;
        private readonly IShoeRepository _S;
        private readonly ICustomerRepository _C;
        public static Order order { get; private set; }
        public CreateOrderDialog()
        {
            InitializeComponent();
            _OR = new OrderRepository();
            _ODR = new OrderDetailRepository();
            _S = new ShoeRepository();
            _C = new CustomerRepository();
            order = new Order()
            {
                OrderDate = DateTime.Now,
                TotalAmount = 0,
            };
        }

        private void resetInput()
        {
            txttotal.Text = order.TotalAmount.ToString();
            cboShoes.Text = "";
            txtQuantity.Text = "";
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            // return normal to shoes
            foreach(OrderDetail detail in order.OrderDetails)
            {
                updateShoes(detail.ShoesId, detail.Quantity);
            }
            _OR.DeleteOrder(order);
            order = null;
            this.Close();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                order.OrderDate = DateTime.Parse(txtOrderDate.Text);
                order.CustomerId = Int32.Parse(cboCustomer.SelectedValue.ToString());
                _OR.AddOrder(order);
                //foreach(OrderDetail detail in order.OrderDetails)
                //{
                //    _ODR.AddOrderDetail(detail);
                //}
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int shoeID = Int32.Parse(cboShoes.SelectedValue.ToString());
                int quan = Int32.Parse(txtQuantity.Text);
                var shoe = _S.GetShoes().FirstOrDefault(s => s.ShoesId == shoeID);
                if (shoe.StockQuantity > quan)
                {
                    var detail = new OrderDetail()
                    {
                        ShoesId = shoeID,
                        Quantity = quan,
                        Price = quan * shoe.Price
                    };
                    order.OrderDetails.Add(detail);
                    order.TotalAmount += detail.Price;
                    updateShoes(shoeID, -1*quan);
                }
                else
                    MessageBox.Show("Not enough in stock of shoe!");
            }
            catch (Exception ex) { MessageBox.Show("Cannot Add Shoe!"); }

            finally
            {
                LoadDetails();
                LoadShoes();
            }

        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Int32.Parse(cboShoes.SelectedValue.ToString());
                if (!string.IsNullOrEmpty(id.ToString()))
                {
                    OrderDetail detail = order.OrderDetails.FirstOrDefault(detail => detail.ShoesId == id);
                    order.OrderDetails.Remove(detail);
                    order.TotalAmount -= detail.Price;
                    updateShoes(detail.ShoesId,detail.Quantity);
                }
                else
                {
                    MessageBox.Show("Please select a Detail!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select a Detail!");
            }
            finally
            {
                LoadDetails();
                LoadShoes();
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
                    RowColumn = dataGrid.Columns[1].GetCellContent(row).Parent as DataGridCell;
                    String shoesID = ((TextBlock)RowColumn.Content).Text;
                    if (id != "" && shoesID != "")
                    {
                        var detail = order.OrderDetails.FirstOrDefault(detail => detail.OrderId == Int32.Parse(id) && detail.ShoesId == Int32.Parse(shoesID));
                        cboShoes.SelectedValue = detail.ShoesId.ToString();
                        txtQuantity.Text = detail.Quantity.ToString();
                    }
                    else resetInput();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void updateShoes(int shoeID, int quantity)
        {
            Shoe shoe = _S.GetShoeById(shoeID);
            shoe.StockQuantity += quantity;
            _S.UpdateShoe(shoe);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadShoes();
            LoadDetails();
            LoadCustomer();
        }

        private void LoadCustomer()
        {
            try
            {
                var list = _C.GetCustomers();
                cboCustomer.ItemsSource = list;
                cboCustomer.SelectedValuePath = "CustomerId";
                cboCustomer.DisplayMemberPath = "CustomerName";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot load Customer List!");
            }
        }

        private void LoadShoes()
        {
            try
            {
                var list = _S.GetShoes();
                cboShoes.ItemsSource = list;
                cboShoes.SelectedValuePath = "ShoesId";
                cboShoes.DisplayMemberPath = "ShoesName";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot load Shoes List!");
            }

        }

        private void LoadDetails()
        {
            try
            {
                dgData.ItemsSource = null;
                dgData.ItemsSource = order.OrderDetails.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot load Detail List!");
            }
            finally
            {
                resetInput();
            }
        }
    }
}
