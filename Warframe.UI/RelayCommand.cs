using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Warframe.UI
{
    class RelayCommand : ICommand
    {
        Func<object, bool> _canExecute;
        Action<object> _execute;

        public RelayCommand(Action execute)
            : this((o) => execute(), (o) => true)
        {
        }

        public RelayCommand(Action<object> execute)
            : this(o => execute(o), o => true)
        {

        }

        public RelayCommand(Action execute, Func<bool> canExecute)
            : this(o => execute(), o => canExecute())
        {

        }

        public RelayCommand(Action execute, Func<object, bool> canExecute)
            : this(o => execute(), o => canExecute(o))
        {

        }

        public RelayCommand(Action<object> execute, Func<bool> canExecute)
            : this(o => execute(o), o => canExecute())
        {

        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
