using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using StoreApp.ViewModels;

namespace StoreApp.Commands
{
    class SpawnWindowCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private ViewModels.ViewModelBase VM;

        public SpawnWindowCommand(ViewModelBase vM)
        {
            VM = vM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter.ToString() == "InsertItemPage")
            {
                VM.childWindow = new Views.InsertItemPage(VM);
                VM.childWindow.ShowDialog();
            }
        }
    }
}
