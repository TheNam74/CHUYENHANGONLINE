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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CHUYENHANGONLINE.Shipper
{
    /// <summary>
    /// Interaction logic for ShipperRegisterUC.xaml
    /// </summary>
    public partial class ShipperRegisterUC : UserControl
    {
        public ShipperRegisterUC()
        {
            InitializeComponent();
        }

        public void ExecuteQuery(string query, string commandType, ref SqlDataReader reader, List<SqlParameter> parameters = null)
        {
            //create query 
            SqlCommand sqlCmd = new SqlCommand();
            if (commandType == "storedProc")
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
            }
            else if (commandType == "query")
            {
                sqlCmd.CommandType = CommandType.Text;
            }

            sqlCmd.CommandText = query;

            //create parameter 
            //add parameter to stored procedure
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    sqlCmd.Parameters.Add(param);
                }
            }

            //connection to database
            sqlCmd.Connection = MainWindow.sqlCon;

            //execute query
            reader = sqlCmd.ExecuteReader();
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            SqlDataReader reader = null;
            //Cập nhật mã tài xế vào ddonw hàng
            string storedProc = $"usp_insert_taikhoantaixe";

            SqlParameter param = new SqlParameter("@tendangnhap", SqlDbType.NVarChar);
            SqlParameter param2 = new SqlParameter("@matkhau", SqlDbType.NVarChar);
            SqlParameter param3 = new SqlParameter("@hoten", SqlDbType.NVarChar);
            SqlParameter param4 = new SqlParameter("@email", SqlDbType.VarChar);
            SqlParameter param5 = new SqlParameter("@sdt", SqlDbType.VarChar);
            SqlParameter param6 = new SqlParameter("@diachi", SqlDbType.NVarChar);
            SqlParameter param7 = new SqlParameter("@bienso", SqlDbType.VarChar);
            SqlParameter param8 = new SqlParameter("@tknh", SqlDbType.VarChar);
            SqlParameter param9 = new SqlParameter("@cmnd", SqlDbType.VarChar);
            SqlParameter param10 = new SqlParameter("@khuvuc", SqlDbType.NVarChar);

            param.Value = UserName.Text;
            param2.Value = Password.Text;
            param3.Value = Name.Text;
            param4.Value = Email.Text;
            param5.Value = Phone.Text;
            param6.Value = Address.Text;
            param7.Value = VRP.Text;
            param8.Value = BankAccount.Text;
            param9.Value = CitizenId.Text;
            param10.Value = Area.Text;

            if(UserName.Text == "" || Password.Text =="" || Name.Text =="" || Email.Text==""||
                Phone.Text == "" || Address.Text == "" || VRP.Text == "" || BankAccount.Text == "" || CitizenId.Text == "" || Area.Text == "")
            {
                MessageBox.Show("Các thông tin cần được nhập đầy đủ để thực hiện đăng kí");
            }
            else
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(param);
                parameters.Add(param2);
                parameters.Add(param3);
                parameters.Add(param4);
                parameters.Add(param5);
                parameters.Add(param6);
                parameters.Add(param7);
                parameters.Add(param8);
                parameters.Add(param9);
                parameters.Add(param10);

                ExecuteQuery(storedProc, "storedProc", ref reader, parameters);

                int checkError = 0;
                if (reader.Read())
                {
                    checkError = reader.GetInt32(0);
                }

                if (checkError == -1)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại");
                }
                else
                {
                    MessageBox.Show("Đăng kí thành công");
                }
                reader.Close();
            }
        }
    }
}
