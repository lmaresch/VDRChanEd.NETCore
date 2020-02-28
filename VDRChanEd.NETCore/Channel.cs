using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VDRChanEd.NETCore
{
    public class Channel : Notifier
    {
        #region Private Members
        private NameField nameField;
        private ParametersField parametersField;
        private int frequency;
        private Sources source;
        private int symbolRate;
        private VideoField vpidField;
        private short audioPID1;
        private string audioPID1Lang;
        private Nullable<short> audioPID2;
        private string audioPID2Lang;
        private Nullable<short> dolbyPID1;
        private string dolbyPID1Lang;
        private Nullable<short> dolbyPID2;
        private string dolbyPID2Lang;
        private short teletexPID1;
        private string teletexPID1Lang;
        private Nullable<short> teletextPID2;
        private string teletextPID2Lang;
        private ushort conditionalAccess;
        private ushort serviceID;
        private ushort networkID;
        private ushort transportStreamID;
        private ushort radioID;
        #endregion Private Members

        #region Constructors
        public Channel()
        {
            this.nameField = new NameField();
            this.parametersField = new ParametersField();
            this.frequency = 0;
            this.source = Sources.S360E;
            this.symbolRate = 0;
            this.vpidField = new VideoField(); ;
            this.audioPID1 = 0;
            this.AudioPID1Lang = string.Empty;
            this.teletexPID1 = 0;
            this.conditionalAccess = 0;
            this.serviceID = 0;
            this.networkID = 0;
            this.transportStreamID = 0;
            this.radioID = 0;
        }
        #endregion Constructors

        #region Public Properties
        public NameField NameField
        {
            get => this.nameField;
            set => this.SetField(ref this.nameField, value);
        }
        public ParametersField ParametersField
        {
            get => this.parametersField;
            set => this.SetField(ref this.parametersField, value);
        }

        public int Frequency
        {
            get => this.frequency;
            set => this.SetField(ref this.frequency, value);
        }

        public Sources Source
        {
            get => this.source;
            set => this.SetField(ref this.source, value);
        }

        public int SymbolRate
        {
            get => this.symbolRate;
            set => this.SetField(ref this.symbolRate, value);
        }

        public VideoField VPIDField
        {
            get => this.vpidField;
            set => this.SetField(ref this.vpidField, value);
        }

        public short AudioPID1
        {
            get => this.audioPID1;
            set => this.SetField(ref this.audioPID1, value);
        }

        public string AudioPID1Lang
        {
            get => this.audioPID1Lang;
            set => this.SetField(ref this.audioPID1Lang, value);
        }

        public Nullable<short> AudioPID2
        {
            get => this.audioPID2;
            set => this.SetField(ref this.audioPID2, value);
        }

        public string AudioPID2Lang
        {
            get => this.audioPID2Lang;
            set => this.SetField(ref this.audioPID2Lang, value);
        }

        public Nullable<short> DolbyPID1
        {
            get => this.dolbyPID1;
            set => this.SetField(ref this.dolbyPID1, value);
        }

        public string DolbyPID1Lang
        {
            get => this.dolbyPID1Lang;
            set => this.SetField(ref this.dolbyPID1Lang, value);
        }

        public Nullable<short> DolbyPID2
        {
            get => this.dolbyPID2;
            set => this.SetField(ref this.dolbyPID2, value);
        }

        public string DolbyPID2Lang
        {
            get => this.dolbyPID2Lang;
            set => this.SetField(ref this.dolbyPID2Lang, value);
        }

        public short TeletexPID1
        {
            get => this.teletexPID1;
            set => this.SetField(ref this.teletexPID1, value);
        }

        public string TeletexPID1Lang
        {
            get => this.teletexPID1Lang;
            set => this.SetField(ref this.teletexPID1Lang, value);
        }

        public Nullable<short> TeletextPID2
        {
            get => this.teletextPID2;
            set => this.SetField(ref this.teletextPID2, value);
        }

        public string TeletextPID2Lang
        {
            get => this.teletextPID2Lang;
            set => this.SetField(ref this.teletextPID2Lang, value);
        }

        public ushort ConditionalAccess
        {
            get => this.conditionalAccess;
            set => this.SetField(ref this.conditionalAccess, value);
        }

        public ushort ServiceID
        {
            get => this.serviceID;
            set => this.SetField(ref this.serviceID, value);
        }

        public ushort NetworkID
        {
            get => this.networkID;
            set => this.SetField(ref this.networkID, value);
        }

        public ushort TransportStreamID
        {
            get => this.transportStreamID;
            set => this.SetField(ref this.transportStreamID, value);
        }

        public ushort RadioID
        {
            get => this.radioID;
            set => this.SetField(ref this.radioID, value);
        }
        #endregion Public Properties

        #region Public Methods
        public void EvaluateLine(string line)
        {

        }
        #endregion Public Methods
    }
}
