using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace CHUYENHANGONLINE.Provider
{
    /// <summary>
    /// Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        private Branch _branch;
        public AddProductWindow(Branch inputBranch)
        {
            _branch = inputBranch;
            InitializeComponent();
        }

        private void AddProductWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            ProviderId.Text = _branch.ProviderID.ToString();
            BranchId.Text = _branch.BranchID.ToString();
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            //Lấy thông tin từ các textbox trên màn hình thêm sản phẩm
            string TENSANPHAM = NewProName.Text;
            string THONGTIN = NewProInfo.Text;
            float DONGIA = (float)Convert.ToDouble(NewProPrice.Text);
            string DONVITINH = NewProUnit.Text;
            int SOLUONG = Convert.ToInt32(NewProName.Text);

            //create query for stored procedure
            SqlCommand sqlCmd = new SqlCommand($"USP_THEMSANPHAM_DOITAC", MainWindow.sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;

            //create parameter 
            sqlCmd.Parameters.Add(new SqlParameter("@MADT", _branch.ProviderID));
            sqlCmd.Parameters.Add(new SqlParameter("@MACN", _branch.BranchID));
            sqlCmd.Parameters.Add(new SqlParameter("@TENSANPHAM", TENSANPHAM));
            sqlCmd.Parameters.Add(new SqlParameter("@THONGTIN", THONGTIN));
            sqlCmd.Parameters.Add(new SqlParameter("@DONGIA", DONGIA));
            sqlCmd.Parameters.Add(new SqlParameter("@DONVITINH", DONVITINH));
            sqlCmd.Parameters.Add(new SqlParameter("SOLUONG", SOLUONG));

            //execute query
            int ret = sqlCmd.ExecuteNonQuery();

            MessageBox.Show(ret != -1 ? $"Thêm sản phẩm thành công({ret})" : "Thêm sản phẩm thất bại");
        }
    }
}
