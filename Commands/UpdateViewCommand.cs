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
                viewModel.SelectedViewModel.FilterGridCommand.Execute("Assepted");
            }
            else if(parameter.ToString() == "StorageItems")
            {
                viewModel.SelectedViewModel = new StorageItemsViewModel();
                viewModel.SelectedViewModel.FilterGridCommand.Execute("OnStore");
            }
            else if(parameter.ToString() == "Report")
            {
                viewModel.SelectedViewModel = new ReportViewModel();
                viewModel.SelectedViewModel.FilterGridCommand.Execute("All");
            }
            else if(parameter.ToString() == "SoldItems")
            {
                viewModel.SelectedViewModel = new SoldItemsViewModel();
                viewModel.SelectedViewModel.FilterGridCommand.Execute("Sold");
            }
        }
    }
}
