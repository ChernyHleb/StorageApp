using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StoreApp.Commands
{
    class ComplexCommand : ICommand
    {
        public ComplexCommand(params ICommand[] commands)
        {
            _commands = commands;
        }

        private ICommand[] _commands;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }


        public void Execute(object parameter)
        {
            string[] p = parameter.ToString().Split(' ');
            
            for (int i = 0; i < _commands.Count(); i++)
            {
                _commands[i].Execute(p[i]);
            }
        }
    }
}
