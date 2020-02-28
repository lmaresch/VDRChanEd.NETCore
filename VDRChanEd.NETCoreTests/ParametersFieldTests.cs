using Microsoft.VisualStudio.TestTools.UnitTesting;
using VDRChanEd.NETCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace VDRChanEd.NETCore.Tests
{
    [TestClass()]
    public class ParametersFieldTests
    {
        [TestMethod()]
        public void EvaluateParametersTest1()
        {
            ParametersField parameters = new ParametersField(ChannelSources.CHANNEL_SOURCE_DVBT);
            string text = "B8C23D12G8M16T8Y0S0";
            parameters.EvaluateParameters(text);
            Assert.AreEqual(BandwidthValues.BANDWIDTH_8000000, parameters.Bandwidth);
            Assert.AreEqual(CoderateValues.FEC_2_3, parameters.CodeRateHighPriority);
            Assert.AreEqual(CoderateValues.FEC_1_2, parameters.CodeRateLowPriority);
            Assert.AreEqual(GuardIntervals.GUARD_INTERVAL_1_8, parameters.GuardInterval);
            Assert.AreEqual(Modulations.QAM_16, parameters.Modulation);
            Assert.AreEqual(TransmissionModes.TRANSMISSION_MODE_8k, parameters.TransmissionMode);
            Assert.AreEqual(Hierarchies.HIERARCHY_NONE, parameters.Hierarchy);
            Assert.AreEqual(DeliverySystems.DVB_SYSTEM_1, parameters.DeliverySystem);
            string errorMessage = string.Empty;
            bool retVal = Helper.AreDictsEqual(Helper.SplitParameters(text), Helper.SplitParameters(parameters.ToString()), ref errorMessage);
            Assert.IsTrue(retVal, errorMessage);
        }

        [TestMethod()]
        public void EvaluateParametersTest2()
        {
            ParametersField parameters = new ParametersField(ChannelSources.CHANNEL_SOURCE_DVBT2);
            string text = "B8C23D12G8M16T8Y0P0S1";
            parameters.EvaluateParameters(text);
            Assert.AreEqual(BandwidthValues.BANDWIDTH_8000000, parameters.Bandwidth);
            Assert.AreEqual(CoderateValues.FEC_2_3, parameters.CodeRateHighPriority);
            Assert.AreEqual(CoderateValues.FEC_1_2, parameters.CodeRateLowPriority);
            Assert.AreEqual(GuardIntervals.GUARD_INTERVAL_1_8, parameters.GuardInterval);
            Assert.AreEqual(Modulations.QAM_16, parameters.Modulation);
            Assert.AreEqual(TransmissionModes.TRANSMISSION_MODE_8k, parameters.TransmissionMode);
            Assert.AreEqual(Hierarchies.HIERARCHY_NONE, parameters.Hierarchy);
            Assert.AreEqual((short)0, parameters.StreamId);
            Assert.AreEqual(DeliverySystems.DVB_SYSTEM_2, parameters.DeliverySystem);
            string errorMessage = string.Empty;
            bool retVal = Helper.AreDictsEqual(Helper.SplitParameters(text), Helper.SplitParameters(parameters.ToString()), ref errorMessage);
            Assert.IsTrue(retVal, errorMessage);
        }

        [TestMethod()]
        public void EvaluateParametersTest3()
        {
            ParametersField parameters = new ParametersField(ChannelSources.CHANNEL_SOURCE_DVBC);
            string text = "C0M64";
            parameters.EvaluateParameters(text);
            Assert.AreEqual(CoderateValues.FEC_NONE, parameters.CodeRateHighPriority);
            Assert.AreEqual(Modulations.QAM_64, parameters.Modulation);
            string errorMessage = string.Empty;
            bool retVal = Helper.AreDictsEqual(Helper.SplitParameters(text), Helper.SplitParameters(parameters.ToString()), ref errorMessage);
            Assert.IsTrue(retVal, errorMessage);
        }

        [TestMethod()]
        public void EvaluateParametersTest4()
        {
            ParametersField parameters = new ParametersField(ChannelSources.CHANNEL_SOURCE_DVBS);
            string text = "HC56M2O35S0";
            parameters.EvaluateParameters(text);
            Assert.AreEqual(Polarizations.H, parameters.Polarization);
            Assert.AreEqual(CoderateValues.FEC_5_6, parameters.CodeRateHighPriority);
            Assert.AreEqual(Modulations.QPSK, parameters.Modulation);
            Assert.AreEqual(Rolloffs.ROLLOFF_35, parameters.Rolloff);
            Assert.AreEqual(DeliverySystems.DVB_SYSTEM_1, parameters.DeliverySystem);
            string errorMessage = string.Empty;
            bool retVal = Helper.AreDictsEqual(Helper.SplitParameters(text), Helper.SplitParameters(parameters.ToString()), ref errorMessage);
            Assert.IsTrue(retVal, errorMessage);
        }

        [TestMethod()]
        public void EvaluateParametersTest5()
        {
            ParametersField parameters = new ParametersField(ChannelSources.CHANNEL_SOURCE_DVBS2);
            string text = "HC910M2O35S1";
            parameters.EvaluateParameters(text);
            Assert.AreEqual(Polarizations.H, parameters.Polarization);
            Assert.AreEqual(CoderateValues.FEC_9_10, parameters.CodeRateHighPriority);
            Assert.AreEqual(Modulations.QPSK, parameters.Modulation);
            Assert.AreEqual(Rolloffs.ROLLOFF_35, parameters.Rolloff);
            Assert.AreEqual(DeliverySystems.DVB_SYSTEM_2, parameters.DeliverySystem);
            string errorMessage = string.Empty;
            bool retVal = Helper.AreDictsEqual(Helper.SplitParameters(text), Helper.SplitParameters(parameters.ToString()), ref errorMessage);
            Assert.IsTrue(retVal, errorMessage);
        }

        #region Properties Tests
        #region Property Bandwidth
        #region BandwidthTests
        [DataTestMethod()]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, BandwidthValues.BANDWIDTH_10000000)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, BandwidthValues.BANDWIDTH_1712000)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, BandwidthValues.BANDWIDTH_5000000)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, BandwidthValues.BANDWIDTH_6000000)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, BandwidthValues.BANDWIDTH_7000000)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, BandwidthValues.BANDWIDTH_8000000)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, BandwidthValues.BANDWIDTH_10000000)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, BandwidthValues.BANDWIDTH_1712000)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, BandwidthValues.BANDWIDTH_5000000)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, BandwidthValues.BANDWIDTH_6000000)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, BandwidthValues.BANDWIDTH_7000000)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, BandwidthValues.BANDWIDTH_8000000)]
        public void BandwidthTests(ChannelSources src, BandwidthValues val)
        {
            ParametersField parameters = new ParametersField(src);
            string text = "B" + (short)val;
            parameters.EvaluateParameters(text);
            Assert.AreEqual(val, parameters.Bandwidth);
            Assert.AreEqual(text, parameters.ToString());
        }
        #endregion BandwidthTests

        #region BandwidthEnabledTests
        [DataTestMethod()]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, true)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, true)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, false)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, false)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, false)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_ATSC, false)]
        public void BandwidthEnabledTests(ChannelSources src, bool result)
        {
            ParametersField parameters = new ParametersField(src);
            Assert.AreEqual(result, parameters.BandwidthEnabled);
        }
        #endregion BandwidthEnabledTests
        #endregion Property Bandwidth

        #region Property CodeRateHighPriority
        #region CoderateHighPriorityTests
        [DataTestMethod()]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, CoderateValues.FEC_NONE)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, CoderateValues.FEC_1_2)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, CoderateValues.FEC_2_3)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, CoderateValues.FEC_3_4)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, CoderateValues.FEC_3_5)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, CoderateValues.FEC_4_5)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, CoderateValues.FEC_5_6)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, CoderateValues.FEC_6_7)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, CoderateValues.FEC_7_8)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, CoderateValues.FEC_8_9)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, CoderateValues.FEC_9_10)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, CoderateValues.FEC_AUTO)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, CoderateValues.FEC_NONE)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, CoderateValues.FEC_1_2)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, CoderateValues.FEC_2_3)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, CoderateValues.FEC_3_4)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, CoderateValues.FEC_3_5)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, CoderateValues.FEC_4_5)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, CoderateValues.FEC_5_6)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, CoderateValues.FEC_6_7)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, CoderateValues.FEC_7_8)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, CoderateValues.FEC_8_9)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, CoderateValues.FEC_9_10)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, CoderateValues.FEC_AUTO)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, CoderateValues.FEC_NONE)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, CoderateValues.FEC_1_2)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, CoderateValues.FEC_2_3)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, CoderateValues.FEC_3_4)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, CoderateValues.FEC_3_5)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, CoderateValues.FEC_4_5)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, CoderateValues.FEC_5_6)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, CoderateValues.FEC_6_7)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, CoderateValues.FEC_7_8)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, CoderateValues.FEC_8_9)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, CoderateValues.FEC_9_10)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, CoderateValues.FEC_AUTO)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, CoderateValues.FEC_NONE)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, CoderateValues.FEC_1_2)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, CoderateValues.FEC_2_3)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, CoderateValues.FEC_3_4)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, CoderateValues.FEC_3_5)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, CoderateValues.FEC_4_5)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, CoderateValues.FEC_5_6)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, CoderateValues.FEC_6_7)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, CoderateValues.FEC_7_8)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, CoderateValues.FEC_8_9)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, CoderateValues.FEC_9_10)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, CoderateValues.FEC_AUTO)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, CoderateValues.FEC_NONE)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, CoderateValues.FEC_1_2)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, CoderateValues.FEC_2_3)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, CoderateValues.FEC_3_4)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, CoderateValues.FEC_3_5)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, CoderateValues.FEC_4_5)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, CoderateValues.FEC_5_6)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, CoderateValues.FEC_6_7)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, CoderateValues.FEC_7_8)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, CoderateValues.FEC_8_9)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, CoderateValues.FEC_9_10)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, CoderateValues.FEC_AUTO)]
        public void CoderateHighPriorityTests(ChannelSources src, CoderateValues val)
        {
            ParametersField parameters = new ParametersField(src);
            string text = "C" + (short)val;
            parameters.EvaluateParameters(text);
            Assert.AreEqual(val, parameters.CodeRateHighPriority);
            Assert.AreEqual(val.Equals(CoderateValues.FEC_AUTO) ? string.Empty : text, parameters.ToString());
        }
        #endregion CoderateHighPriorityTests

        #region CodeRateHighPriorityEnabledTests
        [DataTestMethod()]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, true)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, true)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, true)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, true)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, true)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_ATSC, false)]
        public void CodeRateHighPriorityEnabledTests(ChannelSources src, bool result)
        {
            ParametersField parameters = new ParametersField(src);
            Assert.AreEqual(result, parameters.CodeRateHighPriorityEnabled);
        }
        #endregion CodeRateHighPriorityEnabledTests
        #endregion CodeRateHighPriority

        #region Property CodeRateLowPriority
        #region CoderateLowPriorityTests
        [DataTestMethod()]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, CoderateValues.FEC_NONE)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, CoderateValues.FEC_1_2)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, CoderateValues.FEC_2_3)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, CoderateValues.FEC_3_4)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, CoderateValues.FEC_3_5)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, CoderateValues.FEC_4_5)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, CoderateValues.FEC_5_6)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, CoderateValues.FEC_6_7)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, CoderateValues.FEC_7_8)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, CoderateValues.FEC_8_9)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, CoderateValues.FEC_9_10)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, CoderateValues.FEC_AUTO)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, CoderateValues.FEC_NONE)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, CoderateValues.FEC_1_2)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, CoderateValues.FEC_2_3)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, CoderateValues.FEC_3_4)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, CoderateValues.FEC_3_5)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, CoderateValues.FEC_4_5)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, CoderateValues.FEC_5_6)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, CoderateValues.FEC_6_7)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, CoderateValues.FEC_7_8)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, CoderateValues.FEC_8_9)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, CoderateValues.FEC_9_10)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, CoderateValues.FEC_AUTO)]
        public void CoderateLowPriorityTests(ChannelSources src, CoderateValues val)
        {
            ParametersField parameters = new ParametersField(src);
            string text = "D" + (short)val;
            parameters.EvaluateParameters(text);
            Assert.AreEqual(val, parameters.CodeRateLowPriority);
            Assert.AreEqual(val.Equals(CoderateValues.FEC_AUTO) ? string.Empty : text, parameters.ToString());
        }
        #endregion CoderateLowPriorityTests

        #region CodeRateLowPriorityEnabledTests
        [DataTestMethod()]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, true)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, true)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, false)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, false)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, false)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_ATSC, false)]
        public void CodeRateLowPriorityEnabledTests(ChannelSources src, bool result)
        {
            ParametersField parameters = new ParametersField(src);
            Assert.AreEqual(result, parameters.CodeRateLowPriorityEnabled);
        }
        #endregion CodeRateLowPriorityEnabledTests
        #endregion Property CodeRateLowPriority

        #region Property GuardInterval
        #region GuardIntervalTests
        [DataTestMethod()]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, GuardIntervals.GUARD_INTERVAL_19_128)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, GuardIntervals.GUARD_INTERVAL_19_256)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, GuardIntervals.GUARD_INTERVAL_1_128)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, GuardIntervals.GUARD_INTERVAL_1_16)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, GuardIntervals.GUARD_INTERVAL_1_32)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, GuardIntervals.GUARD_INTERVAL_1_4)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, GuardIntervals.GUARD_INTERVAL_1_8)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, GuardIntervals.GUARD_INTERVAL_AUTO)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, GuardIntervals.GUARD_INTERVAL_19_128)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, GuardIntervals.GUARD_INTERVAL_19_256)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, GuardIntervals.GUARD_INTERVAL_1_128)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, GuardIntervals.GUARD_INTERVAL_1_16)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, GuardIntervals.GUARD_INTERVAL_1_32)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, GuardIntervals.GUARD_INTERVAL_1_4)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, GuardIntervals.GUARD_INTERVAL_1_8)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, GuardIntervals.GUARD_INTERVAL_AUTO)]
        public void GuardIntervalTests(ChannelSources src, GuardIntervals val)
        {
            ParametersField parameters = new ParametersField(src);
            string text = "G" + (short)val;
            parameters.EvaluateParameters(text);
            Assert.AreEqual(val, parameters.GuardInterval);
            Assert.AreEqual(val.Equals(GuardIntervals.GUARD_INTERVAL_AUTO) ? string.Empty : text, parameters.ToString());
        }
        #endregion GuardIntervalTests

        #region GuardIntervalEnabledTests
        [DataTestMethod()]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, true)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, true)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, false)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, false)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, false)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_ATSC, false)]
        public void GuardIntervalEnabledTests(ChannelSources src, bool result)
        {
            ParametersField parameters = new ParametersField(src);
            Assert.AreEqual(result, parameters.GuardIntervalEnabled);
        }
        #endregion GuardIntervalEnabledTests
        #endregion Property GuardInterval

        #region Property DeliverySystem
        #region DeliverySystemTests
        [DataTestMethod()]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, DeliverySystems.DVB_SYSTEM_1)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, DeliverySystems.DVB_SYSTEM_2)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, DeliverySystems.DVB_SYSTEM_1)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, DeliverySystems.DVB_SYSTEM_2)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, DeliverySystems.DVB_SYSTEM_1)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, DeliverySystems.DVB_SYSTEM_2)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, DeliverySystems.DVB_SYSTEM_1)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, DeliverySystems.DVB_SYSTEM_2)]
        public void DeliverySystemTests(ChannelSources src, DeliverySystems val)
        {
            ParametersField parameters = new ParametersField(src);
            string text = "S" + (short)val;
            parameters.EvaluateParameters(text);
            Assert.AreEqual(val, parameters.DeliverySystem);
            Assert.AreEqual(text, parameters.ToString());
        }
        #endregion DeliverySystemTests

        #region DeliverySystemEnabledTests
        [DataTestMethod()]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, true)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, true)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, true)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, true)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, false)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_ATSC, false)]
        public void DeliverySystemEnabledTests(ChannelSources src, bool result)
        {
            ParametersField parameters = new ParametersField(src);
            Assert.AreEqual(result, parameters.DeliverySystemEnabled);
        }
        #endregion DeliverySystemEnabledTests
        #endregion Property DeliverySystem

        #region Property Hierarchy
        #region HierarchyTests
        [DataTestMethod()]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, Hierarchies.HIERARCHY_1)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, Hierarchies.HIERARCHY_2)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, Hierarchies.HIERARCHY_4)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, Hierarchies.HIERARCHY_NONE)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, Hierarchies.HIERARCHY_AUTO)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, Hierarchies.HIERARCHY_1)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, Hierarchies.HIERARCHY_2)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, Hierarchies.HIERARCHY_4)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, Hierarchies.HIERARCHY_NONE)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, Hierarchies.HIERARCHY_AUTO)]
        public void HierarchyTests(ChannelSources src, Hierarchies val)
        {
            ParametersField parameters = new ParametersField(src);
            string text = "Y" + (short)val;
            parameters.EvaluateParameters(text);
            Assert.AreEqual(val, parameters.Hierarchy);
            Assert.AreEqual(val.Equals(Hierarchies.HIERARCHY_AUTO) ? string.Empty : text, parameters.ToString());
        }
        #endregion HierarchyTests

        #region HierarchyEnabledTests
        [DataTestMethod()]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, true)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, true)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, false)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, false)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, false)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_ATSC, false)]
        public void HierarchyEnabledTests(ChannelSources src, bool result)
        {
            ParametersField parameters = new ParametersField(src);
            Assert.AreEqual(result, parameters.HierarchyEnabled);
        }
        #endregion HierarchyEnabledTests
        #endregion Property Hierarchy

        #region Property Polarization
        #region PolarizationTests
        [DataTestMethod()]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, Polarizations.H)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, Polarizations.L)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, Polarizations.R)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, Polarizations.V)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, Polarizations.H)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, Polarizations.L)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, Polarizations.R)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, Polarizations.V)]
        public void PolarizationTests(ChannelSources src, Polarizations val)
        {
            ParametersField parameters = new ParametersField(src);
            string text = val.ToString();
            parameters.EvaluateParameters(text);
            Assert.AreEqual(val, parameters.Polarization);
            Assert.AreEqual(text, parameters.ToString());
        }
        #endregion PolarizationTests

        #region PolarizationEnabledTests
        [DataTestMethod()]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, false)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, false)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, true)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, true)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, false)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_ATSC, false)]
        public void PolarizationEnabledTests(ChannelSources src, bool result)
        {
            ParametersField parameters = new ParametersField(src);
            Assert.AreEqual(result, parameters.PolarizationEnabled);
        }
        #endregion PolarizationEnabledTests
        #endregion Property Polarization

        #region Property Modulation
        #region ModulationTests
        [DataTestMethod()]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, Modulations.APSK_16)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, Modulations.APSK_32)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, Modulations.DQPSK)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, Modulations.PSK_8)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, Modulations.QAM_128)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, Modulations.QAM_16)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, Modulations.QAM_256)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, Modulations.QAM_32)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, Modulations.QAM_64)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, Modulations.QPSK)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, Modulations.VSB_16)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, Modulations.VSB_8)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, Modulations.QAM_AUTO)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, Modulations.APSK_16)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, Modulations.APSK_32)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, Modulations.DQPSK)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, Modulations.PSK_8)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, Modulations.QAM_128)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, Modulations.QAM_16)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, Modulations.QAM_256)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, Modulations.QAM_32)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, Modulations.QAM_64)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, Modulations.QPSK)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, Modulations.VSB_16)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, Modulations.VSB_8)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, Modulations.QAM_AUTO)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, Modulations.APSK_16)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, Modulations.APSK_32)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, Modulations.DQPSK)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, Modulations.PSK_8)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, Modulations.QAM_128)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, Modulations.QAM_16)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, Modulations.QAM_256)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, Modulations.QAM_32)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, Modulations.QAM_64)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, Modulations.QPSK)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, Modulations.VSB_16)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, Modulations.VSB_8)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, Modulations.QAM_AUTO)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, Modulations.APSK_16)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, Modulations.APSK_32)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, Modulations.DQPSK)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, Modulations.PSK_8)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, Modulations.QAM_128)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, Modulations.QAM_16)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, Modulations.QAM_256)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, Modulations.QAM_32)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, Modulations.QAM_64)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, Modulations.QPSK)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, Modulations.VSB_16)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, Modulations.VSB_8)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, Modulations.QAM_AUTO)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, Modulations.APSK_16)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, Modulations.APSK_32)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, Modulations.DQPSK)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, Modulations.PSK_8)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, Modulations.QAM_128)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, Modulations.QAM_16)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, Modulations.QAM_256)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, Modulations.QAM_32)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, Modulations.QAM_64)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, Modulations.QPSK)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, Modulations.VSB_16)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, Modulations.VSB_8)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, Modulations.QAM_AUTO)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_ATSC, Modulations.APSK_16)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_ATSC, Modulations.APSK_32)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_ATSC, Modulations.DQPSK)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_ATSC, Modulations.PSK_8)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_ATSC, Modulations.QAM_128)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_ATSC, Modulations.QAM_16)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_ATSC, Modulations.QAM_256)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_ATSC, Modulations.QAM_32)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_ATSC, Modulations.QAM_64)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_ATSC, Modulations.QPSK)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_ATSC, Modulations.VSB_16)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_ATSC, Modulations.VSB_8)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_ATSC, Modulations.QAM_AUTO)]
        public void ModulationTests(ChannelSources src, Modulations val)
        {
            ParametersField parameters = new ParametersField(src);
            string text = "M" + (short)val;
            parameters.EvaluateParameters(text);
            Assert.AreEqual(val, parameters.Modulation);
            Assert.AreEqual(val.Equals(Modulations.QAM_AUTO) ? string.Empty : text, parameters.ToString());
        }
        #endregion ModulationTests

        #region ModulationEnabledTests
        [DataTestMethod()]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, true)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, true)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, true)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, true)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, true)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_ATSC, true)]
        public void ModulationEnabledTests(ChannelSources src, bool result)
        {
            ParametersField parameters = new ParametersField(src);
            Assert.AreEqual(result, parameters.ModulationEnabled);
        }
        #endregion ModulationEnabledTests
        #endregion Property Modulation

        #region Property Inversion
        #region InversionTests
        [DataTestMethod()]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, 0)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, 1)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, 0)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, 1)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, 0)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, 1)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, 0)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, 1)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, 0)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, 1)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_ATSC, 0)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_ATSC, 1)]
        public void PolarizationTests(ChannelSources src, short val)
        {
            ParametersField parameters = new ParametersField(src);
            string text = "I" + val.ToString();
            parameters.EvaluateParameters(text);
            Assert.AreEqual(val, parameters.Inversion);
            Assert.AreEqual(text, parameters.ToString());
        }
        #endregion InversionTests

        #region InversionEnabledTests
        [DataTestMethod()]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, true)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, true)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, true)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, true)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, true)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_ATSC, true)]
        public void InversionEnabledTests(ChannelSources src, bool result)
        {
            ParametersField parameters = new ParametersField(src);
            Assert.AreEqual(result, parameters.InversionEnabled);
        }
        #endregion InversionEnabledTests
        #endregion Property Inversion

        #region Property PilotMode
        #region PilotModeTests
        [DataTestMethod()]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, PilotModes.PILOT_ON)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, PilotModes.PILOT_OFF)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, PilotModes.PILOT_AUTO)]
        public void PilotModeTests(ChannelSources src, PilotModes val)
        {
            ParametersField parameters = new ParametersField(src);
            string text = "N" + (short)val;
            parameters.EvaluateParameters(text);
            Assert.AreEqual(val, parameters.PilotMode);
            Assert.AreEqual(val.Equals(PilotModes.PILOT_AUTO) ? string.Empty : text, parameters.ToString());
        }
        #endregion PilotModeTests

        #region PilotModeEnabledTests
        [DataTestMethod()]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, false)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, false)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, false)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, true)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, false)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_ATSC, false)]
        public void PilotModeEnabledTests(ChannelSources src, bool result)
        {
            ParametersField parameters = new ParametersField(src);
            Assert.AreEqual(result, parameters.PilotModeEnabled);
        }
        #endregion PilotModeEnabledTests
        #endregion Property PilotMode

        #region Property RollOff
        #region RollOffTests
        [DataTestMethod()]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, Rolloffs.ROLLOFF_NONE)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, Rolloffs.ROLLOFF_20)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, Rolloffs.ROLLOFF_25)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, Rolloffs.ROLLOFF_35)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, Rolloffs.ROLLOFF_AUTO)]
        public void RollOffTests(ChannelSources src, Rolloffs val)
        {
            ParametersField parameters = new ParametersField(src);
            string text = "O" + (short)val;
            parameters.EvaluateParameters(text);
            Assert.AreEqual(val, parameters.Rolloff);
            Assert.AreEqual(val.Equals(Rolloffs.ROLLOFF_AUTO) ? string.Empty : text, parameters.ToString());
        }
        #endregion RollOffTests

        #region RollOffEnabledTests
        [DataTestMethod()]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, false)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, false)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, true)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, true)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, false)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_ATSC, false)]
        public void RollOffEnabledTests(ChannelSources src, bool result)
        {
            ParametersField parameters = new ParametersField(src);
            Assert.AreEqual(result, parameters.RollOffEnabled);
        }
        #endregion RollOffEnabledTests
        #endregion Property RollOff

        #region Property StreamId
        #region StreamIdTests
        [DataTestMethod()]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, (short)-1)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, (short)0)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, (short)255)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, (short)256)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, (short)-1)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, (short)0)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, (short)255)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, (short)256)]
        public void StreamIdTests(ChannelSources src, short val)
        {
            ParametersField parameters = new ParametersField(src);
            string text = "P" + val.ToString();
            parameters.EvaluateParameters(text);
            Assert.AreEqual(val, parameters.StreamId);
            string temp = string.Empty;
            if (val >= 0 && val <= 255)
                temp = text;
            Assert.AreEqual(temp, parameters.ToString());
        }
        #endregion StreamIdTests

        #region StreamIdEnabledTests
        [DataTestMethod()]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, false)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, true)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, false)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, true)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, false)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_ATSC, false)]
        public void StreamIdEnabledTests(ChannelSources src, bool result)
        {
            ParametersField parameters = new ParametersField(src);
            Assert.AreEqual(result, parameters.StreamIdEnabled);
        }
        #endregion StreamIdEnabledTests
        #endregion Property StreamId

        #region Property T2SystemId
        #region T2SystemIdTests
        [DataTestMethod()]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, -1)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, 0)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, 65535)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, 65536)]
        public void T2SystemIdTests(ChannelSources src, int val)
        {
            ParametersField parameters = new ParametersField(src);
            string text = "Q" + val;
            parameters.EvaluateParameters(text);
            Assert.AreEqual(val, parameters.T2SystemId);
            string temp = string.Empty;
            if (val >= 0 && val <= 65535)
                temp = text;
            Assert.AreEqual(temp, parameters.ToString());
        }
        #endregion T2SystemIdTests

        #region T2SystemIdEnabledTests
        [DataTestMethod()]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, false)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, true)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, false)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, false)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, false)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_ATSC, false)]
        public void T2SystemIdEnabledTests(ChannelSources src, bool result)
        {
            ParametersField parameters = new ParametersField(src);
            Assert.AreEqual(result, parameters.T2SystemIdEnabled);
        }
        #endregion T2SystemIdEnabledTests
        #endregion Property T2SystemId

        #region Property TransmissionMode
        #region TransmissionModeTests
        [DataTestMethod()]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, TransmissionModes.TRANSMISSION_MODE_16k)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, TransmissionModes.TRANSMISSION_MODE_1k)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, TransmissionModes.TRANSMISSION_MODE_2k)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, TransmissionModes.TRANSMISSION_MODE_32k)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, TransmissionModes.TRANSMISSION_MODE_4k)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, TransmissionModes.TRANSMISSION_MODE_8k)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, TransmissionModes.TRANSMISSION_MODE_AUTO)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, TransmissionModes.TRANSMISSION_MODE_16k)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, TransmissionModes.TRANSMISSION_MODE_1k)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, TransmissionModes.TRANSMISSION_MODE_2k)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, TransmissionModes.TRANSMISSION_MODE_32k)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, TransmissionModes.TRANSMISSION_MODE_4k)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, TransmissionModes.TRANSMISSION_MODE_8k)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, TransmissionModes.TRANSMISSION_MODE_AUTO)]
        public void TransmissionModeTests(ChannelSources src, TransmissionModes val)
        {
            ParametersField parameters = new ParametersField(src);
            string text = "T" + (short)val;
            parameters.EvaluateParameters(text);
            Assert.AreEqual(val, parameters.TransmissionMode);
            Assert.AreEqual(val.Equals(TransmissionModes.TRANSMISSION_MODE_AUTO) ? string.Empty : text, parameters.ToString());
        }
        #endregion TransmissionModeTests

        #region TransmissionModeEnabledTests
        [DataTestMethod()]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, true)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, true)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, false)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, false)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, false)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_ATSC, false)]
        public void TransmissionModeEnabledTests(ChannelSources src, bool result)
        {
            ParametersField parameters = new ParametersField(src);
            Assert.AreEqual(result, parameters.TransmissionModeEnabled);
        }
        #endregion TransmissionModeEnabledTests
        #endregion Property TransmissionMode

        #region Property SM_mode
        #region SM_modeTests
        [DataTestMethod()]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, SISO_MISO_Modes.SISO)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, SISO_MISO_Modes.MISO)]
        public void SM_modeTests(ChannelSources src, SISO_MISO_Modes val)
        {
            ParametersField parameters = new ParametersField(src);
            string text = "X" + (short)val;
            parameters.EvaluateParameters(text);
            Assert.AreEqual(val, parameters.SM_mode);
            Assert.AreEqual(text, parameters.ToString());
        }
        #endregion SM_modeTests

        #region SM_modeEnabledTests
        [DataTestMethod()]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT, false)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBT2, true)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS, false)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBS2, false)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_DVBC, false)]
        [DataRow(ChannelSources.CHANNEL_SOURCE_ATSC, false)]
        public void SM_modeEnabledTests(ChannelSources src, bool result)
        {
            ParametersField parameters = new ParametersField(src);
            Assert.AreEqual(result, parameters.SM_modeEnabled);
        }
        #endregion SM_modeEnabledTests
        #endregion Property SM_Mode
        #endregion Properties Tests

    }
}