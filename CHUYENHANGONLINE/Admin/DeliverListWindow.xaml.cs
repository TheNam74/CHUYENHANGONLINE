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
    /// Interaction logic for DeliverListWindow.xaml
    /// </summary>
    public partial class DeliverListWindow : Window
    {
        private BindingList<Shipper.Shipper> _shipperList;
        public DeliverListWindow(BindingList<Shipper.Shipper> shipperList)
        {
            _shipperList = shipperList;
            InitializeComponent();
        }
        private void DeliverListWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            DeliverListView.Items.Clear();
            DeliverListView.ItemsSource = _shipperList;
        }
    }
}
