using System;
using System.Collections.Generic;
using System.Data;
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
using System.Data.SqlClient;


namespace CHUYENHANGONLINE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string strCon =
            @"Data Source=112.78.2.94;Initial Catalog=webt2289_QL_CHUYENHANGONLINE;Persist Security Info=True;User ID=webt2289_tung;Password=zg4B7*6x;";
        public static SqlConnection sqlCon = null; //cho tất cả window khác xài ké
        public static string Actor;
        public MainWindow()
        {
            
            InitializeComponent();
            try
            {
                //C# bảo chỗ này sqlCon==null always true nên k cần if
                sqlCon = new SqlConnection(strCon);
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                    var loginWindow = new LoginWindow();
                    loginWindow.ShowDialog();
                    if (loginWindow.DialogResult != true)
                    {
                       this.Close();//Chưa đăng nhập thành công
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;//Ngắt app luôn
            }
        }

        //đóng main window thì ngắt kết nối
        private void MainWindow_OnClosed(object? sender, EventArgs e)
        {
            if (sqlCon != null && sqlCon.State == ConnectionState.Open)
            {
                sqlCon.Close();
            }
            
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            switch (Actor)
            {
                case "staff":
                    this.Content = new Staff.StaffHomePageUC();
                    break;

            }
        }
    }
}
