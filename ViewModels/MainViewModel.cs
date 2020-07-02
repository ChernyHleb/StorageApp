using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _selectedViewModel;

        public ViewModelBase SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(_selectedViewModel));
            }
        }

        public System.Windows.Input.ICommand UpdateViewCommand { get; set; }

        public MainViewModel()
        {
            UpdateViewCommand = new Commands.UpdateViewCommand(this);
        }

    }
}
