// ViewModels/RelayCommand.cs
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CRMApp.ViewModels
{
    public class RelayCommand : ICommand
    {
        private readonly Func<Task> _asyncExecute;
        private readonly Action _syncExecute;
        private readonly Func<bool> _canExecute;
        private bool _isExecuting;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _syncExecute = execute;
            _canExecute = canExecute;
        }

        public RelayCommand(Func<Task> asyncExecute, Func<bool> canExecute = null)
        {
            _asyncExecute = asyncExecute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return !_isExecuting && (_canExecute == null || _canExecute());
        }

        public async void Execute(object parameter)
        {
            _isExecuting = true;
            CommandManager.InvalidateRequerySuggested();

            try
            {
                if (_asyncExecute != null)
                {
                    await _asyncExecute();
                }
                else
                {
                    _syncExecute?.Invoke();
                }
            }
            finally
            {
                _isExecuting = false;
                CommandManager.InvalidateRequerySuggested();
            }
        }
    }
}