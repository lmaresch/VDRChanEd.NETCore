using Microsoft.VisualStudio.TestTools.UnitTesting;
using VDRChanEd.NETCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace VDRChanEd.NETCore.Tests
{
    [TestClass()]
    public class VideoFieldTests
    {
        [TestMethod()]
        public void SplitVPIDFieldTest1()
        {
            VideoField vPIDField = new VideoField();
            int expectedVideoPID = 0;
            Nullable<int> expectedPCRPID = null;
            Nullable<int> expectedVideoType = null;
            string expected = expectedVideoPID.ToString() + (expectedPCRPID.HasValue ? "+" + expectedPCRPID.Value.ToString() : string.Empty) + (expectedVideoType.HasValue ? "=" + expectedVideoType.Value.ToString() : string.Empty);
            vPIDField.SplitVideoField(expected);
            Assert.AreEqual(expectedVideoPID, vPIDField.VideoPID);
            Assert.AreEqual(expectedPCRPID, vPIDField.PCRPID);
            Assert.AreEqual(expectedVideoType, vPIDField.VideoType);
            string actual = vPIDField.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SplitVPIDFieldTest2()
        {
            VideoField vPIDField = new VideoField();
            int expectedVideoPID = 127;
            Nullable<int> expectedPCRPID = null;
            Nullable<int> expectedVideoType = null;
            string expected = expectedVideoPID.ToString() + (expectedPCRPID.HasValue ? "+" + expectedPCRPID.Value.ToString() : string.Empty) + (expectedVideoType.HasValue ? "=" + expectedVideoType.Value.ToString() : string.Empty);
            vPIDField.SplitVideoField(expected);
            Assert.AreEqual(expectedVideoPID, vPIDField.VideoPID);
            Assert.AreEqual(expectedPCRPID, vPIDField.PCRPID);
            Assert.AreEqual(expectedVideoType, vPIDField.VideoType);
            string actual = vPIDField.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SplitVPIDFieldTest3()
        {
            VideoField vPIDField = new VideoField();
            int expectedVideoPID = 127;
            Nullable<int> expectedPCRPID = 67;
            Nullable<int> expectedVideoType = null;
            string expected = expectedVideoPID.ToString() + (expectedPCRPID.HasValue ? "+" + expectedPCRPID.Value.ToString() : string.Empty) + (expectedVideoType.HasValue ? "=" + expectedVideoType.Value.ToString() : string.Empty);
            vPIDField.SplitVideoField(expected);
            Assert.AreEqual(expectedVideoPID, vPIDField.VideoPID);
            Assert.AreEqual(expectedPCRPID, vPIDField.PCRPID);
            Assert.AreEqual(expectedVideoType, vPIDField.VideoType);
            string actual = vPIDField.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SplitVPIDFieldTest4()
        {
            VideoField vPIDField = new VideoField();
            int expectedVideoPID = 127;
            Nullable<int> expectedPCRPID = 67;
            Nullable<int> expectedVideoType = 51;
            string expected = expectedVideoPID.ToString() + (expectedPCRPID.HasValue ? "+" + expectedPCRPID.Value.ToString() : string.Empty) + (expectedVideoType.HasValue ? "=" + expectedVideoType.Value.ToString() : string.Empty);
            vPIDField.SplitVideoField(expected);
            Assert.AreEqual(expectedVideoPID, vPIDField.VideoPID);
            Assert.AreEqual(expectedPCRPID, vPIDField.PCRPID);
            Assert.AreEqual(expectedVideoType, vPIDField.VideoType);
            string actual = vPIDField.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SplitVPIDFieldTest5()
        {
            VideoField vPIDField = new VideoField();
            int expectedVideoPID = 127;
            Nullable<int> expectedPCRPID = null;
            Nullable<int> expectedVideoType = 51;
            string expected = expectedVideoPID.ToString() + (expectedPCRPID.HasValue ? "+" + expectedPCRPID.Value.ToString() : string.Empty) + (expectedVideoType.HasValue ? "=" + expectedVideoType.Value.ToString() : string.Empty);
            vPIDField.SplitVideoField(expected);
            Assert.AreEqual(expectedVideoPID, vPIDField.VideoPID);
            Assert.AreEqual(expectedPCRPID, vPIDField.PCRPID);
            Assert.AreEqual(expectedVideoType, vPIDField.VideoType);
            string actual = vPIDField.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SplitVPIDFieldTest6()
        {
            VideoField vPIDField = new VideoField();
            int expectedVideoPID = 127;
            Nullable<int> expectedPCRPID = 127;
            Nullable<int> expectedVideoType = null;
            string expected = expectedVideoPID.ToString() + (expectedPCRPID.HasValue ? "+" + expectedPCRPID.Value.ToString() : string.Empty) + (expectedVideoType.HasValue ? "=" + expectedVideoType.Value.ToString() : string.Empty);
            vPIDField.SplitVideoField(expected);
            Assert.AreEqual(expectedVideoPID, vPIDField.VideoPID);
            Assert.AreEqual(expectedPCRPID, vPIDField.PCRPID);
            Assert.AreEqual(expectedVideoType, vPIDField.VideoType);
            string actual = vPIDField.ToString();
            Assert.AreEqual("127", actual);
        }

        [TestMethod()]
        public void SplitVPIDFieldTest7()
        {
            VideoField vPIDField = new VideoField();
            int expectedVideoPID = 127;
            Nullable<int> expectedPCRPID = 127;
            Nullable<int> expectedVideoType = 51;
            string expected = expectedVideoPID.ToString() + (expectedPCRPID.HasValue ? "+" + expectedPCRPID.Value.ToString() : string.Empty) + (expectedVideoType.HasValue ? "=" + expectedVideoType.Value.ToString() : string.Empty);
            vPIDField.SplitVideoField(expected);
            Assert.AreEqual(expectedVideoPID, vPIDField.VideoPID);
            Assert.AreEqual(expectedPCRPID, vPIDField.PCRPID);
            Assert.AreEqual(expectedVideoType, vPIDField.VideoType);
            string actual = vPIDField.ToString();
            Assert.AreEqual("127=51", actual);
        }

        [TestMethod()]
        public void SplitVPIDFieldTest8()
        {
            VideoField vPIDField = new VideoField();
            int expectedVideoPID = 0;
            Nullable<int> expectedPCRPID = 127;
            Nullable<int> expectedVideoType = 51;
            string expected = expectedVideoPID.ToString() + (expectedPCRPID.HasValue ? "+" + expectedPCRPID.Value.ToString() : string.Empty) + (expectedVideoType.HasValue ? "=" + expectedVideoType.Value.ToString() : string.Empty);
            vPIDField.SplitVideoField(expected);
            Assert.AreEqual(expectedVideoPID, vPIDField.VideoPID);
            Assert.AreEqual(expectedPCRPID, vPIDField.PCRPID);
            Assert.AreEqual(expectedVideoType, vPIDField.VideoType);
            string actual = vPIDField.ToString();
            Assert.AreEqual("0+127", actual);
        }

        [TestMethod()]
        public void SplitVPIDFieldTest9()
        {
            VideoField vPIDField = new VideoField();
            int expectedVideoPID = 0;
            Nullable<int> expectedPCRPID = null;
            Nullable<int> expectedVideoType = 51;
            string expected = expectedVideoPID.ToString() + (expectedPCRPID.HasValue ? "+" + expectedPCRPID.Value.ToString() : string.Empty) + (expectedVideoType.HasValue ? "=" + expectedVideoType.Value.ToString() : string.Empty);
            vPIDField.SplitVideoField(expected);
            Assert.AreEqual(expectedVideoPID, vPIDField.VideoPID);
            Assert.AreEqual(expectedPCRPID, vPIDField.PCRPID);
            Assert.AreEqual(expectedVideoType, vPIDField.VideoType);
            string actual = vPIDField.ToString();
            Assert.AreEqual("0", actual);
        }
    }
}