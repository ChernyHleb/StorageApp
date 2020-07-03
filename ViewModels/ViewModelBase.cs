using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Controls;

namespace StoreApp.ViewModels
{ 
    /// Parent class for all ViewModels
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //protected void BindDataGrid(DataGrid grid, string SQLcmd)
        //{
        //    SqlConnection connection = new SqlConnection();
        //    connection.ConnectionString = ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;
        //    connection.Open();

        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = SQLcmd;
        //    cmd.Connection = connection;

        //    SqlDataAdapter TempDataAdapter = new SqlDataAdapter();

        //    DataTable dt = new DataTable("Items");
        //    TempDataAdapter.SelectCommand = cmd;
        //    TempDataAdapter.Fill(dt);

        //    grid.ItemsSource = dt.DefaultView;
        //}

        private Services.GenericCRUD<DbModel.Item> ItemsCRUD;

        public List<DbModel.Item> Items { get; set; }

        public ViewModelBase()
        {
            using (var context = new DbModel.CodeFirstContext())
            {
                ItemsCRUD = new Services.GenericCRUD<DbModel.Item>(context);
                this.Items = ItemsCRUD.Read();

                //Items.ForEach(i => Console.WriteLine(i.Title));
            }
        }
    }
}
