using System.Windows;
using System.Windows.Controls;

namespace CHUYENHANGONLINE.Customer
{
    /// <summary>
    /// Interaction logic for CustomerHomePageUC.xaml
    /// </summary>
    public partial class CustomerHomePageUC : UserControl
    {
        private Customer _customer = (MainWindow.User as Customer);
        public CustomerHomePageUC()
        {
            InitializeComponent();
        }
        private void StaffHomePageUC_OnLoaded(object sender, RoutedEventArgs e)
        {
            HelloLabel.Content = $"Xin chào {_customer.Name}";
        }
    }
}
