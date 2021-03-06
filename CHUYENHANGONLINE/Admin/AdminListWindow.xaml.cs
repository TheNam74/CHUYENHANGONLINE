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

namespace CHUYENHANGONLINE.Admin
{
    /// <summary>
    /// Interaction logic for AdminListWindow.xaml
    /// </summary>
    public partial class AdminListWindow : Window
    {
        private BindingList<Staff.Staff> _adminList;
        public AdminListWindow(BindingList<Staff.Staff> adminList)
        {
            _adminList = adminList;
            InitializeComponent();
        }

        private void AdminListWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            AdminListView.Items.Clear();
            AdminListView.ItemsSource = _adminList;
        }

        private void LockMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var admin = AdminListView.SelectedItem as Staff.Staff;
            using (SqlCommand cmd = new SqlCommand("USP_KHOATAIKHOAN", MainWindow.sqlCon))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MATK", SqlDbType.VarChar).Value = admin.LoginId;
                cmd.ExecuteNonQuery();
            }

            admin.Status = false;
        }

        private void UnlockMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var admin = AdminListView.SelectedItem as Staff.Staff;
            using (SqlCommand cmd = new SqlCommand("USP_MOKHOATAIKHOAN", MainWindow.sqlCon))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MATK", SqlDbType.VarChar).Value = admin.LoginId;
                cmd.ExecuteNonQuery();
            }
            admin.Status = true;
        }
    }
}
