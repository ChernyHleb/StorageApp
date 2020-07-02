using System;
using System.Collections.Generic;
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
using System.Configuration;
using System.Data;


namespace StoreApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //using (var context = new DbModel.CodeFirstContext())
            //{ }

            InitializeComponent();

            DataContext = new StoreApp.ViewModels.MainViewModel();
            //BindDataGrid();
        }

        //private void BindDataGrid()
        //{
        //    SqlConnection connection = new SqlConnection();
        //    connection.ConnectionString = ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;
        //    connection.Open();

        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = "select * from [Items]";
        //    cmd.Connection = connection;

        //    SqlDataAdapter TempDataAdapter = new SqlDataAdapter();

        //    DataTable dt = new DataTable("Items");
        //    TempDataAdapter.SelectCommand = cmd;
        //    TempDataAdapter.Fill(dt);

        //    grid1.ItemsSource = dt.DefaultView;
        //}
    }
}
