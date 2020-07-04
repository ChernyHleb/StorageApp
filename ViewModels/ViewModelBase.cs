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
using System.Windows.Input;

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

        public ICommand FilterGridCommand { get; set; }

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
        private Services.GenericCRUD<DbModel.Storage> StoragesCRUD;
        private Services.GenericCRUD<DbModel.Category> CategoriesCRUD;

        private List<DbModel.Item> _items;
        public List<DbModel.Item> Items
        {
            get { return _items; }
            set { _items = value; OnPropertyChanged("Items"); }
        }

        private List<DbModel.Storage> _storages;
        public List<DbModel.Storage> Storages
        {
            get { return _storages; }
            set { _storages = value; OnPropertyChanged("Storages"); }
        }

        private List<DbModel.Category> _categories;
        public List<DbModel.Category> Categories
        {
            get { return _categories; }
            set { _categories = value; OnPropertyChanged("Categories"); }
        }
        

        public ViewModelBase()
        {
            using (var context = new DbModel.CodeFirstContext())
            {
                FilterGridCommand = new Commands.FilterGridCommand(this);

                ItemsCRUD = new Services.GenericCRUD<DbModel.Item>(context);
                this.Items = ItemsCRUD.Read();

                CategoriesCRUD = new Services.GenericCRUD<DbModel.Category>(context);
                this.Categories = CategoriesCRUD.Read();

                StoragesCRUD = new Services.GenericCRUD<DbModel.Storage>(context);
                this.Storages = StoragesCRUD.Read();

                //Items.ForEach(i => Console.WriteLine(i.Title));
                //Categories.ForEach(i => Console.WriteLine(i.Name));
                //Storages.ForEach(i => Console.WriteLine(i.Name));
            }
        }
    }
}
