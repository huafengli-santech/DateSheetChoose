using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Common.Base
{
    public class CommandBase : ICommand
    {
        private Func<object,bool> _canExecute;
        private Action<object> _execute;
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public CommandBase( Action<object> execute, Func<object, bool> canExecute = null)
        {
            _canExecute = canExecute;
            _execute = execute;
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);

        public void Execute(object parameter)=>_execute(parameter);
       
    }
}
