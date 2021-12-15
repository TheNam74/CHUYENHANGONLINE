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
using Microsoft.Win32;

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

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string actor = (string) (ActorComboBox.SelectedItem as ComboBoxItem).Content;
            UserControl RegisterUC;
            switch (actor)
            {
                case "Khách hàng":
                    RegisterUC = new Customer.CustomerRegisterUC();
                    RegisterContentControl.Content= RegisterUC;
                    this.Height = 300 + RegisterUC.Height;
                    break;
                case "Tài xế":
                    RegisterUC = new Shipper.ShipperRegisterUC();
                    RegisterContentControl.Content = RegisterUC;
                    this.Height = 300 + RegisterUC.Height;
                    break;
                case "Đối tác":
                    RegisterUC = new Provider.ProviderRegisterUC();
                    RegisterContentControl.Content = RegisterUC;
                    this.Height = 300 + RegisterUC.Height;
                    break;

            }

            





        }
    }
}
