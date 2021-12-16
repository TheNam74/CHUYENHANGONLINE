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

namespace CHUYENHANGONLINE.Admin
{
    /// <summary>
    /// Interaction logic for CustomerListWindow.xaml
    /// </summary>
    public partial class CustomerListWindow : Window
    {
        private BindingList<Customer.Customer> _customerList;
        public CustomerListWindow(BindingList<Customer.Customer> customerList)
        {
            _customerList = customerList;
            InitializeComponent();
        }
        private void CustomerListWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            CustomerListView.Items.Clear();
            CustomerListView.ItemsSource = _customerList;
        }
    }
}
