using System;
using System.Data;
using System.Data.SqlClient;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Windows;

using CHUYENHANGONLINE.Admin;
using CHUYENHANGONLINE.Provider;
using CHUYENHANGONLINE.Shipper;
using CHUYENHANGONLINE.Staff;


namespace CHUYENHANGONLINE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string ServerName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        string strCon = 
                @"Data Source=DESKTOP-IF5CCEF\PC1;Initial Catalog = QL_CHUYENHANGONLINE; Integrated Security = True";
        public static SqlConnection sqlCon = null; //cho tất cả window khác xài ké
        public static string Actor;
        public static IUser User;
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
                    this.Content = new StaffHomePageUC();
                    break;
                case "deliver":
                    this.Content = new ShipperHomePageUC();
                    break;
                case "admin":
                    this.Content = new AdminHomePageUC();
                    break;
                case "customer":
                    this.Content = new Customer.CustomerHomePageUC();
                    break;
                case "provider":
                    this.Content = new ProviderHomePageUC();
                    break;
            }
        }
    }
}
         