using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VDRChanEd.NETCore
{
    public class ChannelGroup : Notifier
    {
        #region Private Variables
        private int startChannel;
        private string groupName;
        #endregion

        #region Constructors
        public ChannelGroup()
        {
            this.startChannel = 0;
            this.groupName = string.Empty;
        }
        #endregion Constructors

        #region Public Properties
        public int StartChannel
        {
            get => this.startChannel;
            set => this.SetField(ref this.startChannel, value);
        }

        public string GroupName
        {
            get => this.groupName;
            set => this.SetField(ref this.groupName, value);
        }
        #endregion Public Properties
    }
}
