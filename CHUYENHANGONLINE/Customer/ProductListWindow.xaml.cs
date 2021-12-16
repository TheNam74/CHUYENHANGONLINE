using System.ComponentModel;
using System.Windows;

namespace CHUYENHANGONLINE.Customer
{
    /// <summary>
    /// Interaction logic for ProductListWindow.xaml
    /// </summary>
    public partial class ProductListWindow : Window
    {
        private BindingList<Product> productList;
        public ProductListWindow(BindingList<Product> productList)
        {
            this.productList = productList;
            InitializeComponent();
        }

        private void ProductListWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            ProductList.ItemsSource = productList;
        }
    }
}