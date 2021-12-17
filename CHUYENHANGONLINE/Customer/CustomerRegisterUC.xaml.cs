using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace CHUYENHANGONLINE.Customer
{
    /// <summary>
    /// Interaction logic for CustomerRegisterUC.xaml
    /// </summary>
    public partial class CustomerRegisterUC : UserControl
    {
        public CustomerRegisterUC()
        {
            InitializeComponent();
        }

        private void BtnRegister_OnClick(object sender, RoutedEventArgs e)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "USP_THEMDONHANG_KHACHHANG";
            sqlCmd.Connection = MainWindow.sqlCon;
        }
    }
}
