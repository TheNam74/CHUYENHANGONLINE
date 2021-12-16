using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace CHUYENHANGONLINE
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
