using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for EditProductWindow.xaml
    /// </summary>
    public partial class EditProductWindow : Window
    {
        BindingList<Product> _productList = new BindingList<Product>();
        private Product _product;
        int SelectedIndex;
        public EditProductWindow(Product inputProduct)
        {
            _product = inputProduct;

            InitializeComponent();
        }
        private void EditProductWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            NewProAmount.Text = _product.ProAmount.ToString();
            NewProName.Text = _product.ProName;
            NewProInfo.Text = _product.ProInfo;
            NewProPrice.Text = _product.ProPrice.ToString();
            NewProUnit.Text = _product.ProUnit;
            BranchId.Text =_product.BranchID.ToString();
            ProId.Text =_product.ProID.ToString();
            ProviderId.Text =_product.ProviderID.ToString();
            this.DataContext = _product;
        }
        private void ApplyChange_Click(object sender, RoutedEventArgs e)
        {
            //create query for stored procedure
            SqlCommand sqlCmd = new SqlCommand($"USP_SUASANPHAM_DOITAC", MainWindow.sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;

            //create parameter 
            sqlCmd.Parameters.Add(new SqlParameter("@MADT", _product.ProviderID));
            sqlCmd.Parameters.Add(new SqlParameter("@MACN", _product.BranchID));
            sqlCmd.Parameters.Add(new SqlParameter("@MASP", _product.ProID));
            sqlCmd.Parameters.Add(new SqlParameter("@TENSANPHAM", NewProName.Text));
            sqlCmd.Parameters.Add(new SqlParameter("@THONGTIN", NewProInfo.Text));
            sqlCmd.Parameters.Add(new SqlParameter("@DONGIA", (float)Convert.ToDouble(NewProPrice.Text)));
            sqlCmd.Parameters.Add(new SqlParameter("@DONVITINH", NewProUnit.Text));
            sqlCmd.Parameters.Add(new SqlParameter("SOLUONG", Convert.ToInt32(NewProAmount.Text)));

            //execute query
            int ret = sqlCmd.ExecuteNonQuery();

            MessageBox.Show(ret != -1 ? $"Cập nhật thành công({ret})" : "Cập nhật thất bại");
            //Cập nhật lại địa chỉ mới trên listview
            _product.ProName = NewProName.Text;
            _product.ProInfo = NewProInfo.Text;
            _product.ProPrice = (float)Convert.ToDouble(NewProPrice.Text);
            _product.ProUnit = NewProUnit.Text;
            _product.ProAmount = Convert.ToInt32(NewProAmount.Text);

        }

    }
}
