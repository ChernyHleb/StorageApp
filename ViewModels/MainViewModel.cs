using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        /// This ViewModel contains general application
        /// Controls navigation between other viewmodels
         
        private ViewModelBase _selectedViewModel;

        public ViewModelBase SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public System.Windows.Input.ICommand UpdateViewCommand { get; set; }
        public System.Windows.Input.ICommand ComplexCommand { get; set; }

        public MainViewModel()
        {
            SelectedViewModel = new ReportViewModel();
            UpdateViewCommand = new Commands.UpdateViewCommand(this);

            ComplexCommand = new Commands.ComplexCommand(UpdateViewCommand, FilterGridCommand);
        }

    }
}
