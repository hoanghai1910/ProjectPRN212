using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for ShoesAdminWindow.xaml
    /// </summary>
    public partial class ShoesAdminWindow : Window
    {   
        private readonly IShoeRepository shoeRepository;
        private readonly IBrandRepository brandRepository;
        private readonly ICategoryRepository categoryRepository;
        public ShoesAdminWindow()
        {
            InitializeComponent();
            shoeRepository = new ShoeRepository();
            brandRepository = new BrandRepository();
            categoryRepository = new CategoryRepository();
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
                Shoe shoe = new Shoe
                {
                    ShoesName = txtShoesName.Text,
                    Color = txtShoesColour.Text,
                    Price = Int32.Parse(txtShoesPrice.Text),
                    StockQuantity = Int32.Parse(txtShoesStockQuantity.Text),
                    Size = decimal.Parse(txtShoesSize.Text),
                    BrandId = Int32.Parse(cboBrand.SelectedValue.ToString()),
                    CategoryId = Int32.Parse(cboCategory.SelectedValue.ToString()),
                };
                shoeRepository.AddShoe(shoe);

            }catch(Exception ex)
            { 
            }
            finally
            {
                var shoeList = shoeRepository.GetShoes();
                dgData.ItemsSource = null;
                dgData.ItemsSource = shoeList;

            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Int32.Parse(txtShoesID.Text);
                if (!string.IsNullOrEmpty(id.ToString()))
                {
                    Shoe shoe = shoeRepository.GetShoeById(id);
                    if (shoe != null)
                    {
                        shoe.ShoesName = txtShoesName.Text;
                        shoe.Color = txtShoesColour.Text;
                        shoe.Price = Int32.Parse(txtShoesPrice.Text);
                        shoe.StockQuantity = Int32.Parse(txtShoesStockQuantity.Text);
                        shoe.Size = decimal.Parse(txtShoesSize.Text);
                        shoe.BrandId = Int32.Parse(cboBrand.SelectedValue.ToString());
                        shoe.CategoryId = Int32.Parse(cboCategory.SelectedValue.ToString());
                        shoeRepository.UpdateShoe(shoe);
                    }
                    else
                    {
                        MessageBox.Show("You should choose Shoes");
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                LoadShoes();
            }

        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                int id = Int32.Parse(txtShoesID.Text);
                if (!string.IsNullOrEmpty(id.ToString()))
                {
                    Shoe shoe = shoeRepository.GetShoeById(id);
                    shoeRepository.DeleteShoe(shoe);
                }
                else
                {
                    MessageBox.Show("You should select Product");
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                LoadShoes();
            }

        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgData.SelectedItem is Shoe select)
            {
                txtShoesID.Text = select.ShoesId.ToString();
                txtShoesName.Text = select.ShoesName.ToString();
                txtShoesColour.Text = select.Color.ToString();
                txtShoesPrice.Text = select.Price.ToString();
                txtShoesSize.Text = select.Size.ToString();
                txtShoesStockQuantity.Text = select.StockQuantity.ToString();
                cboBrand.SelectedValue = select.BrandId;
                cboCategory.SelectedValue = select.CategoryId;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadBrand();
            LoadCategory();
            LoadShoes();
        }
        private void LoadShoes()
        {
            try
            {
                var shoesList = shoeRepository.GetShoes();
                dgData.ItemsSource = shoesList;
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }

        }
        private void LoadBrand()
        {
            try
            {
                var brandList = brandRepository.GetBrands();
                cboBrand.ItemsSource = brandList;
                cboBrand.DisplayMemberPath = "BrandName";
                cboBrand.SelectedValuePath = "BrandId";
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }
        private void LoadCategory()
        {
            try
            {
                var list = categoryRepository.GetAll();
                cboCategory.ItemsSource = list;
                cboCategory.DisplayMemberPath = "CategoryName";
                cboCategory.SelectedValuePath = "CategoryId";
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }

    }
}
