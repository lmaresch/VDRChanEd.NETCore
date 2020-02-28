using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace VDRChanEd.NETCore
{
    public class MainViewModel : Notifier
    {
        #region Private Variables
        private ICommand openCommand;
        private ICommand saveCommand;
        #endregion Private Variables

        #region Constrcutors
        public MainViewModel()
        {

        }
        #endregion Constructors

        #region Public Properties
        public ICommand OpenCommand
        {
            get { return this.openCommand; }
            set { this.SetField(ref this.openCommand, value); }
        }

        public ICommand SaveCommand
        {
            get { return this.saveCommand; }
            set { this.SetField(ref this.saveCommand, value); }
        }
        #endregion Public Properties
    }
}
