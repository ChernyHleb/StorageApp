using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreApp.ViewModels;

namespace StoreApp.Commands
{
    class UpdateViewCommand : System.Windows.Input.ICommand
    {
        public event EventHandler CanExecuteChanged;

        private ViewModels.MainViewModel viewModel;

        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter.ToString() == "AsseptedItems")
            {
                viewModel.SelectedViewModel = new AsseptedItemsViewModel();
            }
            else if(parameter.ToString() == "StorageItems")
            {
                viewModel.SelectedViewModel = new StorageItemsViewModel();
            }
              
        }
    }
}
