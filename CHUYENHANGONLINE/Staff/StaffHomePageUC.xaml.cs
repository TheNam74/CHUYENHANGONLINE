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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CHUYENHANGONLINE.Staff
{
    /// <summary>
    /// Interaction logic for StaffHomePageUC.xaml
    /// </summary>
    public partial class StaffHomePageUC : UserControl
    {
        private Staff _staff = (MainWindow.User as Staff);
        public StaffHomePageUC()
        {
            InitializeComponent();
        }

        private void StaffHomePageUC_OnLoaded(object sender, RoutedEventArgs e)
        {
            HelloLabel.Content = $"Xin chào {_staff.Name}";
        }
    }
}
