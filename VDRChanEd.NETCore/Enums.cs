using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VDRChanEd.NETCore
{
    #region enum Modulations
    /// <summary>
    /// Specifies the modulation/constellation of the channel
    /// </summary>
    public enum Modulations
    {
        [Description("QPSK (DVB-S, DVB-S2, DVB-T, DVB-T2, ISDB-T)")]
        QPSK = 2,

        [Description("8PSK (DVB-S, DVB-S2)")]
        PSK_8 = 5,

        [Description("16APSK (DVB-S2)")]
        APSK_16 = 6,

        [Description("32APSK (DVB-S2)")]
        APSK_32 = 7,

        [Description("VSB8 (ATSC aerial)")]
        VSB_8 = 10,

        [Description("VSB16 (ATSC aerial)")]
        VSB_16 = 11,

        [Description("DQPSK (ISDB-T)")]
        DQPSK = 12,

        [Description("QAM16 (DVB-T, DVB-T2, ISDB-T)")]
        QAM_16 = 16,

        [Description("QAM32")]
        QAM_32 = 32,

        [Description("QAM64 (DVB-C, DVB-T, DVB-T2, ISDB-T)")]
        QAM_64 = 64,

        [Description("QAM128 (DVB-C)")]
        QAM_128 = 128,

        [Description("QAM256 (DVB-C, DVB-T2)")]
        QAM_256 = 256,

        [Description("auto")]
        QAM_AUTO = 999
    }
    #endregion Modulations

    #region enum GuardIntervals
    /// <summary>
    /// The guard interval value (DVB-T only)
    /// </summary>
    public enum GuardIntervals
    {
        [Description("1/4")]
        GUARD_INTERVAL_1_4 = 4,

        [Description("1/8")]
        GUARD_INTERVAL_1_8 = 8,

        [Description("1/16")]
        GUARD_INTERVAL_1_16 = 16,

        [Description("1/32")]
        GUARD_INTERVAL_1_32 = 32,

        [Description("1/128")]
        GUARD_INTERVAL_1_128 = 128,

        [Description("19/128")]
        GUARD_INTERVAL_19_128 = 19128,

        [Description("19/256")]
        GUARD_INTERVAL_19_256 = 19256,

        [Description("auto")]
        GUARD_INTERVAL_AUTO = 999
    }
    #endregion enum GuardIntervals

    #region enum PilotModes
    /// <summary>
    /// The pilot mode (0 = "off", 1 = "on", 999 = "auto") for DVB-S2 multiplex (DVB-S2 only)
    /// </summary>
    public enum PilotModes
    {
        [Description("off")]
        PILOT_OFF = 0,

        [Description("on")]
        PILOT_ON = 1,

        [Description("auto")]
        PILOT_AUTO = 999
    }
    #endregion enum PilotModes

    #region enum Rollofs
    /// <summary>
    /// The Nyquist filter rolloff factor for DVB-S (35) and DVB-S2 ( 35, 25, 20)
    /// </summary>
    public enum Rolloffs
    {
        [Description("none")]
        ROLLOFF_NONE = 0,

        [Description("0.35")]
        ROLLOFF_35 = 35,

        [Description("0.25")]
        ROLLOFF_25 = 25,

        [Description("0.20")]
        ROLLOFF_20 = 20,

        [Description("auto")]
        ROLLOFF_AUTO = 999,
    }
    #endregion Rolloffs

    #region enum TransmissionModes
    /// <summary>
    /// Number of DVB-T OFDM carriers
    /// </summary>
    public enum TransmissionModes
    {
        [Description("32k")]
        TRANSMISSION_MODE_32k = 32,

        [Description("16k")]
        TRANSMISSION_MODE_16k = 16,

        [Description("8k")]
        TRANSMISSION_MODE_8k = 8,

        [Description("4k")]
        TRANSMISSION_MODE_4k = 4,

        [Description("2k")]
        TRANSMISSION_MODE_2k = 2,

        [Description("1k")]
        TRANSMISSION_MODE_1k = 1,

        [Description("auto")]
        TRANSMISSION_MODE_AUTO = 999
    }
    #endregion TransmissionModes

    #region enum DeliverySystems
    /// <summary>
    /// The delivery system
    /// </summary>
    public enum DeliverySystems
    {
        [Description("DVB-S/DVB-T")]
        DVB_SYSTEM_1 = 0,

        [Description("DVB-S2/DVB-T2")]
        DVB_SYSTEM_2 = 1
    }
    #endregion enum DeliverySystems

    #region enum Polarizations
    /// <summary>
    /// Satellite antenna polarization
    /// </summary>
    public enum Polarizations
    {
        [Description("horizontal")]
        H = ((int)'H'),

        [Description("vertical")]
        V = ((int)'V'),

        [Description("circular right")]
        R = ((int)'R'),

        [Description("circular left")]
        L = ((int)'L')
    }
    #endregion enum Polarizations

    #region enum SISO_MISO_Modes
    /// <summary>
    /// Specifies the Single-Input/Multiple-Input Single-Output mode (DVB-T2)
    /// </summary>
    public enum SISO_MISO_Modes
    {
        [Description("Single-Input Single-Output (SISO)")]
        SISO = 0,

        [Description("Multiple-Input Single-Output (MISO)")]
        MISO = 1
    }
    #endregion enum SISO_MISO_Modes

    #region enum Hierarchies
    /// <summary>
    /// If set to 1, this transponder uses two streams, high priority and low priority.  If in doubt, try 0 (off). (DVB-T/DVB-T2 only).
    /// </summary>
    public enum Hierarchies
    {
        [Description("none")]
        HIERARCHY_NONE = 0,

        [Description("1")]
        HIERARCHY_1 = 1,

        [Description("2")]
        HIERARCHY_2 = 2,

        [Description("4")]
        HIERARCHY_4 = 4,

        [Description("auto")]
        HIERARCHY_AUTO = 999
    }
    #endregion enum Hierarchies

    #region enum BandwidthValues
    /// <summary>
    /// The bandwidth of the channel in MHz (1712 in kHz): (DVB-T/DVB-T2 only).
    /// </summary>
    public enum BandwidthValues
    {
        [Description("5 MHz")]
        BANDWIDTH_5000000 = 5,

        [Description("6 MHz")]
        BANDWIDTH_6000000 = 6,

        [Description("7 MHz")]
        BANDWIDTH_7000000 = 7,

        [Description("8 MHz")]
        BANDWIDTH_8000000 = 8,

        [Description("10 MHz")]
        BANDWIDTH_10000000 = 10,

        [Description("1.712 MHz")]
        BANDWIDTH_1712000 = 1712
    }
    #endregion enum BandwidthValues

    #region enum CoderateValues
    /// <summary>
    /// Code rate high priority: Forward Error Correction (FEC) of the high priority stream (DVB-T/DVB-T2).  For DVB-S/DVB-S2 this parameter specifies the inner FEC scheme.  12 = 1/2, 23 = 2/3, 34 = 3/4, ...
    /// Code rate low priority: Forward Error Correction (FEC) of the low priority stream (DVB-T/DVB-T2 only).  If no hierarchy is used, set to 0.
    /// </summary>
    public enum CoderateValues
    {
        [Description("none")]
        FEC_NONE,

        [Description("1/2")]
        FEC_1_2 = 12,

        [Description("2/3")]
        FEC_2_3 = 23,

        [Description("3/4")]
        FEC_3_4 = 34,

        [Description("3/5")]
        FEC_3_5 = 35,

        [Description("4/5")]
        FEC_4_5 = 45,

        [Description("5/6")]
        FEC_5_6 = 56,

        [Description("6/7")]
        FEC_6_7 = 67,

        [Description("7/8")]
        FEC_7_8 = 78,

        [Description("8/9")]
        FEC_8_9 = 89,

        [Description("9/10")]
        FEC_9_10 = 910,

        [Description("auto")]
        FEC_AUTO = 999
    }
    #endregion enum CoderateValues

    public enum ChannelSources
    {
        [Description("DVB-S")]
        CHANNEL_SOURCE_DVBS  = 0x00000001,

        [Description("DVB-S2")]
        CHANNEL_SOURCE_DVBS2 = 0x00010001,

        [Description("DVB-T")]
        CHANNEL_SOURCE_DVBT  = 0x00000010,

        [Description("DVB-T2")]
        CHANNEL_SOURCE_DVBT2 = 0x00010010,

        [Description("DVB-C")]
        CHANNEL_SOURCE_DVBC  = 0x00000100,

        [Description("ATSC")]
        CHANNEL_SOURCE_ATSC  = 0x00001000
    }

    #region Sources
    public enum Sources
    {
        [Description("S3E     Eutelsat 3A/3D & Rascom 1R")]
        S3E,

        [Description("S4E     Eutelsat 4B")]
        S4E,

        [Description("S4.8E   Astra 4A")]
        S4_8E,

        [Description("S5E     SES 5")]
        S5E,

        [Description("S7E     Eutelsat 7A")]
        S7E,

        [Description("S9E     Eutelsat 9A/Ka-Sat 9A")]
        S9E,

        [Description("S10E    Eutelsat 10A")]
        S10E,

        [Description("S13E    Eutelsat Hot Bird 13B/13C/13D")]
        S13E,

        [Description("S16E    Eutelsat 16A/16B")]
        S16E,

        [Description("S17E    Amos 5")]
        S17E,

        [Description("S19.2E  Astra 1KR/1L/1M/2C")]
        S19_2E,

        [Description("S21.6E  Eutelsat 21B")]
        S21_6E,

        [Description("S23.5E  Astra 3B")]
        S23_3E,

        [Description("S25.5E  Eutelsat 25B")]
        S25_5E,

        [Description("S26E    Badr 4/5/6")]
        S26E,

        [Description("S28.2E  Astra 1N/2A/2F")]
        S28_2E,

        [Description("S28.5E  Eutelsat 28A")]
        S28_5E,

        [Description("S30.5E  Arabsat 5A")]
        S30_5E,

        [Description("S31.5E  Astra 1G")]
        S31_5E,

        [Description("S33E    Eutelsat 33A & Intelsat 28")]
        S33E,

        [Description("S36E    Eutelsat 36A/36B")]
        S36E,

        [Description("S38E    Paksat 1R")]
        S38E,

        [Description("S39E    Hellas Sat 2")]
        S39E,

        [Description("S42E    Turksat 2A/3A")]
        S42E,

        [Description("S45E    Intelsat 12")]
        S45E,

        [Description("S46E    Azerspace-1")]
        S46E,

        [Description("S47.5E  Intelsat 10")]
        S47_5E,

        [Description("S49E    Yamal 202")]
        S49E,

        [Description("S52.5E  Yahsat 1A")]
        S52_5E,

        [Description("S53E    Express AM22")]
        S53E,

        [Description("S56E    DirecTV 1R")]
        S56E,

        [Description("S57E    NSS 12")]
        S57E,

        [Description("S58.5E  Kazsat 3")]
        S58_5E,

        [Description("S60E    Intelsat 904")]
        S60E,

        [Description("S62E    Intelsat 902")]
        S62E,

        [Description("S64E    Intelsat 906")]
        S64E,

        [Description("S66E    Intelsat 17")]
        S66E,

        [Description("S68.5E  Intelsat 7/10")]
        S68_5E,

        [Description("S70.5E  Eutelsat 70B")]
        S70_5E,

        [Description("S72E    Intelsat 22")]
        S72E,

        [Description("S74E    Insat 3C/4CR")]
        S74E,

        [Description("S75E    ABS 1A")]
        S75E,

        [Description("S76.5E  Apstar 7")]
        S76_5E,

        [Description("S78.5E  Thaicom 5/6A")]
        S78_5E,

        [Description("S80E    Express AM2")]
        S80E,

        [Description("S83E    Insat 4A")]
        S83E,

        [Description("S85.2E  Intelsat 15 & Horizons 2")]
        S85_2E,

        [Description("S87.5E  ChinaSat 12")]
        S87_5E,

        [Description("S88E    ST 2")]
        S88E,

        [Description("S90E    Yamal 201/300K")]
        S90E,

        [Description("S91.5E  Measat 3/3A")]
        S91_5E,

        [Description("S92.2E  ChinaSat 9")]
        S92_2E,

        [Description("S93.5E  Insat 3A/4B")]
        S93_5E,

        [Description("S95E    NSS 6")]
        S95E,

        [Description("S96.5E  Express AM33")]
        S96_5E,

        [Description("S100.5E Asiasat 5")]
        S100_5E,

        [Description("S103E   Express A2")]
        S103E,

        [Description("S105.5E Asiasat 3S")]
        S105_5E,

        [Description("S108.2E Telkom 1 & NSS 11 & SES 7")]
        S108_2E,

        [Description("S110E   N-Sat 110 & BSAT 3A/3C")]
        S110E,

        [Description("S110.5E ChinaSat 10")]
        S110_5E,

        [Description("S113E   Palapa D & Koreasat 5")]
        S113E,

        [Description("S115.5E ChinaSat 6B")]
        S115_5E,

        [Description("S116E   ABS 7 & Koreasat 6")]
        S116E,

        [Description("S118E   Telkom 2")]
        S118E,

        [Description("S119.5E Thaicom 4")]
        S119_5E,

        [Description("S122.2E Asiasat 4")]
        S122_2E,

        [Description("S124E   JCSAT 4B")]
        S124E,

        [Description("S125E   ChinaSat 6A")]
        S125E,

        [Description("S128E   JCSAT 3A")]
        S128E,

        [Description("S132E   Vinasat 1/2 & JCSAT 5A")]
        S132E,

        [Description("S134E   Apstar 6")]
        S134E,

        [Description("S138E   Telstar 18")]
        S138E,

        [Description("S140E   Express AM3")]
        S140E,

        [Description("S144E   Superbird C2")]
        S144E,

        [Description("S150E   JCSAT 1B")]
        S150E,

        [Description("S152E   Optus D2")]
        S152E,

        [Description("S154E   JCSAT 2A")]
        S154E,

        [Description("S156E   Optus C1/D3")]
        S156E,

        [Description("S160E   Optus D1")]
        S160E,

        [Description("S162E   Superbird B2")]
        S162E,

        [Description("S164E   Optus B3")]
        S164E,

        [Description("S166E   Intelsat 19")]
        S166E,

        [Description("S169E   Intelsat 8")]
        S169E,

        [Description("S172E   Eutelsat 172A")]
        S172E,

        [Description("S180E   Intelsat 18")]
        S180E,

        [Description("S177W   NSS 9")]
        S177W,

        [Description("S139W   AMC 8")]
        S139W,

        [Description("S137W   AMC 7")]
        S137W,

        [Description("S135W   AMC 10")]
        S135W,

        [Description("S133W   Galaxy 15")]
        S133W,

        [Description("S131W   AMC 11")]
        S131W,

        [Description("S129W   Ciel 2")]
        S129W,

        [Description("S127W   Galaxy 13/Horizons 1")]
        S127W,

        [Description("S125W   Galaxy 14 & AMC 21")]
        S125W,

        [Description("S123W   Galaxy 18")]
        S123W,

        [Description("S121W   Echostar 9/Galaxy 23")]
        S121W,

        [Description("S119W   Echostar 14 & DirecTV 7S")]
        S119W,

        [Description("S118.8W Anik F3")]
        S118_8W,

        [Description("S116.8W SatMex 8")]
        S116_8W,

        [Description("S114.9W SatMex 5")]
        S114_9W,

        [Description("S113W   SatMex 6")]
        S113W,

        [Description("S111.1W Anik F2")]
        S111_1W,

        [Description("S110W   DirecTV 5 & Echostar 10/11")]
        S110W,

        [Description("S107.3W Anik F1R/G1")]
        S107_3W,

        [Description("S105W   AMC 15/18")]
        S105W,

        [Description("S103W   AMC 1")]
        S103W,

        [Description("S101W   DirecTV 4S/8 & SES 1")]
        S101W,

        [Description("S99.2W  Galaxy 16")]
        S99_2W,

        [Description("S97W    Galaxy 19")]
        S97W,

        [Description("S95W    Galaxy 3C")]
        S95W,

        [Description("S93.1W  Galaxy 25")]
        S93_1W,

        [Description("S91W    Galaxy 17 & Nimiq 6")]
        S91W,

        [Description("S89W    Galaxy 28")]
        S89W,

        [Description("S87W    SES 2")]
        S87W,

        [Description("S85W    AMC 16")]
        S85W,

        [Description("S85.1W  XM 3")]
        S85_1W,

        [Description("S84W    Brasilsat B4")]
        S84W,

        [Description("S83W    AMC 9")]
        S83W,

        [Description("S82W    Nimiq 4")]
        S82W,

        [Description("S77W    QuetzSat 1")]
        S77W,

        [Description("S75W    Star One C3")]
        S75W,

        [Description("S72W    AMC 6")]
        S72W,

        [Description("S72.7W  Nimiq 5")]
        S72_2W,

        [Description("S70W    Star One C2")]
        S70W,

        [Description("S67W    AMC 4")]
        S67W,

        [Description("S65W    Star One C1")]
        S65W,

        [Description("S63W    Telstar 14R")]
        S63W,

        [Description("S61.5W  Echostar 16")]
        S61_5W,

        [Description("S61W    Amazonas 2/3")]
        S61W,

        [Description("S58W    Intelsat 21")]
        S58W,

        [Description("S55.5W  Intelsat 805")]
        S55_5W,

        [Description("S53W    Intelsat 23")]
        S53W,

        [Description("S50W    Intelsat 1R")]
        S50W,

        [Description("S45W    Intelsat 14")]
        S45W,

        [Description("S43W    Intelsat 11")]
        S43W,

        [Description("S40.5W  SES 6")]
        S40_5W,

        [Description("S37.5W  NSS 10 & Telstar 11N")]
        S37_5W,

        [Description("S34.5W  Intelsat 903")]
        S34_5W,

        [Description("S31.5W  Intelsat 25")]
        S31_5W,

        [Description("S30W    Hispasat 1D/1E")]
        S30W,

        [Description("S27.5W  Intelsat 907")]
        S27_5W,

        [Description("S24.5W  Intelsat 905")]
        S24_5W,

        [Description("S22W    SES 4")]
        S22W,

        [Description("S20W    NSS 7")]
        S20W,

        [Description("S18W    Intelsat 901")]
        S18W,

        [Description("S15W    Telstar 12")]
        S15W,

        [Description("S14W    Express A4")]
        S14W,

        [Description("S12.5W  Eutelsat 12 West A")]
        S12_5W,

        [Description("S11W    Express AM44")]
        S11W,

        [Description("S8W     Eutelsat 8 West A/C")]
        S8W,

        [Description("S7W     Nilesat 101/201 & Eutelsat 7 West A")]
        S7W,

        [Description("S5W     Eutelsat 5 West A")]
        S5W,

        [Description("S4W     Amos 2/3")]
        S4W,

        [Description("S3W     ABS-3A")]
        S3W,

        [Description("S1W     Thor 5/6")]
        S1W,

        [Description("S0.8W   Intelsat 10-02")]
        S0_8W,

        [Description("S360E   Any satellite")]
        S360E,

        [Description("C       DVB-C")]
        C,

        [Description("T       DVB-T")]
        T,

        [Description("A       ATSC")]
        A,

        [Description("I       IPTV")]
        I,

        [Description("V       Analog Video")]
        V
    }
    #endregion Sources
}
