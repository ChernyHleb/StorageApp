using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StoreApp.Commands
{
    class FilterGridCommand : ICommand
    {
        public FilterGridCommand(ViewModels.ViewModelBase VM)
        {
            _VM = VM;
        }

        private ViewModels.ViewModelBase _VM;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            List<DbModel.Item> Items;

            using (var context = new DbModel.CodeFirstContext())
            {
                Services.GenericCRUD<DbModel.Item> ItemsCRUD = new Services.GenericCRUD<DbModel.Item>(context);
                Items = ItemsCRUD.Read();

                Console.WriteLine($"{ parameter}");

                if (parameter.ToString() == "All")
                {
                    _VM.Items = Items;
                }
                else if (parameter.ToString() == "Assepted")
                {
                    _VM.Items = (Items.Where(item => item.Category.Name == "Assepted")).ToList<DbModel.Item>();
                }
                else if (parameter.ToString() == "OnStore")
                {
                    _VM.Items = (Items.Where(item => item.Category.Name == "OnStore")).ToList<DbModel.Item>();
                }
                else if (parameter.ToString() == "Sold")
                {
                    _VM.Items = (Items.Where(item => item.Category.Name == "Sold")).ToList<DbModel.Item>();
                }
                else if (parameter.ToString() == "DatePeriod")
                {
                    
                }
            }
        }
    }
}
