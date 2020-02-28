using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace VDRChanEd.NETCore
{
    public class RelayCommand<T> : ICommand
    {
        #region Private Readonly Variables
        private readonly Predicate<T> canExecute;
        private readonly Action<T> execute;
        #endregion Private Readonly Variables

        #region Constructors
        public RelayCommand(Action<T> execute) : this(execute, null)
        {
            this.execute = execute;
        }

        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            this.execute = execute ?? throw new ArgumentNullException("execute");
            this.canExecute = canExecute;
        }
        #endregion Constructors

        #region Public Events
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        #endregion Public Events

        #region Public Methods
        public bool CanExecute(object parameter) => this.canExecute == null || this.canExecute((T)parameter);
        public void Execute(object parameter) => this.execute((T) parameter);
        #endregion Public Methods
    }

    public class RelayCommand : ICommand
    {
        #region Private Readonly Variables
        private readonly Predicate<object> canExecute;
        private readonly Action<object> execute;
        #endregion Private Readonly Variables

        #region Constructors
        public RelayCommand(Action<object> execute) : this(execute, null)
        {
            this.execute = execute;
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            this.execute = execute ?? throw new ArgumentNullException("execute");
            this.canExecute = canExecute;
        }
        #endregion Constructors

        #region Public Events
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
        #endregion Public Events

        #region Public Methods
        public bool CanExecute(object parameter) => this.canExecute == null || this.canExecute(parameter);
        public void Execute(object parameter) => this.execute(parameter);
        #endregion Public Methods
    }
}
