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

namespace CHUYENHANGONLINE
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var userName = UsernameTextBox.Text;
            var pass = PasswordBox.Password; 
            var query = $"select * from taikhoan t where t.TENDANGNHAP='{userName}' and t.MATKHAU = '{pass}'";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = query;
            sqlCmd.Connection = MainWindow.sqlCon;
            SqlDataReader reader = sqlCmd.ExecuteReader();
            if (reader.Read())
            {
                MainWindow.Actor = reader.GetString(4);
                this.DialogResult = true;
                this.Close();

            }
            else
            {
                reader.Close();
            }
        }
    }
}
