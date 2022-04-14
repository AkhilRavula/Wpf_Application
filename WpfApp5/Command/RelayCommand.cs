using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp5.Command
{
    public class RelayCommand : ICommand
    {


        Action<object> _execute;
        Func<object, bool> _canExecute;
        bool _canExecuteCache;


        public RelayCommand(Action<object> execute, Func<object, bool> canExecute,bool canExecuteCache)
        {
            this._execute = execute;
            this._canExecute = canExecute;
            this._canExecuteCache = canExecuteCache;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            { 
                CommandManager.RequerySuggested -= value;
            }
        }


        public bool CanExecute(object parameter)
        {
            if(_canExecute==null)
            {
                return true;
            }
            else
            {
                return _canExecute(parameter);

            }
            
        }

        public void Execute(object parameter)
        {            
            _execute(parameter);
        }
    }
}
