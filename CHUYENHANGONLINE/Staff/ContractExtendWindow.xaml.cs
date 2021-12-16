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

namespace CHUYENHANGONLINE.Staff
{
    /// <summary>
    /// Interaction logic for ContractExtendWindow.xaml
    /// </summary>
    public partial class ContractExtendWindow : Window
    {
        private Provider.Provider _provider;
        public ContractExtendWindow(Provider.Provider provider)
        {
            this._provider = provider;
            InitializeComponent();
        }

        private void ContractExtendWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            ProviderNameLabel.Content = _provider.Name;
            DatePicker.SelectedDate = _provider.ContractDate;   


        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (_provider.ContractDate != DatePicker.SelectedDate)
            {
                _provider.ContractDate = DatePicker.SelectedDate;

                using (SqlCommand cmd = new SqlCommand("USP_GIAHANHOPDONG_DOITAC", MainWindow.sqlCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@maDoiTac", SqlDbType.VarChar).Value = _provider.Id;
                    cmd.Parameters.Add("@ngayGiaHan", SqlDbType.VarChar).Value = _provider.ContractDate;
                    cmd.ExecuteNonQuery();
                }
            }
            Close();
        }
    }
}
