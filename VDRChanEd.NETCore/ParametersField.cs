using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VDRChanEd.NETCore
{
    public class ParametersField : Notifier
    {
        #region Private Members
        private Nullable<BandwidthValues> bandwidth;
        private Nullable<CoderateValues> codeRateHighPriority;
        private Nullable<CoderateValues> codeRateLowPriority;
        private Nullable<GuardIntervals> guardInterval;
        private Nullable<Polarizations> polarization;
        private Nullable<Modulations> modulation;
        private Nullable<PilotModes> pilotMode;
        private Nullable<Rolloffs> rolloff;
        private Nullable<short> inversion;
        private Nullable<short> streamId;
        private Nullable<int> t2SystemId;
        private Nullable<TransmissionModes> transmissionMode;
        private Nullable<SISO_MISO_Modes> sm_mode;
        private Nullable<Hierarchies> hierarchy;
        private Nullable<DeliverySystems> deliverySystem;
        private ChannelSources channelSource;
        #endregion Private Members

        #region Constructors
        public ParametersField()
        {

        }

        public ParametersField(ChannelSources channelSource) : this()
        {
            this.ChannelSource = channelSource;
        }

        public ParametersField(string parameters) : this()
        {
            this.EvaluateParameters(parameters);
        }
        #endregion Constructors

        #region Public Properties
        public ChannelSources ChannelSource
        {
            get => this.channelSource;
            set => this.SetField(ref this.channelSource, value);
        }

        public Nullable<BandwidthValues> Bandwidth
        {
            get => this.bandwidth;
            set => this.SetField(ref this.bandwidth, value);
        }

        public bool BandwidthEnabled
        {
            get => (this.ChannelSource & ChannelSources.CHANNEL_SOURCE_DVBT) == ChannelSources.CHANNEL_SOURCE_DVBT || 
                   (this.ChannelSource & ChannelSources.CHANNEL_SOURCE_DVBT2) == ChannelSources.CHANNEL_SOURCE_DVBT2;
        }

        public Nullable<CoderateValues> CodeRateHighPriority
        {
            get => this.codeRateHighPriority;
            set => this.SetField(ref this.codeRateHighPriority, value);
        }

        public bool CodeRateHighPriorityEnabled
        {
            get => (this.ChannelSource & ChannelSources.CHANNEL_SOURCE_DVBC) == ChannelSources.CHANNEL_SOURCE_DVBC ||
                   (this.ChannelSource & ChannelSources.CHANNEL_SOURCE_DVBS) == ChannelSources.CHANNEL_SOURCE_DVBS ||
                   (this.ChannelSource & ChannelSources.CHANNEL_SOURCE_DVBS2) == ChannelSources.CHANNEL_SOURCE_DVBS2 ||
                   (this.ChannelSource & ChannelSources.CHANNEL_SOURCE_DVBT) == ChannelSources.CHANNEL_SOURCE_DVBT ||
                   (this.ChannelSource & ChannelSources.CHANNEL_SOURCE_DVBT2) == ChannelSources.CHANNEL_SOURCE_DVBT2;
        }

        public Nullable<CoderateValues> CodeRateLowPriority
        {
            get => this.codeRateLowPriority;
            set => this.SetField(ref this.codeRateLowPriority, value);
        }

        public bool CodeRateLowPriorityEnabled
        {
            get => (this.ChannelSource & ChannelSources.CHANNEL_SOURCE_DVBT) == ChannelSources.CHANNEL_SOURCE_DVBT ||
                   (this.ChannelSource & ChannelSources.CHANNEL_SOURCE_DVBT2) == ChannelSources.CHANNEL_SOURCE_DVBT2;
        }

        public Nullable<GuardIntervals> GuardInterval
        {
            get => this.guardInterval;
            set => this.SetField(ref this.guardInterval, value);
        }

        public bool GuardIntervalEnabled
        {
            get => (this.ChannelSource & ChannelSources.CHANNEL_SOURCE_DVBT) == ChannelSources.CHANNEL_SOURCE_DVBT ||
                   (this.ChannelSource & ChannelSources.CHANNEL_SOURCE_DVBT2) == ChannelSources.CHANNEL_SOURCE_DVBT2;
        }

        public Nullable<Polarizations> Polarization
        {
            get => this.polarization;
            set => this.SetField(ref this.polarization, value);
        }

        public bool PolarizationEnabled
        {
            get => (this.ChannelSource & ChannelSources.CHANNEL_SOURCE_DVBS) == ChannelSources.CHANNEL_SOURCE_DVBS ||
                   (this.ChannelSource & ChannelSources.CHANNEL_SOURCE_DVBS2) == ChannelSources.CHANNEL_SOURCE_DVBS2;
        }

        public Nullable<Modulations> Modulation
        {
            get => this.modulation;
            set => this.SetField(ref this.modulation, value);
        }

        public bool ModulationEnabled
        {
            get => (this.ChannelSource & ChannelSources.CHANNEL_SOURCE_DVBC) == ChannelSources.CHANNEL_SOURCE_DVBC ||
                   (this.ChannelSource & ChannelSources.CHANNEL_SOURCE_DVBS) == ChannelSources.CHANNEL_SOURCE_DVBS ||
                   (this.ChannelSource & ChannelSources.CHANNEL_SOURCE_DVBS2) == ChannelSources.CHANNEL_SOURCE_DVBS2 ||
                   (this.ChannelSource & ChannelSources.CHANNEL_SOURCE_DVBT) == ChannelSources.CHANNEL_SOURCE_DVBT ||
                   (this.ChannelSource & ChannelSources.CHANNEL_SOURCE_DVBT2) == ChannelSources.CHANNEL_SOURCE_DVBT2 ||
                   (this.ChannelSource & ChannelSources.CHANNEL_SOURCE_ATSC) == ChannelSources.CHANNEL_SOURCE_ATSC;
        }

        public Nullable<short> Inversion
        {
            get => this.inversion;
            set => this.SetField(ref this.inversion, value);
        }

        public bool InversionEnabled
        {
            get => (this.ChannelSource & ChannelSources.CHANNEL_SOURCE_DVBC) == ChannelSources.CHANNEL_SOURCE_DVBC ||
                   (this.ChannelSource & ChannelSources.CHANNEL_SOURCE_DVBS) == ChannelSources.CHANNEL_SOURCE_DVBS ||
                   (this.ChannelSource & ChannelSources.CHANNEL_SOURCE_DVBS2) == ChannelSources.CHANNEL_SOURCE_DVBS2 ||
                   (this.ChannelSource & ChannelSources.CHANNEL_SOURCE_DVBT) == ChannelSources.CHANNEL_SOURCE_DVBT ||
                   (this.ChannelSource & ChannelSources.CHANNEL_SOURCE_DVBT2) == ChannelSources.CHANNEL_SOURCE_DVBT2 ||
                   (this.ChannelSource & ChannelSources.CHANNEL_SOURCE_ATSC) == ChannelSources.CHANNEL_SOURCE_ATSC;
        }

        public Nullable<PilotModes> PilotMode
        {
            get => this.pilotMode;
            set => this.SetField(ref this.pilotMode, value);
        }

        public bool PilotModeEnabled
        {
            get => (this.ChannelSource & ChannelSources.CHANNEL_SOURCE_DVBS2) == ChannelSources.CHANNEL_SOURCE_DVBS2;
        }

        public Nullable<Rolloffs> Rolloff
        {
            get => this.rolloff;
            set => this.SetField(ref this.rolloff, value);
        }

        public bool RollOffEnabled
        {
            get => (this.ChannelSource & ChannelSources.CHANNEL_SOURCE_DVBS) == ChannelSources.CHANNEL_SOURCE_DVBS ||
                   (this.ChannelSource & ChannelSources.CHANNEL_SOURCE_DVBS2) == ChannelSources.CHANNEL_SOURCE_DVBS2;
        }

        public Nullable<short> StreamId
        {
            get => this.streamId;
            set => this.SetField(ref this.streamId, value);
        }

        public bool StreamIdEnabled
        {
            get => (this.ChannelSource & ChannelSources.CHANNEL_SOURCE_DVBS2) == ChannelSources.CHANNEL_SOURCE_DVBS2 ||
                   (this.ChannelSource & ChannelSources.CHANNEL_SOURCE_DVBT2) == ChannelSources.CHANNEL_SOURCE_DVBT2;
        }

        public Nullable<int> T2SystemId
        {
            get => this.t2SystemId;
            set => this.SetField(ref this.t2SystemId, value);
        }

        public bool T2SystemIdEnabled
        {
            get => (this.ChannelSource & ChannelSources.CHANNEL_SOURCE_DVBT2) == ChannelSources.CHANNEL_SOURCE_DVBT2;
        }

        public Nullable<TransmissionModes> TransmissionMode
        {
            get => this.transmissionMode;
            set => this.SetField(ref this.transmissionMode, value);
        }

        public bool TransmissionModeEnabled
        {
            get => (this.ChannelSource & ChannelSources.CHANNEL_SOURCE_DVBT) == ChannelSources.CHANNEL_SOURCE_DVBT ||
                   (this.ChannelSource & ChannelSources.CHANNEL_SOURCE_DVBT2) == ChannelSources.CHANNEL_SOURCE_DVBT2;
        }

        public Nullable<SISO_MISO_Modes> SM_mode
        {
            get => this.sm_mode;
            set => this.SetField(ref this.sm_mode, value);
        }

        public bool SM_modeEnabled
        {
            get => (this.ChannelSource & ChannelSources.CHANNEL_SOURCE_DVBT2) == ChannelSources.CHANNEL_SOURCE_DVBT2;
        }

        public Nullable<Hierarchies> Hierarchy
        {
            get => this.hierarchy;
            set => this.SetField(ref this.hierarchy, value);
        }

        public bool HierarchyEnabled
        {
            get => (this.ChannelSource & ChannelSources.CHANNEL_SOURCE_DVBT) == ChannelSources.CHANNEL_SOURCE_DVBT ||
                   (this.ChannelSource & ChannelSources.CHANNEL_SOURCE_DVBT2) == ChannelSources.CHANNEL_SOURCE_DVBT2;
        }

        public Nullable<DeliverySystems> DeliverySystem
        {
            get => this.deliverySystem;
            set => this.SetField(ref this.deliverySystem, value);
        }

        public bool DeliverySystemEnabled
        {
            get => (this.ChannelSource & ChannelSources.CHANNEL_SOURCE_DVBS) == ChannelSources.CHANNEL_SOURCE_DVBS ||
                   (this.ChannelSource & ChannelSources.CHANNEL_SOURCE_DVBS2) == ChannelSources.CHANNEL_SOURCE_DVBS2 ||
                   (this.ChannelSource & ChannelSources.CHANNEL_SOURCE_DVBT) == ChannelSources.CHANNEL_SOURCE_DVBT ||
                   (this.ChannelSource & ChannelSources.CHANNEL_SOURCE_DVBT2) == ChannelSources.CHANNEL_SOURCE_DVBT2;

        }

        #endregion Public Properties

        #region Public Methods
        public List<string> SplitParameters(string parameters)
        {
            List<string> retVal = new List<string>();
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < parameters.Length; ++i)
            {
                if (parameters[i] >= 'A' && sb.Length > 0)
                {
                    retVal.Add(sb.ToString());
                    sb.Clear();
                }

                sb.Append(parameters[i]);
            }

            if (sb.Length > 0)
                retVal.Add(sb.ToString());
            return retVal;
        }
        public void EvaluateParameters(string parameters)
        {
            foreach(string part in this.SplitParameters(parameters))
            {
                char def = part[0];
                short val = -1;
                if (part.Length > 1 && !short.TryParse(part.Substring(1), out val))
                    val = -1;
                switch(part[0])
                {
                    case 'A':  // logical channel Number (0-1023)

                        break;
                    case 'B':  // Bandwidth(1712, 5, 6, 7, 8, 10)
                        this.Bandwidth = (BandwidthValues)val;
                        break;
                    case 'C':  // Code rate high priority(0, 12, 23, 34, 35, 45, 56, 67, 78, 89, 910)
                        this.CodeRateHighPriority = (CoderateValues)val;
                        break;
                    case 'D':  // coDe rate low priority(0, 12, 23, 34, 35, 45, 56, 67, 78, 89, 910)
                        this.CodeRateLowPriority = (CoderateValues)val;
                        break;
                    case 'G':  // Guard interval(4, 8, 16, 32, 128, 19128, 19256)
                        this.GuardInterval = (GuardIntervals)val;
                        break;
                    case 'H':  // Horizontal polarization
                        this.Polarization = Polarizations.H;
                        break;
                    case 'I':  // Inversion(0, 1)
                        this.Inversion = val;
                        break;
                    case 'L':  // Left circular polarization
                        this.Polarization = Polarizations.L;
                        break;
                    case 'M':  // Modulation(2, 5, 6, 7, 10, 11, 12, 16, 32, 64, 128, 256, 999)
                        this.Modulation = (Modulations)val;
                        break;
                    case 'N':  // pilot mode(0, 1, 999)
                        this.PilotMode = (PilotModes)val;
                        break;
                    case 'O':  // rollOff(0, 20, 25, 35)
                        this.Rolloff = (Rolloffs)val;
                        break;
                    case 'P':  // stream id(0 - 255)
                        this.StreamId = val;
                        break;
                    case 'Q':  // t2 system id(0 - 65535)
                        int intVal = -1;
                        if (part.Length > 1 && !int.TryParse(part.Substring(1), out intVal))
                            intVal = -1;
                        this.T2SystemId = (int)intVal;
                        break;
                    case 'R':  // Right circular polarization
                        this.Polarization = Polarizations.R;
                        break;
                    case 'S':  // delivery System(0, 1)
                        this.DeliverySystem = (DeliverySystems)val;
                        break;
                    case 'T':  // Transmission mode(1, 2, 4, 8, 16, 32)
                        this.TransmissionMode = (TransmissionModes)val;
                        break;
                    case 'V':  // Vertical polarization
                        this.Polarization = Polarizations.V;
                        break;
                    case 'X':  // siso / miso mode(0, 1)
                        this.SM_mode = (SISO_MISO_Modes)val;
                        break;
                    case 'Y':  // hierarchY(0, 1, 2, 4)'
                        this.Hierarchy = (Hierarchies)val;
                        break;
                }
            }
        }
        #endregion Public Mathods

        #region Public Override Methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (this.PolarizationEnabled && this.Polarization.HasValue)
                sb.Append(this.Polarization.Value);
            if (this.BandwidthEnabled && this.Bandwidth.HasValue)
                sb.Append("B" + (short)this.Bandwidth.Value);
            if (this.CodeRateHighPriorityEnabled && this.CodeRateHighPriority.HasValue && !this.CodeRateHighPriority.Value.Equals(CoderateValues.FEC_AUTO))
                sb.Append("C" + (short)this.CodeRateHighPriority.Value);
            if (this.CodeRateLowPriorityEnabled && this.CodeRateLowPriority.HasValue && !this.CodeRateLowPriority.Value.Equals(CoderateValues.FEC_AUTO))
                sb.Append("D" + (short)this.CodeRateLowPriority.Value);
            if (this.GuardIntervalEnabled && this.GuardInterval.HasValue && !this.GuardInterval.Value.Equals(GuardIntervals.GUARD_INTERVAL_AUTO))
                sb.Append("G" + (short)this.GuardInterval.Value);
            if (this.InversionEnabled && this.Inversion.HasValue)
                sb.Append("I" + (short)this.Inversion.Value);
            if (this.ModulationEnabled && this.Modulation.HasValue && !this.Modulation.Value.Equals(Modulations.QAM_AUTO))
                sb.Append("M" + (short)this.Modulation.Value);
            if (this.PilotModeEnabled && this.PilotMode.HasValue && !this.PilotMode.Value.Equals(PilotModes.PILOT_AUTO))
                sb.Append("N" + (short)this.PilotMode.Value);
            if (this.RollOffEnabled && this.Rolloff.HasValue && !this.Rolloff.Value.Equals(Rolloffs.ROLLOFF_AUTO))
                sb.Append("O" + (short)this.Rolloff.Value);
            if (this.StreamIdEnabled && this.StreamId.HasValue && this.StreamId.Value >= 0 && this.StreamId.Value < 256)
                sb.Append("P" + (ushort)this.StreamId.Value);
            if (this.T2SystemIdEnabled && this.T2SystemId.HasValue && this.T2SystemId.Value >= 0 && this.T2SystemId.Value < 65536)
                sb.Append("Q" + this.T2SystemId.Value);
            if (this.DeliverySystemEnabled && this.DeliverySystem.HasValue)
                sb.Append("S" + (short)this.DeliverySystem.Value);
            if (this.TransmissionModeEnabled && this.TransmissionMode.HasValue && !this.TransmissionMode.Value.Equals(TransmissionModes.TRANSMISSION_MODE_AUTO))
                sb.Append("T" + (short)this.TransmissionMode.Value);
            if (this.SM_modeEnabled && this.SM_mode.HasValue)
                sb.Append("X" + (short)this.SM_mode.Value);
            if (this.HierarchyEnabled && this.Hierarchy.HasValue && !this.Hierarchy.Value.Equals(Hierarchies.HIERARCHY_AUTO))
                sb.Append("Y" + (short)this.Hierarchy.Value);
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            if (!obj.GetType().Equals(typeof(ParametersField)))
                return false;
            ParametersField pf = obj as ParametersField;
            if (pf == null)
                return false;
            if (!this.PolarizationEnabled.Equals(pf.PolarizationEnabled))
                return false;
            if (!this.Polarization.Equals(pf.Polarization))
                return false;
            if (!this.BandwidthEnabled.Equals(pf.BandwidthEnabled))
                return false;
            if (!this.CodeRateHighPriorityEnabled.Equals(pf.CodeRateHighPriorityEnabled))
                return false;
            if (!this.CodeRateHighPriority.Equals(pf.CodeRateHighPriority))
                return false;
            if (!this.CodeRateLowPriorityEnabled.Equals(pf.CodeRateLowPriorityEnabled))
                return false;
            if (!this.CodeRateLowPriority.Equals(pf.CodeRateLowPriority))
                return false;
            if (!this.GuardIntervalEnabled.Equals(pf.GuardIntervalEnabled))
                return false;
            if (!this.GuardInterval.Equals(pf.GuardInterval))
                return false;
            if (!this.InversionEnabled.Equals(pf.InversionEnabled))
                return false;
            if (!this.Inversion.Equals(pf.Inversion))
                return false;
            if (!this.ModulationEnabled.Equals(pf.ModulationEnabled))
                return false;
            if (!this.Modulation.Equals(pf.Modulation))
                return false;
            if (!this.PilotModeEnabled.Equals(pf.PilotModeEnabled))
                return false;
            if (!this.PilotMode.Equals(pf.PilotMode))
                return false;
            if (!this.RollOffEnabled.Equals(pf.RollOffEnabled))
                return false;
            if (!this.Rolloff.Equals(pf.Rolloff))
                return false;
            if (!this.StreamIdEnabled.Equals(pf.StreamIdEnabled))
                return false;
            if (!this.StreamId.Equals(pf.StreamId))
                return false;
            if (!this.T2SystemIdEnabled.Equals(pf.T2SystemIdEnabled))
                return false;
            if (!this.T2SystemId.Equals(pf.T2SystemId))
                return false;
            if (!this.DeliverySystemEnabled.Equals(pf.DeliverySystemEnabled))
                return false;
            if (!this.DeliverySystem.Equals(pf.DeliverySystem))
                return false;
            if (!this.TransmissionModeEnabled.Equals(this.TransmissionModeEnabled))
                return false;
            if (!this.TransmissionMode.Equals(pf.TransmissionMode))
                return false;
            if (!this.SM_modeEnabled.Equals(pf.SM_modeEnabled))
                return false;
            if (!this.SM_mode.Equals(pf.SM_mode))
                return false;
            if (!this.HierarchyEnabled.Equals(pf.HierarchyEnabled))
                return false;
            if (!this.Hierarchy.Equals(pf.Hierarchy))
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        #endregion Public Override Methods

        #region Public static implicit operators
        public static implicit operator string(ParametersField p) => p.ToString();
        public static implicit operator ParametersField(string s) => new ParametersField(s);
        #endregion Public static implicit operators
    }
}
