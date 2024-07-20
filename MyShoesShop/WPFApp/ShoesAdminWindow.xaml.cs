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
    /// Interaction logic for ShoesAdminWindow.xaml
    /// </summary>
    public partial class ShoesAdminWindow : Window
    {   
        private readonly IShoeRepository shoeRepository;
        public ShoesAdminWindow()
        {
            InitializeComponent();
            shoeRepository = new ShoeRepository();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //LoadBrand();
            //LoadCategory();
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

        }
        private void LoadCategory()
        {

        }

    }
}
